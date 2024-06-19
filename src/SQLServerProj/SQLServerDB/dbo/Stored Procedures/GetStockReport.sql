CREATE proc [GetStockReport]  
  
@CompanyId as varchar(50)='',     
@FinancialYear as varchar(50) =''     
  
as  
BEGIN

SELECT BranchName, Type, ISNULL(TotalWeight,0) TotalWeight, kapanid, name 'Kapan', Size, GalaNumber, NumberId, Number, ISNULL(SUM(AvailableWeight),0) AvailableWeight, SUM(Rate) Rate, SUM(Amount) Amount from 
(
	SELECT SUM(TotalWeight) TotalWeight, Name, Id from 
			(SELECT SUM(PD.Weight) 'TotalWeight', KM.Name, KM.Id from PurchaseMaster PM
			INNER JOIN PurchaseDetails PD ON PM.Id = PD.PurchaseId 
			INNER JOIN KapanMappingMaster KMM ON KMM.PurchaseMasterId = PM.Id --GROUP By Pm.SlipNO
			INNER JOIN KapanMaster KM ON KMM.KapanId = KM.Id
			GROUP By KM.Name, Km.Id

			UNION

			select TotalCts 'TotalWeight', KM.Name, KM.Id from OpeningStockMaster OSM
			INNER JOIN KapanMaster KM ON OSM.KapanId = KM.Id
			WHERE OSM.Category = 1) t
			GROUP By Name, Id
)mappingmaster

RIGHT JOIN (

		SELECT BranchName,  Type, '' KapanId, '' Kapan, SizeId, Size, GalaNumberId, GalaNumber, NumberId, Number, SUM(AvailableWeight) 'AvailableWeight', SUM(Rate) 'Rate', SUM(Amount) Amount  FROM
		(
			Select * from 
			(
				--BOIL SEND
				select 'ST' 'BranchName', 'BoilSend' Type,KapanId, Kapan, SizeId, Size, '' GalaNumberId, '' GalaNumber, '' NumberId, '' Number, AvailableWeight,0 Rate, 0 Amount from(  
				select pm.SlipNo,pm.CompanyId,pm.BranchId,ad.PurchaseDetailsId,am.KapanId,k.Name'Kapan',pd.ShapeId,s.Name'Shape',  
				pd.SizeId,sm.Name'Size',pd.PurityId,p.Name'Purity',pm.FinancialYearId,
				sum(ad.AssignWeight)'NetWeight',sum(pd.TIPWeight)'TIPWeight',sum(pd.LessWeight)'LessWeight',    
				(sum(ad.AssignWeight)+sum(pd.TIPWeight)+sum(pd.LessWeight))'Weight',sum(pd.RejectedWeight)'RejectedWeight',  
				sum(ad.AssignWeight)-isnull((select sum(b.Weight)    
				from BoilProcessMaster b  
				where       
				BoilType=0                 
				and b.SlipNo=pm.SlipNo and b.PurchaseDetailsId=ad.PurchaseDetailsId and b.KapanId=am.KapanId and b.ShapeId=pd.ShapeId and b.SizeId=pd.SizeId and b.PurityId=pd.PurityId  
				and b.FinancialYearId=pm.FinancialYearId  
				),0)'AvailableWeight',  
				convert(varchar,pm.SlipNo)+am.KapanId+pd.ShapeId+pd.SizeId+pd.PurityId+pm.FinancialYearId+ad.PurchaseDetailsId'Id'  
				from AccountToAssortMaster am  
				left join AccountToAssortDetails ad on ad.AccountToAssortMasterId=am.Id  
				left join PurchaseDetails pd on pd.Id=ad.PurchaseDetailsId  
				left join PurchaseMaster pm on pm.Id=pd.PurchaseId  
				left join KapanMaster k on k.Id=am.KapanId  
				left join ShapeMaster s on s.Id=pd.ShapeId  
				left join SizeMaster sm on sm.Id=pd.SizeId  
				left join PurityMaster p on p.Id=pd.PurityId  
				--where pm.CompanyId=@CompanyId and pm.FinancialYearId=@FinancialYear  
				group by pm.SlipNo,am.KapanId,k.Name,pd.ShapeId,s.Name,pd.SizeId,sm.Name,pd.PurityId,p.Name,pm.FinancialYearId,ad.PurchaseDetailsId, pm.CompanyId, pm.BranchId  
				)x  
				where x.AvailableWeight<>0

				UNION

				--convert(varchar,BoilNo)+KapanId+ShapeId+SizeId+PurityId'Id'
				select 'ST' 'BranchName', 'BoilReceive' Type, KapanId, Kapan, SizeId, Size, '' GalaNumberId, '' GalaNumber, '' NumberId, '' Number, AvailableWeight,0 Rate, 0 Amount
				 from(      
				select BoilNo,KapanId,Kapan,ShapeID,Shape,SizeID,Size,PurityId,Purity,sum(Weight)-x.ReceivedWeight'AvailableWeight',       
				STUFF(      
				(SELECT ',' + convert(varchar,b1.SlipNo)      
				FROM BoilProcessMaster b1      
				WHERE BoilType=0 and b1.BoilNo = x.BoilNo and b1.KapanId=x.KapanId and b1.ShapeId=x.ShapeID and b1.SizeID=x.SizeID and b1.PurityId=x.PurityId
				FOR XML PATH('')),1,1,'')'SlipNo',sum(x.Weight)'TotalWeight'      
				from         
				(select BoilNo,SlipNo,EntryDate,b.KapanId,k.Name'Kapan',b.ShapeId,s.Name'Shape',b.SizeId,sz.Name'Size',b.PurityId,p.Name'Purity',        
				Weight,isnull((select sum(Weight)+sum(LossWeight) from BoilProcessMaster b1        
				where b1.BoilType=1 and b1.BoilNo=b.BoilNo and        
				b1.KapanId=b.KapanId and b1.ShapeId=b.ShapeId and b1.SizeId=b.SizeId and b1.PurityId=b.PurityId and b1.FinancialYearId=b.FinancialYearId
				),0)'ReceivedWeight',              
				b.KapanId+b.ShapeId+b.SizeId+b.PurityId+CONVERT(nvarchar(10),b.BoilNo) as 'ID'               
				from BoilProcessMaster b              
				left join KapanMaster k on k.Id=b.KapanId
				left join ShapeMaster s on s.Id=b.ShapeId
				left join SizeMaster sz on sz.Id=b.SizeId
				left join PurityMaster p on p.Id=b.PurityId
				where BoilType=0 --Send
				--	and b.HandOverToId=@ReceivedFrom and b.CompanyId=@CompanyId and b.FinancialYearId=@FinancialYear
				)x      
				group by BoilNo,KapanId,Kapan,ShapeID,Shape,SizeID,Size,PurityId,Purity,x.ReceivedWeight        
				)y      
				where AvailableWeight <> 0 

				UNION

				-- CHARNI SEND      
				select 'ST' 'BranchName', 'CharniSend' Type, KapanId, Kapan, SizeId, Size,'' GalaNumberId, '' GalaNumber, '' NumberId, '' Number, AvailableWeight,0 Rate, 0 Amount from(      
				select SlipNo,BoilNo,KapanId,Kapan,ShapeID,Shape,SizeID,Size,PurityId,Purity,ID,SUM(Weight)'Weight',FinancialYearId,      
				SUM(Weight)-isnull((select sum(c.Weight) from CharniProcessMaster c         
				where CharniType=0  
				and c.CompanyId=x.CompanyId 
				--and c.BranchId=x.BranchId 
				and c.SlipNo=x.SlipNo and c.KapanId=x.KapanId and c.ShapeId=x.ShapeId and c.SizeId=x.SizeId
				and c.PurityId=x.PurityId and c.FinancialYearId=x.FinancialYearId and c.BoilJangadNo=x.BoilNo
				),0)
				-isnull((select sum(b1.Weight) from BoilProcessMaster b1        
				where b1.CompanyId=x.CompanyId 
				--and b1.BranchId=x.BranchId 
				and b1.KapanId=x.KapanId and b1.ShapeId=x.ShapeId 
				and b1.SizeId=x.SizeId and b1.PurityId=x.PurityId and b1.SlipNo=x.SlipNo and b1.BoilNo=x.BoilNo and b1.FinancialYearId=x.FinancialYearId
				and b1.BoilType=2),0)'AvailableWeight'
				from(          
				select b.SlipNo,b.JangadNo,b.BoilNo,b.KapanId,k.Name'Kapan',b.ShapeId,s.Name'Shape',b.SizeId,sz.Name'Size',b.PurityId,p.Name'Purity',
				b.Weight,b.FinancialYearId,b.CompanyId,b.BranchId,          
				CONVERT(nvarchar(10),b.SlipNo)+b.KapanId+b.ShapeId+b.SizeId+b.PurityId+convert(varchar,b.BoilNo) as 'ID'           
				from BoilProcessMaster b          
				left join KapanMaster k on k.Id=b.KapanId
				left join ShapeMaster s on s.Id=b.ShapeId
				left join SizeMaster sz on sz.Id=b.SizeId
				left join PurityMaster p on p.Id=b.PurityId
				where 
				--b.CompanyId=@CompanyId and b.FinancialYearId=@FinancialYear and
				b.BoilNo in (          
				select * from(          
				select max(b1.BoilNo) as id from BoilProcessMaster b1        
				where b1.CompanyId=b.CompanyId 
				and b1.KapanId=b.KapanId and b1.ShapeId=b.ShapeId 
				and b1.SizeId=b.SizeId and b1.PurityId=b.PurityId and b1.FinancialYearId=b.FinancialYearId
				group by b1.BoilNo)x)          
				and BoilType=1
				--and b.BoilNo not in (select distinct c.BoilJangadNo from CharniProcessMaster c where c.CompanyId=b.CompanyId and c.BranchId=b.BranchId 
				--and c.KapanId=b.KapanId and c.ShapeId=b.ShapeId and c.SizeId=b.SizeId and c.PurityId=b.PurityId and c.FinancialYearId=b.FinancialYearId)      
				)x      
				group by SlipNo,BoilNo,KapanId,Kapan,ShapeId,Shape,SizeID,Size,PurityId,Purity,ID,FinancialYearId,CompanyId,BranchId
				)y      
				where AvailableWeight<>0 

				UNION

				--Charni Receive
				select 'ST' 'BranchName', 'CharniReceive' Type, KapanId, Kapan, SizeId, Size, '' GalaNumberId, '' GalaNumber, '' NumberId, '' Number, AvailableWeight,0 Rate, 0 Amount from(            
				select y.SlipNo,y.CharniNo,y.EntryDate,y.BoilJangadNo,y.KapanId,y.Kapan,y.ShapeID,y.Shape,y.SizeID,y.Size,y.PurityId,y.Purity,
				y.Weight,y.ID,y.FinancialYearId,            
				y.Weight-isnull((select sum(c1.CharniWeight)+sum(c1.LossWeight)+sum(c1.RejectionWeight) from CharniProcessMaster c1               
				where c1.CharniType = 1
				and c1.CompanyId=y.CompanyId 
				--and c1.BranchId=y.BranchId 
				and c1.SlipNo=y.SlipNo and c1.KapanId=y.KapanId and c1.ShapeId=y.ShapeID            
				and c1.SizeId=y.SizeID and c1.PurityId=y.PurityId and c1.FinancialYearId=y.FinancialYearId and c1.BoilJangadNo=y.BoilJangadNo            
				and c1.CharniNo=y.CharniNo
				),0)'AvailableWeight'                   
				from(            
				select c.SlipNo,c.CharniNo,c.EntryDate,c.BoilJangadNo,c.KapanId,k.Name'Kapan',c.ShapeId,s.Name'Shape',c.SizeId,sz.Name'Size',c.PurityId,p.Name'Purity',
				sum(c.Weight)'Weight',c.FinancialYearId,c.CompanyId,c.BranchId,            
				c.SlipNo+c.KapanId+c.ShapeId+c.SizeId+c.PurityId+CONVERT(nvarchar(10),c.CharniNo) as 'ID'                   
				from CharniProcessMaster c                  
				left join KapanMaster k on k.Id=c.KapanId
				left join ShapeMaster s on s.Id=c.ShapeId
				left join SizeMaster sz on sz.Id=c.SizeId
				left join PurityMaster p on p.Id=c.PurityId
				where c.CharniType=0 
				--and c.HandOverToId=@ReceivedFrom and c.CompanyId=@CompanyId and c.FinancialYearId=@FinancialYear
				group by c.SlipNo,c.CharniNo,c.EntryDate,c.BoilJangadNo,c.KapanId,k.Name,c.ShapeId,s.Name,c.SizeId,sz.Name,c.PurityId,p.Name,c.FinancialYearId,c.CompanyId,c.BranchId            
				)y            
				)z where AvailableWeight<>0 


				UNION

				-- GALA SEND
				select 'ST' 'BranchName', 'GalaSend' Type, KapanId, Kapan, CharniSizeId 'SizeId', CharniSize 'Size', '' GalaNumberId, '' GalaNumber, '' NumberId, '' Number, AvailableWeight,0 Rate, 0 Amount
				from (          
				select   
				STUFF(        
				(SELECT ',' + convert(nvarchar(MAX),c1.SlipNo)        
				FROM CharniProcessMaster c1  
				WHERE c1.CompanyId=c.CompanyId 
				--and c1.BranchId=c.BranchId 
				and c1.FinancialYearId=c.FinancialYearId and c1.CharniType=c.CharniType 
				and c1.KapanId=c.KapanId and c1.ShapeId=c.ShapeId and c1.SizeId=c.SizeId and c1.PurityId=c.PurityId and c1.CharniSizeId=c.CharniSizeId
				order by c1.SlipNo
				for xml path(''),TYPE).value('.', 'varchar(MAX)'),1,1,'') AS SlipNo,  
				c.KapanId,k.Name'Kapan',c.ShapeId,s.Name'Shape',c.SizeId,sz.Name'Size',c.PurityId,p.Name'Purity',c.FinancialYearId,c.CharniSizeId,s1.Name'CharniSize',          
				sum(c.CharniWeight)'Weight',sum(c.CharniWeight)
				-isnull((select sum(g.Weight)         
				from GalaProcessMaster g         
				where g.CompanyId=c.CompanyId --and g.BranchId=c.BranchId 
				and g.GalaProcessType=0 and g.KapanId=c.KapanId and g.ShapeId=c.ShapeId and g.SizeId=c.SizeId and g.PurityId=c.PurityId and g.CharniSizeId=c.CharniSizeId
				and g.FinancialYearId=c.FinancialYearId),0)
				-isnull((select sum(c2.CharniWeight) FROM CharniProcessMaster c2  
				WHERE c2.CompanyId=c.CompanyId and c2.FinancialYearId=c.FinancialYearId --and c2.BranchId=c.BranchId 
				and c2.KapanId=c.KapanId and c2.ShapeId=c.ShapeId and c2.SizeId=c.SizeId and c2.PurityId=c.PurityId and c2.CharniSizeId=c.CharniSizeId 
				and c2.CharniType=2),0)'AvailableWeight',          
				c.CompanyId+c.FinancialYearId+c.KapanId+c.ShapeId+c.SizeId+c.PurityId+c.CharniSizeId as 'ID' --+c.BranchId          
				from CharniProcessMaster c          
				left join KapanMaster k on k.Id=c.KapanId
				left join ShapeMaster s on s.Id=c.ShapeId
				left join SizeMaster s1 on s1.Id=c.CharniSizeId
				left join SizeMaster sz on sz.Id=c.SizeId
				left join PurityMaster p on p.Id=c.PurityId
				where c.CharniType=1
				--and c.CompanyId=@CompanyId and c.FinancialYearId=@FinancialYear
				group by c.KapanId,k.Name,c.ShapeId,s.Name,c.SizeId,sz.Name,c.PurityId,p.Name,c.CharniType,c.CompanyId,c.FinancialYearId,c.CharniSizeId,s1.Name--,c.BranchId
				)x          
				where AvailableWeight<>0   

				UNION

				select 'ST' 'BranchName', 'GalaReceive' Type, KapanId, Kapan, CharniSizeId 'SizeId', CharniSize 'Size', '' GalaNumberId, '' GalaNumber, '' NumberId, '' Number, AvailableWeight,0 Rate, 0 Amount from(            
				select g.GalaNo,g.KapanId,k.Name'Kapan',g.ShapeId,s.Name'Shape',g.SizeId,sz.Name'Size',g.PurityId,p.Name'Purity',        
				sum(g.Weight)'Weight',g.FinancialYearId,g.CharniSizeId,sz1.Name'CharniSize',    
				sum(g.Weight)-isnull((select sum(g1.GalaWeight)+sum(g1.LossWeight)+sum(g1.RejectionWeight) from GalaProcessMaster g1                 
				where g1.GalaProcessType=1                   
				and g1.CompanyId=g.CompanyId 
				--and g1.BranchId=g.BranchId 
				and g1.KapanId=g.KapanId and g1.ShapeId=g.ShapeId  
				and g1.SizeId=g.SizeId and g1.PurityId=g.PurityId and g1.FinancialYearId=g.FinancialYearId          
				and g1.GalaNo=g.GalaNo and g1.CharniSizeId=g.CharniSizeId 
				),0)'AvailableWeight',        
				STUFF(            
				(SELECT ',' + convert(nvarchar(max),g1.SlipNo)            
				FROM GalaProcessMaster g1            
				WHERE g1.GalaProcessType=0 and g1.CompanyId=g.CompanyId 
				--and g1.BranchId=g.BranchId 
				and g1.FinancialYearId=g.FinancialYearId and  
				g1.KapanId=g.KapanId and g1.GalaNo = g.GalaNo and g1.KapanId=g.KapanId and g1.ShapeId=g.ShapeId and g1.SizeId=g.SizeId and g1.PurityId=g.PurityId and g1.CharniSizeId=g.CharniSizeId        
				FOR XML PATH('')),1,1,'') AS SlipNo,             
				g.KapanId+g.ShapeId+g.SizeId+g.PurityId+CONVERT(nvarchar(10),g.GalaNo)+g.CharniSizeId as 'ID'             
				from GalaProcessMaster g            
				left join KapanMaster k on k.Id=g.KapanId  
				left join ShapeMaster s on s.Id=g.ShapeId  
				left join SizeMaster sz on sz.Id=g.SizeId
				left join SizeMaster sz1 on sz1.Id=g.CharniSizeId
				left join PurityMaster p on p.Id=g.PurityId  
				where g.GalaProcessType=0   
				--and g.HandOverToId=@ReceivedFrom and g.CompanyId=@CompanyId and g.FinancialYearId=@FinancialYear   
				group by g.GalaNo,g.KapanId,k.Name,g.ShapeId,s.Name,g.SizeId,sz.Name,g.PurityId,p.Name,g.FinancialYearId,g.CompanyId,g.CharniSizeId,sz1.Name--,g.BranchId  
				)x          
				where AvailableWeight<>0 

				UNION

				--NUmber Send
				select 'ST' 'BranchName', 'NumberSend' Type, KapanId, Kapan, CharniSizeId 'SizeId', CharniSize 'Size', GalaNumberId, GalaNumber,'' NumberId, '' Number, AvailableWeight,0 Rate, 0 Amount from(            
				select       
				STUFF(            
				(SELECT ',' + convert(nvarchar(MAX),g1.SlipNo)            
				FROM GalaProcessMaster g1      
				WHERE g1.GalaProcessType=g.GalaProcessType and g1.CompanyId=g.CompanyId --and g1.BranchId=g.BranchId     
				and g1.FinancialYearId=g.FinancialYearId    
				and g1.KapanId=g.KapanId and g1.ShapeId=g.ShapeId and g1.SizeId=g.SizeId    
				and g1.PurityId=g.PurityId and g1.GalaNumberID=g.GalaNumberId and g1.CharniSizeId=g.CharniSizeId    
				order by g1.SlipNo      
				for xml path(''),TYPE).value('.', 'varchar(MAX)'),1,1,'') AS SlipNo,      
				g.KapanId,k.Name'Kapan',g.ShapeId,s.Name'Shape',g.SizeId,sz.Name'Size',g.PurityId,p.Name'Purity',    
				g.GalaNumberId,gm.Name'GalaNumber',g.FinancialYearId,g.CharniSizeId,sz1.Name'CharniSize',            
				sum(g.GalaWeight)'Weight',sum(g.GalaWeight)-isnull((select sum(n.Weight)           
				from NumberProcessMaster n           
				where n.NumberProcessType=0 and n.CompanyId=g.CompanyId --and n.BranchId=g.BranchId     
				and n.FinancialYearId=g.FinancialYearId    
				and n.KapanId=g.KapanId and n.ShapeId=g.ShapeId and n.SizeId=g.SizeId    
				and n.PurityId=g.PurityId and n.GalaNumberID=g.GalaNumberId
				and n.CharniSizeId=g.CharniSizeId),0)    
				-isnull((select sum(GalaWeight)    
				FROM GalaProcessMaster g2      
				WHERE g2.CompanyId=g.CompanyId --and g2.BranchId=g.BranchId     
				and g2.FinancialYearId=g.FinancialYearId    
				and g2.KapanId=g.KapanId and g2.ShapeId=g.ShapeId and g2.SizeId=g.SizeId    
				and g2.PurityId=g.PurityId and g2.GalaNumberID=g.GalaNumberId and g2.GalaProcessType=2 and g2.CharniSizeId=g.CharniSizeId),0)'AvailableWeight',            
				g.KapanId+g.ShapeId+g.SizeId+g.PurityId+g.GalaNumberId+g.CompanyId+g.FinancialYearId+g.CharniSizeId as 'ID'         --+g.BranchId    
				from GalaProcessMaster g            
				left join KapanMaster k on k.Id=g.KapanId    
				left join ShapeMaster s on s.Id=g.ShapeId    
				left join SizeMaster sz on sz.Id=g.SizeId    
				left join PurityMaster p on p.Id=g.PurityId    
				left join GalaMaster gm on gm.Id=g.GalaNumberID            
				left join SizeMaster sz1 on sz1.Id=g.CharniSizeId
				where g.GalaProcessType=1      
				--and g.CompanyId=@CompanyId and g.FinancialYearId=@FinancialYear    
				group by g.KapanId,k.Name,g.ShapeId,s.Name,g.SizeId,sz.Name,g.PurityId,p.Name,gm.Name,g.GalaProcessType,g.CompanyId,g.FinancialYearId,g.GalaNumberId,g.CharniSizeId,sz1.Name--,g.BranchId    
				)x             
			where AvailableWeight<>0) Pending

			UNION

			--Number Receive    
			select 'ST' 'BranchName', 'NumberReceive' Type, KapanId, Kapan, CharniSizeId 'SizeId', CharniSize 'Size', GalaNumberId, GalaNumber, '' NumberId, '' Number, AvailableWeight,0 Rate, 0 Amount 
			FROM(          
				select n.NumberNo,n.KapanId,k.Name'Kapan',n.ShapeId,s.Name'Shape',n.SizeId,sz.Name'Size',n.PurityId,p.Name'Purity',    
				n.GalaNumberID,gm.Name'GalaNumber',sum(n.Weight)'Weight',n.FinancialYearId,n.CharniSizeId,sz1.Name'CharniSize',            
				sum(n.Weight)-isnull(
				(select sum(n1.NumberWeight)+sum(n1.LossWeight)+sum(n1.RejectionWeight) from NumberProcessMaster n1          
					where n1.NumberProcessType =1    
					and n1.NumberNo = n.NumberNo and n1.CompanyId=n.CompanyId --and n1.BranchId=n.BranchId   
					and n1.FinancialYearId=n.FinancialYearId    
					and n1.GalaNumberId=n.GalaNumberId and n1.KapanId=n.KapanId and n1.ShapeId=n.ShapeId and n1.SizeId=n.SizeId and n1.PurityId=n.PurityId    
					and n1.CharniSizeId=n.CharniSizeId),0
				)'AvailableWeight',         
				STUFF(            
					(SELECT ',' + convert(varchar,n1.SlipNo)            
					FROM NumberProcessMaster n1            
						Where n1.NumberProcessType=0 and n1.NumberNo = n.NumberNo and n1.CompanyId=n.CompanyId --and n1.BranchId=n.BranchId   
						and n1.FinancialYearId=n.FinancialYearId    
						and n1.GalaNumberId=n.GalaNumberId and n1.KapanId=n.KapanId and n1.ShapeId=n.ShapeId and n1.SizeId=n.SizeId and n1.PurityId=n.PurityId
						and n1.CharniSizeId=n.CharniSizeId
						FOR XML PATH('')),1,1,''
					) AS SlipNo,          
					n.KapanId+n.ShapeId+n.SizeId+n.PurityId+CONVERT(nvarchar(10),n.NumberNo)+n.GalaNumberID+n.CharniSizeId as 'ID'             
					from NumberProcessMaster n            
					left join KapanMaster k on k.Id=n.KapanId    
					left join ShapeMaster s on s.Id=n.ShapeId    
					left join SizeMaster sz on sz.Id=n.SizeId    
					left join PurityMaster p on p.Id=n.PurityId    
					left join GalaMaster gm on gm.Id=n.GalaNumberID            
					left join SizeMaster sz1 on sz1.Id=n.CharniSizeId
					left join NumberMaster nm on nm.Id = n.NumberId
					where n.NumberProcessType=0  
					--and n.HandOverToId=@ReceivedFrom and n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYear    
					group by n.NumberNo,n.KapanId,k.Name,n.ShapeId,s.Name,n.SizeId,sz.Name,n.PurityId,p.Name,n.GalaNumberID,gm.Name,n.FinancialYearId,n.CompanyId,n.CharniSizeId,sz1.Name--,n.BranchId          
			)x            
			where AvailableWeight<>0 

			UNION

			-- Assort Receive 
			select 'ST' 'BranchName', 'AssortReceive' Type, KapanId, Kapan, CharniSizeId 'SizeId', CharniSize 'Size', '' GalaNumberId, '' GalaNumber, NumberId, Number, AvailableWeight,0 Rate, 0 Amount from(            
			select       
			STUFF(            
			(SELECT ',' + convert(nvarchar(MAX),n1.SlipNo)            
			FROM NumberProcessMaster n1      
			WHERE n1.NumberProcessType=n.NumberProcessType and n1.CompanyId=n.CompanyId --and n1.BranchId=n.BranchId     
			and n1.FinancialYearId=n.FinancialYearId    
			and n1.KapanId=n.KapanId and n1.ShapeId=n.ShapeId and n1.SizeId=n.SizeId    
			and n1.PurityId=n.PurityId and n1.NumberID=n.NumberID and isnull(n1.CharniSizeId,'')=isnull(n.CharniSizeId,'')   
			order by n1.SlipNo      
			for xml path(''),TYPE).value('.', 'varchar(MAX)'),1,1,'') AS SlipNo,      
			n.KapanId,k.Name'Kapan',n.ShapeId,s.Name'Shape',n.SizeId,sz.Name'Size',n.PurityId,p.Name'Purity',    
			n.NumberId,nm.Name'Number',n.FinancialYearId,n.CharniSizeId,sz1.Name'CharniSize',            
			sum(n.NumberWeight)'Weight',    
			sum(n.NumberWeight)-isnull((select sum(n2.NumberWeight)    
			FROM NumberProcessMaster n2      
			WHERE n2.CompanyId=n.CompanyId --and n2.BranchId=n.BranchId     
			and n2.FinancialYearId=n.FinancialYearId    
			and n2.KapanId=n.KapanId and n2.ShapeId=n.ShapeId and n2.SizeId=n.SizeId    
			and n2.PurityId=n.PurityId and n2.NumberId=n.NumberId   
			and n2.CharniSizeId=n.CharniSizeId and n2.NumberProcessType=2),0)'AvailableWeight',            
			n.KapanId+n.ShapeId+n.SizeId+n.PurityId+n.CompanyId+n.FinancialYearId+n.NumberId+n.CharniSizeId as 'ID'         --+n.BranchId    
			from NumberProcessMaster n     
			left join KapanMaster k on k.Id=n.KapanId    
			left join ShapeMaster s on s.Id=n.ShapeId    
			left join SizeMaster sz on sz.Id=n.SizeId    
			left join PurityMaster p on p.Id=n.PurityId            
			left join NumberMaster nm on nm.Id=n.NumberID    
			left join SizeMaster sz1 on sz1.Id=n.CharniSizeId  
			where n.NumberProcessType=1
			--and n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYear    
			group by n.KapanId,k.Name,n.ShapeId,s.Name,n.SizeId,sz.Name,n.PurityId,p.Name,n.CompanyId,n.FinancialYearId,n.NumberId,nm.Name,n.NumberProcessType,n.CharniSizeId,sz1.Name--,n.BranchId    
			)x             
			where AvailableWeight<>0 

			UNION

			-- Opening Stock 
			select 'ST' 'BranchName', 'OpeningStock' Type, KapanId, Kapan, CharniSizeId 'SizeId', CharniSize 'Size', '' GalaNumberId, '' GalaNumber, NumberId, Number, AvailableWeight,0 Rate, 0 Amount from(            
			select       
			STUFF(            
			(SELECT ',' + convert(nvarchar(MAX),n1.SlipNo)            
			FROM NumberProcessMaster n1      
			WHERE n1.NumberProcessType=n.NumberProcessType and n1.CompanyId=n.CompanyId --and n1.BranchId=n.BranchId     
			and n1.FinancialYearId=n.FinancialYearId    
			and n1.KapanId=n.KapanId and n1.ShapeId=n.ShapeId and n1.SizeId=n.SizeId    
			and n1.PurityId=n.PurityId and n1.NumberID=n.NumberID and isnull(n1.CharniSizeId,'')=isnull(n.CharniSizeId,'')   
			order by n1.SlipNo      
			for xml path(''),TYPE).value('.', 'varchar(MAX)'),1,1,'') AS SlipNo,      
			n.KapanId,k.Name'Kapan',n.ShapeId,s.Name'Shape',n.SizeId,sz.Name'Size',n.PurityId,p.Name'Purity',    
			n.NumberId,nm.Name'Number',n.FinancialYearId,n.CharniSizeId,sz1.Name'CharniSize',            
			sum(n.NumberWeight)'Weight',    
			sum(n.NumberWeight)-isnull((select sum(n2.NumberWeight)    
			FROM NumberProcessMaster n2      
			WHERE n2.CompanyId=n.CompanyId --and n2.BranchId=n.BranchId     
			and n2.FinancialYearId=n.FinancialYearId    
			and n2.KapanId=n.KapanId and n2.ShapeId=n.ShapeId and n2.SizeId=n.SizeId    
			and n2.PurityId=n.PurityId and n2.NumberId=n.NumberId   
			and n2.CharniSizeId=n.CharniSizeId and n2.NumberProcessType=2),0)'AvailableWeight',            
			n.KapanId+n.ShapeId+n.SizeId+n.PurityId+n.CompanyId+n.FinancialYearId+n.NumberId+n.CharniSizeId as 'ID'         --+n.BranchId    
			from NumberProcessMaster n     
			left join KapanMaster k on k.Id=n.KapanId    
			left join ShapeMaster s on s.Id=n.ShapeId    
			left join SizeMaster sz on sz.Id=n.SizeId    
			left join PurityMaster p on p.Id=n.PurityId            
			left join NumberMaster nm on nm.Id=n.NumberID    
			left join SizeMaster sz1 on sz1.Id=n.CharniSizeId  
			where n.NumberProcessType = 4     
			--and n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYear    
			group by n.KapanId,k.Name,n.ShapeId,s.Name,n.SizeId,sz.Name,n.PurityId,p.Name,n.CompanyId,n.FinancialYearId,n.NumberId,nm.Name,n.NumberProcessType,n.CharniSizeId,sz1.Name--,n.BranchId    
			)x             
			where AvailableWeight<>0 

			UNION

			-- Get Sales Weight
			SELECT BM.Name 'BranchName', 'OpeningStock' Type, '' KapanId, '' Kapan, CharniSizeId 'SizeId', 
			SM.Name Size, GalaSizeId 'GalaNumberId', '' GalaNumber, NumberSizeId 'NumberId', NM.Name Number, 
			(0-SUM(Weight)) 'AvailableWeight',0 Rate, 0 Amount FROM SalesDetails SD
				INNER JOIN SalesMaster SMM ON SMM.Id = SD.SalesId
				INNER JOIN BranchMaster BM ON BM.Id = SMM.BranchId
				INNER JOIN SizeMaster SM ON SM.Id = SD.CharniSizeId
				INNER JOIN NumberMaster NM on NM.Id = SD.NumberSizeId
				Group BY CharniSizeId, SM.Name, GalaSizeId, NumberSizeId, NM.Name, BM.Name

		)temp GRoUP BY Type, SizeId, Size, GalaNumberId, GalaNumber, NumberId, Number, BranchName	

		UNION		

		-- Get KAPAN CONT
		select BM.Name 'BranchName', 'KapanOpenStock' Type, KapanId, KM.name Kapan, SizeId, SM.Name Size, '' GalaNumberId, '' GalaNumber, 
		NumberId, '' Number, TotalCts 'AvailableWeight',Rate, Amount  from OpeningStockMaster OSM
		INNER JOIN BranchMaster BM ON BM.Id = OSM.BranchId
		LEFT JOIN KapanMaster KM ON OSM.KapanId = KM.Id
		LEFT JOIN SizeMaster SM ON SM.Id = OSM.SizeId
		WHERE OSM.Category = 1
) p
 
ON mappingmaster.Id = p.KapanId

GROUP by TotalWeight, name, kapanid, Kapan, Size, GalaNumber, Type, NumberId, Number, BranchName

END
CREATE proc [GetSalesItemDetails]     
                      
@ActionType as numeric,                      
@CompanyId as varchar(50),                              
@BranchId as varchar(50),                          
@FinancialYear as varchar(50)                        
                      
as                      
                      
if(@ActionType=3)      --Charni                
Begin                      
 select c.CompanyId,c.FinancialYearId,KapanId,k.Name'Kapan',ShapeId,s.Name'Shape',SizeId,sz.Name'Size',PurityId,p.Name'Purity',CharniSizeId,sz1.Name'CharniSize',''GalaNumberId,''GalaSize,''NumberSize,''NumberSizeId,                      
 sum(CharniWeight)-isnull((                      
 select sum(Weight) from SalesMaster sm                      
 left join SalesDetails s on s.SalesId=sm.Id                      
 where s.Category=3                      
 and sm.CompanyId=c.CompanyId and sm.BranchId=c.BranchId                       
 and sm.FinancialYearId=c.FinancialYearId                      
 and s.KapanId=c.KapanId and s.ShapeId=c.ShapeId and s.SizeId=c.SizeId and s.PurityId=c.PurityId                      
 and s.CharniSizeId=c.CharniSizeId),0)'Weight',                      
 KapanId+ShapeId+SizeId+CharniSizeId'Id'                      
 from CharniProcessMaster c                      
 left join KapanMaster k on k.Id=c.KapanId                      
 left join ShapeMaster s on s.Id=c.ShapeId                      
 left join SizeMaster sz on sz.Id=c.SizeId                      
 left join SizeMaster sz1 on sz1.Id=c.CharniSizeId                      
 left join PurityMaster p on p.Id=c.PurityId                      
 where CharniType=2                      
 and c.CompanyId=@CompanyId and c.BranchId=@BranchId and c.FinancialYearId=@FinancialYear                      
 group by c.CompanyId,c.FinancialYearId,KapanId,k.Name,ShapeId,s.Name,SizeId,sz.Name,PurityId,p.Name,CharniSizeId,sz1.Name,c.BranchId                      
End                      
else if(@ActionType=0)      --Number                
Begin                      
 --select n.CompanyId,n.FinancialYearId,KapanId,k.Name'Kapan',ShapeId,s.Name'Shape',SizeId,sz.Name'Size',PurityId,p.Name'Purity',''GalaNumberId,''GalaSize,nm.Name'NumberSize',n.NumberId'NumberSizeId',                    
 --n.CharniSizeId,sz1.Name'CharniSize',                    
 --sum(NumberWeight)-isnull((                      
 --select sum(Weight) from SalesMaster sm                      
 --left join SalesDetails s on s.SalesId=sm.Id                      
 --where s.Category=0                      
 --and sm.CompanyId=n.CompanyId --and sm.BranchId=n.BranchId                       
 --and sm.FinancialYearId=n.FinancialYearId                      
 --and s.KapanId=n.KapanId and s.ShapeId=n.ShapeId and s.SizeId=n.SizeId and s.PurityId=n.PurityId                      
 --and s.NumberSizeId=n.NumberId                    
 --and s.CharniSizeId=n.CharniSizeId),0)'Weight',                      
 --KapanId+ShapeId+SizeId+n.NumberId+n.CharniSizeId'Id'                      
 --from NumberProcessMaster n                      
 --left join KapanMaster k on k.Id=n.KapanId                      
 --left join ShapeMaster s on s.Id=n.ShapeId                      
 --left join SizeMaster sz on sz.Id=n.SizeId                      
 --left join NumberMaster nm on nm.Id=n.NumberId                      
 --left join PurityMaster p on p.Id=n.PurityId                      
 --left join SizeMaster sz1 on sz1.Id=n.CharniSizeId                      
 --where NumberProcessType=2                      
 ----and n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYear                      
 --group by n.CompanyId,n.FinancialYearId,KapanId,k.Name,ShapeId,s.Name,SizeId,sz.Name,PurityId,p.Name,NumberId,nm.Name,n.CharniSizeId,sz1.Name--,n.BranchId                      
 select * from(              
 select n.CompanyId,n.FinancialYearId,ShapeId,isnull(s.Name,'N/A')'Shape',                
 ''KapanId,''Kapan,''SizeId,''Size,''PurityId,''Purity,                
''GalaNumberId,''GalaSize,nm.Name'NumberSize',n.NumberId'NumberSizeId',                    
 n.CharniSizeId,sz1.Name'CharniSize',            
 sum(NumberWeight)-isnull((                      
 select sum(sd.Weight) from SalesDetailsSummary sd                                     
 where sd.Category=0              
 and sd.ShapeId=n.ShapeId            
 and sd.CompanyId=n.CompanyId and sd.BranchId=n.BranchId                       
 and sd.FinancialYearId=n.FinancialYearId                      
 and sd.NumberSizeId=n.NumberId                    
 and sd.CharniSizeId=n.CharniSizeId),0)'AvailableWeight',                      
 ShapeId+n.NumberId+n.CharniSizeId'Id'                
 from NumberProcessMaster n                      
 left join ShapeMaster s on s.Id=n.ShapeId                      
 left join NumberMaster nm on nm.Id=n.NumberId                      
 left join SizeMaster sz1 on sz1.Id=n.CharniSizeId                      
 where NumberProcessType in (2,3,4,5)            
 and n.CompanyId=@CompanyId and n.BranchId=@BranchId and n.FinancialYearId=@FinancialYear                      
 group by n.CompanyId,ShapeId,s.Name,n.FinancialYearId,NumberId,nm.Name,n.CharniSizeId,sz1.Name,n.BranchId                
 )x              
 where AvailableWeight>0              
End                      
else if(@ActionType=4)    --Gala                  
Begin                      
 select g.CompanyId,g.FinancialYearId,KapanId,k.Name'Kapan',ShapeId,s.Name'Shape',SizeId,sz.Name'Size',PurityId,p.Name'Purity',GalaNumberId,gm.Name'GalaSize',                  
 g.CharniSizeId,sz1.Name as 'CharniSize',''NumberSize,''NumberSizeId,                      
 sum(GalaWeight)-isnull((                      
 select sum(Weight) from SalesMaster sm                      
 left join SalesDetails s on s.SalesId=sm.Id                      
 where s.Category=4                      
 and sm.CompanyId=g.CompanyId and sm.BranchId=g.BranchId                       
 and sm.FinancialYearId=g.FinancialYearId                      
 and s.KapanId=g.KapanId and s.ShapeId=g.ShapeId and s.SizeId=g.SizeId and s.PurityId=g.PurityId                      
 and s.GalaSizeId=g.GalaNumberId and s.CharniSizeId=g.CharniSizeId),0)'Weight',                      
 KapanId+ShapeId+SizeId+g.GalaNumberId+g.CharniSizeId'Id'                      
 from GalaProcessMaster g                      
 left join KapanMaster k on k.Id=g.KapanId                      
 left join ShapeMaster s on s.Id=g.ShapeId                      
 left join SizeMaster sz on sz.Id=g.SizeId                      
 left join GalaMaster gm on gm.Id=g.GalaNumberId                      
 left join PurityMaster p on p.Id=g.PurityId                      
 left join SizeMaster sz1 on sz1.Id=g.CharniSizeId                    
 where GalaProcessType=2                      
 and g.CompanyId=@CompanyId and g.BranchId=@BranchId and g.FinancialYearId=@FinancialYear                      
 group by g.CompanyId,g.FinancialYearId,KapanId,k.Name,ShapeId,s.Name,SizeId,sz.Name,PurityId,p.Name,GalaNumberId,gm.Name,g.CharniSizeId,sz1.Name,g.BranchId                      
End                      
else if(@ActionType=2)      --Boil                
Begin                      
 select b.CompanyId,b.FinancialYearId,KapanId,k.Name'Kapan',ShapeId,s.Name'Shape',SizeId,sz.Name'Size',PurityId,p.Name'Purity',''GalaNumberId,''GalaSize,''CharniSizeId,''CharniSize,''NumberSize,''NumberSizeId,                      
 sum(Weight)-isnull((                      
 select sum(Weight) from SalesMaster sm                      
 left join SalesDetails s on s.SalesId=sm.Id                      
 where s.Category=2                      
 and sm.CompanyId=b.CompanyId and sm.BranchId=b.BranchId                       
 and sm.FinancialYearId=b.FinancialYearId                      
 and s.KapanId=b.KapanId and s.ShapeId=b.ShapeId and s.SizeId=b.SizeId and s.PurityId=b.PurityId),0)'Weight',                      
 KapanId+ShapeId+SizeId'Id'                      
 from BoilProcessMaster b                      
 left join KapanMaster k on k.Id=b.KapanId                      
 left join ShapeMaster s on s.Id=b.ShapeId                      
 left join SizeMaster sz on sz.Id=b.SizeId                      
 left join PurityMaster p on p.Id=b.PurityId                      
 where BoilType=2         
 and b.CompanyId=@CompanyId and b.BranchId=@BranchId and b.FinancialYearId=@FinancialYear                      
 group by b.CompanyId,b.FinancialYearId,KapanId,k.Name,ShapeId,s.Name,SizeId,sz.Name,PurityId,p.Name,b.BranchId                      
End        
else if(@ActionType=1)      --Kapan                
Begin        
 select CompanyId,FinancialYearId,KapanId,Kapan,ShapeId,Shape,SizeId,Size,PurityId,Purity,GalaNumberId,GalaSize,CharniSizeId,CharniSize,NumberSize,NumberSizeId        
 ,KapanId+ShapeId+SizeId+PurityId'Id'        
 ,(sum(NetWeight)-sum(UsedWeight))        
  -isnull((select sum(LessWeight)+sum(NetWeight)+sum(TipWeight)         
 from SalesMaster sm        
 left join SalesDetails sd on sd.SalesId=sm.Id        
where sd.Category=1        
and sm.CompanyId=y.CompanyId and sm.FinancialYearId=y.FinancialYearId and sd.KapanId=y.KapanId and sd.ShapeId=y.ShapeId        
and sd.SizeId=y.SizeId and sd.PurityId=y.PurityId),0)'Weight'            
from(                
select x.* from(                
 select pm.CompanyId,pm.FinancialYearId,km.KapanId,k.Name'Kapan',pd.ShapeId,s.Name'Shape',pd.SizeId,sm.Name'Size',pd.PurityId,p.Name'Purity',''GalaNumberId,''GalaSize,''CharniSizeId,''CharniSize,''NumberSize,''NumberSizeId,                      
 sum(km.Weight)'NetWeight',isnull((select sum(AssignWeight)                  
from AccountToAssortDetails a                
left join AccountToAssortMaster am on am.Id=a.AccountToAssortMasterId                
where                     
AccountToAssortType=0                               
and a.SlipNo=convert(varchar,pm.SlipNo) and a.PurchaseDetailsId=pd.Id and a.ShapeId=pd.ShapeId and a.SizeId=pd.SizeId and a.PurityId=pd.PurityId                
and am.FinancialYearId=pm.FinancialYearId                
),0)'UsedWeight'        
from KapanMappingMaster km                
left join PurchaseDetails pd on pd.Id=km.PurchaseDetailsId                
left join PurchaseMaster pm on pm.Id=pd.PurchaseId                
left join KapanMaster k on k.Id=km.KapanId                
left join ShapeMaster s on s.Id=pd.ShapeId                
left join SizeMaster sm on sm.Id=pd.SizeId                
left join PurityMaster p on p.Id=pd.PurityId              
where pm.CompanyId=@CompanyId and pm.FinancialYearId=@FinancialYear  --Removed the branchid condition as per riddesh              
group by pm.CompanyId,km.KapanId,pm.SlipNo,k.Name,pd.ShapeId,s.Name,pd.SizeId,sm.Name,pd.PurityId,p.Name,pm.FinancialYearId,pd.Id                
)x                
            
union            
        
 select o.CompanyId,o.FinancialYearId,o.KapanId,k.Name'Kapan',        
 ShapeId,'N/A' as 'Shape', (case when SizeId='' then '00000000-0000-0000-0000-000000000000' else SizeId end)'SizeId',isnull(s.Name,'N/A')'Size',PurityId,'N/A' as 'Purity',        
 ''GalaNumberId,''GalaSize,''CharniSizeId,''CharniSize,''NumberSize,''NumberSizeId,                      
 sum(TotalCts)'NetWeight',isnull((select sum(AssignWeight)                  
from AccountToAssortDetails a                
left join AccountToAssortMaster am on am.Id=a.AccountToAssortMasterId                
where                     
AccountToAssortType=0                               
and a.SlipNo=0 and a.ShapeId=o.ShapeId and a.SizeId=o.SizeId and a.PurityId=o.PurityId                
and am.FinancialYearId=o.FinancialYearId                
),0)'UsedWeight'        
from OpeningStockMaster o            
left join KapanMaster k on k.Id=o.KapanId            
left join SizeMaster s on s.Id=o.SizeId            
where Category=1            
and o.CompanyId=@CompanyId and FinancialYearId=@FinancialYear            
group by o.CompanyId,o.KapanId,k.Name,ShapeId,SizeId,s.Name,PurityId,FinancialYearId            
)y            
where (NetWeight-UsedWeight)<>0        
group by CompanyId,FinancialYearId,KapanId,Kapan,ShapeId,Shape,SizeId,Size,PurityId,Purity,GalaNumberId,GalaSize,CharniSizeId,CharniSize,NumberSize,NumberSizeId        
      
union      
select x.CompanyId,FinancialYearId,KapanId,k.Name'Kapan',ShapeId,s.Name as 'Shape',      
SizeId,sz.Name as 'Size',PurityId,p.Name as 'Purity',      
''GalaNumberId,''GalaSize,''CharniSizeId,''CharniSize,''NumberSize,''NumberSizeId,      
x.CompanyId+KapanId+ShapeId+SizeId+PurityId+FinancialYearId'Id',      
sum(NetWeight)'Weight'      
from(        
--Boil        
select b.CompanyId,KapanId,SlipNo,ShapeId,        
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,            
FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',            
sum(Weight) as 'Weight',0 as 'RejectedWeight',            
0 as 'UsedWeight',            
KapanId+ShapeId+SizeId+PurityId+FinancialYearId'Id'            
from BoilProcessMaster b            
where BoilType=2            
and b.CompanyId=@CompanyId and FinancialYearId=@FinancialYear            
group by b.CompanyId,KapanId,SlipNo,ShapeId,SizeId,PurityId,FinancialYearId        
        
union         
--Charni        
select c.CompanyId,KapanId,SlipNo,ShapeId,        
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,            
FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',            
sum(Weight) as 'Weight',0 as 'RejectedWeight',            
0 as 'UsedWeight',            
KapanId+ShapeId+SizeId+PurityId+FinancialYearId'Id'            
from CharniProcessMaster c            
where CharniType=2            
and c.CompanyId=@CompanyId and FinancialYearId=@FinancialYear            
group by c.CompanyId,KapanId,SlipNo,ShapeId,SizeId,PurityId,FinancialYearId        
        
union        
--Gala        
select g.CompanyId,KapanId,SlipNo,ShapeId,        
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,            
FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',            
sum(Weight) as 'Weight',0 as 'RejectedWeight',            
0 as 'UsedWeight',            
KapanId+ShapeId+SizeId+PurityId+FinancialYearId'Id'            
from GalaProcessMaster g        
where GalaProcessType=2            
and g.CompanyId=@CompanyId and FinancialYearId=@FinancialYear            
group by g.CompanyId,KapanId,SlipNo,ShapeId,SizeId,PurityId,FinancialYearId,Id        
        
)x        
left join KapanMaster k on k.Id=x.KapanId            
left join ShapeMaster s on s.Id=x.ShapeId        
left join SizeMaster sz on sz.Id=x.SizeId            
left join PurityMaster p on p.Id=x.PurityId        
group by x.CompanyId,KapanId,k.Name,ShapeId,s.Name,SizeId,sz.Name,PurityId,p.Name,FinancialYearId        
      
End
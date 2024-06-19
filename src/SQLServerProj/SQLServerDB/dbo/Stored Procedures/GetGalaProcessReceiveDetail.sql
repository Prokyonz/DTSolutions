CREATE proc [GetGalaProcessReceiveDetail]  
    
@ReceivedFrom as varchar(50),  
@CompanyId as varchar(50),          
@BranchId as varchar(50),      
@FinancialYear as varchar(50)     
                    
as  
  
select * from(            
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
and g.HandOverToId=@ReceivedFrom and g.CompanyId=@CompanyId and g.FinancialYearId=@FinancialYear   
group by g.GalaNo,g.KapanId,k.Name,g.ShapeId,s.Name,g.SizeId,sz.Name,g.PurityId,p.Name,g.FinancialYearId,g.CompanyId,g.CharniSizeId,sz1.Name--,g.BranchId  
)x          
where AvailableWeight<>0
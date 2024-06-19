CREATE proc [GetNumberProcessSendToDetail_bk_20220308]  
  
@CompanyId as varchar(50),          
@BranchId as varchar(50),      
@FinancialYear as varchar(50)   
  
as           
    
select * from(          
select     
STUFF(          
(SELECT ',' + convert(nvarchar(MAX),g1.SlipNo)          
FROM GalaProcessMaster g1    
WHERE g1.GalaProcessType=g.GalaProcessType and g1.CompanyId=g.CompanyId --and g1.BranchId=g.BranchId   
and g1.FinancialYearId=g.FinancialYearId  
and g1.KapanId=g.KapanId and g1.ShapeId=g.ShapeId and g1.SizeId=g.SizeId  
and g1.PurityId=g.PurityId and g1.GalaNumberID=g.GalaNumberId  
order by g1.SlipNo    
for xml path(''),TYPE).value('.', 'varchar(MAX)'),1,1,'') AS SlipNo,    
g.KapanId,k.Name'Kapan',g.ShapeId,s.Name'Shape',g.SizeId,sz.Name'Size',g.PurityId,p.Name'Purity',  
g.GalaNumberId,gm.Name'GalaNumber',g.FinancialYearId,          
sum(g.GalaWeight)'Weight',sum(g.GalaWeight)-isnull((select sum(n.Weight)         
from NumberProcessMaster n         
where n.NumberProcessType=0 and n.CompanyId=g.CompanyId --and n.BranchId=g.BranchId   
and n.FinancialYearId=g.FinancialYearId  
and n.KapanId=g.KapanId and n.ShapeId=g.ShapeId and n.SizeId=g.SizeId  
and n.PurityId=g.PurityId and n.GalaNumberID=g.GalaNumberId),0)  
-isnull((select sum(GalaWeight)  
FROM GalaProcessMaster g2    
WHERE g2.CompanyId=g.CompanyId --and g2.BranchId=g.BranchId   
and g2.FinancialYearId=g.FinancialYearId  
and g2.KapanId=g.KapanId and g2.ShapeId=g.ShapeId and g2.SizeId=g.SizeId  
and g2.PurityId=g.PurityId and g2.GalaNumberID=g.GalaNumberId and g2.GalaProcessType=2),0)'AvailableWeight',          
g.KapanId+g.ShapeId+g.SizeId+g.PurityId+g.GalaNumberId+g.CompanyId+g.FinancialYearId as 'ID'         --+g.BranchId  
from GalaProcessMaster g          
left join KapanMaster k on k.Id=g.KapanId  
left join ShapeMaster s on s.Id=g.ShapeId  
left join SizeMaster sz on sz.Id=g.SizeId  
left join PurityMaster p on p.Id=g.PurityId  
left join GalaMaster gm on gm.Id=g.GalaNumberID          
where g.GalaProcessType=1    
and g.CompanyId=@CompanyId and g.FinancialYearId=@FinancialYear  
group by g.KapanId,k.Name,g.ShapeId,s.Name,g.SizeId,sz.Name,g.PurityId,p.Name,gm.Name,g.GalaProcessType,g.CompanyId,g.FinancialYearId,g.GalaNumberId--,g.BranchId  
)x           
where AvailableWeight<>0
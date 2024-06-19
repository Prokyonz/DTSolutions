CREATE proc [GetGalaProcessSendToDetail]

@CompanyId as varchar(50),        
@BranchId as varchar(50),    
@FinancialYear as varchar(50)    

as

select *  
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
and c.CompanyId=@CompanyId and c.FinancialYearId=@FinancialYear
group by c.KapanId,k.Name,c.ShapeId,s.Name,c.SizeId,sz.Name,c.PurityId,p.Name,c.CharniType,c.CompanyId,c.FinancialYearId,c.CharniSizeId,s1.Name--,c.BranchId
)x          
where AvailableWeight<>0
CREATE proc [GetCharniDetailsForSales]

@CompanyId as varchar(50),        
@BranchId as varchar(50),    
@FinancialYear as varchar(50)  

as

select c.CompanyId,c.FinancialYearId,KapanId,k.Name'Kapan',ShapeId,s.Name'Shape',SizeId,sz.Name'Size',PurityId,p.Name'Purity',CharniSizeId,sz1.Name'CharniSize',''NumberSize,''NumberSizeId,
sum(CharniWeight)'Weight',
KapanId+ShapeId+SizeId+CharniSizeId'Id'
from CharniProcessMaster c
left join KapanMaster k on k.Id=c.KapanId
left join ShapeMaster s on s.Id=c.ShapeId
left join SizeMaster sz on sz.Id=c.SizeId
left join SizeMaster sz1 on sz1.Id=c.CharniSizeId
left join PurityMaster p on p.Id=c.PurityId
where CharniType=2
and c.CompanyId=@CompanyId and c.FinancialYearId=@FinancialYear
group by c.CompanyId,c.FinancialYearId,KapanId,k.Name,ShapeId,s.Name,SizeId,sz.Name,PurityId,p.Name,CharniSizeId,sz1.Name--,c.BranchId
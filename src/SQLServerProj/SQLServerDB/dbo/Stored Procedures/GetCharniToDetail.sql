CREATE proc [GetCharniToDetail]

@CompanyId as varchar(50),        
@BranchId as varchar(50),    
@FinancialYear as varchar(50)  

as          
      
select * from(      
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
b.CompanyId=@CompanyId and b.FinancialYearId=@FinancialYear and
b.BoilNo in (          
select * from(          
select max(b1.BoilNo) as id from BoilProcessMaster b1        
where b1.CompanyId=b.CompanyId 
--and b1.BranchId=b.BranchId 
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
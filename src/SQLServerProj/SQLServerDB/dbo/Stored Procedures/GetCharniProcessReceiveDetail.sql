CREATE proc [GetCharniProcessReceiveDetail]
  
@ReceivedFrom as varchar(50),
@CompanyId as varchar(50),        
@BranchId as varchar(50),    
@FinancialYear as varchar(50)   
                  
as

select * from(            
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
and c.HandOverToId=@ReceivedFrom and c.CompanyId=@CompanyId and c.FinancialYearId=@FinancialYear
group by c.SlipNo,c.CharniNo,c.EntryDate,c.BoilJangadNo,c.KapanId,k.Name,c.ShapeId,s.Name,c.SizeId,sz.Name,c.PurityId,p.Name,c.FinancialYearId,c.CompanyId,c.BranchId            
)y            
)z where AvailableWeight<>0
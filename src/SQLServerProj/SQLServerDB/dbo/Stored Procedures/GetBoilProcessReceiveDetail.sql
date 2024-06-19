CREATE proc GetBoilProcessReceiveDetail  
  
@ReceivedFrom as varchar(50),  
@CompanyId as varchar(50),          
@BranchId as varchar(50),      
@FinancialYear as varchar(50)    
  
as  
  
select *,  
convert(varchar,BoilNo)+KapanId+ShapeId+SizeId+PurityId'Id' from(        
select BoilNo,KapanId,Kapan,ShapeID,isnull(Shape,'N/A')'Shape',SizeID,Size,PurityId,isnull(Purity,'N/A')'Purity',sum(Weight)-x.ReceivedWeight'AvailableWeight',         
STUFF(        
(SELECT ',' + convert(varchar,b1.SlipNo)        
FROM BoilProcessMaster b1        
WHERE BoilType=0 and b1.BoilNo = x.BoilNo and b1.KapanId=x.KapanId and b1.ShapeId=x.ShapeID and b1.SizeID=x.SizeID and b1.PurityId=x.PurityId  
FOR XML PATH('')),1,1,'')'SlipNo',sum(x.Weight)'TotalWeight'        
from           
(select BoilNo,SlipNo,EntryDate,b.KapanId,k.Name'Kapan',b.ShapeId,s.Name'Shape',b.SizeId,sz.Name'Size',b.PurityId,p.Name'Purity',          
Weight,isnull((select sum(Weight)+sum(LossWeight)+sum(RejectionWeight) from BoilProcessMaster b1          
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
and b.HandOverToId=@ReceivedFrom and b.CompanyId=@CompanyId and b.FinancialYearId=@FinancialYear  
)x        
  
  
group by BoilNo,KapanId,Kapan,ShapeID,Shape,SizeID,Size,PurityId,Purity,x.ReceivedWeight          
)y        
where AvailableWeight <> 0
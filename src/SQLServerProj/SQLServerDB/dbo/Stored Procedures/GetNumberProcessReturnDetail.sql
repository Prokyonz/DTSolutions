CREATE proc [GetNumberProcessReturnDetail]    
    
@CompanyId as varchar(50),            
@BranchId as varchar(50),        
@FinancialYear as varchar(50)     
    
as             
      
select x.* from(            
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
and n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYear    
group by n.KapanId,k.Name,n.ShapeId,s.Name,n.SizeId,sz.Name,n.PurityId,p.Name,n.CompanyId,n.FinancialYearId,n.NumberId,nm.Name,n.NumberProcessType,n.CharniSizeId,sz1.Name--,n.BranchId    
)x             
where AvailableWeight<>0
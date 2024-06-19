CREATE proc [GetNumberProcessReceiveDetail]    
        
@ReceivedFrom as varchar(50),    
@CompanyId as varchar(50),            
@BranchId as varchar(50),        
@FinancialYear as varchar(50)     
          
as            
            
select * from(          
select n.NumberNo,n.KapanId,k.Name'Kapan',n.ShapeId,s.Name'Shape',n.SizeId,sz.Name'Size',n.PurityId,p.Name'Purity',    
n.GalaNumberID,gm.Name'GalaNumber',sum(n.Weight)'Weight',n.FinancialYearId,n.CharniSizeId,sz1.Name'CharniSize',            
sum(n.Weight)-isnull((select sum(n1.NumberWeight)+sum(n1.LossWeight)+sum(n1.RejectionWeight) from NumberProcessMaster n1          
where n1.NumberProcessType =1    
and n1.NumberNo = n.NumberNo and n1.CompanyId=n.CompanyId --and n1.BranchId=n.BranchId   
and n1.FinancialYearId=n.FinancialYearId    
and n1.GalaNumberId=n.GalaNumberId and n1.KapanId=n.KapanId and n1.ShapeId=n.ShapeId and n1.SizeId=n.SizeId and n1.PurityId=n.PurityId    
and n1.CharniSizeId=n.CharniSizeId),0)'AvailableWeight',         
STUFF(            
(SELECT ',' + convert(varchar,n1.SlipNo)            
FROM NumberProcessMaster n1            
Where n1.NumberProcessType=0 and n1.NumberNo = n.NumberNo and n1.CompanyId=n.CompanyId --and n1.BranchId=n.BranchId   
and n1.FinancialYearId=n.FinancialYearId    
and n1.GalaNumberId=n.GalaNumberId and n1.KapanId=n.KapanId and n1.ShapeId=n.ShapeId and n1.SizeId=n.SizeId and n1.PurityId=n.PurityId
and n1.CharniSizeId=n.CharniSizeId
FOR XML PATH('')),1,1,'') AS SlipNo,          
n.KapanId+n.ShapeId+n.SizeId+n.PurityId+CONVERT(nvarchar(10),n.NumberNo)+n.GalaNumberID+n.CharniSizeId as 'ID'             
from NumberProcessMaster n            
left join KapanMaster k on k.Id=n.KapanId    
left join ShapeMaster s on s.Id=n.ShapeId    
left join SizeMaster sz on sz.Id=n.SizeId    
left join PurityMaster p on p.Id=n.PurityId    
left join GalaMaster gm on gm.Id=n.GalaNumberID            
left join SizeMaster sz1 on sz1.Id=n.CharniSizeId
where n.NumberProcessType=0    
and n.HandOverToId=@ReceivedFrom and n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYear    
group by n.NumberNo,n.KapanId,k.Name,n.ShapeId,s.Name,n.SizeId,sz.Name,n.PurityId,p.Name,n.GalaNumberID,gm.Name,n.FinancialYearId,n.CompanyId,n.CharniSizeId,sz1.Name--,n.BranchId          
)x            
where AvailableWeight<>0
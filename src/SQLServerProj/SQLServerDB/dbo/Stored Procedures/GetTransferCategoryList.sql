--Exec GetTransferCategoryList 'c444ca9f-03ec-493f-9447-4e1bf15eefbf','8e34d261-0a6b-44ac-9f86-89d5fdd5ef56'
CREATE proc [GetTransferCategoryList]  
  
@CompanyId as varchar(50),                  
@FinancialYear as varchar(50)              
          
as    
  
select * from(  
select distinct KapanId'ID',Kapan'Name',1 as CategoryID,'Kapan' as Category  
from(          
select * from(          
select km.KapanId,k.Name'Kapan',  
(sum(km.Weight)+sum(pd.TIPWeight)+sum(pd.LessWeight))'Weight',sum(pd.RejectedWeight)'RejectedWeight',          
isnull((select sum(AssignWeight)            
from AccountToAssortDetails a          
left join AccountToAssortMaster am on am.Id=a.AccountToAssortMasterId          
where               
AccountToAssortType=0                         
and a.SlipNo=convert(varchar,pm.SlipNo) and a.PurchaseDetailsId=pd.Id and a.ShapeId=pd.ShapeId and a.SizeId=pd.SizeId and a.PurityId=pd.PurityId          
and am.FinancialYearId=pm.FinancialYearId          
),0)'UsedWeight',      
convert(varchar,pm.SlipNo)+km.KapanId+pd.ID+pd.ShapeId+pd.SizeId+pd.PurityId+pm.FinancialYearId'Id'          
from KapanMappingMaster km          
left join PurchaseDetails pd on pd.Id=km.PurchaseDetailsId          
left join PurchaseMaster pm on pm.Id=pd.PurchaseId          
left join KapanMaster k on k.Id=km.KapanId          
where pm.CompanyId=@CompanyId and pm.FinancialYearId=@FinancialYear  --Removed the branchid condition as per riddesh        
group by km.KapanId,pm.SlipNo,k.Name,pd.ShapeId,pd.SizeId,pd.PurityId,pm.FinancialYearId,pd.Id,pd.PurchaseId          
)x          
      
union      
      
select KapanId,k.Name'Kapan',    
sum(TotalCts) as 'Weight','0' as 'RejectedWeight',      
isnull((select sum(AssignWeight)            
from AccountToAssortDetails a          
left join AccountToAssortMaster am on am.Id=a.AccountToAssortMasterId          
where               
AccountToAssortType=0                         
and a.SlipNo=0 and a.ShapeId=o.ShapeId and a.SizeId=o.SizeId and a.PurityId=o.PurityId          
and am.FinancialYearId=o.FinancialYearId          
),0)'UsedWeight',      
KapanId+ShapeId+SizeId+PurityId+o.FinancialYearId'Id'      
from OpeningStockMaster o      
left join KapanMaster k on k.Id=o.KapanId      
where Category=1      
and o.CompanyId=@CompanyId and o.FinancialYearId=@FinancialYear      
group by KapanId,k.Name,ShapeId,SizeId,PurityId,o.FinancialYearId     


union
select KapanId,k.Name'Kapan',
sum(NetWeight)'Weight','0' as 'RejectedWeight',0 as 'UsedWeight',KapanId as 'Id'
from(  
--Boil  
select b.CompanyId,KapanId,SlipNo,ShapeId,  
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,      
b.FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',      
sum(Weight) as 'Weight',0 as 'RejectedWeight',      
0 as 'UsedWeight',      
KapanId+ShapeId+SizeId+PurityId+b.FinancialYearId'Id'      
from BoilProcessMaster b      
where BoilType=2      
and b.CompanyId=@CompanyId and b.FinancialYearId=@FinancialYear      
group by b.CompanyId,KapanId,SlipNo,ShapeId,SizeId,PurityId,b.FinancialYearId  
  
union   
--Charni  
select c.CompanyId,KapanId,SlipNo,ShapeId,  
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,      
c.FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',      
sum(Weight) as 'Weight',0 as 'RejectedWeight',      
0 as 'UsedWeight',      
KapanId+ShapeId+SizeId+PurityId+c.FinancialYearId'Id'      
from CharniProcessMaster c      
where CharniType=2      
and c.CompanyId=@CompanyId and c.FinancialYearId=@FinancialYear      
group by c.CompanyId,KapanId,SlipNo,ShapeId,SizeId,PurityId,c.FinancialYearId  
  
union  
--Gala  
select g.CompanyId,KapanId,SlipNo,ShapeId,  
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,      
g.FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',      
sum(Weight) as 'Weight',0 as 'RejectedWeight',      
0 as 'UsedWeight',      
KapanId+ShapeId+SizeId+PurityId+g.FinancialYearId'Id'      
from GalaProcessMaster g  
where GalaProcessType=2      
and g.CompanyId=@CompanyId and g.FinancialYearId=@FinancialYear      
group by g.CompanyId,KapanId,SlipNo,ShapeId,SizeId,PurityId,g.FinancialYearId,Id  
  
)x  
left join KapanMaster k on k.Id=x.KapanId      
group by KapanId,k.Name
)y      
where ((Weight+RejectedWeight)-UsedWeight)<>0  
  
union  
  
select distinct CharniSizeId'ID',CharniSize'Name',0 as CategoryID, 'Number' as Category from(      
 select          
 n.CharniSizeId,sz1.Name'CharniSize',            
 sum(NumberWeight)-isnull((              
 select sum(Weight) from SalesMaster sm              
 left join SalesDetails s on s.SalesId=sm.Id              
 where s.Category=0              
 and sm.CompanyId=n.CompanyId --and sm.BranchId=n.BranchId               
 and sm.FinancialYearId=n.FinancialYearId              
 and s.NumberSizeId=n.NumberId            
 and s.CharniSizeId=n.CharniSizeId),0)'Weight',              
 ShapeId+n.NumberId+n.CharniSizeId'Id'        
 from NumberProcessMaster n              
 left join ShapeMaster s on s.Id=n.ShapeId              
 left join NumberMaster nm on nm.Id=n.NumberId              
 left join SizeMaster sz1 on sz1.Id=n.CharniSizeId              
 where NumberProcessType in (2,3,4,5)    
 and n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYear              
 group by n.CompanyId,ShapeId,s.Name,n.FinancialYearId,NumberId,nm.Name,n.CharniSizeId,sz1.Name        
 )x      
 where Weight>0    
 )z  
order by Category
CREATE proc [GetBoilProcessSendToDetail]        
        
@CompanyId as varchar(50),                
@BranchId as varchar(50),            
@FinancialYear as varchar(50)            
        
as        
        
select * from(        
select ad.Id as AccountToAssortDetailsId,'0' as StockId,pm.SlipNo,ad.PurchaseDetailsId,am.KapanId,k.Name'Kapan',pd.ShapeId,s.Name'Shape',        
pd.SizeId,sm.Name'Size',pd.PurityId,p.Name'Purity',pm.FinancialYearId,        
sum(ad.AssignWeight)'NetWeight',sum(pd.TIPWeight)'TIPWeight',sum(pd.LessWeight)'LessWeight',          
(sum(ad.AssignWeight)+sum(pd.TIPWeight)+sum(pd.LessWeight))'Weight',sum(pd.RejectedWeight)'RejectedWeight',        
sum(ad.AssignWeight)-isnull((select sum(b.Weight)          
from BoilProcessMaster b        
where             
BoilType=0                       
and b.SlipNo=pm.SlipNo and b.PurchaseDetailsId=ad.PurchaseDetailsId and b.KapanId=am.KapanId and b.ShapeId=pd.ShapeId and b.SizeId=pd.SizeId and b.PurityId=pd.PurityId        
and b.FinancialYearId=pm.FinancialYearId and b.AccountToAssortDetailsId=ad.Id        
),0)'AvailableWeight',        
convert(varchar,pm.SlipNo)+am.KapanId+pd.ShapeId+pd.SizeId+pd.PurityId+pm.FinancialYearId+ad.PurchaseDetailsId'Id'        
from AccountToAssortMaster am        
left join AccountToAssortDetails ad on ad.AccountToAssortMasterId=am.Id        
left join PurchaseDetails pd on pd.Id=ad.PurchaseDetailsId        
left join PurchaseMaster pm on pm.Id=pd.PurchaseId        
left join KapanMaster k on k.Id=am.KapanId        
left join ShapeMaster s on s.Id=pd.ShapeId        
left join SizeMaster sm on sm.Id=pd.SizeId        
left join PurityMaster p on p.Id=pd.PurityId        
where pm.SlipNo<>0    
and pm.CompanyId=@CompanyId and pm.FinancialYearId=@FinancialYear        
group by ad.Id,pm.SlipNo,am.KapanId,k.Name,pd.ShapeId,s.Name,pd.SizeId,sm.Name,pd.PurityId,p.Name,pm.FinancialYearId,ad.PurchaseDetailsId        
    
union    
select ad.Id as AccountToAssortDetailsId,o.Id as StockId,0 as SlipNo,'0' as PurchaseDetailsId,am.KapanId,k.Name'Kapan',o.ShapeId,'N/A' as Shape,        
o.SizeId,sm.Name'Size',o.PurityId,'N/A' as Purity,o.FinancialYearId,        
sum(ad.AssignWeight)'NetWeight',0 as TIPWeight,0 as LessWeight,          
sum(ad.AssignWeight)'Weight',0 as RejectedWeight,        
sum(ad.AssignWeight)-isnull((select sum(b.Weight)          
from BoilProcessMaster b        
where             
BoilType=0                       
and b.StockId=o.Id and b.KapanId=am.KapanId and b.ShapeId=o.ShapeId and b.SizeId=o.SizeId and b.PurityId=o.PurityId        
and b.FinancialYearId=o.FinancialYearId and b.AccountToAssortDetailsId=ad.Id        
),0)'AvailableWeight',        
o.Id+am.KapanId+o.ShapeId+o.SizeId+o.PurityId+o.FinancialYearId'Id'        
from AccountToAssortMaster am    
left join AccountToAssortDetails ad on ad.AccountToAssortMasterId=am.Id        
inner join OpeningStockMaster o on o.Id=ad.StockId       
left join KapanMaster k on k.Id=am.KapanId        
left join SizeMaster sm on sm.Id=o.SizeId        
where ad.SlipNo=0    
and am.CompanyId=@CompanyId and am.FinancialYearId=@FinancialYear        
group by ad.Id,o.Id,am.KapanId,k.Name,o.ShapeId,o.SizeId,sm.Name,o.PurityId,o.FinancialYearId    
    
    
)x        
where x.AvailableWeight<>0
--exec GetAssortProcessSendToDetail 'ff8d3c9b-957b-46d1-b661-560ae4a2433e','','146c24c5-6663-4f3d-bdfd-80469275c898'    
--exec GetAssortProcessSendToDetail_bk '00000000-0000-0000-0000-000000000000','','2ac16086-fb8c-4e2c-803b-1748dbe4fd30'        
CREATE proc [dbo].[GetAssortProcessSendToDetail_bk] --'a6bfccfa-3d53-4452-96d3-f9cf31248da8','','b4835b22-940e-48c0-b851-5d836f274b42'                       
                        
@CompanyId as varchar(50),                                
@BranchId as varchar(50),                            
@FinancialYear as varchar(50)                            
                        
as                        
select *,(Weight-(case when UsedWeight<0 then UsedWeight*-1 else UsedWeight end))'AvailableWeight' --(Weight+RejectedWeight)-UsedWeight'AvailableWeight'
from(                        
select * from(                        
select '0' as StockId,km.KapanId,k.Name'Kapan',convert(varchar,pm.SlipNo)'SlipNo',pd.ShapeId,s.Name'Shape',pd.Id'PurchaseDetailsId',pd.PurchaseId'PurchaseMasterId',                        
pd.SizeId,sm.Name'Size',pd.PurityId,p.Name'Purity',pm.FinancialYearId,                        
sum(km.Weight)'NetWeight',sum(pd.TIPWeight)'TIPWeight',sum(pd.LessWeight)'LessWeight',                          
(sum(km.Weight)+sum(pd.TIPWeight)+sum(pd.LessWeight))'Weight',sum(pd.RejectedWeight)'RejectedWeight',                        
isnull((select sum(y.Weight) from(          
select sum(Weight)'Weight'                          
from salesdetailssummary sds                        
where sds.Category=1                        
and sds.PurchaseDetailsId=pd.Id          
and sds.SlipNo=convert(varchar,pm.SlipNo) and sds.ShapeId=pd.ShapeId and sds.SizeId=pd.SizeId and sds.PurityId=pd.PurityId                        
and sds.FinancialYearId=pm.FinancialYearId                        
union all          
select sum(AssignWeight)'Weight'        
from AccountToAssortDetails a                        
left join AccountToAssortMaster am on am.Id=a.AccountToAssortMasterId                        
where                             
AccountToAssortType=0                                       
and a.SlipNo=convert(varchar,pm.SlipNo) and a.PurchaseDetailsId=pd.Id and a.ShapeId=pd.ShapeId and a.SizeId=pd.SizeId and a.PurityId=pd.PurityId                        
and am.FinancialYearId=pm.FinancialYearId                        
)y          
),0)'UsedWeight',                    
convert(varchar,pm.SlipNo)+km.KapanId+pd.ID+pd.ShapeId+pd.SizeId+pd.PurityId+pm.FinancialYearId'Id',        
'KapanMapped' as 'KapanType'                        
from KapanMappingMaster km                        
left join PurchaseDetails pd on pd.Id=km.PurchaseDetailsId                        
left join PurchaseMaster pm on pm.Id=pd.PurchaseId                        
left join KapanMaster k on k.Id=km.KapanId                        
left join ShapeMaster s on s.Id=pd.ShapeId                        
left join SizeMaster sm on sm.Id=pd.SizeId                        
left join PurityMaster p on p.Id=pd.PurityId                      
where pm.CompanyId=@CompanyId and pm.FinancialYearId=@FinancialYear  --Removed the branchid condition as per riddesh                      
group by km.KapanId,pm.SlipNo,k.Name,pd.ShapeId,s.Name,pd.SizeId,sm.Name,pd.PurityId,p.Name,pm.FinancialYearId,pd.Id,pd.PurchaseId                        
)x                        
                    
union                    
                    
select o.Id as StockId,KapanId,k.Name'Kapan','0' as 'SlipNo', ShapeId,sh.Name as 'Shape',                    
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,s.Name'Size',PurityId,p.Name as 'Purity',                    
FinancialYearId,sum(TotalCts) as 'NetWeight','0' as 'TipWeight','0' as 'LessWeight',                    
sum(TotalCts) as 'Weight','0' as 'RejectedWeight',                    
--'0' as 'AvailableWeight',                    
isnull ((select sum(y.Weight) from(          
--Sales Details
select sum(Weight)'Weight'                          
from salesdetailssummary sds                        
where sds.Category=1                        
and sds.StockId=o.Id
and sds.SlipNo='0' and sds.ShapeId=o.ShapeId and sds.SizeId=o.SizeId and sds.PurityId=o.PurityId                        
and sds.FinancialYearId=o.FinancialYearId                        
union all     
--Assort Send Details
select sum(AssignWeight)'Weight'                          
from AccountToAssortDetails a                        
left join AccountToAssortMaster am on am.Id=a.AccountToAssortMasterId                        
where AccountToAssortType=0                                       
and a.StockId=o.Id and a.SlipNo='0' and a.ShapeId=o.ShapeId and a.SizeId=o.SizeId and a.PurityId=o.PurityId                        
and am.FinancialYearId=o.FinancialYearId     
union all
--Transfered Stock
select sum(o1.TotalCts) 
from OpeningStockMaster o1
where o1.StockId=o.Id
--and o1.CompanyId=o.CompanyId
and  isnull(TransferType,'')<>'' 
)y)          
,0)'UsedWeight',                    
o.Id+KapanId+ShapeId+SizeId+PurityId+FinancialYearId'Id',        
'OpeningStock' as 'KapanType'                                    
from OpeningStockMaster o                    
left join KapanMaster k on k.Id=o.KapanId                    
left join SizeMaster s on s.Id=o.SizeId            
left join ShapeMaster sh on sh.Id=o.ShapeId                        
left join PurityMaster p on p.Id=o.PurityId                   
where Category=1                    
and o.CompanyId=@CompanyId and FinancialYearId=@FinancialYear   
and isnull(TransferType,'')='' 
group by o.Id,KapanId,k.Name,ShapeId,sh.Name, p.Name, SizeId,s.Name,PurityId,FinancialYearId            
                
union                
select '0' as StockId,KapanId,k.Name'Kapan',convert(varchar,SlipNo)'SlipNo',ShapeId,s.Name as 'Shape',PurchsaeDetailId,PurchaseMasterId,                
SizeId,sz.Name as 'Size',PurityId,p.Name as 'Purity',FinancialYearId,sum(NetWeight)'NetWeight',sum(TipWeight)'TipWeight',sum(LessWeight)'LessWeight',                
sum(Weight)'Weight',sum(RejectedWeight)'RejectedWeight',sum(UsedWeight)'UsedWeight',                
KapanId+ShapeId+SizeId+PurityId+FinancialYearId'Id',KapanType                    
from(                
--Boil                
select KapanId,convert(varchar,SlipNo)'SlipNo',ShapeId,                
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,                    
FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',                    
sum(Weight) as 'Weight',0 as 'RejectedWeight',                    
isnull((select sum(Weight)'Weight'                          
from salesdetailssummary sds                        
where sds.Category=1 and sds.KapanType='Boil'                        
and sds.SlipNo=convert(varchar,b.SlipNo) and sds.ShapeId=b.ShapeId and sds.SizeId=b.SizeId and sds.PurityId=b.PurityId                        
and sds.FinancialYearId=b.FinancialYearId),0) as 'UsedWeight',                    
KapanId+ShapeId+SizeId+PurityId+FinancialYearId'Id',        
'Boil' as 'KapanType'                                    
from BoilProcessMaster b                    
where BoilType in (2,3,4)    
and b.CompanyId=@CompanyId and FinancialYearId=@FinancialYear                    
group by KapanId,SlipNo,ShapeId,SizeId,PurityId,FinancialYearId                
                
union                 
--Charni                
select KapanId,convert(varchar,SlipNo)'SlipNo',ShapeId,                
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,                    
FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',                    
sum(Weight) as 'Weight',0 as 'RejectedWeight',                    
isnull((select sum(Weight)'Weight'                          
from salesdetailssummary sds                        
where sds.Category=1 and sds.KapanType='Charni'                        
and sds.SlipNo=convert(varchar,c.SlipNo) and sds.ShapeId=c.ShapeId and sds.SizeId=c.SizeId and sds.PurityId=c.PurityId        
and sds.CharniSizeId=c.CharniSizeId                        
and sds.FinancialYearId=c.FinancialYearId),0) as 'UsedWeight',                    
KapanId+ShapeId+SizeId+PurityId+FinancialYearId+CharniSizeId'Id',        
'Charni' as 'KapanType'                                    
from CharniProcessMaster c                    
where CharniType in (2,3,4)    
and c.CompanyId=@CompanyId and FinancialYearId=@FinancialYear                    
group by KapanId,SlipNo,ShapeId,SizeId,PurityId,FinancialYearId,CharniSizeId                
                
union                
--Gala                
select KapanId,convert(varchar,SlipNo)'SlipNo',ShapeId,                
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,                    
FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',                    
sum(Weight) as 'Weight',0 as 'RejectedWeight',                    
isnull((select sum(Weight)'Weight'                          
from salesdetailssummary sds                        
where sds.Category=1 and sds.KapanType='Gala'                        
and sds.SlipNo=convert(varchar,g.SlipNo) and sds.ShapeId=g.ShapeId and sds.SizeId=g.SizeId and sds.PurityId=g.PurityId        
and sds.GalaSizeId=g.GalaNumberId        
and sds.FinancialYearId=g.FinancialYearId),0) as 'UsedWeight',                    
KapanId+ShapeId+SizeId+PurityId+FinancialYearId+GalaNumberId'Id',        
'Gala' as 'KapanType'                                    
from GalaProcessMaster g                
where GalaProcessType in (2,3,4)    
and g.CompanyId=@CompanyId and FinancialYearId=@FinancialYear                    
group by KapanId,SlipNo,ShapeId,SizeId,PurityId,FinancialYearId,GalaNumberId                
                
)x                
left join KapanMaster k on k.Id=x.KapanId                    
left join ShapeMaster s on s.Id=x.ShapeId                
left join SizeMaster sz on sz.Id=x.SizeId                    
left join PurityMaster p on p.Id=x.PurityId                
group by KapanId,k.Name,SlipNo,ShapeId,s.Name,SizeId,sz.Name,PurityId,p.Name,PurchsaeDetailId,PurchaseMasterId,FinancialYearId,KapanType                
                
)y                    
--where ((Weight+RejectedWeight)-UsedWeight)>0  
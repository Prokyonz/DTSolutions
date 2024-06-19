CREATE proc [GetPendingKapanMapping]          
          
@CompanyId as varchar(50),          
@BranchId as varchar(50),      
@FinancialYear as varchar(50),
@SrNo as varchar(50)=null,
@ActionType as int=0      
          
AS            
          
BEGIN            

if(@ActionType=0)          
Begin
	select x.PurchaseID,x.PurchaseDetailId,Date,x.SlipNo,x.SizeId,x.Size,x.NetWeight,  
	(x.NetWeight-X.Allocated)'AvailableCts','' as KapanId,'' as Remarks,0.00 as Cts        
	from  (    
	Select pm.Id'PurchaseID',p.ID'PurchaseDetailId',convert(datetime,pm.Date)'Date',pm.SlipNo,  
	p.NetWeight,p.SizeId,sm.Name'Size', isnull((select sum(k.Weight)         
	from KapanMappingMaster k           
	where ISNULL(k.TransferId,'0') = '0' and k.PurchaseDetailsId=p.Id and k.PurchaseMasterId=p.PurchaseId and k.SlipNo=pm.SlipNo),0)'Allocated'           
	from PurchaseDetails p          
	left join PurchaseMaster pm on pm.Id=p.PurchaseId          
	left join SizeMaster sm on sm.Id=p.SizeId          
	where pm.isDelete = 0 and pm.CompanyId=@CompanyId and pm.FinancialYearId=@FinancialYear      
	)x  where (x.NetWeight-X.Allocated)<>0       
	order by Date asc        
End
else
Begin
	select x.PurchaseID,x.PurchaseDetailId,Date,x.SlipNo,x.SizeId,x.Size,x.NetWeight,  
	x.NetWeight'AvailableCts',X.Allocated as Cts, KapanId, Remarks        
	from  (    
	Select pm.Id'PurchaseID',p.ID'PurchaseDetailId',convert(datetime,pm.Date)'Date',pm.SlipNo,  
	p.NetWeight,p.SizeId,sm.Name'Size',km.KapanId,km.Remarks, isnull((select sum(k.Weight)
	from KapanMappingMaster k           
	where ISNULL(k.TransferId,'0') = '0' and k.PurchaseDetailsId=p.Id and k.PurchaseMasterId=p.PurchaseId and k.SlipNo=pm.SlipNo),0)'Allocated'           
	from KapanMappingMaster km
	left join PurchaseDetails p on p.Id=km.PurchaseDetailsId 
	left join PurchaseMaster pm on pm.Id=km.PurchaseMasterId and pm.SlipNo=km.SlipNo       
	left join SizeMaster sm on sm.Id=p.SizeId            
	where pm.isDelete = 0 and pm.CompanyId=@CompanyId and pm.FinancialYearId=@FinancialYear      
	and km.Sr=@SrNo
	)x      
	order by Date asc       
End
          
END
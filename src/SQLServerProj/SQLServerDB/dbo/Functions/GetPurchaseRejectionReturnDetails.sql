CREATE FUNCTION [dbo].[GetPurchaseRejectionReturnDetails]  
(  
    @kapanId VARCHAR(MAX),  
    @CompanyId AS VARCHAR(50),  
    @FinancialYearId AS VARCHAR(50)  
)        
RETURNS TABLE        
AS        
RETURN        
(
	SELECT 
		3 as Id,
		CAST(R.EntryDate as date) Date, 
		R.SlipNo,
		'' as OperationType,
		'' as Size,                    
		PAM.Name + ' (Rej)' AS Party, 
		R.TotalCarat as NetWeight,
		R.Rate as 'Rate', 
		R.Amount as Amount,
		'Outward' as Category, 
		2 as CategoryId,
		1 as Records,
		KM.KapanId,
		PM.BranchId
	 From RejectionInOutMaster R
	 left join KapanMappingMaster KM ON km.PurchaseDetailsId = R.PurchaseSaleDetailsId
	 Left JOIN [PurchaseMaster] AS PM ON PM.Id=KM.PurchaseMasterId                    
	 Left JOIN [PurchaseDetails] AS PD ON PD.Id=KM.PurchaseDetailsId AND PM.Id = PD.PurchaseId                        
	 Left JOIN [PartyMaster] AS PAM ON PAM.Id = PM.PartyId                     
	 JOIN CSVToTable(@kapanId) AS K ON KM.KapanId = K.id
	 where R.PurchaseSaleDetailsId=pd.Id and R.TransType=2 and R.ProcessType='Purchase'
	 and pd.RejectedWeight = 0
	 and isnull(KM.TransferType,'')=''
);
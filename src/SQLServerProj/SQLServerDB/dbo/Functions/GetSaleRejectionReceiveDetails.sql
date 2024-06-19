CREATE FUNCTION [dbo].[GetSaleRejectionReceiveDetails]  
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
		4 as Id,
		CAST(R.EntryDate as date) Date, 
		R.SlipNo,
		'' as OperationType,
		'' as Size,                    
		PAM.Name + ' (Rej)' AS Party, 
		R.TotalCarat as NetWeight,
		R.Rate as 'Rate', 
		R.Amount as Amount,
		'Inward' as Category, 
		1 as CategoryId,
		1 as Records,
		SD.KapanId,
		SM.BranchId
	 From RejectionInOutMaster R              
	 Left JOIN [SalesDetails] AS SD ON SD.Id=R.PurchaseSaleDetailsId 
	 Left JOIN [SalesMaster] AS SM ON SM.Id=SD.SalesId     
	 Left JOIN [PartyMaster] AS PAM ON PAM.Id = SM.PartyId                     
	 JOIN CSVToTable(@kapanId) AS K ON SD.KapanId = K.id
	 where R.PurchaseSaleDetailsId=SD.Id and R.TransType=1 and R.ProcessType='Sale'
	 and sd.RejectedWeight = 0
);
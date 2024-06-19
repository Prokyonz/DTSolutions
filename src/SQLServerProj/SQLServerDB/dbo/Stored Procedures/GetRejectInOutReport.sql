CREATE PROCEDURE [dbo].[GetRejectInOutReport]   
 @CompanyId as varchar(50),          
 @FinancialYearId as varchar(50),
 @RejectionType as int /*Rejection In/Receive - Sales = 1, Rejecton Out/Send - Purchase = 2*/
AS  
BEGIN  

	Select CAST(RIOM.EntryDate as Date) 'EntryDate', RIOM.TransType, RIOM.Id, RIOM.SrNo, RIOM.CompanyId, RIOM.BranchId, RIOM.FinancialYearId, RIOM.PartyId, PM.Name 'PartyName', RIOM.BrokerageId, PM1.Name 'BrokerName',    
		RIOM.SlipNo, RIOM.SizeId, ISNULL(SM.Name, '') 'SizeName', RIOM.Rate, RIOM.TotalCarat, RIOM.Amount, RIOM.Remarks, RIOM.CharniSizeId, ISNULL(SM1.Name,'') 'CharniSizeName',  
		RIOM.GalaSizeId, ISNULL(SM2.Name, '') 'GalaSizeName', RIOM.NumberSizeId, ISNULL(SM3.Name, '') 'NumberSizeName', RIOM.PurityId, ISNULL(PUM.Name, '') 'PurityName',
		RIOM.Image1, RIOM.Image2, RIOM.Image3 from RejectionInOutMaster RIOM
		
		INNER JOIN PartyMaster PM ON  PM.Id = RIOM.PartyId
		INNER JOIN PartyMaster PM1 ON PM1.Id = RIOM.BrokerageId
		LEFT JOIN SizeMaster SM ON SM.Id = RIOM.SizeId
		LEFT JOIN SizeMaster SM1 ON SM1.Id = RIOM.CharniSizeId
		LEFT JOIN SizeMaster SM2 ON SM2.Id = RIOM.GalaSizeId
		LEFT JOIN SizeMaster SM3 ON SM3.Id = RIOM.NumberSizeId
		LEFT JOIN PurityMaster PUM ON PUM.Id = RIOM.PurityId
	
	WHERE RIOM.TransType=@RejectionType
	AND RIOM.CompanyId = @CompanyId AND RIOM.FinancialYearId = @FinancialYearId

END
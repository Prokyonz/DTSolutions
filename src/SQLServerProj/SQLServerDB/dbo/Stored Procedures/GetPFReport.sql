CREATE proc [dbo].[GetPFReport]
  
@CompanyId as varchar(50)='', 
@FinancialYear as varchar(50) ='',
@PFType as BIT

as  
BEGIN

	SELECT 'Purchase' Type, PM.CompanyId, PM.FinancialYearId, PMS.Id 'PartyId', PMS.Name 'PartyName', PMS1.Id 'BrokerId', PMS1.Name 'BrokerName', SM.Id 'SizeId', SM.name 'Size', '' 'Number', '' 'NumberId', PD.Weight, PD.NetWeight, PD.BuyingRate 'Rate', PD.Amount, PM.CreatedDate  from PurchaseMaster PM
		INNER JOIN PurchaseDetails PD ON PM.Id = PD.PurchaseId
		INNER JOIN PartyMaster PMS ON PMS.Id = PM.PartyId
		INNER JOIN PartyMaster PMS1 ON PMS1.Id = PM.BrokerageId
		INNER JOIN SizeMaster SM ON SM.Id = PD.SizeId
	WHERE PM.IsPF = @PFType AND PM.CompanyId = @CompanyId AND PM.FinancialYearId = @FinancialYear

	UNION

	SELECT 'Sales' Type, SM.CompanyId, SM.FinancialYearId, PM.Id 'PartyId', PM.Name 'PartyName', PM1.Id 'BrokerId', PM1.Name 'BrokerName', SM1.Id 'SizeId', SM1.name 'Size', NM.Name 'Number', NM.Id 'NumberId', SD.Weight, SD.NetWeight, SD.SaleRate 'Rate', SD.Amount, SM.CreatedDate  from SalesMaster SM
		INNER JOIN SalesDetails SD ON SM.Id = SD.SalesId
		INNER JOIN PartyMaster PM ON PM.Id = SM.PartyId
		INNER JOIN PartyMaster PM1 ON PM1.Id = SM.BrokerageId
		INNER JOIN SizeMaster SM1 ON SM1.Id = SD.SizeId
		INNER JOIN NumberMaster NM ON NM.Id = SD.NumberSizeId
	WHERE SM.IsPF = @PFType AND SM.CompanyId = @CompanyId AND SM.FinancialYearId = @FinancialYear
END
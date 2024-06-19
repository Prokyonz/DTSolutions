CREATE proc [dbo].[GetPartyMasterReport]
   
@CompanyId as varchar(50)

AS  
BEGIN
		SELECT PM.Id, PM.Sr, PM.CompanyId, PM.BrokerageId, PM.Type, PM.SubType, PM.Name, PM.ShortName, PM.EmailId, PM.Address, PM.Address2, PM.MobileNo, PM.OfficeNo, PM.GSTNo, PM.AadharCardNo, PM.PancardNo, PM.OpeningBalance, PM.IsDelete, PM.Status, PM.CreatedDate, PM.UpdatedDate, PM.CreatedBy, PM.UpdatedBy, PM.Salary, PM.CRDRType,
		CASE  
			WHEN type = 1 THEN 'Sundry Creditors'--'Party-Buy'  
			WHEN Type=2 THEN 'Employee'
			WHEN Type=3 THEN 'Expense'
			WHEN type=4 THEN 'Bank'
			WHEN type=5 THEN 'Cash'
			WHEN type=6 THEN 'DirectIncome'
			WHEN type=7 THEN 'InDirectIncome'
			WHEN type=8 THEN 'Asset'
			WHEN type=9 THEN 'Deposit'
			WHEN type=10 THEN 'Loan and Advance'
			WHEN type=11 THEN 'CapitalAccount'
			WHEN type=12 THEN 'Investment'
			WHEN type=13 THEN 'Loan'
			WHEN type = 14 THEN 'Sundry Debtors'--'Party-Sale'  

		END AS TypeName,		 
		CASE
			WHEN SubType=6 THEN 'Buyer'
			WHEN SubType=7 THEN 'Seller'
			WHEN SubType=8 THEN 'Broker'
			WHEN SubType=9 THEN 'Other'
			WHEN SubType=16 THEN 'Salaried'
			WHEN SubType=0 THEN ''
		END AS SubTypeName,
		LBM.Balance from PartyMaster PM 
		INNER JOIN LedgerBalanceManager LBM ON PM.Id = LBM.LedgerId
		WHERE PM.CompanyId = @CompanyId AND PM.IsDelete = 0
END
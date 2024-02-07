truncate table KapanMaster
truncate table  CurrencyMaster
truncate table LessWeightDetails
delete from   LessWeightMasters
DBCC CHECKIDENT (LessWeightMasters, RESEED, 0)
truncate table SizeMaster
truncate table PurityMaster
truncate table GalaMaster
truncate table NumberMaster
truncate table BrokerageMaster
truncate table FinancialYearMaster -- Need Insert statemetn for DEFAUTL FIN YEAR
truncate table PurchaseDetails
delete from PurchaseMaster
DBCC CHECKIDENT (PurchaseMaster, RESEED, 0)
truncate table SalesDetailsSummary
delete from SalesDetails
DBCC CHECKIDENT (SalesDetails, RESEED, 0)
delete from  SalesMaster
DBCC CHECKIDENT (SalesMaster, RESEED, 0)
truncate table ExpenseDetails
delete from  ExpenseMaster
DBCC CHECKIDENT (ExpenseMaster, RESEED, 0)
delete from SalaryDetails
DBCC CHECKIDENT (SalaryDetails, RESEED, 0)
delete from SalaryMaster
DBCC CHECKIDENT (SalaryMaster, RESEED, 0)
truncate table PaymentDetails
delete from  PaymentMaster
DBCC CHECKIDENT (PaymentMaster, RESEED, 0)
delete from  GroupPaymentMaster
DBCC CHECKIDENT (GroupPaymentMaster, RESEED, 0)
truncate table ContraEntryDetails
delete from  ContraEntryMaster
DBCC CHECKIDENT (ContraEntryMaster, RESEED, 0)
truncate table SlipTransferEntry
truncate table KapanMappingMaster
truncate table AccountToAssortDetails
delete from AccountToAssortMaster
DBCC CHECKIDENT (AccountToAssortMaster, RESEED, 0)
truncate table BoilProcessMaster
truncate table CharniProcessMaster
truncate table GalaProcessMaster
truncate table NumberProcessMaster
truncate table TransferMaster
truncate table LoanMaster
select * from  PermissionMaster -- DO NOT DELTE THIS PERMISSIONS
select * from  UserPermissionChild -- ONLY DEFAULT ADMIN PERMISSION SHOULD BE THERE
select * from  ApprovalPermissionMaster -- ONLY DEFAULT ADMIN PERMISSION SHOULD BE THERE
truncate table JangadMaster
truncate table PriceMaster
truncate table PriceMasterMobile
truncate table RejectionInOutMaster
truncate table OpeningStockMaster
truncate table LedgerBalanceManager
truncate table CalculatorMaster
select * from UserCompanyMappings -- ONLY DEFAULT ADMIN USER HAS ONE COMPANY MAPPINGS
truncate table BillPrintModel
delete from  PartyMaster        
DBCC CHECKIDENT (PartyMaster, RESEED, 0)
select * from  BranchMaster -- BEFORE REMVOING YOU NEED DEFAUTL BRANCH INSERT QUERY
select * from UserMaster -- BEFORE DELTEE YOU NEED DEFAULT ADMIN USER WITH COMPANY, APPROVAL, and all PERMISSSIONS
select * from  ShapeMaster -- FOUND DEFAULT SHAPE IN DB
SELECT * from  CompanyMaster -- NEED AN INSERT QUERY OF DEFAULT COMPANY
        

        
        




                        
        
        
        
        

        
        
        
        
        
        
        
        
        
        
        
        
        
        
		
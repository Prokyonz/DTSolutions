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
select * from  ApprovalPermissionMaster -- ONLY DEFAULT ADMIN PERMISSION SHOULD BE THERE using update query
truncate table JangadMaster
truncate table PriceMaster
truncate table PriceMasterMobile
truncate table RejectionInOutMaster
truncate table OpeningStockMaster
truncate table LedgerBalanceManager
truncate table CalculatorMaster
truncate table BillPrintModel
delete from  PartyMaster        
DBCC CHECKIDENT (PartyMaster, RESEED, 0)
delete from  BranchMaster -- BEFORE REMVOING YOU NEED DEFAUTL BRANCH INSERT QUERY
DBCC CHECKIDENT (BranchMaster, RESEED, 0)
delete from UserCompanyMappings -- ONLY DEFAULT ADMIN USER HAS ONE COMPANY MAPPINGS
DBCC CHECKIDENT (UserCompanyMappings, RESEED, 0)
delete from  UserPermissionChild -- ONLY DEFAULT ADMIN PERMISSION SHOULD BE THERE
DBCC CHECKIDENT (UserPermissionChild, RESEED, 0)
delete from UserMaster -- BEFORE DELTEE YOU NEED DEFAULT ADMIN USER WITH COMPANY, APPROVAL, and all PERMISSSIONS
DBCC CHECKIDENT (UserMaster, RESEED, 0)
delete from  ShapeMaster -- FOUND DEFAULT SHAPE IN DB
DBCC CHECKIDENT (ShapeMaster, RESEED, 0)
delete from  CompanyMaster -- NEED AN INSERT QUERY OF DEFAULT COMPANY
DBCC CHECKIDENT (CompanyMaster, RESEED, 0)
delete from FinancialYearMaster -- Need Insert statemetn for DEFAUTL FIN YEAR        
DBCC CHECKIDENT (FinancialYearMaster, RESEED, 0)


insert into UserMaster(Id,Name,Password,UserName,UserType,DateOfBirth,DateOfJoin,DateOfEnd,IsActive,IsDelete,CreatedDate)
values('00000000-0000-0000-0000-000000000000','ADMINISTRATOR','123','ADMIN','1','2024-02-01 00:00:00.0000000','2024-02-01 00:00:00.0000000','2024-02-01 00:00:00.0000000',1,0,'2024-02-01 00:00:00.0000000')

insert into ShapeMaster (Id,Name,IsDelete,CreatedDate)
values('00000000-0000-0000-0000-000000000000','ROUND',0,'2024-02-01 00:00:00.0000000')

insert into CompanyMaster (Id,Name,RegistrationNo,IsDelete,CreatedDate)
values('00000000-0000-0000-0000-000000000000','DEFAULT COMPANY','0000000000',0,'2024-02-01 00:00:00.0000000')

insert into BranchMaster (Id,CompanyId,LessWeightId,Name,CVDWeight,TipWeight,IsDelete,CreatedDate)
values('00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000000','DEFAULT BRANCH',0,0,0,'2024-02-01 00:00:00.0000000')

insert into FinancialYearMaster(Id,Name,StartDate,EndDate,IsDelete,CreatedDate)
values('00000000-0000-0000-0000-000000000000','DEFAULT YEAR','2024-02-01 00:00:00.0000000','2024-02-01 00:00:00.0000000',0,'2024-02-01 00:00:00.0000000')

insert into UserCompanyMappings(Id,UserId,CompanyId,CreatedDate)
values('00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000000','2024-02-01 00:00:00.0000000')
 
insert into UserPermissionChild(Id,PermissionMasterId,UserId,KeyName,Status)
select Id,Id,'00000000-0000-0000-0000-000000000000',KeyName,1 from PermissionMaster

update ApprovalPermissionMaster set UserId='00000000-0000-0000-0000-000000000000'



        
        




                        
        
        
        
        

        
        
        
        
        
        
        
        
        
        
        
        
        
        
		
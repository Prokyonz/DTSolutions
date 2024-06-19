create proc [GetPurchaseDetailsForEdit]

@PurchaseId as varchar(50)

as 

select * from PurchaseMaster where Id=@PurchaseId

select * from PurchaseDetails where PurchaseId=@PurchaseId
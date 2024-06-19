CREATE function [GetKapanLagadDetails]
(@kapanId varchar(max))    
returns Table    
as    
return
(
select * from GetKapanOpeningBalance(@kapanId)
union
select * from GetKapanPurchaseDetails(@kapanId)
union
select * from GetTransferToDetails(@kapanId)
union
select * from GetKapanPurchaseExpenseDetail(@kapanId)
union
select * from GetKapanSaleDetail(@kapanId)
union
select * from GetAssortmentReceiveDetails(@kapanId)
union
select * from GetTransferFromDetails(@kapanId)
)
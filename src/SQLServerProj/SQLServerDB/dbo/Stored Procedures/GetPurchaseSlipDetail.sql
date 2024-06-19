CREATE Proc [GetPurchaseSlipDetail]
  
@Company as varchar(50),  
@SlipNo as varchar(50),  
@FinancialYear as varchar(50)
  
as  
  
select *,convert(decimal(18,2),Rate-Disc) 'Total',convert(decimal(18,2),(Rate-Disc)-CVDCharge)'Final',SlipNo as Id  
from(  
select pm.SlipNo,CONVERT(varchar,CONVERT(datetime, pm.Date),103)'Date',pm.PartyId,party.Name'Party',
pm.BrokerageId,party1.Name'Broker',  
p.Weight-p.TipWeight'Weight',p.CVDWeight,p.RejectedWeight,p.LessWeight,  
p.NetWeight,convert(decimal(18,2),p.BuyingRate)'CRate',  
p.LessDiscountPercentage,convert(decimal(18,2),(p.NetWeight*p.BuyingRate))'Rate',  
convert(decimal(18,2),(((p.NetWeight*p.BuyingRate)*p.LessDiscountPercentage)/100))'Disc',  
convert(decimal(18,2),(((p.Weight-p.TipWeight)*p.CVDCharge)))'CVDCharge',  
pm.DueDays,pm.PaymentDays   
from PurchaseDetails p
left join PurchaseMaster pm on pm.Id=p.PurchaseId  
left join PartyMaster party on party.Id=pm.PartyId
left join PartyMaster party1 on party1.Id=pm.BrokerageId   
where pm.CompanyId=@Company and pm.SlipNo=@SlipNo and pm.FinancialYearId=@FinancialYear  
)x
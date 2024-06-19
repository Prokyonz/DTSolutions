Create Proc [GetSalesSlipDetail]
  
@Company as varchar(50),  
@SlipNo as varchar(50),  
@FinancialYear as varchar(50)
  
as  
  
select *,convert(decimal(18,2),Rate-Disc) 'Total',convert(decimal(18,2),(Rate-Disc)-CVDCharge)'Final',SlipNo as Id  
from(  
select sm.SlipNo,CONVERT(varchar,CONVERT(datetime, sm.Date),103)'Date',sm.PartyId,party.Name'Party',
sm.BrokerageId,party1.Name'Broker',  
s.Weight-s.TipWeight'Weight',s.CVDWeight,s.RejectedWeight,s.LessWeight,  
s.NetWeight,convert(decimal(18,2),s.SaleRate)'CRate',  
s.LessDiscountPercentage,convert(decimal(18,2),(s.NetWeight*s.SaleRate))'Rate',  
convert(decimal(18,2),(((s.NetWeight*s.SaleRate)*s.LessDiscountPercentage)/100))'Disc',  
convert(decimal(18,2),(((s.Weight-s.TipWeight)*s.CVDCharge)))'CVDCharge',  
sm.DueDays,sm.PaymentDays   
from SalesDetails s
left join SalesMaster sm on sm.Id=s.SalesId
left join PartyMaster party on party.Id=sm.PartyId
left join PartyMaster party1 on party1.Id=sm.BrokerageId   
where sm.CompanyId=@Company and sm.SlipNo=@SlipNo and sm.FinancialYearId=@FinancialYear  
)x
CREATE proc [dbo].[GetPurchaseSlipPrintList]

@Company as varchar(50),
@FinancialYear as varchar(50)

as  
  
select SlipNo as Id,pm.SlipNo,
CONVERT(varchar,CONVERT(datetime, pm.Date),103)'Date',pm.PartyId,
party.Name'Party',
pm.BrokerageId,
party1.Name'Broker',
pm.FinancialYearId       
from PurchaseMaster pm
left join PartyMaster party on party.Id=pm.PartyId
left join PartyMaster party1 on party1.Id=pm.BrokerageId
where pm.isDelete = 0 and pm.AllowSlipPrint=1
and pm.CompanyId=@Company and pm.FinancialYearId=@FinancialYear
order by pm.SlipNo
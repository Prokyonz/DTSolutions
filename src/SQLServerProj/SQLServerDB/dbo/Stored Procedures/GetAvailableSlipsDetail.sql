CREATE proc [dbo].[GetAvailableSlipsDetail]  
  
@ActionType as int,
@Company as varchar(50),  
@FinancialYear as varchar(50)  
  
as    

if(@ActionType=1)--Purchase
Begin
	select pm.Id,isnull(pm.IsSlipPrint,1) as IsSlipPrint,pm.SlipNo,  
	CONVERT(varchar,CONVERT(datetime, pm.Date),103)'Date',pm.PartyId,  
	party.Name'Party',  
	pm.BrokerageId,  
	party1.Name'Broker',  
	pm.FinancialYearId         
	from PurchaseMaster pm  
	left join PartyMaster party on party.Id=pm.PartyId  
	left join PartyMaster party1 on party1.Id=pm.BrokerageId  
	where pm.IsDelete = 0 and pm.AllowSlipPrint=1   
	and pm.CompanyId=@Company and pm.FinancialYearId=@FinancialYear  
	order by pm.SlipNo
End
Else
Begin
	select sm.Id,isnull(sm.IsSlipPrint,1) as IsSlipPrint,sm.SlipNo,  
	CONVERT(varchar,CONVERT(datetime, sm.Date),103)'Date',sm.PartyId,  
	party.Name'Party',  
	sm.BrokerageId,  
	party1.Name'Broker',  
	sm.FinancialYearId         
	from SalesMaster sm  
	left join PartyMaster party on party.Id=sm.PartyId  
	left join PartyMaster party1 on party1.Id=sm.BrokerageId  
	where sm.IsDelete = 0 and sm.AllowSlipPrint=1   
	and sm.CompanyId=@Company and sm.FinancialYearId=@FinancialYear  
	order by sm.SlipNo
End
CREATE Proc [dbo].[GetAvailableSlipDetail]

@ActionType as int,  
@Company as varchar(50),  
@SlipNo as varchar(50),  
@FinancialYear as varchar(50)
  
as  

if(@ActionType=1)--Purchase  
Begin
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
	where pm.IsDelete = 0 and pm.CompanyId=@Company and pm.SlipNo=@SlipNo and pm.FinancialYearId=@FinancialYear  
	)x
End
Else --Sales
Begin
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
	where sm.IsDelete = 0 and sm.CompanyId=@Company and sm.SlipNo=@SlipNo and sm.FinancialYearId=@FinancialYear  
	)x 
End
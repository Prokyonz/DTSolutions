CREATE proc [dbo].[GetRejectionProcessReceivedDetails]

@CompanyId as varchar(50),                                     
@FinancialYear as varchar(50)

as

select pm.PartyId,p.Name'PartyName',b.SlipNo,sum(b.RejectionWeight)'RejectionWeight',b.CompanyId,b.FinancialYearId,'Boil' as ProcessType
 from BoilProcessMaster b
 left join PurchaseMaster pm on pm.SlipNo=b.SlipNo and pm.CompanyId=b.CompanyId and pm.FinancialYearId=b.FinancialYearId
 left join PartyMaster p on p.Id=pm.PartyId
 where b.CompanyId=@CompanyId and b.FinancialYearId=@FinancialYear
 and b.BoilType=1 and convert(numeric(18,3),b.RejectionWeight) > 0
 and pm.isDelete=0
 group by pm.PartyId,b.SlipNo,p.Name,b.CompanyId,b.FinancialYearId
 --and b.SlipNo=p.SlipNo
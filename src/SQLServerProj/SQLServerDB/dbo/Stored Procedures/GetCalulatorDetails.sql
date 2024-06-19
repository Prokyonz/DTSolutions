--exec GetCalulatorDetails '1','1','20230429','20230429'  
CREATE proc [dbo].[GetCalulatorDetails]  
  
@CompanyId as varchar(50),  
@FinacialYearId as varchar(50),  
@Fromdate as varchar(50),  
@Todate as varchar(50)  
  
as  
  
select c.Date, c.SrNo, c.CompanyId, c.FinancialYearId, c.BranchId, b.Name as BranchName,  
c.PartyId, c.PartyId  as PartyName, c.DealerId as BrokerId, c.DealerId as BrokerName,  
c.NetCarat, c.CreatedBy as UserId,u.Name as UserName,  
c.SizeId, s.Name as SizeName, c.TotalCarat,  
c.NumberId, n.Name as NumberName, c.Carat, c.Rate, c.Amount, c.Percentage, c.Note  
from CalculatorMaster c  
--left join PartyMaster p on p.Id=c.PartyId  
--left join PartyMaster pb on pb.Id=c.DealerId  
left join SizeMaster s on s.Id=c.SizeId  
left join NumberMaster n on n.Id=c.NumberId  
left join UserMaster u on u.Id=c.CreatedBy  
left join BranchMaster b on b.Id=c.BranchId  
where (CAST(c.Date as Date) >= @FromDate AND CAST(c.Date as Date) <= @ToDate) 
and c.CompanyId=@CompanyId and c.FinancialYearId=@FinacialYearId
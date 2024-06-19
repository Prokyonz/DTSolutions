CREATE proc [GetJangadPrintDetails]    
    
@SrNo as varchar(50),    
@CompanyId as varchar(50),    
@FinancialYearId as varchar(50),
@EntryType as numeric(18,0)
    
as    
    
select ROW_NUMBER() OVER (ORDER BY SrNo) As SNo,SrNo,    
convert(varchar,convert(datetime, j.CreatedDate),103)'Date',c.Name'CompanyName',    
c.Address,c.GSTNo,p.Name'PartyName',''BrokerName,s.Name'Size',    
j.Totalcts,j.Rate,j.Amount,j.Remarks    
from JangadMaster j    
left join SizeMaster s on s.Id=j.SizeId    
left join CompanyMaster c on c.Id=j.CompanyId    
left join PartyMaster p on p.Id=j.PartyId    
where j.EntryType=@EntryType
and j.SrNo=@SrNo and j.CompanyId=@CompanyId and j.FinancialYearId=@FinancialYearId
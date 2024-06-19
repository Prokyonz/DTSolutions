CREATE proc [GetJangadReceiveDetail]  
    
@CompanyId as varchar(50),            
@FinancialYear as varchar(50)      
    
as    
            
select SrNo,SizeId,Size,Rate,Amount,Totalcts-x.ReceivedWeight'AvailableWeight',           
Totalcts'TotalWeight',PartyId,PartyName,BrokerId,BrokerName,  
convert(varchar,SrNo)+convert(varchar,SizeId)'Id'  
from             
(select j.SrNo,j.Rate,j.PartyId,j.BrokerId,j.SizeId,sz.Name'Size',j.Amount,p.Name'PartyName',''BrokerName,
Totalcts,isnull((select sum(TotalCts) from JangadMaster j1            
where j1.EntryType=1 and j1.ReceivedSrNo=j.SrNo   
and j1.SizeId=j.SizeId  
and j1.FinancialYearId=j.FinancialYearId    
),0)'ReceivedWeight',                  
j.SizeId+CONVERT(nvarchar(10),j.SrNo) as 'ID'                   
from JangadMaster j                 
left join SizeMaster sz on sz.Id=j.SizeId    
left join PartyMaster p on p.Id=j.PartyId  
where EntryType=2 --Send    
and j.CompanyId=@CompanyId and j.FinancialYearId=@FinancialYear
)x                  
where Totalcts-x.ReceivedWeight <> 0
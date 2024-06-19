CREATE function GetAssortmentReceiveDetails
(
@kapanId varchar(max),
@CompanyId as varchar(50),
@FinancialYearId as varchar(50)
)      
returns Table      
as      
return      
(select 1 as Id,n.EntryDate as Date,'0' as SlipNo,'NR' as OperationType,'' as Size,        
 '('+s.Name+')'+' '+nm.Name as Party,NumberWeight as NetWeight,TransferCaratRate as Rate,NumberWeight*TransferCaratRate as Amount,    
 'Outward' as Category, 2 as CategoryId, 1 as Records,KapanId,n.BranchId                    
 from NumberProcessMaster n                    
 left join NumberMaster nm on nm.Id=n.NumberId                    
 left join SizeMaster s on s.Id=n.CharniSizeId                    
 where n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYearId
 and NumberProcessType=2                    
 and KapanId in (select id from CSVToTable(@kapanId)))
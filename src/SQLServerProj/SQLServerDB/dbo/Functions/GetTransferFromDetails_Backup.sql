CREATE function [dbo].[GetTransferFromDetails_Backup]
(
@kapanId varchar(max),
@CompanyId as varchar(50),
@FinancialYearId as varchar(50)
)      
returns Table      
as      
return      
(select 2 as Id,Date,'' as SlipNo,'TT' as OperationType,Size,        
 Kapan as Party, sum(Weight) as NetWeight,Rate as Rate,sum(Weight)*Rate as Amount,'Outward' as Category, 2 as CategoryId, 1 as Records,KapanId,BranchId from(                    
 select t.Date,k.Weight*-1'Weight',s.Name as Size,                      
 (case when ISNULL(n.TransferId, '')<>'' then '('+s.Name+') '+nm.Name else (select top 1 km1.Name from KapanMappingMaster k1 left join KapanMaster km1 on km1.Id=k1.KapanId where k1.TransferId=k.TransferId and k1.TransferEntryId=k.TransferEntryId and TransferType='TransferedTo') end)'Kapan',      
 (select top 1 k1.TransferCaratRate from KapanMappingMaster k1 where k1.TransferId=k.TransferId and k1.TransferEntryId=k.TransferEntryId and TransferType='TransferedFrom')'Rate',    
 k.KapanId, k.BranchId    
 from TransferMaster t                    
 inner join KapanMappingMaster k on k.TransferId=t.Id               
 left join NumberProcessMaster n on n.TransferId=t.Id and n.TransferEntryId=k.TransferEntryId                   
 left join SizeMaster s on s.Id=n.CharniSizeId              
 left join NumberMaster nm on nm.Id=n.NumberId              
 inner join KapanMaster km on km.Id=k.KapanId              
 where t.CompanyId=@CompanyId and t.FinancialYearId=@FinancialYearId
 and k.TransferType='TransferedFrom' and k.KapanId in (select id from CSVToTable(@kapanId))                          
 and k.SlipNo<>'0'                    
 )x                    
 group by Date,Size,Kapan,Rate,KapanId,BranchId
                 
 union                    
 select 2 as Id,Date,'' as SlipNo,'TT' as OperationType,Size,        
 Kapan as Party,sum(Weight) as NetWeight,Rate as Rate,sum(Weight)*Rate as Amount,'Outward' as Category, 2 as CategoryId, 1 as Records,KapanId, BranchId from(                    
 select t.Date,o.TotalCts*-1'Weight',s.Name as Size,                    
 (case when ISNULL(n.TransferId, '')<>'' then '('+s.Name+') '+nm.Name else (select top 1 km1.Name from OpeningStockMaster o1 left join KapanMaster km1 on km1.Id=o1.KapanId where o1.TransferId=o.TransferId and o1.TransferEntryId=o.TransferEntryId and TransferType='TransferedTo') end)'Kapan',               
 (select top 1 o1.TransferCaratRate from OpeningStockMaster o1 where o1.TransferId=o.TransferId and o1.TransferEntryId=o.TransferEntryId and TransferType='TransferedFrom')'Rate',    
 o.KapanId, o.BranchId    
 from TransferMaster t                    
 left join OpeningStockMaster o on o.TransferId=t.Id                  
 left join NumberProcessMaster n on n.TransferId=t.Id and n.TransferEntryId=o.TransferEntryId                   
 left join SizeMaster s on s.Id=n.CharniSizeId              
 left join NumberMaster nm on nm.Id=n.NumberId              
 inner join KapanMaster km on km.Id=o.KapanId                
 where t.CompanyId=@CompanyId and t.FinancialYearId=@FinancialYearId
 and o.TransferType='TransferedFrom' and o.KapanId in (select id from CSVToTable(@kapanId))                          
 )x
 group by Date,Size,Kapan,Rate,KapanId,BranchId
 )
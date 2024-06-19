CREATE proc [GetAllNumberStockDetails_New]        
        
as        
      
select ROW_NUMBER() OVER(PARTITION BY b.Name,y.Size,y.Number ORDER BY b.Name,y.Size,y.Number ASC) AS RowNo,y.*,b.Name as BranchName     
into #tempNumberDetails from(        
--Inwards        
--Opening Stock Details      
select 0 as Id,CAST(o.CreatedDate as date) Date, '' as SlipNo,'Opening Stock' as OperationType,sz.Name as Size,nm.Name as Number, k.Name as Kapan,                      
 'Opening Stock' AS Party,'Inward' as Category, 1 as CategoryId, 1 as Records, o.BranchId,                     
  convert(decimal(18,2),TotalCts)'InwardNetWeight',          
  convert(decimal(18,2),Rate)'InwardRate',          
  convert(decimal(18,2),TotalCts*Rate)'InwardAmount',          
  convert(decimal(18,2),0)'OutwardNetWeight',          
  convert(decimal(18,2),0)'OutwardRate',          
  convert(decimal(18,2),0)'OutwardAmount'        
 from OpeningStockMaster o                       
 left join NumberMaster nm on nm.Id=o.NumberId      
 left join SizeMaster sz on sz.Id=o.SizeId      
 left join KapanMaster k on k.Id=o.KapanId      
 where Category=0 and isnull(TransferType,'')=''      
      
union       
--Kapan Numbers Details      
select 1 as Id,CreatedDate as Date,'' SlipNo,'Kapan Number' as OperationType,Size, Number, Kapan,        
Kapan AS Party,'Inward' as Category, 1 as CategoryId, 1 as Records, BranchId,         
convert(decimal(18,2),Weight)'InwardNetWeight',          
convert(decimal(18,2),Rate)'InwardRate',          
convert(decimal(18,2),Weight*Rate)'InwardAmount',          
convert(decimal(18,2),0)'OutwardNetWeight',          
convert(decimal(18,2),0)'OutwardRate',          
convert(decimal(18,2),0)'OutwardAmount'        
 from(                        
 select n.CreatedDate,n.NumberWeight'Weight',sz1.Name as Size,                        
 nm.Name as Number,isnull(k.Name,'') as Kapan,        
 n.TransferCaratRate as Rate, n.BranchId        
 from NumberProcessMaster n                              
 left join ShapeMaster s on s.Id=n.ShapeId                              
 left join NumberMaster nm on nm.Id=n.NumberId                              
 left join SizeMaster sz1 on sz1.Id=n.CharniSizeId                              
 left join KapanMaster k on k.Id=n.KapanId        
 where NumberProcessType = 2 --Assort Receive        
 )x        
       
union        
--Number Stock Transfer To Details      
select 2 as Id,Date,'' SlipNo,'TF' as OperationType,Size,Number,Kapan,        
Number as Party, 'Inward' as Category, 1 as CategoryId, 1 as Records,BranchId,         
convert(decimal(18,2),Weight)'InwardNetWeight',          
convert(decimal(18,2),Rate)'InwardRate',          
convert(decimal(18,2),Weight*Rate)'InwardAmount',          
convert(decimal(18,2),0)'OutwardNetWeight',          
convert(decimal(18,2),0)'OutwardRate',          
convert(decimal(18,2),0)'OutwardAmount'        
from(                        
 select t.Date,n.NumberWeight'Weight',s.Name as Size,nm.Name as Number,                        
 k.Name as Kapan,                           
(select n1.TransferCaratRate from NumberProcessMaster n1 where n1.TransferId=n.TransferId and n1.TransferEntryId=n.TransferEntryId and TransferType='TransferedTo')'Rate',      
 n.BranchId                        
 from TransferMaster t                        
 left join NumberProcessMaster n on n.TransferId=t.Id        
 left join SizeMaster s on s.Id=n.CharniSizeId                  
 left join NumberMaster nm on nm.Id=n.NumberId                  
 left join KapanMaster k on k.Id=n.KapanId        
 where n.TransferType='TransferedTo'                        
 )x           
          
 union        
 --Outwards         
 --Number Stock Transfer From Details      
select 3 as Id,Date,'' SlipNo,'TF' as OperationType,Size,Number,Kapan,      
Number as Party,'Outward' as Category, 2 as CategoryId, 2 as Records,BranchId,        
convert(decimal(18,2),0)'InwardNetWeight',          
convert(decimal(18,2),0)'InwardRate',          
convert(decimal(18,2),0)'InwardAmount',          
convert(decimal(18,2),Weight)'OutwardNetWeight',          
convert(decimal(18,2),Rate)'OutwardRate',          
convert(decimal(18,2),Weight*Rate)'OutwardAmount'        
 from(                        
 select t.Date,n.NumberWeight*-1'Weight',s.Name as Size,nm.Name as Number,                        
 k.Name as Kapan,                        
(select n1.TransferCaratRate from NumberProcessMaster n1 where n1.TransferId=n.TransferId and n1.TransferEntryId=n.TransferEntryId and TransferType='TransferedFrom')'Rate',      
 n.BranchId                        
 from TransferMaster t                        
 left join NumberProcessMaster n on n.TransferId=t.Id        
 left join SizeMaster s on s.Id=n.CharniSizeId                  
 left join NumberMaster nm on nm.Id=n.NumberId                  
 left join KapanMaster k on k.Id=n.KapanId        
 where n.TransferType='TransferedFrom'                        
 )x         
             
union         
--Number Sale Details      
select 4 as Id,CreatedDate as Date,convert(varchar,SlipNo) as SlipNo,'Sale' as OperationType,Size,Number,Kapan,        
Party,'Outward' as Category, 2 as CategoryId, 2 as Records,BranchId,        
convert(decimal(18,2),0)'InwardNetWeight',          
convert(decimal(18,2),0)'InwardRate',          
convert(decimal(18,2),0)'InwardAmount',          
convert(decimal(18,2),Weight)'OutwardNetWeight',          
convert(decimal(18,2),Rate)'OutwardRate',          
convert(decimal(18,2),Weight*Rate)'OutwardAmount'        
  from(                        
 select sd.CreatedDate,sm.SlipNo,sd.Weight'Weight',sz.Name as Size,                        
 nm.Name as Number,isnull(k.Name,'') as Kapan,        
 s.SaleRate as Rate,pm.Name as Party,      
 sm.BranchId        
from SalesDetailsSummary sd         
left join SalesMaster sm on sm.Id=sd.SalesId        
left join SalesDetails s on s.Id= sd.SalesDetailsId                                           
left join SizeMaster sz on sz.Id=sd.CharniSizeId         
left join NumberMaster nm on nm.Id=sd.NumberSizeId        
left join KapanMaster k on k.Id=sd.KapanId        
left join PartyMaster pm ON pm.Id = sm.PartyId        
 where sd.Category=0                      
 )x      
 )y      
 left join BranchMaster b on b.Id=y.BranchId    
     
     
 select n1.RowNo,n1.Id,n1.Date,n1.SlipNo,n1.OperationType,n1.Size,n1.Number,n1.Kapan,n1.Party,n1.Category,    
 n1.CategoryId,n1.Records,n1.BranchId,n1.InwardNetWeight,n1.InwardRate,n1.InwardAmount,n1.OutwardNetWeight,    
 n1.OutwardRate,n1.OutwardAmount,n1.BranchName,    
 sum(n2.InwardNetWeight)-sum(n2.OutwardNetWeight) as ClosingNetWeight,    
 (sum(n2.InwardRate)/n1.RowNo)-(sum(n2.OutwardRate)/n1.RowNo) as ClosingRate,    
 sum(n2.InwardAmount)-sum(n2.OutwardAmount) as ClosingAmount    
 from #tempNumberDetails n1    
 inner join #tempNumberDetails n2 on n1.RowNo>=n2.RowNo and n1.BranchId=n2.BranchId and n1.Size=n2.Size and n1.Number=n2.Number   
 group by n1.BranchName,n1.Size,n1.Number,n1.RowNo,n1.Id,  
 n1.Date,n1.SlipNo,n1.OperationType,n1.Kapan,n1.Party,n1.Category,    
 n1.CategoryId,n1.Records,n1.BranchId,n1.InwardNetWeight,n1.InwardRate,n1.InwardAmount,n1.OutwardNetWeight,    
 n1.OutwardRate,n1.OutwardAmount   
 order by n1.BranchName,n1.Size,n1.Number
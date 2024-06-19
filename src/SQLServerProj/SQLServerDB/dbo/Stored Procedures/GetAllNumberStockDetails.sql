--exec GetAllNumberStockDetails 'b279e4ea-2875-470e-8d1d-aa7c00979e5b','2ac16086-fb8c-4e2c-803b-1748dbe4fd30'
CREATE proc [dbo].[GetAllNumberStockDetails]  
  
@CompanyId as varchar(50),  
@FinancialYearId as varchar(50)  
            
as            
          
select ROW_NUMBER() OVER(PARTITION BY b.Name,y.Size,y.Number ORDER BY b.Name,y.Size,y.Number ASC) AS RowNo,y.*,b.Name as BranchName         
into #tempNumberDetails from(            
--Inwards            
--Opening Stock Details          
select 0 as Id,CAST(o.EntryDate as date) Date, '' as SlipNo,'Opening Stock' as OperationType,sz.Name as Size,nm.Name as Number, k.Name as Kapan,                          
 'Opening Stock' AS Party,'Purchase' as Category, 1 as CategoryId, 1 as Records, o.BranchId,                         
  convert(decimal(18,2),TotalCts)'InwardNetWeight',              
  convert(decimal(18,2),Rate)'InwardRate',              
  convert(decimal(18,2),TotalCts*Rate)'InwardAmount',              
  convert(decimal(18,2),0.0)'OutwardNetWeight',              
  convert(decimal(18,2),0.0)'OutwardRate',              
  convert(decimal(18,2),0.0)'OutwardAmount'            
 from OpeningStockMaster o                           
 left join NumberMaster nm on nm.Id=o.NumberId          
 left join SizeMaster sz on sz.Id=o.SizeId          
 left join KapanMaster k on k.Id=o.KapanId          
 where o.CompanyId=@CompanyId and o.FinancialYearId=@FinancialYearId  
 and Category=0 and isnull(TransferType,'')=''          
          
union all           
--Kapan Numbers Details          
select 1 as Id,CreatedDate as Date,'' SlipNo,partyname as OperationType,Size, Number, Kapan,            
Kapan AS Party,'Purchase' as Category, 1 as CategoryId, 1 as Records, BranchId,             
convert(decimal(18,2),Weight)'InwardNetWeight',              
convert(decimal(18,2),Rate)'InwardRate',              
convert(decimal(18,2),Weight*Rate)'InwardAmount',              
convert(decimal(18,2),0)'OutwardNetWeight',              
convert(decimal(18,2),0)'OutwardRate',              
convert(decimal(18,2),0)'OutwardAmount'            
 from(                            
 select pm1.name as partyname, cast(pm.Date as date) as CreatedDate,n.NumberWeight'Weight',sz1.Name as Size,                            
 nm.Name as Number,isnull(k.Name,'') as Kapan,            
 n.TransferCaratRate as Rate, n.BranchId            
 from NumberProcessMaster n                                  
 left join ShapeMaster s on s.Id=n.ShapeId                                  
 left join NumberMaster nm on nm.Id=n.NumberId                                  
 left join SizeMaster sz1 on sz1.Id=n.CharniSizeId                                  
 left join KapanMaster k on k.Id=n.KapanId  
 left join purchasemaster pm on pm.id = n.purchasemasterid
 left join partymaster pm1 on pm.partyid = pm1.id
 where n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYearId  
 and NumberProcessType in (2, 5) --Assort Receive            
 and pm.isDelete=0
 )x            
           
union all           
--Number Stock Transfer To Details          
select 2 as Id,Date,'' SlipNo,'TF' as OperationType,Size,Number,Kapan,            
Number as Party, 'Stock Transfer' as Category, 1 as CategoryId, 1 as Records,BranchId,             
convert(decimal(18,2),Weight)'InwardNetWeight',              
convert(decimal(18,2),Rate)'InwardRate',              
convert(decimal(18,2),Weight*Rate)'InwardAmount',              
convert(decimal(18,2),0)'OutwardNetWeight',              
convert(decimal(18,2),0)'OutwardRate',              
convert(decimal(18,2),0)'OutwardAmount'            
from(                            
 select t.Date,n.NumberWeight'Weight',s.Name as Size,nm.Name as Number,                            
 k.Name as Kapan,                               
 isnull(n.TransferCaratRate,0) as 'Rate',--(select n1.TransferCaratRate from NumberProcessMaster n1 where n1.TransferId=n.TransferId and n1.TransferEntryId=n.TransferEntryId and TransferType='TransferedTo')'Rate',          
 n.BranchId                            
 from TransferMaster t                            
 left join NumberProcessMaster n on n.TransferId=t.Id    
 --left join NumberProcessMaster n1 on n1.TransferId=n.Id and n1.TransferEntryId=n.TransferEntryId and n1.TransferType='TransferedTo'
 left join SizeMaster s on s.Id=n.CharniSizeId                      
 left join NumberMaster nm on nm.Id=n.NumberId                      
 left join KapanMaster k on k.Id=n.KapanId            
 where t.CompanyId=@CompanyId and t.FinancialYearId=@FinancialYearId  
 and n.TransferType='TransferedTo'                            
 )x               

 union all
 --Rejection receive
 select 3 as Id,Date,'' SlipNo,Party as OperationType,Size,Number,'',            
Number as Party, 'Rejection Receive' as Category, 1 as CategoryId, 1 as Records,BranchId,             
convert(decimal(18,2),NetWeight)'InwardNetWeight',              
convert(decimal(18,2),Rate)'InwardRate',              
convert(decimal(18,2),Amount)'InwardAmount',              
convert(decimal(18,2),0)'OutwardNetWeight',              
convert(decimal(18,2),0)'OutwardRate',              
convert(decimal(18,2),0)'OutwardAmount'            
from(
 SELECT 4 as Id,CAST(R.EntryDate as date) Date, R.SlipNo,'' as OperationType,sz.Name as Size,                    
 PAM.Name + ' (Rej)' AS Party, R.TotalCarat as NetWeight,
 R.Rate as 'Rate', R.Amount as Amount,'Inward' as Category, 1 as CategoryId,1 as Records,
 nm.Name as 'Number',SM.BranchId
 From RejectionInOutMaster R              
 Left JOIN [SalesDetails] AS SD ON SD.Id=R.PurchaseSaleDetailsId 
 Left JOIN [SalesMaster] AS SM ON SM.Id=SD.SalesId     
 Left JOIN [PartyMaster] AS PAM ON PAM.Id = SM.PartyId                     
 left join NumberMaster nm on nm.Id=SD.NumberSizeId
 left join SizeMaster sz on sz.Id=sd.CharniSizeId
 where R.PurchaseSaleDetailsId=SD.Id and R.TransType=1 and R.ProcessType='Sale'
 and sd.RejectedWeight = 0
 and SM.CompanyId=@CompanyId and SM.FinancialYearId=@FinancialYearId  
 )x

 union all           
 --Outwards             
 --Number Stock Transfer From Details          
select 4 as Id,Date,'' SlipNo,'TF' as OperationType,Size,Number,Kapan,          
Number as Party,'Stock Transfer' as Category, 2 as CategoryId, 2 as Records,BranchId,            
convert(decimal(18,2),0)'InwardNetWeight',              
convert(decimal(18,2),0)'InwardRate',              
convert(decimal(18,2),0)'InwardAmount',              
convert(decimal(18,2),isnull(Weight,0))'OutwardNetWeight',              
convert(decimal(18,2),isnull(Rate,0))'OutwardRate',              
convert(decimal(18,2),isnull(Weight,0)*isnull(Rate,0))'OutwardAmount'            
 from(                            
 select t.Date,isnull(n.NumberWeight,0)*-1'Weight',s.Name as Size,nm.Name as Number,                            
 k.Name as Kapan,                            
 isnull(n.TransferCaratRate,0) as 'Rate',--isnull((select n1.TransferCaratRate from NumberProcessMaster n1 where n1.TransferId=n.TransferId and n1.TransferEntryId=n.TransferEntryId and TransferType='TransferedFrom'),0)'Rate',          
 n.BranchId                            
 from TransferMaster t                            
 left join NumberProcessMaster n on n.TransferId=t.Id 
 --left join NumberProcessMaster n1 on n1.TransferId=n.Id and n1.TransferEntryId=n.TransferEntryId and n1.TransferType='TransferedFrom'
 left join SizeMaster s on s.Id=n.CharniSizeId                      
 left join NumberMaster nm on nm.Id=n.NumberId                      
 left join KapanMaster k on k.Id=n.KapanId            
 where t.CompanyId=@CompanyId and t.FinancialYearId=@FinancialYearId  
 and n.TransferType='TransferedFrom'                            
 )x             
                 
union all            
--Number Sale Details          
select 5 as Id,CreatedDate as Date,convert(varchar,SlipNo) as SlipNo, Name  as OperationType,Size,Number,Kapan,            
Party,'Sales' as Category, 2 as CategoryId, 2 as Records,BranchId,            
convert(decimal(18,2),0)'InwardNetWeight',              
convert(decimal(18,2),0)'InwardRate',              
convert(decimal(18,2),0)'InwardAmount',              
convert(decimal(18,2),Weight)'OutwardNetWeight',              
convert(decimal(18,2),Rate)'OutwardRate',              
convert(decimal(18,2),Weight*Rate)'OutwardAmount'            
  from (                            
 select pm.Name, cast(sm.Date as date) as CreatedDate,sm.SlipNo,isnull(sd.Weight,0)'Weight',sz.Name as Size,                            
 nm.Name as Number,isnull(k.Name,'') as Kapan,            
 isnull((s.SaleRate - ((s.SaleRate * s.LessDiscountPercentage)/100)),0) as Rate,pm.Name as Party,          
 sm.BranchId            
from SalesDetailsSummary sd             
left join SalesMaster sm on sm.Id=sd.SalesId            
left join SalesDetails s on s.Id= sd.SalesDetailsId                                               
left join SizeMaster sz on sz.Id=sd.CharniSizeId             
left join NumberMaster nm on nm.Id=sd.NumberSizeId            
left join KapanMaster k on k.Id=sd.KapanId            
left join PartyMaster pm ON pm.Id = sm.PartyId            
 where sd.CompanyId=@CompanyId and sd.FinancialYearId=@FinancialYearId  
 and sd.Category=0                          
 and sm.isDelete=0
 )x          
 )y          
 left join BranchMaster b on b.Id=y.BranchId;        
         
         
 --select n1.RowNo,n1.Id,n1.Date,n1.SlipNo,n1.OperationType,n1.Size,n1.Number,n1.Kapan,n1.Party,n1.Category,        
 --n1.CategoryId,n1.Records,n1.BranchId,n1.InwardNetWeight,n1.InwardRate,n1.InwardAmount,n1.OutwardNetWeight,        
 --n1.OutwardRate,n1.OutwardAmount,n1.BranchName,        
 --sum(n2.InwardNetWeight)-sum(n2.OutwardNetWeight) as ClosingNetWeight,        
 --(sum(n2.InwardRate)/n1.RowNo)-(sum(n2.OutwardRate)/n1.RowNo) as ClosingRate,        
 --sum(n2.InwardAmount)-sum(n2.OutwardAmount) as ClosingAmount        
 --from #tempNumberDetails n1        
 --inner join #tempNumberDetails n2 on n1.RowNo>=n2.RowNo and n1.BranchId=n2.BranchId and n1.Size=n2.Size and n1.Number=n2.Number       
 --group by n1.BranchName,n1.Size,n1.Number,n1.RowNo,n1.Id,      
 --n1.Date,n1.SlipNo,n1.OperationType,n1.Kapan,n1.Party,n1.Category,        
 --n1.CategoryId,n1.Records,n1.BranchId,n1.InwardNetWeight,n1.InwardRate,n1.InwardAmount,n1.OutwardNetWeight,        
 --n1.OutwardRate,n1.OutwardAmount       
 --order by n1.BranchName,n1.Size,n1.Number 

 --select n1.RowNo,n1.Id,n1.Date,n1.SlipNo,n1.OperationType,n1.Size,n1.Number,n1.Kapan,n1.Party,n1.Category,        
 --n1.CategoryId,n1.Records,n1.BranchId,n1.InwardNetWeight,n1.InwardRate,n1.InwardAmount,n1.OutwardNetWeight,        
 --n1.OutwardRate,n1.OutwardAmount,n1.BranchName,        
 --0.00 as ClosingNetWeight,        
 --0.00 as ClosingRate,        
 --0.00 as ClosingAmount        
 --from #tempNumberDetails n1        
 ----inner join #tempNumberDetails n2 on n1.RowNo>=n2.RowNo and n1.BranchId=n2.BranchId and n1.Size=n2.Size and n1.Number=n2.Number       
 --order by n1.BranchName,n1.Size,n1.Number 

 WITH NumberDetailsCTE AS (
    SELECT
        RowNo,
        Id,
        Date,
        SlipNo,
        OperationType,
        Size,
        Number,
        Kapan,
        Party,
        Category,
        CategoryId,
        Records,
        BranchId,
        InwardNetWeight,
        InwardRate,
        InwardAmount,
        OutwardNetWeight,
        OutwardRate,
        OutwardAmount,
        BranchName,
        SUM(InwardNetWeight) OVER (PARTITION BY BranchId, Size, Number ORDER BY RowNo) AS RunningInwardNetWeight,
        SUM(OutwardNetWeight) OVER (PARTITION BY BranchId, Size, Number ORDER BY RowNo) AS RunningOutwardNetWeight,
        SUM(InwardRate) OVER (PARTITION BY BranchId, Size, Number ORDER BY RowNo) AS RunningInwardRate,
        SUM(OutwardRate) OVER (PARTITION BY BranchId, Size, Number ORDER BY RowNo) AS RunningOutwardRate,
        SUM(InwardAmount) OVER (PARTITION BY BranchId, Size, Number ORDER BY RowNo) AS RunningInwardAmount,
        SUM(OutwardAmount) OVER (PARTITION BY BranchId, Size, Number ORDER BY RowNo) AS RunningOutwardAmount
    FROM
        #tempNumberDetails
)
SELECT
    RowNo,
    Id,
    Date,
    SlipNo,
    OperationType,
    Size,
    Number,
    Kapan,
    Party,
    Category,
    CategoryId,
    Records,
    BranchId,
    InwardNetWeight,
    InwardRate,
    InwardAmount,
    OutwardNetWeight,
    OutwardRate,
    OutwardAmount,
    BranchName,
    RunningInwardNetWeight - RunningOutwardNetWeight AS ClosingNetWeight,
    (RunningInwardRate / RowNo) - (RunningOutwardRate / RowNo) AS ClosingRate,
    RunningInwardAmount - RunningOutwardAmount AS ClosingAmount
FROM
    NumberDetailsCTE
ORDER BY
    BranchName,
    Size,
    Number;
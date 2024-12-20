﻿CREATE proc [dbo].[GetAllKapanLagadDetails_bk_20240308]  
  
@CompanyId as varchar(50),  
@FinancialYearId as varchar(50)    
      
as        
    
--drop table #tempKapanDetails        
declare @kapanId as varchar(max)        
set @KapanId=(select STUFF(                
(SELECT ',' + convert(nvarchar(MAX),k.Id)        
FROM KapanMaster k  
order by Sr desc        
for xml path(''),TYPE).value('.', 'varchar(MAX)'),1,1,''))        
--set @kapanId='3d992a40-c8c2-452b-8b45-0352abeb147f,9f1d241c-26e1-4878-9d70-f6b7d3c4162c,d9556fc5-a020-4a8f-ad13-eefe541ea675'        
        
select ROW_NUMBER() OVER(PARTITION BY k.Name ORDER BY k.Name,x.Date,x.Id ASC) AS RowNo,k.Name,        
x.Id,x.Date,x.Party,        
convert(decimal(18,2),x.InwardNetWeight)'InwardNetWeight',        
convert(decimal(18,2),x.InwardRate)'InwardRate',        
convert(decimal(18,2),x.InwardAmount)'InwardAmount',        
convert(decimal(18,2),x.OutwardNetWeight)'OutwardNetWeight',        
convert(decimal(18,2),x.OutwardRate)'OutwardRate',        
convert(decimal(18,2),x.OutwardAmount)'OutwardAmount',x.Category,x.CategoryId,x.Records,x.KapanId,x.BranchId,b.Name as BranchName        
into #tempKapanDetails from(        
select Id,Date,Party, NetWeight as InwardNetWeight,Rate as InwardRate,Amount as InwardAmount, 0 as OutwardNetWeight,      
0 as OutwardRate,0 as OutwardAmount, Category,CategoryId,Records,KapanId,BranchId       
from GetKapanOpeningBalance(@KapanId,@CompanyId,@FinancialYearId)       
union       
select Id,Date,Party,       
NetWeight as InwardNetWeight,Rate as InwardRate,Amount as InwardAmount, 0 as OutwardNetWeight,      
0 as OutwardRate,0 as OutwardAmount, Category,CategoryId,Records,KapanId,BranchId       
from GetKapanPurchaseDetails(@KapanId,@CompanyId,@FinancialYearId)       
union       
select Id,Date,Kapan +(case when Size<> null then (Size) else '' end) as Party, Weight as InwardNetWeight,Rate as InwardRate,Amount as InwardAmount, 0 as OutwardNetWeight,      
0 as OutwardRate,0 as OutwardAmount, Category,CategoryId,Records,KapanId,BranchId       
from GetTransferToDetails(@KapanId,@CompanyId,@FinancialYearId)       
union       
select Id,Date,Party, NetWeight as InwardNetWeight,Rate as InwardRate,Amount as InwardAmount, 0 as OutwardNetWeight,      
0 as OutwardRate,0 as OutwardAmount, Category,CategoryId,Records,KapanId,BranchId       
from GetKapanPurchaseExpenseDetail(@KapanId,@CompanyId,@FinancialYearId)       
union       
select Id,Date,Party, 0 as InwardNetWeight,0 as InwardRate,0 as InwardAmount,       
NetWeight as OutwardNetWeight,Rate as OutwardRate,Amount as OutwardAmount, Category,CategoryId,Records,KapanId,BranchId       
from GetKapanSaleDetail(@KapanId,@CompanyId,@FinancialYearId)       
union       
select Id,Date,Party, 0 as InwardNetWeight,0 as InwardRate,0 as InwardAmount,       
NetWeight as OutwardNetWeight,Rate as OutwardRate,Amount as OutwardAmount, Category,CategoryId,Records,KapanId,BranchId       
from GetAssortmentReceiveDetails(@KapanId,@CompanyId,@FinancialYearId)       
union       
select Id,Date,Party, 0 as InwardNetWeight,0 as InwardRate,0 as InwardAmount,       
NetWeight as OutwardNetWeight,Rate as OutwardRate,Amount as OutwardAmount, Category,CategoryId,Records,KapanId,BranchId        
from GetTransferFromDetails(@KapanId,@CompanyId,@FinancialYearId)
union       
select Id,Date,Party, 0 as InwardNetWeight,0 as InwardRate,0 as InwardAmount,       
NetWeight as OutwardNetWeight,Rate as OutwardRate,Amount as OutwardAmount, Category,CategoryId,Records,KapanId,BranchId       
from GetRejectionOutDetail(@KapanId,@CompanyId,@FinancialYearId)          
)x        
left join KapanMaster k on k.Id=x.KapanId        
left join BranchMaster b on b.Id=x.BranchId      
order by KapanId,Category    
    
select k1.RowNo,k1.Name,k1.Id,k1.Date,k1.Party,k1.InwardNetWeight,k1.InwardRate,k1.InwardAmount,    
k1.OutwardNetWeight,k1.OutwardRate,k1.OutwardAmount,k1.Category,k1.CategoryId,k1.Records,    
k1.KapanId,k1.BranchId,k1.BranchName,    
sum(k2.InwardNetWeight)-sum(k2.OutwardNetWeight) as ClosingNetWeight,        
(sum(k2.InwardRate)/k1.RowNo)-(sum(k2.OutwardRate)/k1.RowNo) as ClosingRate,        
sum(k2.InwardAmount)-sum(k2.OutwardAmount) as ClosingAmount      
from #tempKapanDetails k1    
inner join #tempKapanDetails k2 on k1.RowNo>=k2.RowNo and k1.Name=k2.Name    
group by k1.Name,k1.RowNo,k1.Id,k1.Date,k1.Party,k1.InwardNetWeight,k1.InwardRate,k1.InwardAmount,    
k1.OutwardNetWeight,k1.OutwardRate,k1.OutwardAmount,k1.Category,k1.CategoryId,k1.Records,    
k1.KapanId,k1.BranchId,k1.BranchName    
order by k1.Name
USE [diamondtrading]
GO
/****** Object:  UserDefinedFunction [dbo].[CSVToTable]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CSVToTable] (@InStr VARCHAR(MAX))
RETURNS @TempTab TABLE
   (id varchar(max) not null)
AS
BEGIN
    ;-- Ensure input ends with comma
	SET @InStr = REPLACE(@InStr + ',', ',,', ',')
	DECLARE @SP INT
DECLARE @VALUE VARCHAR(1000)
WHILE PATINDEX('%,%', @INSTR ) <> 0 
BEGIN
   SELECT  @SP = PATINDEX('%,%',@INSTR)
   SELECT  @VALUE = LEFT(@INSTR , @SP - 1)
   SELECT  @INSTR = STUFF(@INSTR, 1, @SP, '')
   INSERT INTO @TempTab(id) VALUES (@VALUE)
END
	RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetTransferFromDetails]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[GetTransferFromDetails]
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
 (case when ISNULL(n.TransferId, '')<>'' then '('+s.Name+') '+nm.Name else (select km1.Name from KapanMappingMaster k1 left join KapanMaster km1 on km1.Id=k1.KapanId where k1.TransferId=k.TransferId and k1.TransferEntryId=k.TransferEntryId and TransferType='TransferedTo') end)'Kapan',      
 (select k1.TransferCaratRate from KapanMappingMaster k1 where k1.TransferId=k.TransferId and k1.TransferEntryId=k.TransferEntryId and TransferType='TransferedFrom')'Rate',    
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
 (case when ISNULL(n.TransferId, '')<>'' then '('+s.Name+') '+nm.Name else (select km1.Name from OpeningStockMaster o1 left join KapanMaster km1 on km1.Id=o1.KapanId where o1.TransferId=o.TransferId and o1.TransferEntryId=o.TransferEntryId and TransferType='TransferedTo') end)'Kapan',               
 (select o1.TransferCaratRate from OpeningStockMaster o1 where o1.TransferId=o.TransferId and o1.TransferEntryId=o.TransferEntryId and TransferType='TransferedFrom')'Rate',    
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
GO
/****** Object:  UserDefinedFunction [dbo].[GetKapanSaleDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[GetKapanSaleDetail]
(
@kapanId varchar(max),
@CompanyId as varchar(50),
@FinancialYearId as varchar(50)
)      
returns Table      
as      
return      
(SELECT 0 as Id,CAST(S.Date as date) Date, S.SlipNo,'' as OperationType,'' as Size,                    
 PAM.Name AS Party, SD.NetWeight as NetWeight,SD.SaleRate 'Rate', S.GrossTotal as Amount,'Outward' as Category, 2 as CategoryId, 1 as Records,    
 K.Id as KapanId, s.BranchId    
 FROM [SalesMaster] S                    
 INNER JOIN [SalesDetails] AS SD ON SD.SalesId=S.Id                    
 INNER JOIN [KapanMaster] AS K ON K.Id=SD.KapanId                    
 INNER JOIN [PartyMaster] AS PAM ON PAM.Id = S.PartyId                     
 where S.CompanyId=@CompanyId and S.FinancialYearId=@FinancialYearId
 and SD.Category=1 and K.Id in (select id from CSVToTable(@kapanId)))
GO
/****** Object:  UserDefinedFunction [dbo].[GetKapanPurchaseExpenseDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[GetKapanPurchaseExpenseDetail]
(
@kapanId varchar(max),
@CompanyId as varchar(50),
@FinancialYearId as varchar(50)
)        
returns Table        
as        
return        
(SELECT 3 as Id,GetDate() as Date,0 as SlipNo,'' as OperationType,'' as Size,          
 'Expense (' + convert(varchar,convert(numeric(18,2),K.CaratLimit)) + '%)' as Party,      
 '0' as NetWeight,'0' as Rate,(SUM(PM.GrossTotal)/((100-K.CaratLimit)/100))-SUM(PM.GrossTotal) 'Amount',      
 'Inward' as Category, 1 as CategoryId, 1 as Records, KM.KapanId, KM.BranchId                      
 FROM KapanMappingMaster KM                      
 INNER JOIN [PurchaseMaster] AS PM ON PM.Id=KM.PurchaseMasterId                      
 --INNER JOIN [PurchaseDetails] AS PD ON PD.Id=KM.PurchaseDetailsId AND PM.Id = PD.PurchaseId                          
 INNER JOIN [KapanMaster] AS K ON K.Id = KM.KapanId                      
 where KM.CompanyId=@CompanyId and KM.FinancialYearId=@FinancialYearId
 and KM.KapanId in (select id from CSVToTable(@kapanId))                     
 group by k.CaratLimit,KM.KapanId,KM.BranchId)
GO
/****** Object:  UserDefinedFunction [dbo].[GetAssortmentReceiveDetails]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[GetAssortmentReceiveDetails]
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
GO
/****** Object:  UserDefinedFunction [dbo].[GetKapanOpeningBalance]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[GetKapanOpeningBalance]     
(
@kapanId varchar(max),
@CompanyId as varchar(50),
@FinancialYearId as varchar(50)
)      
returns Table      
as      
return      
 (select 0 as Id,CAST(CreatedDate as date) Date, '0' as SlipNo,'' as OperationType,'' as Size,                    
 'Opening Stock' AS Party, TotalCts as NetWeight,Rate, TotalCts*Rate as Amount,'Inward' as Category, 1 as CategoryId, 1 as Records,    
 o.KapanId,o.BranchId    
 from OpeningStockMaster o                     
 where o.CompanyId=@CompanyId and o.FinancialYearId=@FinancialYearId
 and Category=1 and isnull(TransferType,'')='' 
 and o.KapanId in (select id from CSVToTable(@kapanId))) 
GO
/****** Object:  UserDefinedFunction [dbo].[GetKapanPurchaseDetails]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[GetKapanPurchaseDetails]  
(  
@kapanId varchar(max),  
@CompanyId as varchar(50),  
@FinancialYearId as varchar(50)  
)        
returns Table        
as        
return        
(SELECT 1 as Id,CAST(PM.Date as date) Date, PM.SlipNo,'' as OperationType,'' as Size,                      
 PAM.Name AS Party, PD.NetWeight as NetWeight,
 (case when PD.LessWeight > 0 then PM.GrossTotal/PD.NetWeight else PD.BuyingRate end) as 'Rate', PM.GrossTotal as Amount,'Inward' as Category, 1 as CategoryId,1 as Records,      
 KM.KapanId, km.BranchId      
 FROM KapanMappingMaster KM                      
 Left JOIN [PurchaseMaster] AS PM ON PM.Id=KM.PurchaseMasterId                      
 Left JOIN [PurchaseDetails] AS PD ON PD.Id=KM.PurchaseDetailsId AND PM.Id = PD.PurchaseId                          
 Left JOIN [PartyMaster] AS PAM ON PAM.Id = PM.PartyId                       
 where KM.CompanyId=@CompanyId and KM.FinancialYearId=@FinancialYearId  
 and KM.KapanId in (select id from CSVToTable(@kapanId)) and isnull(KM.TransferType,'')='')                    
 --group by PM.Date,PM.SlipNo,PAM.Name,PM.GrossTotal,KM.KapanId,km.BranchId) 
 
 --(SELECT 1 as Id,CAST(PM.Date as date) Date, PM.SlipNo,'' as OperationType,'' as Size,                      
 --PAM.Name AS Party, sum(PD.NetWeight) as NetWeight,sum(PD.BuyingRate)/count(PM.SlipNo) 'Rate', PM.GrossTotal as Amount,'Inward' as Category, 1 as CategoryId,count(PM.SlipNo) as Records,      
 --KM.KapanId, km.BranchId      
 --FROM KapanMappingMaster KM                      
 --Left JOIN [PurchaseMaster] AS PM ON PM.Id=KM.PurchaseMasterId                      
 --Left JOIN [PurchaseDetails] AS PD ON PD.Id=KM.PurchaseDetailsId AND PM.Id = PD.PurchaseId                          
 --Left JOIN [PartyMaster] AS PAM ON PAM.Id = PM.PartyId                       
 --where KM.CompanyId=@CompanyId and KM.FinancialYearId=@FinancialYearId  
 --and KM.KapanId in (select id from CSVToTable(@kapanId)) and isnull(KM.TransferType,'')=''                    
 --group by PM.Date,PM.SlipNo,PAM.Name,PM.GrossTotal,KM.KapanId,km.BranchId) 

 
GO
/****** Object:  UserDefinedFunction [dbo].[GetTransferToDetails]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[GetTransferToDetails]
(
@kapanId varchar(max),
@CompanyId as varchar(50),
@FinancialYearId as varchar(50)
)          
returns Table          
as          
return          
(select 2 as Id,Date,'' as SlipNo,'TF' as OperationType,Size,Kapan'Kapan',Weight,Rate,Weight*Rate as Amount,'Inward' as Category, 1 as CategoryId, 1 as Records,KapanId,BranchId from(                      
 select t.Date,k.Weight'Weight',s.Name as Size,                      
(case when n.TransferId<>'' then '('+s.Name+') '+nm.Name else (select km1.Name from KapanMappingMaster k1 left join KapanMaster km1 on km1.Id=k1.KapanId where k1.TransferId=k.TransferId and k1.TransferEntryId=k.TransferEntryId and TransferType='TransferedFrom') end)'Kapan',                      
(select k1.TransferCaratRate from KapanMappingMaster k1 where k1.TransferId=k.TransferId and k1.TransferEntryId=k.TransferEntryId and TransferType='TransferedTo')'Rate',      
k.KapanId, k.BranchId      
 from TransferMaster t                      
 inner join KapanMappingMaster k on k.TransferId=t.Id                   
 left join NumberProcessMaster n on n.TransferId=t.Id and n.TransferEntryId=k.TransferEntryId                     
 left join SizeMaster s on s.Id=n.CharniSizeId                
 left join NumberMaster nm on nm.Id=n.NumberId                
 inner join KapanMaster km on km.Id=k.KapanId                   
 where t.CompanyId=@CompanyId and t.FinancialYearId=@FinancialYearId
 and k.TransferType='TransferedTo' and k.KapanId in (select id from CSVToTable(@kapanId))                     
 --and k.SlipNo<>'0'   --When Transfer from number to kapan that time SlipNo is 0                   
 )x                      
                 
 union                      
 select 2 as Id,Date,'' as SlipNo,'TF' as OperationType,Size,Kapan'Kapan',Weight,Rate,Weight*Rate as Amount,'Inward' as Category, 1 as CategoryId, 1 as Records,KapanId,BranchId from(                      
 select t.Date,o.TotalCts'Weight',s.Name as Size,                      
 (case when n.TransferId<>'' then '('+s.Name+') '+nm.Name else (select km1.Name from OpeningStockMaster o1 left join KapanMaster km1 on km1.Id=o1.KapanId where o1.TransferId=o.TransferId and o1.TransferEntryId=o.TransferEntryId and TransferType='TransferedFrom') end)'Kapan',                      
 (select o1.TransferCaratRate from OpeningStockMaster o1 where o1.TransferId=o.TransferId and o1.TransferEntryId=o.TransferEntryId and TransferType='TransferedTo')'Rate',      
 o.KapanId,o.BranchId      
 from TransferMaster t                      
 inner join OpeningStockMaster o on o.TransferId=t.Id                    
 left join NumberProcessMaster n on n.TransferId=t.Id and n.TransferEntryId=o.TransferEntryId                     
 left join SizeMaster s on s.Id=n.CharniSizeId                
 left join NumberMaster nm on nm.Id=n.NumberId                
 inner join KapanMaster km on km.Id=o.KapanId                    
 where t.CompanyId=@CompanyId and t.FinancialYearId=@FinancialYearId
 and o.TransferType='TransferedTo' and o.KapanId in (select id from CSVToTable(@kapanId))                    
 )x)
GO
/****** Object:  UserDefinedFunction [dbo].[GetKapanLagadDetails]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[GetKapanLagadDetails]
(@kapanId varchar(max))    
returns Table    
as    
return
(
select * from GetKapanOpeningBalance(@kapanId)
union
select * from GetKapanPurchaseDetails(@kapanId)
union
select * from GetTransferToDetails(@kapanId)
union
select * from GetKapanPurchaseExpenseDetail(@kapanId)
union
select * from GetKapanSaleDetail(@kapanId)
union
select * from GetAssortmentReceiveDetails(@kapanId)
union
select * from GetTransferFromDetails(@kapanId)
)
GO
/****** Object:  UserDefinedFunction [dbo].[GetRejectionOutDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[GetRejectionOutDetail]  
(  
@kapanId varchar(max),  
@CompanyId as varchar(50),  
@FinancialYearId as varchar(50)  
)        
returns Table        
as        
return        
(SELECT 0 as Id,CAST(r.EntryDate as date) Date, r.SlipNo,'' as OperationType,'' as Size,                      
 PAM.Name AS Party, r.TotalCarat as NetWeight,r.Rate 'Rate', r.Amount as Amount,'Outward' as Category, 2 as CategoryId, 1 as Records,      
 r.KapanId as KapanId, r.BranchId      
 from RejectionInOutMaster r                    
 left join PurchaseMaster p on p.SlipNo=r.SlipNo     
 left join PurchaseDetails pd on pd.PurchaseId=p.Id 
 Left JOIN [PartyMaster] AS PAM ON PAM.Id = r.PartyId                         
 where pd.RejectedWeight=0 and r.ProcessType='Boil'    
 and r.KapanId in (select id from CSVToTable(@kapanId)))
GO
/****** Object:  StoredProcedure [dbo].[CheckIsKapanMapEntryProcessed]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CheckIsKapanMapEntryProcessed]

@CompanyId as varchar(50),
@FinancialYearId as varchar(50),
@PurchaseDetailsId as varchar(50),
@SlipNo as varchar(50)

as

select am.* from AccountToAssortMaster am      
left join AccountToAssortDetails ad on ad.AccountToAssortMasterId=am.Id 
where am.CompanyId=@CompanyId and am.FinancialYearId=@FinancialYearId 
and ad.PurchaseDetailsId=@PurchaseDetailsId
and ad.SlipNo=@SlipNo
GO
/****** Object:  StoredProcedure [dbo].[GetAllKapanLagadDetails]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec GetAllKapanLagadDetails_bk 'dba610f5-d394-4cf4-bdfe-dc561bf75af4','2ac16086-fb8c-4e2c-803b-1748dbe4fd30'
CREATE proc [dbo].[GetAllKapanLagadDetails]  
  
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
        
select --ROW_NUMBER() OVER(PARTITION BY k.Name ORDER BY k.Name,x.Date,x.Id ASC) AS RowNo,k.Name,        
x.Id,x.Date,x.Party,        
convert(decimal(18,2),x.InwardNetWeight)'InwardNetWeight',        
convert(decimal(18,2),x.InwardRate)'InwardRate',        
convert(decimal(18,2),x.InwardAmount)'InwardAmount',        
convert(decimal(18,2),x.OutwardNetWeight)'OutwardNetWeight',        
convert(decimal(18,2),x.OutwardRate)'OutwardRate',        
convert(decimal(18,2),x.OutwardAmount)'OutwardAmount',x.Category,x.CategoryId,x.Records,x.KapanId,x.BranchId--,b.Name as BranchName        
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

select ROW_NUMBER() OVER(PARTITION BY k.Name ORDER BY k.Name,x.Date,x.Id ASC) AS RowNo,k.Name, 
x.*,
b.Name as BranchName
into #tempKapanDetails1
from(
select Id,Date,Party,InwardNetWeight,InwardRate,InwardAmount,OutwardNetWeight,OutwardRate,OutwardAmount,Category,CategoryId,Records,KapanId,BranchId 
from #tempKapanDetails
union
select 4 as Id,GetDate() as Date,         
'Tip Weight' as Party,sum(y.TIPWeight)+sum(y.LessWeight) 'InwardNetWeight',convert(decimal(18,2),(select Sum(InwardAmount)/Sum(InwardNetWeight) from #tempKapanDetails where CategoryId=1)) 'InwardRate',                     
convert(decimal(18,2),(sum(y.TIPWeight)+sum(y.LessWeight))*(select Sum(InwardAmount)/Sum(InwardNetWeight) from #tempKapanDetails where CategoryId=1))'InwardAmount',
0 as OutwardNetWeight,0 as OutwardRate,0 as OutwardAmount,
'Inward' as Category, 1 as CategoryId, 1 as Records,y.KapanId,y.BranchId                   
from(  
 SELECT distinct pd.id,pd.TIPWeight,pd.LessWeight,km.KapanId,km.BranchId  
 FROM [PurchaseDetails] AS PD                   
 left JOIN [PurchaseMaster] AS PM ON PM.Id=PD.PurchaseId  
 left JOIN KapanMappingMaster KM  ON PD.Id=KM.PurchaseDetailsId  
 where KM.KapanId in (select id from CSVToTable(@kapanId))
 )y  
 group by y.KapanId,y.BranchId 
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
from #tempKapanDetails1 k1    
inner join #tempKapanDetails1 k2 on k1.RowNo>=k2.RowNo and k1.Name=k2.Name    
group by k1.Name,k1.RowNo,k1.Id,k1.Date,k1.Party,k1.InwardNetWeight,k1.InwardRate,k1.InwardAmount,    
k1.OutwardNetWeight,k1.OutwardRate,k1.OutwardAmount,k1.Category,k1.CategoryId,k1.Records,    
k1.KapanId,k1.BranchId,k1.BranchName    
order by k1.Name   
GO
/****** Object:  StoredProcedure [dbo].[GetAllKapanLagadDetails_bk]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec GetAllKapanLagadDetails_bk 'dba610f5-d394-4cf4-bdfe-dc561bf75af4','2ac16086-fb8c-4e2c-803b-1748dbe4fd30'
CREATE proc [dbo].[GetAllKapanLagadDetails_bk]  
  
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
        
select --ROW_NUMBER() OVER(PARTITION BY k.Name ORDER BY k.Name,x.Date,x.Id ASC) AS RowNo,k.Name,        
x.Id,x.Date,x.Party,        
convert(decimal(18,2),x.InwardNetWeight)'InwardNetWeight',        
convert(decimal(18,2),x.InwardRate)'InwardRate',        
convert(decimal(18,2),x.InwardAmount)'InwardAmount',        
convert(decimal(18,2),x.OutwardNetWeight)'OutwardNetWeight',        
convert(decimal(18,2),x.OutwardRate)'OutwardRate',        
convert(decimal(18,2),x.OutwardAmount)'OutwardAmount',x.Category,x.CategoryId,x.Records,x.KapanId,x.BranchId--,b.Name as BranchName        
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

select ROW_NUMBER() OVER(PARTITION BY k.Name ORDER BY k.Name,x.Date,x.Id ASC) AS RowNo,k.Name, 
x.*,
b.Name as BranchName
into #tempKapanDetails1
from(
select Id,Date,Party,InwardNetWeight,InwardRate,InwardAmount,OutwardNetWeight,OutwardRate,OutwardAmount,Category,CategoryId,Records,KapanId,BranchId 
from #tempKapanDetails
union
select 4 as Id,GetDate() as Date,         
'Tip Weight' as Party,sum(y.TIPWeight)+sum(y.LessWeight) 'InwardNetWeight',convert(decimal(18,2),(select Sum(InwardAmount)/Sum(InwardNetWeight) from #tempKapanDetails where CategoryId=1)) 'InwardRate',                     
convert(decimal(18,2),(sum(y.TIPWeight)+sum(y.LessWeight))*(select Sum(InwardAmount)/Sum(InwardNetWeight) from #tempKapanDetails where CategoryId=1))'InwardAmount',
0 as OutwardNetWeight,0 as OutwardRate,0 as OutwardAmount,
'Inward' as Category, 1 as CategoryId, 1 as Records,y.KapanId,y.BranchId                   
from(  
 SELECT distinct pd.id,pd.TIPWeight,pd.LessWeight,km.KapanId,km.BranchId  
 FROM [PurchaseDetails] AS PD                   
 left JOIN [PurchaseMaster] AS PM ON PM.Id=PD.PurchaseId  
 left JOIN KapanMappingMaster KM  ON PD.Id=KM.PurchaseDetailsId  
 where KM.KapanId in (select id from CSVToTable(@kapanId))
 )y  
 group by y.KapanId,y.BranchId 
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
from #tempKapanDetails1 k1    
inner join #tempKapanDetails1 k2 on k1.RowNo>=k2.RowNo and k1.Name=k2.Name    
group by k1.Name,k1.RowNo,k1.Id,k1.Date,k1.Party,k1.InwardNetWeight,k1.InwardRate,k1.InwardAmount,    
k1.OutwardNetWeight,k1.OutwardRate,k1.OutwardAmount,k1.Category,k1.CategoryId,k1.Records,    
k1.KapanId,k1.BranchId,k1.BranchName    
order by k1.Name   
GO
/****** Object:  StoredProcedure [dbo].[GetAllKapanLagadDetails_bk_20240308]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetAllKapanLagadDetails_bk_20240308]  
  
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
GO
/****** Object:  StoredProcedure [dbo].[GetAllKapanLagadDetails_bk_20340308]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[GetAllKapanLagadDetails_bk_20340308]  
  
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
GO
/****** Object:  StoredProcedure [dbo].[GetAllNumberStockDetails]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetAllNumberStockDetails]  
  
@CompanyId as varchar(50),  
@FinancialYearId as varchar(50)  
            
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
 where o.CompanyId=@CompanyId and o.FinancialYearId=@FinancialYearId  
 and Category=0 and isnull(TransferType,'')=''          
          
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
 where n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYearId  
 and NumberProcessType = 2 --Assort Receive            
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
 where t.CompanyId=@CompanyId and t.FinancialYearId=@FinancialYearId  
 and n.TransferType='TransferedTo'                            
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
 where t.CompanyId=@CompanyId and t.FinancialYearId=@FinancialYearId  
 and n.TransferType='TransferedFrom'                            
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
 (s.SaleRate - ((s.SaleRate * s.LessDiscountPercentage)/100)) as Rate,pm.Name as Party,          
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
GO
/****** Object:  StoredProcedure [dbo].[GetAllNumberStockDetails_New]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetAllNumberStockDetails_New]        
        
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
GO
/****** Object:  StoredProcedure [dbo].[GetAssortProcessKapanDetails]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[GetAssortProcessKapanDetails]

@CompanyId as varchar(50),        
@BranchId as varchar(50)   

as

select distinct k.* from AccountToAssortMaster a
left join KapanMaster k on k.Id=a.KapanId
where k.IsStatus=1 and a.CompanyId=@CompanyId and a.BranchId=@BranchId
GO
/****** Object:  StoredProcedure [dbo].[GetAssortProcessSendToDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec GetAssortProcessSendToDetail 'ff8d3c9b-957b-46d1-b661-560ae4a2433e','','146c24c5-6663-4f3d-bdfd-80469275c898'    
--exec GetAssortProcessSendToDetail 'a6bfccfa-3d53-4452-96d3-f9cf31248da8','','b4835b22-940e-48c0-b851-5d836f274b42'        
CREATE proc [dbo].[GetAssortProcessSendToDetail] --'a6bfccfa-3d53-4452-96d3-f9cf31248da8','','b4835b22-940e-48c0-b851-5d836f274b42'                       
                        
@CompanyId as varchar(50),                                
@BranchId as varchar(50),                            
@FinancialYear as varchar(50)                            
                        
as                        
select *,(Weight+RejectedWeight)-UsedWeight'AvailableWeight'                    
from(                        
select * from(                        
select '0' as StockId,km.KapanId,k.Name'Kapan',convert(varchar,pm.SlipNo)'SlipNo',pd.ShapeId,s.Name'Shape',pd.Id'PurchaseDetailsId',pd.PurchaseId'PurchaseMasterId',                        
pd.SizeId,sm.Name'Size',pd.PurityId,p.Name'Purity',pm.FinancialYearId,                        
sum(km.Weight)'NetWeight',sum(pd.TIPWeight)'TIPWeight',sum(pd.LessWeight)'LessWeight',                          
(sum(km.Weight)+sum(pd.TIPWeight)+sum(pd.LessWeight))'Weight',sum(pd.RejectedWeight)'RejectedWeight',                        
isnull((select sum(y.Weight) from(          
select sum(Weight)'Weight'                          
from salesdetailssummary sds                        
where sds.Category=1                        
and sds.PurchaseDetailsId=pd.Id          
and sds.SlipNo=convert(varchar,pm.SlipNo) and sds.ShapeId=pd.ShapeId and sds.SizeId=pd.SizeId and sds.PurityId=pd.PurityId                        
and sds.FinancialYearId=pm.FinancialYearId                        
union all          
select sum(AssignWeight)'Weight'        
from AccountToAssortDetails a                        
left join AccountToAssortMaster am on am.Id=a.AccountToAssortMasterId                        
where                             
AccountToAssortType=0                                       
and a.SlipNo=convert(varchar,pm.SlipNo) and a.PurchaseDetailsId=pd.Id and a.ShapeId=pd.ShapeId and a.SizeId=pd.SizeId and a.PurityId=pd.PurityId                        
and am.FinancialYearId=pm.FinancialYearId                        
)y          
),0)'UsedWeight',                    
convert(varchar,pm.SlipNo)+km.KapanId+pd.ID+pd.ShapeId+pd.SizeId+pd.PurityId+pm.FinancialYearId'Id',        
'KapanMapped' as 'KapanType'                        
from KapanMappingMaster km                        
left join PurchaseDetails pd on pd.Id=km.PurchaseDetailsId                        
left join PurchaseMaster pm on pm.Id=pd.PurchaseId                        
left join KapanMaster k on k.Id=km.KapanId                        
left join ShapeMaster s on s.Id=pd.ShapeId                        
left join SizeMaster sm on sm.Id=pd.SizeId                        
left join PurityMaster p on p.Id=pd.PurityId                      
where pm.CompanyId=@CompanyId and pm.FinancialYearId=@FinancialYear  --Removed the branchid condition as per riddesh                      
group by km.KapanId,pm.SlipNo,k.Name,pd.ShapeId,s.Name,pd.SizeId,sm.Name,pd.PurityId,p.Name,pm.FinancialYearId,pd.Id,pd.PurchaseId                        
)x                        
                    
union                    
                    
select o.Id as StockId,KapanId,k.Name'Kapan','0' as 'SlipNo', ShapeId,sh.Name as 'Shape',                    
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,s.Name'Size',PurityId,p.Name as 'Purity',                    
FinancialYearId,sum(TotalCts) as 'NetWeight','0' as 'TipWeight','0' as 'LessWeight',                    
sum(TotalCts) as 'Weight','0' as 'RejectedWeight',                    
--'0' as 'AvailableWeight',                    
isnull ((select sum(y.Weight) from(          
select sum(Weight)'Weight'                          
from salesdetailssummary sds                        
where sds.Category=1                        
and sds.StockId=o.Id    
and sds.SlipNo='0' and sds.ShapeId=o.ShapeId and sds.SizeId=o.SizeId and sds.PurityId=o.PurityId                        
and sds.FinancialYearId=o.FinancialYearId                        
union all         
select sum(AssignWeight)'Weight'                          
from AccountToAssortDetails a                        
left join AccountToAssortMaster am on am.Id=a.AccountToAssortMasterId                        
where AccountToAssortType=0                                       
and a.StockId=o.Id and a.SlipNo='0' and a.ShapeId=o.ShapeId and a.SizeId=o.SizeId and a.PurityId=o.PurityId                        
and am.FinancialYearId=o.FinancialYearId                        
)y)          
,0)'UsedWeight',                    
o.Id+KapanId+ShapeId+SizeId+PurityId+FinancialYearId'Id',        
'OpeningStock' as 'KapanType'                                    
from OpeningStockMaster o                    
left join KapanMaster k on k.Id=o.KapanId                    
left join SizeMaster s on s.Id=o.SizeId            
left join ShapeMaster sh on sh.Id=o.ShapeId                        
left join PurityMaster p on p.Id=o.PurityId                   
where Category=1                    
and o.CompanyId=@CompanyId and FinancialYearId=@FinancialYear                    
group by o.Id,KapanId,k.Name,ShapeId,sh.Name, p.Name, SizeId,s.Name,PurityId,FinancialYearId                    
                
union                
select '0' as StockId,KapanId,k.Name'Kapan',convert(varchar,SlipNo)'SlipNo',ShapeId,s.Name as 'Shape',PurchsaeDetailId,PurchaseMasterId,                
SizeId,sz.Name as 'Size',PurityId,p.Name as 'Purity',FinancialYearId,sum(NetWeight)'NetWeight',sum(TipWeight)'TipWeight',sum(LessWeight)'LessWeight',                
sum(Weight)'Weight',sum(RejectedWeight)'RejectedWeight',sum(UsedWeight)'UsedWeight',                
KapanId+ShapeId+SizeId+PurityId+FinancialYearId'Id',KapanType                    
from(                
--Boil                
select KapanId,convert(varchar,SlipNo)'SlipNo',ShapeId,                
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,                    
FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',                    
sum(Weight) as 'Weight',0 as 'RejectedWeight',                    
isnull((select sum(Weight)'Weight'                          
from salesdetailssummary sds                        
where sds.Category=1 and sds.KapanType='Boil'                        
and sds.SlipNo=convert(varchar,b.SlipNo) and sds.ShapeId=b.ShapeId and sds.SizeId=b.SizeId and sds.PurityId=b.PurityId                        
and sds.FinancialYearId=b.FinancialYearId),0) as 'UsedWeight',                    
KapanId+ShapeId+SizeId+PurityId+FinancialYearId'Id',        
'Boil' as 'KapanType'                                    
from BoilProcessMaster b                    
where BoilType in (2,3,4)    
and b.CompanyId=@CompanyId and FinancialYearId=@FinancialYear                    
group by KapanId,SlipNo,ShapeId,SizeId,PurityId,FinancialYearId                
                
union                 
--Charni                
select KapanId,convert(varchar,SlipNo)'SlipNo',ShapeId,                
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,                    
FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',                    
sum(Weight) as 'Weight',0 as 'RejectedWeight',                    
isnull((select sum(Weight)'Weight'                          
from salesdetailssummary sds                        
where sds.Category=1 and sds.KapanType='Charni'                        
and sds.SlipNo=convert(varchar,c.SlipNo) and sds.ShapeId=c.ShapeId and sds.SizeId=c.SizeId and sds.PurityId=c.PurityId        
and sds.CharniSizeId=c.CharniSizeId                        
and sds.FinancialYearId=c.FinancialYearId),0) as 'UsedWeight',                    
KapanId+ShapeId+SizeId+PurityId+FinancialYearId+CharniSizeId'Id',        
'Charni' as 'KapanType'                                    
from CharniProcessMaster c                    
where CharniType in (2,3,4)    
and c.CompanyId=@CompanyId and FinancialYearId=@FinancialYear                    
group by KapanId,SlipNo,ShapeId,SizeId,PurityId,FinancialYearId,CharniSizeId                
                
union                
--Gala                
select KapanId,convert(varchar,SlipNo)'SlipNo',ShapeId,                
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,                    
FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',                    
sum(Weight) as 'Weight',0 as 'RejectedWeight',                    
isnull((select sum(Weight)'Weight'                          
from salesdetailssummary sds                        
where sds.Category=1 and sds.KapanType='Gala'                        
and sds.SlipNo=convert(varchar,g.SlipNo) and sds.ShapeId=g.ShapeId and sds.SizeId=g.SizeId and sds.PurityId=g.PurityId        
and sds.GalaSizeId=g.GalaNumberId        
and sds.FinancialYearId=g.FinancialYearId),0) as 'UsedWeight',                    
KapanId+ShapeId+SizeId+PurityId+FinancialYearId+GalaNumberId'Id',        
'Gala' as 'KapanType'                                    
from GalaProcessMaster g                
where GalaProcessType in (2,3,4)    
and g.CompanyId=@CompanyId and FinancialYearId=@FinancialYear                    
group by KapanId,SlipNo,ShapeId,SizeId,PurityId,FinancialYearId,GalaNumberId                
                
)x                
left join KapanMaster k on k.Id=x.KapanId                    
left join ShapeMaster s on s.Id=x.ShapeId                
left join SizeMaster sz on sz.Id=x.SizeId                    
left join PurityMaster p on p.Id=x.PurityId                
group by KapanId,k.Name,SlipNo,ShapeId,s.Name,SizeId,sz.Name,PurityId,p.Name,PurchsaeDetailId,PurchaseMasterId,FinancialYearId,KapanType                
                
)y                    
--where ((Weight+RejectedWeight)-UsedWeight)>0  
GO
/****** Object:  StoredProcedure [dbo].[GetAssortReceiveReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAssortReceiveReport] 
	@CompanyId as varchar(50),
	@BranchId as varchar(50),
	@FinancialYearId as varchar(50)
AS
BEGIN

	SELECT * FROM (
		SELECT 'Boil' 'Dept', BPM.CompanyId, BPM.BranchId, BPM.FinancialYearId,  BPM.Id, BPM.Sr, BPM.JangadNo, BPM.SlipNo, BPM.EntryDate, BPM.KapanId, KM.Name 'KapanName', BPM.ShapeId, SM.Name 'ShapeName', 
		BPM.SizeId, SM1.Name 'SizeName', '' NumberId, '' NumberName, BPM.PurityId, PM2.Name 'PurityName', BPM.Weight, BPM.HandOverById, PM.Name 'HandOverByName', BPM.HandOverToId, PM1.Name 'HandOverToName', BPM.Remarks, BPM.CreatedBy, BPM.CreatedDate, BPM.UpdatedBy, BPM.UpdatedDate 
		FROM [BoilProcessMaster] BPM
		INNER JOIN PartyMaster PM on BPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on BPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on BPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on BPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on BPM.SizeId = SM1.Id
		INNER JOIN PurityMaster PM2 ON BPM.PurityId = PM2.Id
		
		Where BoilType=2
	UNION
		SELECT 'Charni' 'Dept', CPM.CompanyId, CPM.BranchId, CPM.FinancialYearId, CPM.Id, CPM.Sr, CPM.JangadNo, CPM.SlipNo, CPM.EntryDate, CPM.KapanId, KM.Name 'KapanName',  CPM.ShapeId, SM.Name 'ShapeName', 
		CPM.CharniSizeId 'SizeId', SM1.Name 'SizeName', '' NumberId, '' NumberName, CPM.PurityId, PM2.Name 'PurityName', CPM.CharniWeight 'Weight', CPM.HandOverById, PM.Name 'HandOverByName',  CPM.HandOverToId, PM1.Name 'HandOverToName',  CPM.Remarks, CPM.CreatedBy, CPM.CreatedDate, CPM.UpdatedBy, CPM.UpdatedDate 
		FROM [CharniProcessMaster] CPM
		INNER JOIN PartyMaster PM on CPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on CPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on CPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on CPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on CPM.SizeId = SM1.Id
		INNER JOIN PurityMaster PM2 ON CPM.PurityId = PM2.Id

		Where charniType =2
	UNION
		SELECT 'Gala' 'Dept', GPM.CompanyId, GPM.BranchId, GPM.FinancialYearId, GPM.Id, GPM.Sr, GPM.JangadNo, GPM.SlipNo, CONVERT(datetime,GPM.EntryDate), GPM.KapanId, KM.Name 'KapanName', GPM.ShapeId, SM.Name 'ShapeName', 
		GPM.CharniSizeId 'SizeId', SM1.Name 'SizeName', '' NumberId, '' NumberName, GPM.PurityId, PM2.Name 'PurityName', GPM.GalaWeight 'Weight', GPM.HandOverById, PM.Name 'HandOverByName', GPM.HandOverToId, PM1.Name 'HandOverToName', GPM.Remarks, GPM.CreatedBy, GPM.CreatedDate, GPM.UpdatedBy, GPM.UpdatedDate 
		FROM [GalaProcessMaster] GPM
		INNER JOIN PartyMaster PM on GPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on GPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on GPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on GPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on GPM.CharniSizeId = SM1.Id
		INNER JOIN PurityMaster PM2 ON GPM.PurityId = PM2.Id
		
		Where GalaProcessType=2
	UNION
		SELECT 'Number' 'Dept', NPM.CompanyId, NPM.BranchId, NPM.FinancialYearId, NPM.Id, NPM.Sr, NPM.JangadNo, NPM.SlipNo, CONVERT(datetime,NPM.EntryDate), NPM.KapanId, KM.Name 'KapanName', NPM.ShapeId, SM.Name 'ShapeName', 
		NPM.CharniSizeId 'SizeId', SM1.Name 'SizeName', NPM.NumberId, NM.Name 'NumberName',  NPM.PurityId, PM2.Name 'PurityName', NPM.NumberWeight 'Weight', NPM.HandOverById, PM.Name 'HandOverByName', NPM.HandOverToId, PM1.Name 'HandOverToName', NPM.Remarks, NPM.CreatedBy, NPM.CreatedDate, NPM.UpdatedBy, NPM.UpdatedDate 
		FROM NumberProcessMaster NPM
		INNER JOIN PartyMaster PM on NPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on NPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on NPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on NPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on NPM.CharniSizeId = SM1.Id
		INNER JOIN NumberMaster NM ON NPM.NumberId = NM.Id
		INNER JOIN PurityMaster PM2 ON NPM.PurityId = PM2.Id
		
		Where NumberProcessType=2) as MainTable
	
	WHERE MainTable.CompanyId=@CompanyId AND MainTable.FinancialYearId = @FinancialYearId -- AND MainTable.BranchId = @BranchId

END
GO
/****** Object:  StoredProcedure [dbo].[GetAssortSendReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAssortSendReport] 
	@CompanyId as varchar(50),
	@BranchId as varchar(50),
	@FinancialYearId as varchar(50),
	@AccountToAssortType int
AS
BEGIN
	Select 
		CASE 
			WHEN AAM.Department = 1 THEN 'Boil'
			WHEN AAM.Department = 2 THEN 'Charni'
			WHEN AAM.Department = 3 THEN 'Gala'
			WHEN AAM.Department = 4 THEN 'Number'
		END 'Department', AAM.Id, AAD.Id 'ChildId', AAM.Sr, AAM.CompanyId, AAM.BranchId, AAM.FinancialYearId, CONVERT(datetime,AAM.EntryDate) 'EntryDate', AAM.FromParyId 'FromPartyId', PM.Name 'FromPartyName', AAM.ToPartyId, PM1.Name 'ToPartyName', AAM.KapanId, KM.Name 'KapanName', AAM.AccountToAssortType, AAM.Remarks, AAM.CreatedBy, AAM.CreatedDate, AAM.UpdatedBy, AAM.UpdatedDate,
	AAD.SlipNo, AAD.SizeId, SM.Name 'SizeName', AAD.Weight, AAD.AssignWeight
	from AccountToAssortMaster AAM 
	INNER JOIN AccountToAssortDetails AAD ON AAM.Id = AAD.AccountToAssortMasterId
	INNER JOIN PartyMaster PM ON AAM.FromParyId = PM.Id
	INNER JOIN PartyMaster PM1 ON AAM.ToPartyId = PM1.Id
	INNER JOIN KapanMaster KM ON AAM.KapanId = KM.Id
	LEFT JOIN SizeMaster SM ON AAD.SizeId = SM.Id
	WHERE AAM.CompanyId = @CompanyId AND AAM.FinancialYearId = @FinancialYearId AND AAM.AccountToAssortType = @AccountToAssortType --AND AAM.BranchId = @BranchId
END
GO
/****** Object:  StoredProcedure [dbo].[GetAvailableSlipDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[GetAvailableSlipDetail]

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
	where pm.CompanyId=@Company and pm.SlipNo=@SlipNo and pm.FinancialYearId=@FinancialYear  
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
	where sm.CompanyId=@Company and sm.SlipNo=@SlipNo and sm.FinancialYearId=@FinancialYear  
	)x 
End
GO
/****** Object:  StoredProcedure [dbo].[GetAvailableSlipsDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetAvailableSlipsDetail]  
  
@ActionType as int,
@Company as varchar(50),  
@FinancialYear as varchar(50)  
  
as    

if(@ActionType=1)--Purchase
Begin
	select SlipNo as Id,pm.SlipNo,  
	CONVERT(varchar,CONVERT(datetime, pm.Date),103)'Date',pm.PartyId,  
	party.Name'Party',  
	pm.BrokerageId,  
	party1.Name'Broker',  
	pm.FinancialYearId         
	from PurchaseMaster pm  
	left join PartyMaster party on party.Id=pm.PartyId  
	left join PartyMaster party1 on party1.Id=pm.BrokerageId  
	where pm.AllowSlipPrint=1   
	and pm.CompanyId=@Company and pm.FinancialYearId=@FinancialYear  
	order by pm.SlipNo
End
Else
Begin
	select SlipNo as Id,sm.SlipNo,  
	CONVERT(varchar,CONVERT(datetime, sm.Date),103)'Date',sm.PartyId,  
	party.Name'Party',  
	sm.BrokerageId,  
	party1.Name'Broker',  
	sm.FinancialYearId         
	from SalesMaster sm  
	left join PartyMaster party on party.Id=sm.PartyId  
	left join PartyMaster party1 on party1.Id=sm.BrokerageId  
	where sm.AllowSlipPrint=1   
	and sm.CompanyId=@Company and sm.FinancialYearId=@FinancialYear  
	order by sm.SlipNo
End
GO
/****** Object:  StoredProcedure [dbo].[GetBalanceSheet]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBalanceSheet] 
	@CompanyId as varchar(50),
	@FinancialYearId as varchar(50),
	@BalanceSheetType as int = 2
AS
BEGIN

IF @BalanceSheetType = 2
BEGIN
	Declare @tempTable TABLE(PartyType int, Type varchar(100), SubType varchar(100), Id varchar(100), Name varchar(100),CompanyId varchar(100), FinancialYearId varchar(100), LedgerId varchar(100), OpeningBalance decimal(18,2), PurchaseAmount decimal(18,2), Brokerage decimal(18,2), SalesAmount decimal(18,2), PaymentFrom decimal(18,2), PaymentTo decimal(18,2), ReceiptFrom decimal(18,2), ReceiptTo decimal(18,2), ClosingBalance decimal(18,2))
	INSERT @tempTable EXEC [GetLedgerBalanceReport] @CompanyId, @FinancialYearId

	--FIRST SECTION
	select 'Debit' 'ColType', 'Capital Account' 'Type',  CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
		Inner join LedgerBalanceManager LBM ON PM.Id = LBM.LedgerId
		where PM.type=11 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL
 	
	-- INCLUDE THE OPENING BALANCE WITH LOAN ENTRY
		--SELECT 'Debit' 'ColType', 'Loan' 'Type',  CAST(ISNULL(
				--(select ISNULL(sum(amount),0) Amont from loanmaster where loantype=1 AND CompanyId = @CompanyId) - 
				--(select ISNULL(sum(amount),0) Amont from loanmaster where loantype=2 AND CompanyId = @CompanyId),0) as decimal(18,4)) Amount 
	
		SELECT T.ColType, T.Type, ISNULL(SUM(T.Amount),0) 'Amount' FROM (
				select 'Debit' 'ColType', 'Loan' 'Type', LBM.Balance 'Amount' from LedgerBalanceManager LBM INNER JOIN PartyMaster PM ON PM.Id = LBM.LedgerId
				where PM.Type = 13 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

				UNION ALL

				SELECT 'Debit' 'ColType', 'Loan' 'Type',  CAST(ISNULL(
					(select ISNULL(sum(amount),0) Amont from loanmaster where loantype=1 AND CompanyId = @CompanyId) - 
					(select ISNULL(sum(amount),0) Amont from loanmaster where loantype=2 AND CompanyId = @CompanyId),0) as decimal(18,4)) Amount 
					)T

				Group by T.ColType, T.Type
	UNION ALL

	SELECT 'Debit' 'ColType', 'Purchase' 'Type',SUM(Amount) 'Amount' FROM
	(
		select CAST(ISNULL(SUM(GrossTotal),0) as decimal(18,4)) 'Amount' from PurchaseMaster PM
		WHERE  IsDelete = 0 AND PM.CompanyId = @CompanyId AND PM.FinancialYearId = @FinancialYearId
	
		UNION

		select SUM(Balance) 'Amount' from PartyMaster PM
		INNER JOIN LedgerBalanceManager LBM ON PM.Id = LBM.LedgerId 
		where PM.Type=1 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId
	)Temp

	UNION ALL

	--SECOND SECTION

	select 'Credit' 'ColType', 'Investment' 'Type', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
	WHERE Type=12 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

	select 'Credit' 'ColType', 'Deposit' 'Type', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
	WHERE Type=9 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

	SELECT 'Credit' 'ColType', 'Uchina + Employee' 'Type', SUM(T.UchinaAmount) - SUM(T.EmpAmount) 'Amount'  from (
	select  0 'EmpAmount', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'UchinaAmount' from PartyMaster PM
		INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
		WHERE Type=10  AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

	select CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'EmpAmount', 0 'UchinaAmount' from PartyMaster PM
		INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
		WHERE  Type=2 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId
	)T

	UNION ALL

	select  'Credit' 'ColType', 'Cash In Hand' 'Type', SUM(ClosingBalance) from @tempTable WHere PartyType=4 OR PartyType=5

	UNION ALL

	select 'Credit' 'ColType', 'Asset' 'Type', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
	WHERE Type=8 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL
	
	SELECT 'Credit' 'ColType', 'Sales' 'Type', SUM(Amount) 'Amount' FROM
	(
		select CAST(ISNULL(SUM(GrossTotal),0) as decimal(18,4)) 'Amount' from SalesMaster SM
		WHERE SM.CompanyId = @CompanyId AND SM.FinancialYearId = @FinancialYearId
	
		UNION

		SELECT SUM(Balance) 'Amount' from PartyMaster PM
		INNER JOIN LedgerBalanceManager LBM ON PM.Id = LBM.LedgerId 
		where PM.Type=14 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	)Temp

	UNION ALL
	
	SELECT 'Credit' 'ColType', 'Opening Stock' 'Type', CAST(ISNULL(SUM(Amount),0) as decimal(18,4)) 'Amount' FROM OpeningStockMaster OSM
		WHERE OSM.CompanyId = @CompanyId AND OSM.FinancialYearId = @FinancialYearId
END
ELSE
BEGIN
	select 'Debit' 'ColType', 'Capital Account' 'Type',  CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
		Inner join LedgerBalanceManager LBM ON PM.Id = LBM.LedgerId
		where PM.type=11 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

		select 'Debit' 'ColType', 'Loan' 'Type', ISNULL(SUM(LBM.Balance),0) 'Amount' from LedgerBalanceManager LBM INNER JOIN PartyMaster PM ON PM.Id = LBM.LedgerId
		where LBM.Balance > 0 AND PM.Type = 13 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId
		--GROUP BY 'ColType', 'Type'

	UNION ALL

	SELECT 'Debit' 'ColType', 'Purchase' 'Type',SUM(Balance) 'Amount' from PartyMaster PM
		INNER JOIN LedgerBalanceManager LBM ON PM.Id = LBM.LedgerId 
		where PM.Type=1 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

	--SECOND SECTION

	select 'Credit' 'ColType', 'Investment' 'Type', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
	WHERE Type=12 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

	select 'Credit' 'ColType', 'Deposit' 'Type', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
	WHERE Type=9 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

	
	SELECT 'Credit' 'ColType', 'Uchina + Employee' 'Type', SUM(T.UchinaAmount) - SUM(T.EmpAmount) 'Amount'  from (
	select  0 'EmpAmount', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'UchinaAmount' from PartyMaster PM
		INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
		WHERE Type=10  AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

	select CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'EmpAmount', 0 'UchinaAmount' from PartyMaster PM
		INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
		WHERE  Type=2 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId
	)T

	UNION ALL

	select 'Credit' 'ColType', 'Cash In Hand' 'Type', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
	WHERE Type = 5 OR Type = 4 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

	select 'Credit' 'ColType', 'Asset' 'Type', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
	WHERE Type=8 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL
	
	SELECT 'Credit' 'ColType', 'Sales' 'Type', CAST(ISNULL(SUM(Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
		INNER JOIN LedgerBalanceManager LBM ON PM.Id = LBM.LedgerId 
		where PM.Type=14 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL
	
	SELECT 'Credit' 'ColType', 'Opening Stock' 'Type', CAST(ISNULL(SUM(Amount),0) as decimal(18,4)) 'Amount' FROM OpeningStockMaster OSM
		WHERE OSM.CompanyId = @CompanyId AND OSM.FinancialYearId = @FinancialYearId

END
END
GO
/****** Object:  StoredProcedure [dbo].[GetBoilProcessReceiveDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetBoilProcessReceiveDetail]  
  
@ReceivedFrom as varchar(50),  
@CompanyId as varchar(50),          
@BranchId as varchar(50),      
@FinancialYear as varchar(50)    
  
as  
  
select *,  
convert(varchar,BoilNo)+KapanId+ShapeId+SizeId+PurityId'Id' from(        
select BoilNo,KapanId,Kapan,ShapeID,isnull(Shape,'N/A')'Shape',SizeID,Size,PurityId,isnull(Purity,'N/A')'Purity',sum(Weight)-x.ReceivedWeight'AvailableWeight',         
STUFF(        
(SELECT ',' + convert(varchar,b1.SlipNo)        
FROM BoilProcessMaster b1        
WHERE BoilType=0 and b1.BoilNo = x.BoilNo and b1.KapanId=x.KapanId and b1.ShapeId=x.ShapeID and b1.SizeID=x.SizeID and b1.PurityId=x.PurityId  
FOR XML PATH('')),1,1,'')'SlipNo',sum(x.Weight)'TotalWeight'        
from           
(select BoilNo,SlipNo,EntryDate,b.KapanId,k.Name'Kapan',b.ShapeId,s.Name'Shape',b.SizeId,sz.Name'Size',b.PurityId,p.Name'Purity',          
Weight,isnull((select sum(Weight)+sum(LossWeight)+sum(RejectionWeight) from BoilProcessMaster b1          
where b1.BoilType=1 and b1.BoilNo=b.BoilNo and          
b1.KapanId=b.KapanId and b1.ShapeId=b.ShapeId and b1.SizeId=b.SizeId and b1.PurityId=b.PurityId and b1.FinancialYearId=b.FinancialYearId  
),0)'ReceivedWeight',                
b.KapanId+b.ShapeId+b.SizeId+b.PurityId+CONVERT(nvarchar(10),b.BoilNo) as 'ID'                 
from BoilProcessMaster b                
left join KapanMaster k on k.Id=b.KapanId  
left join ShapeMaster s on s.Id=b.ShapeId  
left join SizeMaster sz on sz.Id=b.SizeId  
left join PurityMaster p on p.Id=b.PurityId  
where BoilType=0 --Send  
and b.HandOverToId=@ReceivedFrom and b.CompanyId=@CompanyId and b.FinancialYearId=@FinancialYear  
)x        
  
  
group by BoilNo,KapanId,Kapan,ShapeID,Shape,SizeID,Size,PurityId,Purity,x.ReceivedWeight          
)y        
where AvailableWeight <> 0 
GO
/****** Object:  StoredProcedure [dbo].[GetBoilProcessSendToDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetBoilProcessSendToDetail]        
        
@CompanyId as varchar(50),                
@BranchId as varchar(50),            
@FinancialYear as varchar(50)            
        
as        
        
select * from(        
select ad.Id as AccountToAssortDetailsId,'0' as StockId,pm.SlipNo,ad.PurchaseDetailsId,am.KapanId,k.Name'Kapan',pd.ShapeId,s.Name'Shape',        
pd.SizeId,sm.Name'Size',pd.PurityId,p.Name'Purity',pm.FinancialYearId,        
sum(ad.AssignWeight)'NetWeight',sum(pd.TIPWeight)'TIPWeight',sum(pd.LessWeight)'LessWeight',          
(sum(ad.AssignWeight)+sum(pd.TIPWeight)+sum(pd.LessWeight))'Weight',sum(pd.RejectedWeight)'RejectedWeight',        
sum(ad.AssignWeight)-isnull((select sum(b.Weight)          
from BoilProcessMaster b        
where             
BoilType=0                       
and b.SlipNo=pm.SlipNo and b.PurchaseDetailsId=ad.PurchaseDetailsId and b.KapanId=am.KapanId and b.ShapeId=pd.ShapeId and b.SizeId=pd.SizeId and b.PurityId=pd.PurityId        
and b.FinancialYearId=pm.FinancialYearId and b.AccountToAssortDetailsId=ad.Id        
),0)'AvailableWeight',        
convert(varchar,pm.SlipNo)+am.KapanId+pd.ShapeId+pd.SizeId+pd.PurityId+pm.FinancialYearId+ad.PurchaseDetailsId'Id'        
from AccountToAssortMaster am        
left join AccountToAssortDetails ad on ad.AccountToAssortMasterId=am.Id        
left join PurchaseDetails pd on pd.Id=ad.PurchaseDetailsId        
left join PurchaseMaster pm on pm.Id=pd.PurchaseId        
left join KapanMaster k on k.Id=am.KapanId        
left join ShapeMaster s on s.Id=pd.ShapeId        
left join SizeMaster sm on sm.Id=pd.SizeId        
left join PurityMaster p on p.Id=pd.PurityId        
where pm.SlipNo<>0    
and pm.CompanyId=@CompanyId and pm.FinancialYearId=@FinancialYear        
group by ad.Id,pm.SlipNo,am.KapanId,k.Name,pd.ShapeId,s.Name,pd.SizeId,sm.Name,pd.PurityId,p.Name,pm.FinancialYearId,ad.PurchaseDetailsId        
    
union    
select ad.Id as AccountToAssortDetailsId,o.Id as StockId,0 as SlipNo,'0' as PurchaseDetailsId,am.KapanId,k.Name'Kapan',o.ShapeId,'N/A' as Shape,        
o.SizeId,sm.Name'Size',o.PurityId,'N/A' as Purity,o.FinancialYearId,        
sum(ad.AssignWeight)'NetWeight',0 as TIPWeight,0 as LessWeight,          
sum(ad.AssignWeight)'Weight',0 as RejectedWeight,        
sum(ad.AssignWeight)-isnull((select sum(b.Weight)          
from BoilProcessMaster b        
where             
BoilType=0                       
and b.StockId=o.Id and b.KapanId=am.KapanId and b.ShapeId=o.ShapeId and b.SizeId=o.SizeId and b.PurityId=o.PurityId        
and b.FinancialYearId=o.FinancialYearId and b.AccountToAssortDetailsId=ad.Id        
),0)'AvailableWeight',        
o.Id+am.KapanId+o.ShapeId+o.SizeId+o.PurityId+o.FinancialYearId'Id'        
from AccountToAssortMaster am    
left join AccountToAssortDetails ad on ad.AccountToAssortMasterId=am.Id        
inner join OpeningStockMaster o on o.Id=ad.StockId       
left join KapanMaster k on k.Id=am.KapanId        
left join SizeMaster sm on sm.Id=o.SizeId        
where ad.SlipNo=0    
and am.CompanyId=@CompanyId and am.FinancialYearId=@FinancialYear        
group by ad.Id,o.Id,am.KapanId,k.Name,o.ShapeId,o.SizeId,sm.Name,o.PurityId,o.FinancialYearId    
    
    
)x        
where x.AvailableWeight<>0 
GO
/****** Object:  StoredProcedure [dbo].[GetBoilSendReceiveReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBoilSendReceiveReport] 
	@CompanyId as varchar(50),
	@BranchId as varchar(50),
	@FinancialYearId as varchar(50),
	@BoilType int
AS
BEGIN
	Select Id 'BoilSendId', BoilType, BoilNo, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, CONVERT(datetime,EntryDate) 'EntryDate', KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, PurityId, PurityName, SUM(Weight) 'Weight', SUM(LossWeight) 'LossWeight', SUM(RejectionWeight) 'RejectionWeight', SUM(Weight) + SUM(LossWeight) + SUM(RejectionWeight) as TotalWeight,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks
	
		FROM (SELECT BPM.BoilType, BPM.BoilNo, BPM.Id, BPM.Sr,  BPM.CompanyId, BPM.BranchId, BPM.FinancialYearId,  BPM.JangadNo, BPM.SlipNo, BPM.EntryDate, BPM.KapanId, KM.Name 'KapanName', BPM.ShapeId, SM.Name 'ShapeName', 
		BPM.SizeId, SM1.Name 'SizeName', BPM.PurityId, PM2.Name 'PurityName', BPM.Weight, BPM.LossWeight, BPM.RejectionWeight, BPM.HandOverById, PM.Name 'HandOverByName', BPM.HandOverToId, PM1.Name 'HandOverToName', BPM.Remarks, BPM.CreatedBy, BPM.CreatedDate, BPM.UpdatedBy, BPM.UpdatedDate 
		FROM [BoilProcessMaster] BPM
		INNER JOIN PartyMaster PM on BPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on BPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on BPM.KapanId = KM.Id
		LEFT JOIN ShapeMaster SM on BPM.ShapeId = SM.Id
		LEFT JOIN SizeMaster SM1 on BPM.SizeId = SM1.Id
		LEFT JOIN PurityMaster PM2 ON BPM.PurityId = PM2.Id) T

	WHERE CompanyId=@CompanyId AND FinancialYearId = @FinancialYearId AND BoilType = @BoilType --AND BranchId = @BranchId
	
	Group By BoilNo, BoilType, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, EntryDate, KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, PurityId, PurityName,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks, Id
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetCalulatorDetails]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[GetCashBankReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[GetCashBankReport]

@CompanyId as varchar(50),        
@FinancialYearId as varchar(50),
@FromDate as date = '',
@ToDate as date = ''   

as
begin

	select CAST(GPM.EntryDate as Date) 'EntryDate', PAM.Id + GPM.Id AS Id,
		CASE  
			WHEN GPM.CrDrType = 0 THEN 'Payment'
			WHEN GPM.CrDrType = 1 THEN 'Receipt'
		END AS Type,
	PAM1.Name 'ToParty', PAM.Name 'FromParty', 		
	CASE 
		WHEN GPM.CrDrType = 0 THEN Amount
		WHEN GPM.CrDrType = 1 THEN 0
	END AS 'Debit', 
	CASE 
		WHEN GPM.CrDrType = 0 THEN 0
		WHEN GPM.CrDrType = 1 THEN Amount
	END AS 'Credit', 	
	GPM.CrDrType, GPM.Remarks from GroupPaymentMaster GPM
	INNER JOIN PaymentMaster PM ON PM.GroupId = GPM.Id
	INNER JOIN PartyMaster PAM ON GPM.ToPartyId = PAM.Id
	INNER JOIN PartyMaster PAM1 ON PM.FromPartyId = PAM1.Id 
	
	Where GPM.IsDelete= 0 AND (PAM.Type = 4 OR PAM.Type = 5) 
	AND (CAST(GPM.EntryDate as Date) >= @FromDate AND CAST(GPM.EntryDate as Date) <= @ToDate) 
	AND GPM.CompanyId = @CompanyId AND GPM.FinancialYearId = @FinancialYearId

	UNION

	select CAST(CEM.EntryDate as Date) 'EntryDate', CEM.Id + CED.Id as Id, 'Contra' as Type, PM.Name 'ToParty', PM1.Name 'FromParty', Amount 'Debit', Amount 'Credit',0 'CrDrType', CEM.Remarks  from ContraEntryMaster CEM
	INNER JOIN contraentrydetails CED ON CEM.Id = CED.ContraEntryMasterId
	INNER JOIN [PartyMaster] AS PM ON PM.Id = CEM.ToPartyId
	
	INNER JOIN [PartyMaster] as PM1 ON PM1.Id = CED.FromParty
	WHERE CEM.IsDelete= 0
	AND (CAST(CEM.EntryDate as Date) >= @FromDate AND CAST(CEM.EntryDate as Date) <= @ToDate) AND
	CEM.CompanyId = @CompanyId AND CEM.FinancialYearId = @FinancialYearId

	UNION

	SELECT CAST(ED.EntryDate as Date) 'EntryDate', ED.Id, 'Expense' as Type, PM.Name 'ToParty', PM1.Name 'FromParty', 
    CAST(ED.Amount as DECIMAL(18,2)) 'Debit', 0 'Credit', 0 'CrDrType', ED.Remarks  from ExpenseDetails ED 
	
	INNER JOIN PartyMaster PM on ED.PartyId = PM.Id
	INNER JOIN PartyMaster PM1 on ED.fromPartyId = PM1.Id 
	WHERE ED.IsDelete=0
	AND (CAST(ED.EntryDate as Date) >= @FromDate AND CAST(ED.EntryDate as Date) <= @ToDate) AND
	ED.CompanyId = @CompanyId AND ED.FinancialYearId = @FinancialYearId

END
GO
/****** Object:  StoredProcedure [dbo].[GetCharniDetailsForSales]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetCharniDetailsForSales]

@CompanyId as varchar(50),        
@BranchId as varchar(50),    
@FinancialYear as varchar(50)  

as

select c.CompanyId,c.FinancialYearId,KapanId,k.Name'Kapan',ShapeId,s.Name'Shape',SizeId,sz.Name'Size',PurityId,p.Name'Purity',CharniSizeId,sz1.Name'CharniSize',''NumberSize,''NumberSizeId,
sum(CharniWeight)'Weight',
KapanId+ShapeId+SizeId+CharniSizeId'Id'
from CharniProcessMaster c
left join KapanMaster k on k.Id=c.KapanId
left join ShapeMaster s on s.Id=c.ShapeId
left join SizeMaster sz on sz.Id=c.SizeId
left join SizeMaster sz1 on sz1.Id=c.CharniSizeId
left join PurityMaster p on p.Id=c.PurityId
where CharniType=2
and c.CompanyId=@CompanyId and c.FinancialYearId=@FinancialYear
group by c.CompanyId,c.FinancialYearId,KapanId,k.Name,ShapeId,s.Name,SizeId,sz.Name,PurityId,p.Name,CharniSizeId,sz1.Name--,c.BranchId
GO
/****** Object:  StoredProcedure [dbo].[GetCharniProcessReceiveDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetCharniProcessReceiveDetail]
  
@ReceivedFrom as varchar(50),
@CompanyId as varchar(50),        
@BranchId as varchar(50),    
@FinancialYear as varchar(50)   
                  
as

select * from(            
select y.SlipNo,y.CharniNo,y.EntryDate,y.BoilJangadNo,y.KapanId,y.Kapan,y.ShapeID,y.Shape,y.SizeID,y.Size,y.PurityId,y.Purity,
y.Weight,y.ID,y.FinancialYearId,            
y.Weight-isnull((select sum(c1.CharniWeight)+sum(c1.LossWeight)+sum(c1.RejectionWeight) from CharniProcessMaster c1               
where c1.CharniType = 1
and c1.CompanyId=y.CompanyId 
--and c1.BranchId=y.BranchId 
and c1.SlipNo=y.SlipNo and c1.KapanId=y.KapanId and c1.ShapeId=y.ShapeID            
and c1.SizeId=y.SizeID and c1.PurityId=y.PurityId and c1.FinancialYearId=y.FinancialYearId and c1.BoilJangadNo=y.BoilJangadNo            
and c1.CharniNo=y.CharniNo
),0)'AvailableWeight'                   
from(            
select c.SlipNo,c.CharniNo,c.EntryDate,c.BoilJangadNo,c.KapanId,k.Name'Kapan',c.ShapeId,s.Name'Shape',c.SizeId,sz.Name'Size',c.PurityId,p.Name'Purity',
sum(c.Weight)'Weight',c.FinancialYearId,c.CompanyId,c.BranchId,            
c.SlipNo+c.KapanId+c.ShapeId+c.SizeId+c.PurityId+CONVERT(nvarchar(10),c.CharniNo) as 'ID'                   
from CharniProcessMaster c                  
left join KapanMaster k on k.Id=c.KapanId
left join ShapeMaster s on s.Id=c.ShapeId
left join SizeMaster sz on sz.Id=c.SizeId
left join PurityMaster p on p.Id=c.PurityId
where c.CharniType=0 
and c.HandOverToId=@ReceivedFrom and c.CompanyId=@CompanyId and c.FinancialYearId=@FinancialYear
group by c.SlipNo,c.CharniNo,c.EntryDate,c.BoilJangadNo,c.KapanId,k.Name,c.ShapeId,s.Name,c.SizeId,sz.Name,c.PurityId,p.Name,c.FinancialYearId,c.CompanyId,c.BranchId            
)y            
)z where AvailableWeight<>0 
GO
/****** Object:  StoredProcedure [dbo].[GetCharniSendReceiveReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCharniSendReceiveReport] 
	@CompanyId as varchar(50),
	@BranchId as varchar(50),
	@FinancialYearId as varchar(50),
	@CharniType int
AS
BEGIN
	IF @CharniType = 1 -- Charni send
	BEGIN

	SELECT CharniType, CharniNo, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, CONVERT(datetime,EntryDate) 'EntryDate', KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, PurityId, PurityName, SUM(Weight) 'Weight', SUM(LossWeight) 'LossWeight', SUM(RejectionWeight) 'RejectionWeight', TotalWeight,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks

	FROM (SELECT BPM.CharniNo, BPM.CharniType, BPM.CompanyId, BPM.BranchId, BPM.FinancialYearId,  BPM.JangadNo, BPM.SlipNo, BPM.EntryDate, BPM.KapanId, KM.Name 'KapanName', BPM.ShapeId, SM.Name 'ShapeName', 
		BPM.CharniSizeId 'SizeId', SM1.Name 'SizeName', BPM.PurityId, PM2.Name 'PurityName', BPM.Weight 'TotalWeight', CharniWeight 'Weight', BPM.LossWeight,BPM.RejectionWeight, BPM.HandOverById, PM.Name 'HandOverByName', BPM.HandOverToId, PM1.Name 'HandOverToName', BPM.Remarks 
		FROM [CharniProcessMaster] BPM
		INNER JOIN PartyMaster PM on BPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on BPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on BPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on BPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on BPM.CharniSizeId = SM1.Id
		INNER JOIN PurityMaster PM2 ON BPM.PurityId = PM2.Id) T

	WHERE CompanyId=@CompanyId AND FinancialYearId = @FinancialYearId AND CharniType = @CharniType --AND BranchId = @BranchId
	

	GROUP BY CharniNo, CharniType,  CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, EntryDate, KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, PurityId, PurityName, TotalWeight,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks
	
	END
	ELSE
	BEGIN

	SELECT CharniType, CharniNo, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, CONVERT(datetime,EntryDate) 'EntryDate', KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, PurityId, PurityName, SUM(Weight) 'Weight', SUM(LossWeight) 'LossWeight', SUM(RejectionWeight) 'RejectionWeight', TotalWeight,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks

	FROM (SELECT BPM.CharniNo, BPM.CharniType, BPM.CompanyId, BPM.BranchId, BPM.FinancialYearId,  BPM.JangadNo, BPM.SlipNo, BPM.EntryDate, BPM.KapanId, KM.Name 'KapanName', BPM.ShapeId, SM.Name 'ShapeName', 
		BPM.SizeId 'SizeId', SM1.Name 'SizeName', BPM.PurityId, PM2.Name 'PurityName', BPM.Weight 'TotalWeight', CharniWeight 'Weight', BPM.LossWeight,BPM.RejectionWeight, BPM.HandOverById, PM.Name 'HandOverByName', BPM.HandOverToId, PM1.Name 'HandOverToName', BPM.Remarks 
		FROM [CharniProcessMaster] BPM
		INNER JOIN PartyMaster PM on BPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on BPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on BPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on BPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on BPM.SizeId = SM1.Id
		INNER JOIN PurityMaster PM2 ON BPM.PurityId = PM2.Id) T

	WHERE CompanyId=@CompanyId AND FinancialYearId = @FinancialYearId AND CharniType = @CharniType -- AND BranchId = @BranchId
	

	GROUP BY CharniNo, CharniType,  CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, EntryDate, KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, PurityId, PurityName, TotalWeight,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks

	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetCharniToDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetCharniToDetail]

@CompanyId as varchar(50),        
@BranchId as varchar(50),    
@FinancialYear as varchar(50)  

as          
      
select * from(      
select SlipNo,BoilNo,KapanId,Kapan,ShapeID,Shape,SizeID,Size,PurityId,Purity,ID,SUM(Weight)'Weight',FinancialYearId,      
SUM(Weight)-isnull((select sum(c.Weight) from CharniProcessMaster c         
where CharniType=0  
and c.CompanyId=x.CompanyId 
--and c.BranchId=x.BranchId 
and c.SlipNo=x.SlipNo and c.KapanId=x.KapanId and c.ShapeId=x.ShapeId and c.SizeId=x.SizeId
and c.PurityId=x.PurityId and c.FinancialYearId=x.FinancialYearId and c.BoilJangadNo=x.BoilNo
),0)
-isnull((select sum(b1.Weight) from BoilProcessMaster b1        
where b1.CompanyId=x.CompanyId 
--and b1.BranchId=x.BranchId 
and b1.KapanId=x.KapanId and b1.ShapeId=x.ShapeId 
and b1.SizeId=x.SizeId and b1.PurityId=x.PurityId and b1.SlipNo=x.SlipNo and b1.BoilNo=x.BoilNo and b1.FinancialYearId=x.FinancialYearId
and b1.BoilType=2),0)'AvailableWeight'
from(          
select b.SlipNo,b.JangadNo,b.BoilNo,b.KapanId,k.Name'Kapan',b.ShapeId,s.Name'Shape',b.SizeId,sz.Name'Size',b.PurityId,p.Name'Purity',
b.Weight,b.FinancialYearId,b.CompanyId,b.BranchId,          
CONVERT(nvarchar(10),b.SlipNo)+b.KapanId+b.ShapeId+b.SizeId+b.PurityId+convert(varchar,b.BoilNo) as 'ID'           
from BoilProcessMaster b          
left join KapanMaster k on k.Id=b.KapanId
left join ShapeMaster s on s.Id=b.ShapeId
left join SizeMaster sz on sz.Id=b.SizeId
left join PurityMaster p on p.Id=b.PurityId
where 
b.CompanyId=@CompanyId and b.FinancialYearId=@FinancialYear and
b.BoilNo in (          
select * from(          
select max(b1.BoilNo) as id from BoilProcessMaster b1        
where b1.CompanyId=b.CompanyId 
--and b1.BranchId=b.BranchId 
and b1.KapanId=b.KapanId and b1.ShapeId=b.ShapeId 
and b1.SizeId=b.SizeId and b1.PurityId=b.PurityId and b1.FinancialYearId=b.FinancialYearId
group by b1.BoilNo)x)          
and BoilType=1
--and b.BoilNo not in (select distinct c.BoilJangadNo from CharniProcessMaster c where c.CompanyId=b.CompanyId and c.BranchId=b.BranchId 
--and c.KapanId=b.KapanId and c.ShapeId=b.ShapeId and c.SizeId=b.SizeId and c.PurityId=b.PurityId and c.FinancialYearId=b.FinancialYearId)      
)x      
group by SlipNo,BoilNo,KapanId,Kapan,ShapeId,Shape,SizeID,Size,PurityId,Purity,ID,FinancialYearId,CompanyId,BranchId
)y      
where AvailableWeight<>0 
GO
/****** Object:  StoredProcedure [dbo].[GetChildPurchaseReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetChildPurchaseReport]   
 @PurchaseId as varchar(50)          
AS  
BEGIN  
SELECT PD.*, SM.Name 'ShapeName', SZM.Name 'SizeName', PM.Name 'PurityName'
	FROM PurchaseDetails PD
	LEFT JOIN ShapeMaster SM ON SM.Id = PD.ShapeId
	LEFT JOIN SizeMaster SZM ON SZM.Id = PD.SizeId
	LEFT JOIN PurityMaster PM ON PM.Id = PD.PurityId	
	WHERE PD.PurchaseId = @PurchaseId
END

GO
/****** Object:  StoredProcedure [dbo].[GetChildSalesReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetChildSalesReport]   
 @SalesId as varchar(50)          
AS  
BEGIN  
SELECT SD.*, SM.Name 'ShapeName', SZM.Name 'SizeName', PM.Name 'PurityName', GM.Name 'GalaSizeName', NM.Name 'NumberSizeName', SZM1.Name 'CharniSizeName' FROM SalesDetails SD
	LEFT JOIN ShapeMaster SM ON SM.Id = SD.ShapeId
	LEFT JOIN SizeMaster SZM ON SZM.Id = SD.SizeId
	LEFT JOIN PurityMaster PM ON PM.Id = SD.PurityId
	LEFT JOIN GalaMaster GM ON GM.Id = SD.GalaSizeId
	LEFT JOIN NumberMaster NM ON NM.Id = SD.NumberSizeId
	LEFT JOIN SizeMaster SZM1 ON SZM1.Id = SD.CharniSizeId
	WHERE SD.SalesId = @SalesId
END

GO
/****** Object:  StoredProcedure [dbo].[GetContraReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetContraReport] 
	@CompanyId as varchar(50),        
	@FinancialYearId as varchar(50),
	@FromDate as date = '',
	@ToDate as date = ''   
AS
BEGIN
	SELECT M.*, PM1.Name as ToPartyName FROM (
	
	SELECT CEM.Sr,CEM.SrNo, CAST(CEM.EntryDate as date) 'EntryDate', CEM.Id AS ContraId, CEM.CompanyId, CEM.FinancialYearId, CED.Id, CED.FromParty AS FromPartyId, 
	CEM.ToPartyId, PM.Name AS FromPartyName, CED.Amount, CEM.Remarks, CEM.UpdatedDate, CEM.UpdatedBy 
	from [ContraEntryDetails] AS CED
	left JOIN [ContraEntryMaster] AS CEM ON CEM.Id = CED.ContraEntryMasterId
	left JOIN [PartyMaster] AS PM ON PM.Id = CEM.ToPartyId) as M
	
	left JOIN [PartyMaster] as PM1 ON PM1.Id = M.FromPartyId

	WHERE 
	--(CAST(EntryDate as Date) >= @FromDate AND CAST(EntryDate as Date) <= @ToDate) AND
	M.CompanyId = @CompanyId and M.FinancialYearId = @FinancialYearId

	Order by M.SrNo Desc
END
GO
/****** Object:  StoredProcedure [dbo].[GetDefaultSizeNumberDetailsForPriceMaster]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetDefaultSizeNumberDetailsForPriceMaster]

as

select ''CompanyId,s.Id'SizeId',S.Name'Size',n.Id'NumberId',N.Name'Number',0.00'Price' from SizeMaster s
cross join NumberMaster n
GO
/****** Object:  StoredProcedure [dbo].[GetExpenseReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetExpenseReport] 
	@CompanyId as varchar(50),
	@FinancialYearId as varchar(50),
	@FromDate as date = '',
	@ToDate as date = ''
AS
BEGIN
	SELECT Ed.CrDrType, CAST(ED.EntryDate as date) 'EntryDate', Ed.Id, Ed.Sr, SrNo, ED.CompanyId, BranchId, BM.Name as BranchName, PartyId, PM.Name as ToPartyName,  
	Amount, Remarks, PA.Name as FromPartyName, ED.UpdatedDate, ED.UpdatedBy
	FROM [ExpenseDetails] ED
	INNER JOIN PartyMaster PM ON PM.Id = ED.PartyId
	INNER JOIN PartyMaster PA ON PA.Id = ED.fromPartyId 
	INNER JOIN BranchMaster BM ON BM.Id = ED.BranchId 
	WHERE 
	(CAST(EntryDate as Date) >= @FromDate AND CAST(EntryDate as Date) <= @ToDate) AND
	ED.CompanyId = @CompanyId AND ED.FinancialYearId = @FinancialYearId
	Order By SrNo
END
GO
/****** Object:  StoredProcedure [dbo].[GetGalaProcessReceiveDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetGalaProcessReceiveDetail]  
    
@ReceivedFrom as varchar(50),  
@CompanyId as varchar(50),          
@BranchId as varchar(50),      
@FinancialYear as varchar(50)     
                    
as  
  
select * from(            
select g.GalaNo,g.KapanId,k.Name'Kapan',g.ShapeId,s.Name'Shape',g.SizeId,sz.Name'Size',g.PurityId,p.Name'Purity',        
sum(g.Weight)'Weight',g.FinancialYearId,g.CharniSizeId,sz1.Name'CharniSize',    
sum(g.Weight)-isnull((select sum(g1.GalaWeight)+sum(g1.LossWeight)+sum(g1.RejectionWeight) from GalaProcessMaster g1                 
where g1.GalaProcessType=1                   
and g1.CompanyId=g.CompanyId 
--and g1.BranchId=g.BranchId 
and g1.KapanId=g.KapanId and g1.ShapeId=g.ShapeId  
and g1.SizeId=g.SizeId and g1.PurityId=g.PurityId and g1.FinancialYearId=g.FinancialYearId          
and g1.GalaNo=g.GalaNo and g1.CharniSizeId=g.CharniSizeId 
),0)'AvailableWeight',        
STUFF(            
(SELECT ',' + convert(nvarchar(max),g1.SlipNo)            
FROM GalaProcessMaster g1            
WHERE g1.GalaProcessType=0 and g1.CompanyId=g.CompanyId 
--and g1.BranchId=g.BranchId 
and g1.FinancialYearId=g.FinancialYearId and  
g1.KapanId=g.KapanId and g1.GalaNo = g.GalaNo and g1.KapanId=g.KapanId and g1.ShapeId=g.ShapeId and g1.SizeId=g.SizeId and g1.PurityId=g.PurityId and g1.CharniSizeId=g.CharniSizeId        
FOR XML PATH('')),1,1,'') AS SlipNo,             
g.KapanId+g.ShapeId+g.SizeId+g.PurityId+CONVERT(nvarchar(10),g.GalaNo)+g.CharniSizeId as 'ID'             
from GalaProcessMaster g            
left join KapanMaster k on k.Id=g.KapanId  
left join ShapeMaster s on s.Id=g.ShapeId  
left join SizeMaster sz on sz.Id=g.SizeId
left join SizeMaster sz1 on sz1.Id=g.CharniSizeId
left join PurityMaster p on p.Id=g.PurityId  
where g.GalaProcessType=0   
and g.HandOverToId=@ReceivedFrom and g.CompanyId=@CompanyId and g.FinancialYearId=@FinancialYear   
group by g.GalaNo,g.KapanId,k.Name,g.ShapeId,s.Name,g.SizeId,sz.Name,g.PurityId,p.Name,g.FinancialYearId,g.CompanyId,g.CharniSizeId,sz1.Name--,g.BranchId  
)x          
where AvailableWeight<>0 
GO
/****** Object:  StoredProcedure [dbo].[GetGalaProcessSendToDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetGalaProcessSendToDetail]

@CompanyId as varchar(50),        
@BranchId as varchar(50),    
@FinancialYear as varchar(50)    

as

select *  
from (          
select   
STUFF(        
(SELECT ',' + convert(nvarchar(MAX),c1.SlipNo)        
FROM CharniProcessMaster c1  
WHERE c1.CompanyId=c.CompanyId 
--and c1.BranchId=c.BranchId 
and c1.FinancialYearId=c.FinancialYearId and c1.CharniType=c.CharniType 
and c1.KapanId=c.KapanId and c1.ShapeId=c.ShapeId and c1.SizeId=c.SizeId and c1.PurityId=c.PurityId and c1.CharniSizeId=c.CharniSizeId
order by c1.SlipNo
for xml path(''),TYPE).value('.', 'varchar(MAX)'),1,1,'') AS SlipNo,  
c.KapanId,k.Name'Kapan',c.ShapeId,s.Name'Shape',c.SizeId,sz.Name'Size',c.PurityId,p.Name'Purity',c.FinancialYearId,c.CharniSizeId,s1.Name'CharniSize',          
sum(c.CharniWeight)'Weight',sum(c.CharniWeight)
-isnull((select sum(g.Weight)         
from GalaProcessMaster g         
where g.CompanyId=c.CompanyId --and g.BranchId=c.BranchId 
and g.GalaProcessType=0 and g.KapanId=c.KapanId and g.ShapeId=c.ShapeId and g.SizeId=c.SizeId and g.PurityId=c.PurityId and g.CharniSizeId=c.CharniSizeId
and g.FinancialYearId=c.FinancialYearId),0)
-isnull((select sum(c2.CharniWeight) FROM CharniProcessMaster c2  
WHERE c2.CompanyId=c.CompanyId and c2.FinancialYearId=c.FinancialYearId --and c2.BranchId=c.BranchId 
and c2.KapanId=c.KapanId and c2.ShapeId=c.ShapeId and c2.SizeId=c.SizeId and c2.PurityId=c.PurityId and c2.CharniSizeId=c.CharniSizeId 
and c2.CharniType=2),0)'AvailableWeight',          
c.CompanyId+c.FinancialYearId+c.KapanId+c.ShapeId+c.SizeId+c.PurityId+c.CharniSizeId as 'ID' --+c.BranchId          
from CharniProcessMaster c          
left join KapanMaster k on k.Id=c.KapanId
left join ShapeMaster s on s.Id=c.ShapeId
left join SizeMaster s1 on s1.Id=c.CharniSizeId
left join SizeMaster sz on sz.Id=c.SizeId
left join PurityMaster p on p.Id=c.PurityId
where c.CharniType=1
and c.CompanyId=@CompanyId and c.FinancialYearId=@FinancialYear
group by c.KapanId,k.Name,c.ShapeId,s.Name,c.SizeId,sz.Name,c.PurityId,p.Name,c.CharniType,c.CompanyId,c.FinancialYearId,c.CharniSizeId,s1.Name--,c.BranchId
)x          
where AvailableWeight<>0   
GO
/****** Object:  StoredProcedure [dbo].[GetGalaSendReceiveReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetGalaSendReceiveReport] 
	@CompanyId as varchar(50),
	@BranchId as varchar(50),
	@FinancialYearId as varchar(50),
	@GalaProcessType int
AS
BEGIN
	IF @GalaProcessType = 1 --Gala Receive Query Report
	BEGIN

	SELECT GalaProcessType, GalaNo, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, CONVERT(datetime,EntryDate) 'EntryDate', KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName,GalaNumberId, GalaName, PurityId, PurityName, TotalWeight, SUM(Weight) 'Weight', SUM(LossWeight) 'LossWeight', SUM(RejectionWeight) 'RejectionWeight',
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks	
		FROM (		
		SELECT BPM.GalaNo, BPM.GalaProcessType, BPM.CompanyId, BPM.BranchId, BPM.FinancialYearId,  BPM.JangadNo,
		BPM.SlipNo, BPM.EntryDate, BPM.KapanId, KM.Name 'KapanName', BPM.ShapeId, SM.Name 'ShapeName',
		BPM.CharniSizeId 'SizeId', SM1.Name 'SizeName', BPM.GalaNumberId, GM2.Name 'GalaName', BPM.PurityId, PM2.Name 'PurityName', BPM.Weight 'TotalWeight',
		BPM.GalaWeight 'Weight', LossWeight, RejectionWeight,BPM.HandOverById, PM.Name 'HandOverByName', BPM.HandOverToId, PM1.Name 'HandOverToName', BPM.Remarks

		FROM [GalaProcessMaster] BPM
		INNER JOIN PartyMaster PM on BPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on BPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on BPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on BPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on BPM.CharniSizeId = SM1.Id
		INNER JOIN GalaMaster GM2 on BPM.GalaNumberId = GM2.Id
		INNER JOIN PurityMaster PM2 ON BPM.PurityId = PM2.Id) T

	WHERE CompanyId=@CompanyId AND FinancialYearId = @FinancialYearId AND GalaProcessType = @GalaProcessType -- AND BranchId = @BranchId

	Group By GalaNo, GalaProcessType, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, EntryDate, KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, TotalWeight, PurityId, PurityName,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks, GalaNumberId, GalaName

	END
	ELSE 
	BEGIN

	SELECT GalaProcessType, GalaNo, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, CONVERT(datetime,EntryDate) 'EntryDate', KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName,GalaNumberId, GalaName, PurityId, PurityName, TotalWeight, SUM(Weight) 'Weight', SUM(LossWeight) 'LossWeight', SUM(RejectionWeight) 'RejectionWeight',
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks	
		FROM (		
		SELECT BPM.GalaNo, BPM.GalaProcessType, BPM.CompanyId, BPM.BranchId, BPM.FinancialYearId,  BPM.JangadNo,
		BPM.SlipNo, BPM.EntryDate, BPM.KapanId, KM.Name 'KapanName', BPM.ShapeId, SM.Name 'ShapeName',
		BPM.CharniSizeId 'SizeId', SM1.Name 'SizeName', '' GalaNumberId, '' GalaName, BPM.PurityId, PM2.Name 'PurityName', BPM.Weight 'TotalWeight',
		BPM.GalaWeight 'Weight', LossWeight, RejectionWeight,BPM.HandOverById, PM.Name 'HandOverByName', BPM.HandOverToId, PM1.Name 'HandOverToName', BPM.Remarks

		FROM [GalaProcessMaster] BPM
		INNER JOIN PartyMaster PM on BPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on BPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on BPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on BPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on BPM.CharniSizeId = SM1.Id
		INNER JOIN PurityMaster PM2 ON BPM.PurityId = PM2.Id) T

	WHERE CompanyId=@CompanyId AND FinancialYearId = @FinancialYearId AND GalaProcessType = @GalaProcessType --AND BranchId = @BranchId

	Group By GalaNo, GalaProcessType, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, EntryDate, KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, TotalWeight, PurityId, PurityName,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks, GalaNumberId, GalaName

	END


	
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetJangadPrintDetails]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetJangadPrintDetails]    
    
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
GO
/****** Object:  StoredProcedure [dbo].[GetJangadReceiveDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetJangadReceiveDetail]  
    
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
GO
/****** Object:  StoredProcedure [dbo].[GetJangadReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetJangadReport] 
	@CompanyId as varchar(50),
	@FinancialYearId as varchar(50),
	@JangadType as int
AS
BEGIN
	SELECT JM.Id, JM.FinancialYearId, JM.Sr,JM.SrNo, JM.PartyId, PM.Name 'PartyName', JM.BrokerId, PM1.Name 'BrokerName', JM.SizeId, SM.Name 'SizeName', JM.Totalcts, JM.Rate, JM.Amount, JM.Remarks, JM.UpdatedDate 
	FROM JangadMaster JM INNER JOIN PartyMaster PM ON JM.PartyId = PM.Id
	INNER JOIN PartyMaster PM1 ON JM.BrokerId = PM1.Id
	INNER JOIN SizeMaster SM ON JM.SizeId = SM.Id
	WHERE JM.FinancialYearId = @FinancialYearId AND JM.CompanyId = @CompanyId AND JM.EntryType = @JangadType  
END
GO
/****** Object:  StoredProcedure [dbo].[GetKapanLagadReportDetails]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Exec GetKapanLagadReportDetails 'e711c76e-7789-4fd3-ac08-272dd94aaa65'
CREATE proc [dbo].[GetKapanLagadReportDetails] --'26bbc3c3-9ef0-4615-92cb-10e4e49b3e0a' --'e711c76e-7789-4fd3-ac08-272dd94aaa65' --'6db63529-93ba-47d7-a96d-36492ec1fd56'--'2010ff7c-ddba-4a68-bf90-cc71bddb5852'--'ad852c84-ce9d-48ed-a5e4-e9bdce16da59'                  
                    
@KapanId as varchar(50)                    
                    
as                    
 --drop table #tblInwordOutword                  
 --drop table #tblInwordOutword1                  
 --drop table #tblInwordOutword2                  
 --drop table #tblInwordOutword4        
                  
 select * into #tblInwordOutword                  
 from(                    
 --Kapan OpeningBalance                    
 select 0 as Id,CAST(CreatedDate as date) Date, '0' as SlipNo,'' as OperationType,'' as Size,                    
 'Opening Stock' AS Party, TotalCts as NetWeight,Rate, TotalCts*Rate as Amount,'Inward' as Category, 1 as CategoryId, 1 as Records                    
 from OpeningStockMaster o                     
 where Category=1 and isnull(TransferType,'')='' and o.KapanId=@KapanId                    
 union                    
 --Partywise kapan purchase details                               
 --SELECT 1 as Id,CAST(PM.Date as date) Date, PM.SlipNo,'' as OperationType,'' as Size,                    
 --PAM.Name AS Party, sum(PD.NetWeight) as NetWeight,sum(PD.BuyingRate)/count(PM.SlipNo) 'Rate', PM.GrossTotal as Amount,'Inward' as Category, 1 as CategoryId,count(PM.SlipNo) as Records                  
 --FROM KapanMappingMaster KM                    
 --Left JOIN [PurchaseMaster] AS PM ON PM.Id=KM.PurchaseMasterId                    
 --Left JOIN [PurchaseDetails] AS PD ON PD.Id=KM.PurchaseDetailsId AND PM.Id = PD.PurchaseId                        
 --Left JOIN [PartyMaster] AS PAM ON PAM.Id = PM.PartyId                     
 --where KM.KapanId=@KapanId and isnull(KM.TransferType,'')=''                  
 --group by PM.Date,PM.SlipNo,PAM.Name,PM.GrossTotal      
  SELECT 1 as Id,CAST(PM.Date as date) Date, PM.SlipNo,'' as OperationType,'' as Size,                    
 PAM.Name AS Party, PD.NetWeight as NetWeight,
 (case when PD.LessWeight > 0 then PM.GrossTotal/PD.NetWeight else PD.BuyingRate end) as 'Rate', PM.GrossTotal as Amount,'Inward' as Category, 1 as CategoryId,1 as Records    
 FROM KapanMappingMaster KM                    
 Left JOIN [PurchaseMaster] AS PM ON PM.Id=KM.PurchaseMasterId                    
 Left JOIN [PurchaseDetails] AS PD ON PD.Id=KM.PurchaseDetailsId AND PM.Id = PD.PurchaseId                        
 Left JOIN [PartyMaster] AS PAM ON PAM.Id = PM.PartyId                     
 where KM.KapanId=@KapanId and isnull(KM.TransferType,'')=''                   
                    
 union                    
                    
 --Kapan Stock Transfer details                    
 select 2 as Id,Date,'','TF' as OperationType,Size,Kapan'Kapan',Weight,Rate,Weight*Rate,'Inward' as Category, 1 as CategoryId, 1 as Records from(                    
 select t.Date,k.Weight'Weight',s.Name as Size,                    
(case when n.TransferId<>'' then '('+s.Name+') '+nm.Name else (select km1.Name from KapanMappingMaster k1 left join KapanMaster km1 on km1.Id=k1.KapanId where k1.TransferId=k.TransferId and k1.TransferEntryId=k.TransferEntryId and TransferType='TransferedFrom') end)'Kapan',                    
(select k1.TransferCaratRate from KapanMappingMaster k1 where k1.TransferId=k.TransferId and k1.TransferEntryId=k.TransferEntryId and TransferType='TransferedTo')'Rate'                    
 from TransferMaster t                    
 inner join KapanMappingMaster k on k.TransferId=t.Id                 
 left join NumberProcessMaster n on n.TransferId=t.Id and n.TransferEntryId=k.TransferEntryId                   
 left join SizeMaster s on s.Id=n.CharniSizeId              
 left join NumberMaster nm on nm.Id=n.NumberId              
 inner join KapanMaster km on km.Id=k.KapanId                 
 where k.TransferType='TransferedTo' and k.KapanId=@KapanId                    
 --and k.SlipNo<>'0' --When Transfer from number to kapan that time SlipNo is 0                   
 )x                    
               
 union   
 select 2 as Id,Date,'','TF' as OperationType,Size,Kapan'Kapan',Weight,Rate,Weight*Rate,'Inward' as Category, 1 as CategoryId, 1 as Records from(                    
 select t.Date,o.TotalCts'Weight',s.Name as Size,                    
 (case when n.TransferId<>'' then '('+s.Name+') '+nm.Name else (select km1.Name from OpeningStockMaster o1 left join KapanMaster km1 on km1.Id=o1.KapanId where o1.TransferId=o.TransferId and o1.TransferEntryId=o.TransferEntryId and TransferType='TransferedFrom') end)'Kapan',                    
 (select o1.TransferCaratRate from OpeningStockMaster o1 where o1.TransferId=o.TransferId and o1.TransferEntryId=o.TransferEntryId and TransferType='TransferedTo')'Rate'                    
 from TransferMaster t                    
 inner join OpeningStockMaster o on o.TransferId=t.Id                  
 left join NumberProcessMaster n on n.TransferId=t.Id and n.TransferEntryId=o.TransferEntryId                   
 left join SizeMaster s on s.Id=n.CharniSizeId              
 left join NumberMaster nm on nm.Id=n.NumberId              
 inner join KapanMaster km on km.Id=o.KapanId                  
 where o.TransferType='TransferedTo' and o.KapanId=@KapanId                    
 )x                       
                    
                    
 union                    
                    
 --Kapan purchase expense details                    
 SELECT 3 as Id,GetDate(),0,'' as OperationType,'' as Size,        
 'Expense (' + convert(varchar,convert(numeric(18,2),K.CaratLimit)) + '%)','0','0',(SUM(PM.GrossTotal)/((100-K.CaratLimit)/100))-SUM(PM.GrossTotal) 'NetAmount','Inward' as Category, 1 as CategoryId, 1 as Records                    
 FROM KapanMappingMaster KM                    
 INNER JOIN [PurchaseMaster] AS PM ON PM.Id=KM.PurchaseMasterId                    
 --INNER JOIN [PurchaseDetails] AS PD ON PD.Id=KM.PurchaseDetailsId AND PM.Id = PD.PurchaseId                        
 INNER JOIN [KapanMaster] AS K ON K.Id = KM.KapanId                    
 where KM.KapanId=@KapanId                    
 group by k.CaratLimit--,convert(varchar,km.CreatedDate,112)                    
                    
 union              
 --Partywise kapan sale details                    
 SELECT 0 as Id,CAST(S.Date as date) Date, S.SlipNo,'' as OperationType,'' as Size,                    
 PAM.Name AS Party, SD.NetWeight as NetWeight,SD.SaleRate 'Rate', S.GrossTotal as Amount,'Outward' as Category, 2 as CategoryId, 1 as Records                    
 FROM [SalesMaster] S                    
 INNER JOIN [SalesDetails] AS SD ON SD.SalesId=S.Id                    
 INNER JOIN [KapanMaster] AS K ON K.Id=SD.KapanId                    
 INNER JOIN [PartyMaster] AS PAM ON PAM.Id = S.PartyId                     
 where SD.Category=1 and K.Id=@KapanId                    
                    
 union                    
 --Assortment Receive                    
 select 1 as Id,n.EntryDate,'0','NR' as OperationType,'' as Size,        
 '('+s.Name+')'+' '+nm.Name'Number',NumberWeight,TransferCaratRate,NumberWeight*TransferCaratRate ,'Outward' as Category, 2 as CategoryId, 1 as Records                    
 from NumberProcessMaster n                    
 left join NumberMaster nm on nm.Id=n.NumberId                    
 left join SizeMaster s on s.Id=n.CharniSizeId                    
 where NumberProcessType=2                    
 and KapanId=@KapanId                    
                    
 union         
                  
 select 2 as Id,Date,'','TT' as OperationType,Size,        
 Kapan'Kapan', Weight,Rate,Weight*Rate,'Outward' as Category, 2 as CategoryId, 1 as Records from(         
 select id,Date,sum(Weight) as 'Weight',Size,Kapan,Rate from(                
 select t.id,t.Date,k.Weight*-1'Weight',s.Name as Size,        
 (case when ISNULL(n.TransferId, '')<>'' then '('+s.Name+') '+nm.Name else (select km1.Name from KapanMappingMaster k1 left join KapanMaster km1 on km1.Id=k1.KapanId where k1.TransferId=k.TransferId and k1.TransferEntryId=k.TransferEntryId and TransferType='TransferedTo') end)'Kapan',      
 (select k1.TransferCaratRate from KapanMappingMaster k1 where k1.TransferId=k.TransferId and k1.TransferEntryId=k.TransferEntryId and TransferType='TransferedFrom')'Rate'              
 from TransferMaster t                    
 inner join KapanMappingMaster k on k.TransferId=t.Id               
 left join NumberProcessMaster n on n.TransferId=t.Id and n.TransferEntryId=k.TransferEntryId                   
 left join SizeMaster s on s.Id=n.CharniSizeId              
 left join NumberMaster nm on nm.Id=n.NumberId              
 inner join KapanMaster km on km.Id=k.KapanId              
 where k.TransferType='TransferedFrom' and k.KapanId=@KapanId                          
 and k.SlipNo<>'0'                    
 )y    
 group by id,Date,Size,Kapan,Rate    
 )x                    
                 
 union                    
 select 2 as Id,Date,'','TT' as OperationType,Size,        
 Kapan'Kapan',Weight,Rate,Weight*Rate,'Outward' as Category, 2 as CategoryId, 1 as Records from(      
 select id,Date,Weight as 'Weight',Size,Kapan,Rate from(                  
 select t.id,t.Date,o.TotalCts*-1'Weight',s.Name as Size,                    
 (case when ISNULL(n.TransferId, '')<>'' then '('+s.Name+') '+nm.Name else (select km1.Name from OpeningStockMaster o1 left join KapanMaster km1 on km1.Id=o1.KapanId where o1.TransferId=o.TransferId and o1.TransferEntryId=o.TransferEntryId and TransferType='TransferedTo') end)'Kapan',               
 (select o1.TransferCaratRate from OpeningStockMaster o1 where o1.TransferId=o.TransferId and o1.TransferEntryId=o.TransferEntryId and TransferType='TransferedFrom')'Rate'              
 from TransferMaster t                    
 left join OpeningStockMaster o on o.TransferId=t.Id                  
 left join NumberProcessMaster n on n.TransferId=t.Id and n.TransferEntryId=o.TransferEntryId                   
 left join SizeMaster s on s.Id=n.CharniSizeId              
 left join NumberMaster nm on nm.Id=n.NumberId              
 inner join KapanMaster km on km.Id=o.KapanId                
 where o.TransferType='TransferedFrom' and o.KapanId=@KapanId                          
 )y    
 --group by id,Date,Size,Kapan,Rate    
 )x                    
  
  union                    
 --Rejection Out
 select 3 as Id,r.EntryDate,r.SlipNo,'Rej.' as OperationType,'' as Size,        
 PAM.Name as Party,r.TotalCarat,r.Rate,r.Amount ,'Outward' as Category, 2 as CategoryId, 1 as Records                    
 from RejectionInOutMaster r                    
 left join PurchaseMaster p on p.SlipNo=r.SlipNo     
 left join PurchaseDetails pd on pd.PurchaseId=p.Id 
 Left JOIN [PartyMaster] AS PAM ON PAM.Id = r.PartyId                         
 where pd.RejectedWeight=0 and r.ProcessType='Boil'                
 and r.KapanId=@KapanId  
                 
 )x                    
                     
 select z.* into #tblInwordOutword1 from(                    
 select Id, Date, SlipNo,OperationType, Size, Party, convert(decimal(18,2),NetWeight) as NetWeight, convert(decimal(18,2),Rate) as Rate,                    
 convert(decimal(18,2),Amount) as Amount,Category, CategoryId, Records                    
 from #tblInwordOutword                    
 union                    
 --Tip Weight                    
 --SELECT 4 as Id,GetDate(), 0, '' as OperationType,'' as Size,        
 --'Tip Weight',sum(pd.TIPWeight)+sum(pd.LessWeight),convert(decimal(18,2),(select Sum(Amount)/Sum(NetWeight) from #tblInwordOutword where CategoryId=1)) 'Rate',                     
 --convert(decimal(18,2),(sum(pd.TIPWeight)+sum(pd.LessWeight))*(select Sum(Amount)/Sum(NetWeight) from #tblInwordOutword where CategoryId=1))'Amount','Inward' as Category, 1 as CategoryId, 1 as Records                    
 --FROM KapanMappingMaster KM                    
 --INNER JOIN [PurchaseMaster] AS PM ON PM.Id=KM.PurchaseMasterId                    
 --INNER JOIN [PurchaseDetails] AS PD ON PD.Id=KM.PurchaseDetailsId AND PM.Id = PD.PurchaseId                        
 --INNER JOIN [PartyMaster] AS PAM ON PAM.Id = PM.PartyId                     
 --where KM.KapanId=@KapanId  
   
 select 4 as Id,GetDate(), 0, '' as OperationType,'' as Size,        
 'Tip Weight',sum(y.TIPWeight)+sum(y.LessWeight),convert(decimal(18,2),(select Sum(Amount)/Sum(NetWeight) from #tblInwordOutword where CategoryId=1)) 'Rate',                     
 convert(decimal(18,2),(sum(y.TIPWeight)+sum(y.LessWeight))*(select Sum(Amount)/Sum(NetWeight) from #tblInwordOutword where CategoryId=1))'Amount','Inward' as Category, 1 as CategoryId, 1 as Records                   from(  
  SELECT distinct pd.id,pd.TIPWeight,pd.LessWeight  
 FROM [PurchaseDetails] AS PD                   
 left JOIN [PurchaseMaster] AS PM ON PM.Id=PD.PurchaseId  
 left JOIN KapanMappingMaster KM  ON PD.Id=KM.PurchaseDetailsId  
 where KM.KapanId=@KapanId)y  
 )z                    
                   
                   
 --Calculate closing balance                  
 select Id,Date,SlipNo, OperationType, Size,        
 Party,NetWeight,            
 (case when Amount<>0 then Amount/(case when NetWeight<>0 then NetWeight else 1 end) else 0 end) as Rate,            
 Amount,OutwordAmount,Category,CategoryId,Records            
 into #tblInwordOutword2             
 from(            
 select 1 as Id,GetDate() as Date,'0' as SlipNo,'' as OperationType,'' as Size,        
 '' as Party,abs(isnull(InwardWeight,0)-isnull(OutwardWeight,0)) as NetWeight,                  
 --(case when isnull(InwardAmount,0)<>0 and isnull(OutwordAmount,0)<>0 then             
 -- convert(decimal(18,2),abs(isnull(InwardAmount,0)-isnull(OutwordAmount,0))            
 --/(isnull(InwardWeight,0)-isnull(OutwardWeight,0)))                  
 --else 0 end) as Rate,                    
 convert(decimal(18,2),abs(isnull(InwardAmount,0)-isnull(OutwordAmount,0))) as Amount,                    
 isnull(OutwordAmount,0) as OutwordAmount,'Closing' as Category, 3 as CategoryId, 1 as Records                   
 from(                    
 select                    
 (select sum(Amount) from #tblInwordOutword1                    
 where Category='Inward'                    
 group by Category) as InwardAmount,                    
 (select sum(Amount) from #tblInwordOutword1                    
 where Category='Outward'                    
 group by Category) as OutwordAmount,                    
 (select sum(Netweight) from #tblInwordOutword1                    
 where Category='Inward'                    
 group by Category) as InwardWeight,                    
 (select sum(Netweight) from #tblInwordOutword1                    
 where Category='Outward'                    
 group by Category) as OutwardWeight                    
 )y            
 )z            
          
 --select * from #tblInwordOutword1        
 select Category,Size,sum(NetWeight)'TotalSizeGroupWeight'         
 into #tblInwordOutword4        
 from #tblInwordOutword1                    
 Where OperationType='TT'        
 group by Category,Size        
          
 declare @ProfitLossPer as numeric(18,2);                  
 set @ProfitLossPer = (select (case when sum(OutwordAmount)<>0 then (sum(Amount)/sum(OutwordAmount))*100 else 0 end) from #tblInwordOutword2)                  
           
 declare @InwardAvg as numeric(18,2);          
 declare @OutwardAvg as numeric(18,2);          
 set @InwardAvg = (select sum(Amount)/sum(Netweight) from #tblInwordOutword1 where Category='Inward' group by Category)          
 set @OutwardAvg = (select sum(Amount)/sum(Netweight) from #tblInwordOutword1 where Category='Outward' group by Category)          
                   
 select z1.*,k.Name as Kapan,@ProfitLossPer as ProfitLossPer,         
 @InwardAvg as InwardAvg, @OutwardAvg as OutwardAvg, @OutwardAvg-@InwardAvg as PerCts,        
 tbl.TotalSizeGroupWeight        
 from(                    
 select Id, Date, SlipNo, OperationType, Size,        
 Party, convert(decimal(18,2),NetWeight) as NetWeight, convert(decimal(18,2),Rate) as Rate,                    
 convert(decimal(18,2),Amount) as Amount,Category, CategoryId, Records          
 from #tblInwordOutword1                    
 union                    
 select Id, Date, SlipNo, OperationType, Size,        
 Party, NetWeight, Rate, Amount,Category, CategoryId, Records                  
 from #tblInwordOutword2                  
 )z1                    
 inner join KapanMaster k on k.Id=@KapanId        
 left join #tblInwordOutword4 tbl on tbl.Size=z1.Size and tbl.Category=z1.Category 
GO
/****** Object:  StoredProcedure [dbo].[GetKapanReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetKapanReport]     
 @CompanyId as varchar(50),    
 @BranchId as varchar(50),    
 @FinancialYearId as varchar(50)       
AS    
BEGIN    
 --SELECT T.*, T.KapanMapingWeight  'Weight' FROM (    
 -- SELECT LOWER(ISNULL(KMM.Id, NEWID())) 'Id', ISNULL(KMM.Sr,0) 'Sr', ISNULL(KMM.CompanyId,'') 'CompanyId', ISNULL(KMM.FinancialYearId,'') 'FinancialYearId', ISNULL(KMM.BranchId,'') 'BranchId', ISNULL(KMM.SlipNo,0) 'SlipNo',     
 -- KM.Id 'KapanId', KM.Name, ISNULL(KMM.Weight,0) KapanMapingWeight,     
 -- KM.CreatedBy, KM.CreatedDate, KM.UpdatedBy, KM.UpdatedDate FROM KapanMaster KM    
 -- LEFT JOIN  KapanMappingMaster KMM ON KMM.KapanId = KM.Id     
 -- --WHERE (KMM.CompanyId = @CompanyId OR KMM.CompanyId IS NULL) AND (KMM.FinancialYearId = @FinancialYearId OR KMM.FinancialYearId IS NULL)    
 --)T LEFT JOIN OpeningStockMaster OSM ON OSM.KapanId = T.KapanId    
 ----Where Name = 'JB'    
 --ORDER BY T.Sr DESC    
    
 SELECT * FROM     
 (    
  SELECT LOWER(ISNULL(KMM.Id, NEWID())) 'Id', ISNULL(KMM.Sr,0) 'Sr', ISNULL(KMM.CompanyId,'') 'CompanyId', ISNULL(KMM.FinancialYearId,'') 'FinancialYearId', ISNULL(KMM.BranchId,'') 'BranchId', ISNULL(KMM.SlipNo,0) 'SlipNo',     
   KM.Id 'KapanId', KM.Name, ISNULL(KMM.Weight,0) Weight,     
   KMM.CreatedBy, KMM.CreatedDate, KMM.UpdatedBy, KMM.UpdatedDate, kMM.PurchaseDetailsId  
   FROM KapanMaster KM    
   INNER JOIN  KapanMappingMaster KMM ON KMM.KapanId = KM.Id     
  WHERE (KMM.CompanyId = @CompanyId OR KMM.CompanyId IS NULL) AND (KMM.FinancialYearId = @FinancialYearId OR KMM.FinancialYearId IS NULL) and ISNULL(KMM.TransferId,'0') = '0' --AND KMM.Weight <> 0    
    
  UNION    
    
  SELECT LOWER(ISNULL(KM.Id, NEWID())) 'Id',0 'Sr',ISNULL(OSM.CompanyId,'') 'CompanyId',ISNULL(OSM.FinancialYearId,'') 'FinancialYearId',ISNULL(OSM.BranchId,'') 'BranchId', '0' 'SlipNo',     
  KM.Id 'KapanId', KM.Name, ISNULL(OSM.TotalCts,0) 'Weight', OSM.CreatedBy, OSM.CreatedDate, OSM.UpdatedBy, OSM.UpdatedDate, '' as PurchaseDetailsId   
  From OpeningStockMaster OSM     
  INNER JOIN KapanMaster KM ON KM.Id = OSM.KapanId     
  WHERE (OSM.CompanyId = @CompanyId OR OSM.CompanyId IS NULL) AND (OSM.FinancialYearId = @FinancialYearId OR OSM.FinancialYearId IS NULL)    
  AND OSM.TotalCts <> 0    
 )T Order by Sr Desc    
    
END 
GO
/****** Object:  StoredProcedure [dbo].[GetLedgerBalanceReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetLedgerBalanceReport] --'00000000-0000-0000-0000-000000000000', '2ac16086-fb8c-4e2c-803b-1748dbe4fd30'  
     
@CompanyId as varchar(50),  
@FinancialYearId as varchar(50)  
  
AS    
BEGIN  
  SELECT PM.Type 'PartyType',  
   CASE    
    WHEN type = 1 THEN 'Party-Buy'  
    WHEN type = 14 THEN 'Party-Sale'  
    WHEN type=2 THEN 'Employee'  
    WHEN type=3 THEN 'Expense'  
    WHEN type=4 THEN 'Bank'  
    WHEN type=5 THEN 'Cash'  
    WHEN type=6 THEN 'DirectIncome'  
    WHEN type=7 THEN 'InDirectIncome'  
    WHEN type=8 THEN 'Asset'  
    WHEN type=9 THEN 'Deposit'  
    WHEN type=10 THEN 'Uchina'  
    WHEN type=11 THEN 'CapitalAccount'  
    WHEN type=12 THEN 'Investment'  
    WHEN type=13 THEN 'Loan'    
   END AS Type,  
   CASE  
    WHEN SubType=6 THEN 'Buyer'  
    WHEN SubType=7 THEN 'Seller'  
    WHEN SubType=8 THEN 'Broker'  
    WHEN SubType=9 THEN 'Other'  
   END AS SubType,   
  
   LBM.Id, PM.Name, LBM.CompanyId, LBM.FinancialYearId, LBM.LedgerId, LBM.Balance 'OpeningBalance', ISNULL(Purchase.Amount,0) 'PurchaseAmount', ISNULL(Brokerage.Amount, 0) 'Brokerage',  
   ISNULL(Sales.Amount,0) 'SalesAmount', ISNULL(PaymentFrom.Amount,0) 'PaymentFrom', ISNULL(PaymentTo.Amount,0) 'PaymentTo',  
   ISNULL(ReceiptFrom.Amount, 0) 'ReceiptFrom', ISNULL(ReceivedTo.Amount, 0) 'ReceiptTo',      
     
   (LBM.Balance + ISNULL(LoansReceive.Amount, 0) - ISNULL(LoansGiven.Amount, 0) + ISNULL(Sales.Amount,0) + ISNULL(Purchase.Amount,0)   
   + ISNULL(ReceiptFrom.Amount, 0) - ISNULL(PaymentTo.Amount,0) - ISNULL(PaymentFrom.Amount,0) + ISNULL(ReceivedTo.Amount, 0) +   
   ISNULL(Salary.Amount, 0) + ISNULL(Brokerage.Amount, 0) + ISNULL(Buyer.Amount,0) + ISNULL(Saler.Amount, 0)) 'ClosingBalance'  
     
   FROM LedgerBalanceManager LBM  


    LEFT JOIN   
    (  
     SELECT 'Purchase' RecType, PartyId 'FromPartyId', PM.Name, CAST(ISNULL(SUM(GrossTotal),0) AS DECIMAL(18,2)) 'Amount' From PurchaseMaster P  
     INNER JOIN PartyMaster PM ON PM.Id = P.PartyId  
     WHERE P.IsDelete=0 AND P.FinancialYearId = @FinancialYearId AND p.CompanyId = @CompanyId  
     Group by PartyId, PM.Name  
    )Purchase ON LBM.LedgerId = Purchase.FromPartyId  
  
    LEFT JOIN  
    (  
     SELECT 'Brokerage' RecType, P.BrokerageId 'FromPartyId', PM.Name, CAST(ISNULL(SUM(BrokerAmount),0) AS DECIMAL(18,2)) 'Amount' FROM PurchaseMaster P  
     INNER JOIN PartyMaster PM ON PM.Id = P.BrokerageId  
     WHERE P.IsDelete=0 AND P.FinancialYearId = @FinancialYearId AND p.CompanyId = @CompanyId  
     GROUP BY P.BrokerageId, PM.Name  
    ) Brokerage ON LBM.LedgerId = Brokerage.FromPartyId  

	LEFT JOIN
	(
		SELECT 'CommissionBuyer' RecType, P.ByuerId 'FromPartyId', PM.Name, CAST(ISNULL(SUM(CommissionAmount),0) AS DECIMAL(18,2)) 'Amount' FROM PurchaseMaster P
		INNER JOIN PartyMaster PM ON PM.Id = P.ByuerId
		WHERE P.IsDelete=0 AND P.FinancialYearId = @FinancialYearId AND p.CompanyId = @CompanyId
		GROUP BY P.ByuerId, PM.Name
	) Buyer ON LBM.LedgerId = Buyer.FromPartyId

	LEFT JOIN
	(
		SELECT 'CommissionSeller' RecType, S.SalerId 'FromPartyId', PM.Name, CAST(ISNULL(SUM(CommissionAmount),0) AS DECIMAL(18,2)) 'Amount' FROM SalesMaster S
		INNER JOIN PartyMaster PM ON PM.Id = S.SalerId
		WHERE S.IsDelete=0 AND S.FinancialYearId = @FinancialYearId AND S.CompanyId = @CompanyId
		GROUP BY S.SalerId, PM.Name
	) Saler ON LBM.LedgerId = Saler.FromPartyId
  
    LEFT JOIN   
    (  
     --Received From  
     SELECT FromPartyId, Name, SUM(Amount) 'Amount' FROM (  
      select MainTable.FromPartyId, Name, amount 'Amount' from (  
       select g.id, g.companyid, g.financialyearid, p.FromPartyId, p.amount from grouppaymentmaster g  
       inner join paymentmaster p on g.id = p.groupid   
       where g.crdrtype=1 AND g.IsDelete=0 AND g.FinancialYearId = @FinancialYearId AND g.CompanyId = @CompanyId  
      )MainTable  
      inner join PartyMaster pm on pm.Id = MainTable.FromPartyId  
       
        )T         
  
     GRoup by  FromPartyId, name  
  
    )ReceiptFrom ON LBM.LedgerId = ReceiptFrom.FromPartyId  
  
    LEFT JOIN  
    (  
     SELECT ToPartyId, Name, SUM(Amount) 'Amount' FROM (  
      select MainTable.ToPartyId, Name, amount from (  
       select g.id, g.companyid, g.financialyearid, g.ToPartyId, p.amount from grouppaymentmaster g  
       inner join paymentmaster p on g.id = p.groupid   
       where g.crdrtype=1 AND g.IsDelete = 0 AND g.FinancialYearId = @FinancialYearId AND g.CompanyId = @CompanyId  
      ) MainTable  
      inner join PartyMaster pm on pm.Id = MainTable.ToPartyId  
  
      UNION ALL  
  
      SELECT CED.FromParty 'ToPartyId', PM.Name, CED.Amount From ContraEntryMaster CEM   
       Inner JOIN ContraEntryDetails CED ON CEM.Id = CED.ContraEntryMasterId  
       INNER JOIN PartyMaster PM ON CED.FromParty = PM.Id  
       WHERE CEM.IsDelete = 0 AND CEM.FinancialYearId = @FinancialYearId AND CEM.CompanyId = @CompanyId  

     )T  
  
     GRoup by  topartyid, name  
    )ReceivedTo ON LBM.LedgerId = ReceivedTo.ToPartyId  
  
    LEFT JOIN   
    (  
     SELECT ToPartyId, Name, SUM(Amount) 'Amount' FROM (  
  
      select MainTable.ToPartyId, name, Amount from (  
       select g.id, g.companyid, g.financialyearid, g.ToPartyId, p.amount from grouppaymentmaster g  
       inner join paymentmaster p on g.id = p.groupid   
       where g.crdrtype=0 AND g.IsDelete=0 AND g.FinancialYearId = @FinancialYearId AND g.CompanyId = @CompanyId  
      ) MainTable  
      inner join PartyMaster pm on pm.Id = MainTable.ToPartyId   
  
      UNION ALL  
  
      SELECT FromPartyId 'ToPartyId', Name, CAST(Amount as Decimal(18,2)) 'Amount' FROM ExpenseDetails ED  
       INNER JOIN PartyMaster PM ON ED.fromPartyId = PM.Id   
       WHERE ED.IsDelete= 0 AND ED.FinancialYearId = @FinancialYearId AND ED.CompanyId = @CompanyId  
  
      UNION ALL  
  
      SELECT CEM.ToPartyId 'FromPartyId', PM.Name, CED.Amount From ContraEntryMaster CEM   
        Inner JOIN ContraEntryDetails CED ON CEM.Id = CED.ContraEntryMasterId  
        INNER JOIN PartyMaster PM ON CEM.ToPartyId = PM.Id  
        WHERE CEM.IsDelete = 0 AND CEM.FinancialYearId = @FinancialYearId AND CEM.CompanyId = @CompanyId 
	
	UNION ALL

	   SELECT  CashBankPartyId 'FromPartyId', PM.Name,  CAST(Amount as DECIMAL(18,2)) 'Amount' FROM LoanMaster LM  
		 INNER JOIN PartyMaster PM ON PM.Id = LM.CashBankPartyId  
		 WHERE LM.IsDelete = 0 AND LM.LoanType=2 AND LM.CompanyId = @CompanyId
  
     ) T  
     GRoup by  topartyid, name  
  
    )PaymentFrom ON LBM.LedgerId = PaymentFrom.ToPartyId  
  
    LEFT JOIN  
    (  
     SELECT FromPartyId, Name, SUM(Amount) 'Amount' FROM (  
      select MainTable.FromPartyId, Name, amount from (  
       select g.id, g.companyid, g.financialyearid, p.FromPartyId, p.amount from grouppaymentmaster g  
       inner join paymentmaster p on g.id = p.groupid   
       where g.crdrtype=0 AND g.IsDelete = 0 AND g.FinancialYearId = @FinancialYearId AND g.CompanyId = @CompanyId  
      ) MainTable  
      inner join PartyMaster pm on pm.Id = MainTable.FromPartyId  
  
      UNION ALL  
  
      SELECT PartyId 'FromPartyId', Name, CAST(Amount as Decimal(18,2)) 'Amount' FROM ExpenseDetails ED  
       INNER JOIN PartyMaster PM ON ED.PartyId = PM.Id  
       WHERE ED.IsDelete = 0 AND ED.FinancialYearId = @FinancialYearId AND ED.CompanyId = @CompanyId 
	   
     )T      
        
     GRoup by  FromPartyId, name  
  
    )PaymentTo ON LBM.LedgerId = PaymentTo.FromPartyId  
  
    LEFT JOIN  
    (  
     SELECT PartyId, PM.Name, CAST(ISNULL(SUM(GrossTotal),0) AS DECIMAL(18,2)) 'Amount' From SalesMaster S  
     INNER JOIN PartyMaster PM ON PM.Id = S.PartyId  
     WHERE S.IsDelete=0 AND S.CompanyId=@CompanyId AND S.FinancialYearId = @FinancialYearId  
     Group by PartyId, PM.Name  
    )Sales ON LBM.LedgerId = Sales.PartyId  
  
    LEFT JOIN  
    (  
     SELECT CashBankPartyId 'PartyId', PM.Name,  CAST(ISNULL(SUM(Amount),0) AS DECIMAL(18,2)) 'Amount' FROM LoanMaster LM  
     INNER JOIN PartyMaster PM ON PM.Id = LM.CashBankPartyId  
     WHERE LM.LoanType=1 AND LM.CompanyId = @CompanyId  
     GROUP BY CashBankPartyId, PM.Name  
    ) LoansReceive ON LBM.LedgerId = LoansReceive.PartyId  
  
    LEFT JOIN  
    (  
     SELECT  PartyId, PM.Name,  CAST(ISNULL(SUM(Amount),0) AS DECIMAL(18,2)) 'Amount' FROM LoanMaster LM  
     INNER JOIN PartyMaster PM ON PM.Id = LM.PartyId  
     WHERE LM.LoanType=2 AND LM.CompanyId = @CompanyId  
     GROUP BY PartyId, PM.Name  
    ) LoansGiven ON LBM.LedgerId = LoansGiven.PartyId

    LEFT JOIN   
    (  
     SELECT ToPartyId 'PartyId', PM.Name, CAST(ISNULL(SUM(TotalAmount),0) AS Decimal(18,2)) 'Amount' FROM SalaryDetails SD  
      INNER JOIN PartyMaster PM ON SD.ToPartyId = PM.Id  
      INNER JOIN SalaryMaster SM ON SM.Id = SD.SalaryMasterId  
      WHERE SM.CompanyId=@CompanyId AND SM.FinancialYearId = @FinancialYearId  
      GROUP BY ToPartyId, PM.Name  
    ) Salary ON LBM.LedgerId = Salary.PartyId  
  
   INNER JOIN PartyMaster PM ON PM.Id = LBM.LedgerId  
  
  WHERE PM.IsDelete= 0 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId  
  --AND LBM.Ledgerid='d0cd20d4-544f-4eff-a0d7-7151ad85a744'  
  Order By PM.Name ASC  
  
END  
  
GO
/****** Object:  StoredProcedure [dbo].[GetLedgerChildReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Exec GetLedgerChildReport 'c444ca9f-03ec-493f-9447-4e1bf15eefbf','8e34d261-0a6b-44ac-9f86-89d5fdd5ef56','02d1865c-0415-491b-95e3-fce214b5c5fa'            
CREATE proc [dbo].[GetLedgerChildReport]    
               
@CompanyId as varchar(50),            
@FinancialYearId as varchar(50),            
@LedgerId as varchar(50)            
            
AS              
BEGIN            
            
SELECT 'OpeningBalance' 'EntryType', '' 'FromPartyId', '' 'FromPartyName', '' 'ToPartyId', '' 'ToPartyName', '' 'SlipNo', 
(CASE WHEN PM.CRDRType = 0 THEN Balance ELSE 0 END) 'Debit', 
(CASE WHEN PM.CRDRType = 1 THEN Balance ELSE 0 END) 'Credit', CAST(LBM.CreatedDate as Date) 'Date', '' Remarks From LedgerBalanceManager LBM INNER JOIN PartyMaster PM
ON LBM.LedgerId = PM.Id
WHERE LedgerId = @LedgerId            
            
UNION  ALL          
            
SELECT * FROM (            
            
 SELECT 'Contra' 'EntryType', CEM.ToPartyId 'FromPartyId', PM.Name 'FromPartyName', CED.FromParty 'ToPartyId', PM1.Name 'ToPartyName','' 'SlipNo', CED.Amount 'Debit', 0 'Credit', CAST(CEM.Entrydate as Date) 'Date', Remarks From ContraEntryMaster CEM      
  
    
      
       
 Inner JOIN ContraEntryDetails CED ON CEM.Id = CED.ContraEntryMasterId            
 INNER JOIN PartyMaster PM ON CEM.ToPartyId = PM.Id            
 INNER JOIN PartyMaster PM1 ON CED.FromParty = PM1.Id            
            
 WHERE CEM.IsDelete = 0 AND CEM.ToPartyId = @LedgerId AND CEM.FinancialYearId = @FinancialYearId AND CEM.CompanyId = @CompanyId            
            
 UNION ALL            
            
 SELECT 'Contra' 'EntryType',  CEM.ToPartyId 'FromPartyId', PM1.Name 'FromPartyName', CED.FromParty 'ToPartyId', PM.Name 'ToPartyName','' 'SlipNo', 0 'Debit', CED.Amount 'Credit', CAST(CEM.EntryDate as Date) 'Date', Remarks From ContraEntryMaster CEM     
  
    
      
        
 Inner JOIN ContraEntryDetails CED ON CEM.Id = CED.ContraEntryMasterId            
 INNER JOIN PartyMaster PM ON CED.FromParty = PM.Id            
 INNER JOIN PartyMaster PM1 ON CEM.ToPartyId = PM1.Id            
            
 WHERE CEM.IsDelete = 0 AND CED.FromParty = @LedgerId AND CEM.FinancialYearId = @FinancialYearId AND CEM.CompanyId = @CompanyId            
            
 UNION ALL            
             
 SELECT 'Receipt' 'EntryType', MainTable.FromPartyId, pm.Name 'FromPartyName', MainTable.ToPartyId, PM1.Name 'ToPartyName', ISNULL(SlipNo, '') 'SlipNo', 0 'Debit', Amount 'Credit',  MainTable.Date, Remarks            
 FROM (            
  SELECT (case when pd.SlipNo=-2 then convert(varchar,pd.SlipNo)+'-'+convert(varchar,g.BillNo) else pd.SlipNo end) 'SlipNo',     
  g.id, g.companyid, g.financialyearid, p.FromPartyId, g.ToPartyId, CASE WHEN ISNULL(pd.amount,0) = 0 THEN p.Amount ELSE pd.Amount END as 'amount', CAST(g.EntryDate as Date) 'Date', g.Remarks FROM grouppaymentmaster g            
   INNER JOIN paymentmaster p on g.id = p.groupid             
   left join paymentdetails pd on pd.groupid = g.id and pd.PaymentId=p.Id        
   WHERE g.crdrtype=1 AND g.IsDelete=0 AND g.FinancialYearId = @FinancialYearId AND g.CompanyId = @CompanyId            
  ) MainTable            
            
 INNER JOIN PartyMaster pm on pm.Id = MainTable.FromPartyId            
 INNER JOIN PartyMaster PM1 ON PM1.Id = MainTable.ToPartyId            
            
 WHERE FromPartyId = @LedgerId             
            
 UNION ALL          
            
 SELECT 'Receipt' 'EntryType', MainTable.FromPartyId, PM1.Name 'FromPartyName', MainTable.ToPartyId, pm.Name 'ToPartyName',ISNULL(SlipNo, '') 'SlipNo', 0 'Debit', Amount 'Credit', MainTable.Date, Remarks             
 FROM (            
   SELECT (case when pd.SlipNo=-2 then convert(varchar,pd.SlipNo)+'-'+convert(varchar,g.BillNo) else pd.SlipNo end) 'SlipNo',    
    g.id, g.companyid, g.financialyearid, p.FromPartyId, g.ToPartyId, CASE WHEN ISNULL(pd.amount,0) = 0 THEN p.Amount ELSE pd.Amount END as 'amount', CAST(g.EntryDate as Date) 'Date', g.Remarks from grouppaymentmaster g            
   INNER JOIN paymentmaster p on g.id = p.groupid             
   left join paymentdetails pd on pd.groupid = g.id and pd.PaymentId=p.Id                
   WHERE g.crdrtype=1 AND g.IsDelete = 0 AND g.FinancialYearId = @FinancialYearId AND g.CompanyId = @CompanyId            
  ) MainTable            
            
 INNER JOIN PartyMaster pm on pm.Id = MainTable.ToPartyId            
 INNER JOIN PartyMaster PM1 ON PM1.Id = MainTable.FromPartyId            
            
 WHERE ToPartyId = @LedgerId            
            
 UNION ALL            
            
 SELECT distinct 'Payment' 'EntryType', MainTable.FromPartyId 'ToPartyId', pm.Name 'ToPartyName', MainTable.ToPartyId 'FromPartyId', PM1.Name 'FromPartyName',ISNULL(SlipNo, '') 'SlipNo', amount 'Debit', 0 'Credit', MainTable.Date, Remarks             
 FROM (            
   SELECT (case when pd.SlipNo=-2 then convert(varchar,pd.SlipNo)+'-'+convert(varchar,g.BillNo) else pd.SlipNo end) 'SlipNo',    
   pd.Sr, g.id, g.companyid, g.financialyearid, p.FromPartyId, g.ToPartyId, CASE WHEN ISNULL(pd.amount,0) = 0 THEN p.Amount ELSE pd.Amount END as 'amount', CAST(g.EntryDate as Date) 'Date', g.Remarks from grouppaymentmaster g            
   INNER join paymentmaster p on g.id = p.groupid             
   LEFT join paymentdetails pd on pd.groupid = g.id and pd.PaymentId=p.Id       
   WHERE g.crdrtype=0 AND g.IsDelete = 0 AND g.FinancialYearId = @FinancialYearId AND g.CompanyId = @CompanyId            
   --order by g.EntryDate,pd.Sr      
  ) MainTable            
 INNER JOIN PartyMaster pm on pm.Id = MainTable.FromPartyId            
 INNER JOIN PartyMaster PM1 ON PM1.Id = MainTable.ToPartyId            
 WHERE FromPartyId = @LedgerId            
            
 UNION ALL            
            
 SELECT distinct 'Payment' 'EntryType', MainTable.FromPartyId, pm.Name 'FromPartyName', MainTable.ToPartyId, PM1.Name 'ToPartyName', ISNULL(SlipNo, '') 'SlipNo', amount 'Debit', 0 'Credit', MainTable.Date, Remarks              
 FROM (            
   SELECT (case when pd.SlipNo=-2 then convert(varchar,pd.SlipNo)+'-'+convert(varchar,g.BillNo) else pd.SlipNo end) 'SlipNo',    
   g.id, g.companyid, g.financialyearid, p.FromPartyId, g.ToPartyId, CASE WHEN ISNULL(pd.amount,0) = 0 THEN p.Amount ELSE pd.Amount END as 'amount', CAST(g.EntryDate as Date) 'Date', g.Remarks from grouppaymentmaster g            
   INNER JOIN paymentmaster p on g.id = p.groupid             
   LEFT JOIN paymentdetails pd on pd.groupid = g.id and pd.PaymentId=p.Id                 
   WHERE g.crdrtype=0 AND g.IsDelete = 0 AND g.FinancialYearId = @FinancialYearId AND g.CompanyId = @CompanyId            
  ) MainTable            
            
 INNER JOIN PartyMaster pm on pm.Id = MainTable.ToPartyId            
 INNER JOIN PartyMaster PM1 ON PM1.Id = MainTable.FromPartyId            
            
 WHERE ToPartyId = @LedgerId            
            
 UNION ALL            
            
 SELECT 'Expense' 'EntryTpe',FromPartyId, PM.Name 'FromPartyName', PartyId 'ToPartyId', PM1.Name 'ToPartyName','' 'SlipNo',  CAST(Amount as Decimal(18,2)) 'Debit', 0 'Credit', CAST(ED.EntryDate as date) 'Date', Remarks FROM ExpenseDetails ED            
 INNER JOIN PartyMaster PM ON ED.fromPartyId = PM.Id            
 INNER JOIN PartyMaster PM1 ON ED.PartyId = PM1.Id            
            
 WHERE ED.IsDelete = 0 AND PM.IsDelete=0 AND PM1.IsDelete=0 AND FromPartyId = @LedgerId AND ED.FinancialYearId = @FinancialYearId AND ED.CompanyId = @CompanyId            
            
 UNION ALL            
            
 SELECT 'Expense' 'EntryTpe',FromPartyId, PM.Name 'FromPartyName', PartyId 'ToPartyId', PM1.Name 'ToPartyName','' 'SlipNo',  CAST(Amount as Decimal(18,2)) 'Debit', 0 'Credit', CAST(ED.EntryDate as date) 'Date', Remarks FROM ExpenseDetails ED            
 INNER JOIN PartyMaster PM ON ED.fromPartyId = PM.Id            
 INNER JOIN PartyMaster PM1 ON ED.PartyId = PM1.Id            
            
 WHERE ED.IsDelete = 0 AND PM.IsDelete=0 AND PM1.IsDelete=0 AND PartyId = @LedgerId AND ED.FinancialYearId = @FinancialYearId AND ED.CompanyId = @CompanyId            
            
 UNION ALL            
            
 SELECT 'Purchase' 'EntryType', PartyId 'FromPartyId', PM1.Name 'FromPartyName', '' 'ToPartyId', '' 'ToPartyName',CAST(SlipNo as nvarchar(max)) 'SlipNo',  0 'Debit', CAST(GrossTotal as Decimal(18,2)) 'Credit', CAST([Date] as Date) 'Date', Remarks FROM PurchaseMaster PM            
 INNER JOIN PartyMaster PM1 ON PM.PartyId = PM1.Id            
            
 WHERE PM.IsDelete = 0 AND PM1.IsDelete=0 AND PartyId = @LedgerId AND PM.FinancialYearId = @FinancialYearId AND PM.CompanyId = @CompanyId            
            
 UNION ALL            
            
 SELECT 'Brokerage' 'EntryType', PartyId 'FromPartyId', PM1.Name 'FromPartyName', PM.BrokerageId 'ToPartyId', PM2.Name 'ToPartyName',CAST(SlipNo as nvarchar(max)) 'SlipNo',  0 'Debit', CAST(BrokerAmount as Decimal(18,2)) 'Credit', CAST([Date] as Date) 'Date', Remarks FROM PurchaseMaster PM            
 INNER JOIN PartyMaster PM1 ON PM.PartyId = PM1.Id            
 INNER JOIN PartyMaster PM2 ON PM.BrokerageId = PM2.Id            
            
 WHERE PM.IsDelete = 0 AND PM1.IsDelete=0 AND PM2.IsDelete=0 AND PM.BrokerageId = @LedgerId AND PM.FinancialYearId = @FinancialYearId AND PM.CompanyId = @CompanyId            

 UNION ALL        

 SELECT 'CommissionBuyer' 'EntryType', PartyId 'FromPartyId', PM1.Name 'FromPartyName', PM.ByuerId 'ToPartyId', PM2.Name 'ToPartyName',CAST(SlipNo as nvarchar(max)) 'SlipNo',  0 'Debit', CAST(CommissionAmount as Decimal(18,2)) 'Credit', CAST([Date] as Date) 'Date', Remarks FROM PurchaseMaster PM        
 INNER JOIN PartyMaster PM1 ON PM.PartyId = PM1.Id        
 INNER JOIN PartyMaster PM2 ON PM.ByuerId = PM2.Id        
        
 WHERE PM.IsDelete = 0 AND PM1.IsDelete=0 AND PM2.IsDelete=0 AND PM.ByuerId = @LedgerId AND PM.FinancialYearId = @FinancialYearId AND PM.CompanyId = @CompanyId

 UNION ALL

 SELECT 'CommissionSaler' 'EntryType', PartyId 'FromPartyId', PM1.Name 'FromPartyName', SM.SalerId 'ToPartyId', PM2.Name 'ToPartyName',CAST(SlipNo as nvarchar(max)) 'SlipNo',  0 'Debit', CAST(CommissionAmount as Decimal(18,2)) 'Credit', CAST([Date] as Date) 'Date', Remarks FROM SalesMaster SM        
 INNER JOIN PartyMaster PM1 ON SM.PartyId = PM1.Id        
 INNER JOIN PartyMaster PM2 ON SM.SalerId = PM2.Id        
        
 WHERE SM.IsDelete = 0 AND PM1.IsDelete=0 AND PM2.IsDelete=0 AND SM.SalerId = @LedgerId AND SM.FinancialYearId = @FinancialYearId AND SM.CompanyId = @CompanyId
            
 UNION ALL            
            
 SELECT 'Sales' 'EntryType', PartyId 'FromPartyId', PM.Name 'FromPartyName', '' 'ToPartyId', '' 'ToPartyName', CAST(SlipNo as nvarchar(max)) 'SlipNo', CAST(GrossTotal as Decimal(18,2)) 'Debit', 0 'Credit', CAST([Date] as Date) 'Date', Remarks FROM SalesMaster SM            
 INNER JOIN PartyMaster PM ON SM.PartyId = PM.Id            
            
 WHERE SM.IsDelete = 0 AND PM.IsDelete=0 AND PartyId = @LedgerId AND SM.FinancialYearId = @FinancialYearId AND SM.CompanyId = @CompanyId            
            
 UNION ALL            
            
 SELECT 'Salary' 'EntryType', '' 'FromPartyId', '' 'FromPartyName', ToPartyId, PM.Name 'ToPartyName', '0' 'SlipNo', 0 'Debit', CAST(TotalAmount as Decimal(18,2)) 'Credit', CAST(SalaryMonthDateTime as Date) 'Date', Remarks FROM SalaryDetails SD            
 INNER JOIN SalaryMaster SM ON SM.Id = SD.SalaryMasterId            
 INNER JOIN PartyMaster PM ON SD.ToPartyId = PM.Id            
 Where ToPartyId = @LedgerId AND SM.FinancialYearId = @FinancialYearId AND SM.CompanyId = @CompanyId            
            
 UNION ALL            
            
 SELECT 'Loan - Received' 'EntryType', PartyId 'FromPartyId', PM.Name 'FromPartyName', LM.CashBankPartyId 'ToPartyId', PM1.Name 'ToPartyName', '0' 'SlipNo', 0 'Debit', CAST(Amount as Decimal(18,2)) 'Credit', CAST(LM.EntryDate as Date) 'Date', Remarks FROM LoanMaster LM            
 INNER JOIN PartyMaster PM1 ON PM1.Id = LM.CashBankPartyId            
 INNER JOIN PartyMaster PM ON LM.PartyId = PM.Id            
 Where LM.IsDelete = 0 AND PM.IsDelete = 0 AND PM1.IsDelete = 0 AND LM.PartyId = @LedgerId AND LM.LoanType = 1 AND LM.CompanyId = @CompanyId              
 UNION ALL            
            
 SELECT 'Loan - Given' 'EntryType', LM.PartyId 'FromPartyId', PM1.Name 'FromPartyName', LM.CashBankPartyId 'ToPartyId', PM.Name 'ToPartyName', '0' 'SlipNo', 0  'Debit', CAST(Amount as Decimal(18,2)) 'Credit', CAST(LM.EntryDate as Date) 'Date', Remarks FROM LoanMaster LM            
 INNER JOIN PartyMaster PM1 ON PM1.Id = LM.PartyId            
 INNER JOIN PartyMaster PM ON LM.CashBankPartyId = PM.Id            
 Where LM.IsDelete = 0 AND PM.IsDelete = 0 AND PM1.IsDelete = 0 AND LM.PartyId = @LedgerId AND  LM.LoanType = 2 AND LM.CompanyId = @CompanyId            
            
 UNION ALL            
            
 SELECT 'Loan - Received' 'EntryType', PartyId 'FromPartyId', PM.Name 'FromPartyName', LM.CashBankPartyId 'ToPartyId', PM1.Name 'ToPartyName', '0' 'SlipNo', 0 'Debit', CAST(Amount as Decimal(18,2)) 'Credit', CAST(LM.EntryDate as Date) 'Date', Remarks FROM LoanMaster LM            
 INNER JOIN PartyMaster PM1 ON PM1.Id = LM.CashBankPartyId            
 INNER JOIN PartyMaster PM ON LM.PartyId = PM.Id            
 Where LM.IsDelete = 0 AND PM.IsDelete = 0 AND PM1.IsDelete = 0 AND LM.CashBankPartyId = @LedgerId AND LM.LoanType = 1 AND LM.CompanyId = @CompanyId            
            
 UNION ALL            
            
 SELECT 'Loan - Given' 'EntryType', LM.CashBankPartyId 'FromPartyId', PM.Name 'FromPartyName', LM.PartyId 'ToPartyId', PM1.Name 'ToPartyName', '0' 'SlipNo', CAST(Amount as Decimal(18,2))  'Debit', 0 'Credit', CAST(LM.EntryDate as Date) 'Date', Remarks 
FROM LoanMaster LM            
 INNER JOIN PartyMaster PM1 ON PM1.Id = LM.PartyId            
 INNER JOIN PartyMaster PM ON LM.CashBankPartyId = PM.Id            
 Where LM.IsDelete = 0 AND PM.IsDelete = 0 AND PM1.IsDelete = 0 AND LM.CashBankPartyId = @LedgerId AND  LM.LoanType = 2 AND LM.CompanyId = @CompanyId            
            
)T order by date asc            
END 
GO
/****** Object:  StoredProcedure [dbo].[GetLoanReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[GetLoanReport] 
	@CompanyId varchar(50)	
AS
BEGIN
	SELECT CAST(L.EntryDate as Date) EntryDate, EntryTime, L.id, L.Sr, L.CompanyId, C.Name as CompanyName, CASE WHEN LoanType = 1 THEN 'Received' ELSE 'GIVEN' END 'LoanType', PartyId, P.Name as PartyName, CashBankPartyId, P1.Name 'CashBankName', Amount, DuratonType, StartDate, EndDate, InterestRate, TotalInterest, NetAmount, Remarks, L.IsDelete, L.CreatedDate, L.UpdatedDate, L.CreatedBy, L.UpdatedBy FROM LoanMaster as L
	INNER JOIN PartyMaster as P ON L.PartyId = P.Id 
	INNER JOIN PartyMaster as P1 ON L.CashBankPartyId = P1.Id
	INNER JOIN CompanyMaster as C ON L.CompanyId = C.Id
	WHERE C.Id = @CompanyId AND L.IsDelete=0
	ORDER BY Sr
END

GO
/****** Object:  StoredProcedure [dbo].[GetMixedRepot]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMixedRepot]   
 @CompanyId as varchar(50),          
 @FinancialYearId as varchar(50),  
 @FromDate as date = '',  
 @ToDate as date = ''  
AS  
BEGIN  
 SET NOCOUNT ON;  
  
    select * from(  
   SELECT M.EntryDate, M.Id, M.FromPartyId, M.FromName, M.ToPartyId, PM1.Name as ToName, '' as Debit, M.Amount as Credit, M.CreatedDate, M.CompanyId, M.FinancialYearId,   
   case WHEN M.CrDrType = 1 then 'Receipt' END as TrType, M.Remarks FROM   
    (SELECT CAST(G.EntryDate AS Date) 'EntryDate', G.CrDrType, G.CompanyId, G.FinancialYearId, G.Id as GroupId, P.Id, PM.Name as FromName, P.Amount, P.FromPartyId, G.ToPartyId, P.ChequeNo, P.ChequeDate, G.Remarks, G.CreatedDate, G.UpdatedDate, G.UpdatedBy
  
    FROM [PaymentMaster] as P INNER JOIN GroupPaymentMaster as G ON P.GroupId = G.Id  
    INNER JOIN [PartyMaster] AS PM ON PM.Id = P.FromPartyId   
    WHERE G.CrDrType = 1 AND G.IsDelete=0  
    AND (CAST(G.EntryDate as Date) >= @FromDate AND CAST(G.EntryDate as Date) <= @ToDate)) AS M  
   INNER JOIN [PartyMaster] AS PM1 ON PM1.Id = M.ToPartyId  
  
   UNION  
  
   SELECT M.EntryDate, M.Id, M.ToPartyId, PM1.Name as FromName, M.FromPartyId, M.FromName as ToName, M.Amount as Debit, '' as Credit, M.CreatedDate, M.CompanyId, M.FinancialYearId,   
   case when M.CrDrType = 0 then 'Payment' END as TrType, M.Remarks  FROM   
    (SELECT CAST(G.EntryDate AS Date) 'EntryDate', G.CrDrType, G.CompanyId, G.FinancialYearId, G.Id as GroupId, P.Id, PM.Name as FromName, P.Amount, P.FromPartyId, G.ToPartyId, P.ChequeNo, P.ChequeDate, G.Remarks, G.CreatedDate, G.UpdatedDate, G.UpdatedBy
   
    FROM [PaymentMaster] as P INNER JOIN GroupPaymentMaster as G ON P.GroupId = G.Id  
    INNER JOIN [PartyMaster] AS PM ON PM.Id = P.FromPartyId   
    WHERE G.CrDrType = 0 and G.IsDelete=0  
    AND (CAST(G.EntryDate as Date) >= @FromDate AND CAST(G.EntryDate as Date) <= @ToDate)) AS M  
   INNER JOIN [PartyMaster] AS PM1 ON PM1.Id = M.ToPartyId  
   union  
  
   SELECT CAST(ED.EntryDate AS Date) 'EntryDate',ED.Id, FromPartyId, PM1.Name as FromName, PartyId as ToPartyId, PM.Name as ToName,  Amount as Debit, CAST(0 as float) as Credit, ED.CreatedDate, ED.CompanyId, ED.FinancialYearId, 'Expense' as TrType, ED.Remarks  
   FROM [ExpenseDetails] ED  
   INNER JOIN PartyMaster PM ON PM.Id = ED.PartyId  
   INNER JOIN PartyMaster PM1 ON PM1.Id = ED.fromPartyId  
   WHERE ED.IsDelete=0   
   AND(CAST(ED.EntryDate as Date) >= @FromDate AND CAST(ED.EntryDate as Date) <= @ToDate)  
  
   UNION  
  
   SELECT M.EntryDate, M.Id, M.FromPartyId, PM1.Name as FromName, M.ToPartyId, M.ToPartyName as ToName, Amount as Debit, Amount as Credit, M.CreatedDate,M.CompanyId, M.FinancialYearId, 'Contra' as TrType, M.Remarks  FROM (   
    SELECT CAST(CEM.EntryDate AS Date) 'EntryDate', CEM.Id AS ContraId, CEM.CompanyId, CEM.FinancialYearId, CED.Id, CED.FromParty AS FromPartyId, CEM.ToPartyId, PM.Name AS ToPartyName, CED.Amount, CEM.Remarks, CED.CreatedDate, CEM.UpdatedDate, CEM.UpdatedBy from [ContraEntryMaster] AS CEM  
    INNER JOIN [ContraEntryDetails] AS CED ON CEM.Id = CED.ContraEntryMasterId  
    INNER JOIN [PartyMaster] AS PM ON PM.Id = CEM.ToPartyId  
    WHERE CEM.IsDelete=0  
    AND (CAST(CEM.EntryDate as Date) >= @FromDate AND CAST(CEM.EntryDate as Date) <= @ToDate)) as M  
   INNER JOIN [PartyMaster] as PM1 ON PM1.Id = M.FromPartyId) as table1  
  
 WHERE CompanyId = @CompanyId and FinancialYearId = @FinancialYearId   
   
 ORDER BY EntryDate DESC  
  
END  
GO
/****** Object:  StoredProcedure [dbo].[GetNumberProcessReceiveDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetNumberProcessReceiveDetail]    
        
@ReceivedFrom as varchar(50),    
@CompanyId as varchar(50),            
@BranchId as varchar(50),        
@FinancialYear as varchar(50)     
          
as            
            
select * from(          
select n.NumberNo,n.KapanId,k.Name'Kapan',n.ShapeId,s.Name'Shape',n.SizeId,sz.Name'Size',n.PurityId,p.Name'Purity',    
n.GalaNumberID,gm.Name'GalaNumber',sum(n.Weight)'Weight',n.FinancialYearId,n.CharniSizeId,sz1.Name'CharniSize',            
sum(n.Weight)-isnull((select sum(n1.NumberWeight)+sum(n1.LossWeight)+sum(n1.RejectionWeight) from NumberProcessMaster n1          
where n1.NumberProcessType =1    
and n1.NumberNo = n.NumberNo and n1.CompanyId=n.CompanyId --and n1.BranchId=n.BranchId   
and n1.FinancialYearId=n.FinancialYearId    
and n1.GalaNumberId=n.GalaNumberId and n1.KapanId=n.KapanId and n1.ShapeId=n.ShapeId and n1.SizeId=n.SizeId and n1.PurityId=n.PurityId    
and n1.CharniSizeId=n.CharniSizeId),0)'AvailableWeight',         
STUFF(            
(SELECT ',' + convert(varchar,n1.SlipNo)            
FROM NumberProcessMaster n1            
Where n1.NumberProcessType=0 and n1.NumberNo = n.NumberNo and n1.CompanyId=n.CompanyId --and n1.BranchId=n.BranchId   
and n1.FinancialYearId=n.FinancialYearId    
and n1.GalaNumberId=n.GalaNumberId and n1.KapanId=n.KapanId and n1.ShapeId=n.ShapeId and n1.SizeId=n.SizeId and n1.PurityId=n.PurityId
and n1.CharniSizeId=n.CharniSizeId
FOR XML PATH('')),1,1,'') AS SlipNo,          
n.KapanId+n.ShapeId+n.SizeId+n.PurityId+CONVERT(nvarchar(10),n.NumberNo)+n.GalaNumberID+n.CharniSizeId as 'ID'             
from NumberProcessMaster n            
left join KapanMaster k on k.Id=n.KapanId    
left join ShapeMaster s on s.Id=n.ShapeId    
left join SizeMaster sz on sz.Id=n.SizeId    
left join PurityMaster p on p.Id=n.PurityId    
left join GalaMaster gm on gm.Id=n.GalaNumberID            
left join SizeMaster sz1 on sz1.Id=n.CharniSizeId
where n.NumberProcessType=0    
and n.HandOverToId=@ReceivedFrom and n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYear    
group by n.NumberNo,n.KapanId,k.Name,n.ShapeId,s.Name,n.SizeId,sz.Name,n.PurityId,p.Name,n.GalaNumberID,gm.Name,n.FinancialYearId,n.CompanyId,n.CharniSizeId,sz1.Name--,n.BranchId          
)x            
where AvailableWeight<>0 
GO
/****** Object:  StoredProcedure [dbo].[GetNumberProcessReturnDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetNumberProcessReturnDetail]    
    
@CompanyId as varchar(50),            
@BranchId as varchar(50),        
@FinancialYear as varchar(50)     
    
as             
      
select x.* from(            
select       
STUFF(            
(SELECT ',' + convert(nvarchar(MAX),n1.SlipNo)            
FROM NumberProcessMaster n1      
WHERE n1.NumberProcessType=n.NumberProcessType and n1.CompanyId=n.CompanyId --and n1.BranchId=n.BranchId     
and n1.FinancialYearId=n.FinancialYearId    
and n1.KapanId=n.KapanId and n1.ShapeId=n.ShapeId and n1.SizeId=n.SizeId    
and n1.PurityId=n.PurityId and n1.NumberID=n.NumberID and isnull(n1.CharniSizeId,'')=isnull(n.CharniSizeId,'')   
order by n1.SlipNo      
for xml path(''),TYPE).value('.', 'varchar(MAX)'),1,1,'') AS SlipNo,      
n.KapanId,k.Name'Kapan',n.ShapeId,s.Name'Shape',n.SizeId,sz.Name'Size',n.PurityId,p.Name'Purity',    
n.NumberId,nm.Name'Number',n.FinancialYearId,n.CharniSizeId,sz1.Name'CharniSize',            
sum(n.NumberWeight)'Weight',    
sum(n.NumberWeight)-isnull((select sum(n2.NumberWeight)    
FROM NumberProcessMaster n2      
WHERE n2.CompanyId=n.CompanyId --and n2.BranchId=n.BranchId     
and n2.FinancialYearId=n.FinancialYearId    
and n2.KapanId=n.KapanId and n2.ShapeId=n.ShapeId and n2.SizeId=n.SizeId    
and n2.PurityId=n.PurityId and n2.NumberId=n.NumberId   
and n2.CharniSizeId=n.CharniSizeId and n2.NumberProcessType=2),0)'AvailableWeight',            
n.KapanId+n.ShapeId+n.SizeId+n.PurityId+n.CompanyId+n.FinancialYearId+n.NumberId+n.CharniSizeId as 'ID'         --+n.BranchId    
from NumberProcessMaster n     
left join KapanMaster k on k.Id=n.KapanId    
left join ShapeMaster s on s.Id=n.ShapeId    
left join SizeMaster sz on sz.Id=n.SizeId    
left join PurityMaster p on p.Id=n.PurityId            
left join NumberMaster nm on nm.Id=n.NumberID    
left join SizeMaster sz1 on sz1.Id=n.CharniSizeId  
where n.NumberProcessType=1      
and n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYear    
group by n.KapanId,k.Name,n.ShapeId,s.Name,n.SizeId,sz.Name,n.PurityId,p.Name,n.CompanyId,n.FinancialYearId,n.NumberId,nm.Name,n.NumberProcessType,n.CharniSizeId,sz1.Name--,n.BranchId    
)x             
where AvailableWeight<>0 
GO
/****** Object:  StoredProcedure [dbo].[GetNumberProcessSendToDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetNumberProcessSendToDetail]    
    
@CompanyId as varchar(50),            
@BranchId as varchar(50),        
@FinancialYear as varchar(50)     
    
as             
      
select * from(            
select       
STUFF(            
(SELECT ',' + convert(nvarchar(MAX),g1.SlipNo)            
FROM GalaProcessMaster g1      
WHERE g1.GalaProcessType=g.GalaProcessType and g1.CompanyId=g.CompanyId --and g1.BranchId=g.BranchId     
and g1.FinancialYearId=g.FinancialYearId    
and g1.KapanId=g.KapanId and g1.ShapeId=g.ShapeId and g1.SizeId=g.SizeId    
and g1.PurityId=g.PurityId and g1.GalaNumberID=g.GalaNumberId and g1.CharniSizeId=g.CharniSizeId    
order by g1.SlipNo      
for xml path(''),TYPE).value('.', 'varchar(MAX)'),1,1,'') AS SlipNo,      
g.KapanId,k.Name'Kapan',g.ShapeId,s.Name'Shape',g.SizeId,sz.Name'Size',g.PurityId,p.Name'Purity',    
g.GalaNumberId,gm.Name'GalaNumber',g.FinancialYearId,g.CharniSizeId,sz1.Name'CharniSize',            
sum(g.GalaWeight)'Weight',sum(g.GalaWeight)-isnull((select sum(n.Weight)           
from NumberProcessMaster n           
where n.NumberProcessType=0 and n.CompanyId=g.CompanyId --and n.BranchId=g.BranchId     
and n.FinancialYearId=g.FinancialYearId    
and n.KapanId=g.KapanId and n.ShapeId=g.ShapeId and n.SizeId=g.SizeId    
and n.PurityId=g.PurityId and n.GalaNumberID=g.GalaNumberId
and n.CharniSizeId=g.CharniSizeId),0)    
-isnull((select sum(GalaWeight)    
FROM GalaProcessMaster g2      
WHERE g2.CompanyId=g.CompanyId --and g2.BranchId=g.BranchId     
and g2.FinancialYearId=g.FinancialYearId    
and g2.KapanId=g.KapanId and g2.ShapeId=g.ShapeId and g2.SizeId=g.SizeId    
and g2.PurityId=g.PurityId and g2.GalaNumberID=g.GalaNumberId and g2.GalaProcessType=2 and g2.CharniSizeId=g.CharniSizeId),0)'AvailableWeight',            
g.KapanId+g.ShapeId+g.SizeId+g.PurityId+g.GalaNumberId+g.CompanyId+g.FinancialYearId+g.CharniSizeId as 'ID'         --+g.BranchId    
from GalaProcessMaster g            
left join KapanMaster k on k.Id=g.KapanId    
left join ShapeMaster s on s.Id=g.ShapeId    
left join SizeMaster sz on sz.Id=g.SizeId    
left join PurityMaster p on p.Id=g.PurityId    
left join GalaMaster gm on gm.Id=g.GalaNumberID            
left join SizeMaster sz1 on sz1.Id=g.CharniSizeId
where g.GalaProcessType=1      
and g.CompanyId=@CompanyId and g.FinancialYearId=@FinancialYear    
group by g.KapanId,k.Name,g.ShapeId,s.Name,g.SizeId,sz.Name,g.PurityId,p.Name,gm.Name,g.GalaProcessType,g.CompanyId,g.FinancialYearId,g.GalaNumberId,g.CharniSizeId,sz1.Name--,g.BranchId    
)x             
where AvailableWeight<>0     
GO
/****** Object:  StoredProcedure [dbo].[GetNumberProcessSendToDetail_bk_20220308]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetNumberProcessSendToDetail_bk_20220308]  
  
@CompanyId as varchar(50),          
@BranchId as varchar(50),      
@FinancialYear as varchar(50)   
  
as           
    
select * from(          
select     
STUFF(          
(SELECT ',' + convert(nvarchar(MAX),g1.SlipNo)          
FROM GalaProcessMaster g1    
WHERE g1.GalaProcessType=g.GalaProcessType and g1.CompanyId=g.CompanyId --and g1.BranchId=g.BranchId   
and g1.FinancialYearId=g.FinancialYearId  
and g1.KapanId=g.KapanId and g1.ShapeId=g.ShapeId and g1.SizeId=g.SizeId  
and g1.PurityId=g.PurityId and g1.GalaNumberID=g.GalaNumberId  
order by g1.SlipNo    
for xml path(''),TYPE).value('.', 'varchar(MAX)'),1,1,'') AS SlipNo,    
g.KapanId,k.Name'Kapan',g.ShapeId,s.Name'Shape',g.SizeId,sz.Name'Size',g.PurityId,p.Name'Purity',  
g.GalaNumberId,gm.Name'GalaNumber',g.FinancialYearId,          
sum(g.GalaWeight)'Weight',sum(g.GalaWeight)-isnull((select sum(n.Weight)         
from NumberProcessMaster n         
where n.NumberProcessType=0 and n.CompanyId=g.CompanyId --and n.BranchId=g.BranchId   
and n.FinancialYearId=g.FinancialYearId  
and n.KapanId=g.KapanId and n.ShapeId=g.ShapeId and n.SizeId=g.SizeId  
and n.PurityId=g.PurityId and n.GalaNumberID=g.GalaNumberId),0)  
-isnull((select sum(GalaWeight)  
FROM GalaProcessMaster g2    
WHERE g2.CompanyId=g.CompanyId --and g2.BranchId=g.BranchId   
and g2.FinancialYearId=g.FinancialYearId  
and g2.KapanId=g.KapanId and g2.ShapeId=g.ShapeId and g2.SizeId=g.SizeId  
and g2.PurityId=g.PurityId and g2.GalaNumberID=g.GalaNumberId and g2.GalaProcessType=2),0)'AvailableWeight',          
g.KapanId+g.ShapeId+g.SizeId+g.PurityId+g.GalaNumberId+g.CompanyId+g.FinancialYearId as 'ID'         --+g.BranchId  
from GalaProcessMaster g          
left join KapanMaster k on k.Id=g.KapanId  
left join ShapeMaster s on s.Id=g.ShapeId  
left join SizeMaster sz on sz.Id=g.SizeId  
left join PurityMaster p on p.Id=g.PurityId  
left join GalaMaster gm on gm.Id=g.GalaNumberID          
where g.GalaProcessType=1    
and g.CompanyId=@CompanyId and g.FinancialYearId=@FinancialYear  
group by g.KapanId,k.Name,g.ShapeId,s.Name,g.SizeId,sz.Name,g.PurityId,p.Name,gm.Name,g.GalaProcessType,g.CompanyId,g.FinancialYearId,g.GalaNumberId--,g.BranchId  
)x           
where AvailableWeight<>0   
  
GO
/****** Object:  StoredProcedure [dbo].[GetNumberSendReceiveReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetNumberSendReceiveReport] 
	@CompanyId as varchar(50),
	@BranchId as varchar(50),
	@FinancialYearId as varchar(50),
	@NumberProcessType int
AS
BEGIN
	IF @NumberProcessType = 1 -- Receive Number
	BEGIN

	SELECT NumberProcessType, NumberNo, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, CONVERT(datetime,EntryDate) 'EntryDate', KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, GalaNumberId, GalaName, NumberId, NumberName, PurityId, PurityName, TotalWeight, SUM(Weight) 'Weight', SUM(LossWeight) 'LossWeight', SUM(RejectionWeight) 'RejectionWeight',
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks	

		FROM (SELECT BPM.NumberProcessType, BPM.NumberNo, BPM.CompanyId, BPM.BranchId, BPM.FinancialYearId,  BPM.JangadNo, BPM.SlipNo, BPM.EntryDate, BPM.KapanId, KM.Name 'KapanName', BPM.ShapeId, SM.Name 'ShapeName', 
		BPM.CharniSizeId 'SizeId', SM1.Name 'SizeName', BPM.GalaNumberId, GM.Name 'GalaName', BPM.NumberId, NM.Name 'NumberName', BPM.PurityId, PM2.Name 'PurityName', BPM.Weight 'TotalWeight',
		BPM.NumberWeight 'Weight', BPM.LossWeight, BPM.RejectionWeight,
		BPM.HandOverById, PM.Name 'HandOverByName', BPM.HandOverToId, PM1.Name 'HandOverToName', BPM.Remarks 
		FROM [NumberProcessMaster] BPM
		INNER JOIN PartyMaster PM on BPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on BPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on BPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on BPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on BPM.CharniSizeId = SM1.Id
		INNER JOIN GalaMaster GM on BPM.GalaNumberId = GM.Id
		INNER JOIN NumberMaster NM on BPM.NumberId = NM.Id
		INNER JOIN PurityMaster PM2 ON BPM.PurityId = PM2.Id) T
	
	WHERE CompanyId=@CompanyId AND FinancialYearId = @FinancialYearId AND NumberProcessType = @NumberProcessType --AND BranchId = @BranchId
	
	Group By NumberNo, NumberProcessType, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, EntryDate, KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, TotalWeight, PurityId, PurityName,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks, GalaNumberId, GalaName, NumberId, NumberName
 
	END
	ELSE
	BEGIN

	SELECT NumberProcessType, NumberNo, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, CONVERT(datetime,EntryDate) 'EntryDate', KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, GalaNumberId, GalaName, NumberId, NumberName, PurityId, PurityName, TotalWeight, SUM(Weight) 'Weight', SUM(LossWeight) 'LossWeight', SUM(RejectionWeight) 'RejectionWeight',
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks	

		FROM (SELECT BPM.NumberProcessType, BPM.NumberNo, BPM.CompanyId, BPM.BranchId, BPM.FinancialYearId,  BPM.JangadNo, BPM.SlipNo, BPM.EntryDate, BPM.KapanId, KM.Name 'KapanName', BPM.ShapeId, SM.Name 'ShapeName', 
		BPM.CharniSizeId 'SizeId', SM1.Name 'SizeName', '' GalaNumberId, '' GalaName, '' NumberId, '' NumberName, BPM.PurityId, PM2.Name 'PurityName', BPM.Weight 'TotalWeight',
		BPM.NumberWeight 'Weight', BPM.LossWeight, BPM.RejectionWeight,
		BPM.HandOverById, PM.Name 'HandOverByName', BPM.HandOverToId, PM1.Name 'HandOverToName', BPM.Remarks 
		FROM [NumberProcessMaster] BPM
		INNER JOIN PartyMaster PM on BPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on BPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on BPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on BPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on BPM.CharniSizeId = SM1.Id
		INNER JOIN PurityMaster PM2 ON BPM.PurityId = PM2.Id) T
	
	WHERE CompanyId=@CompanyId AND FinancialYearId = @FinancialYearId AND NumberProcessType = @NumberProcessType --AND BranchId = @BranchId
	
	Group By NumberNo, NumberProcessType, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, EntryDate, KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, TotalWeight, PurityId, PurityName,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks, GalaNumberId, GalaName, NumberId, NumberName

	END

	
END
GO
/****** Object:  StoredProcedure [dbo].[GetOpeningStockReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[GetOpeningStockReport]

@CompanyId as varchar(50),                  
@FinancialYear as varchar(50)            
          
AS         
BEGIN
SELECT OSM.Id, OSM.FinancialYearId, OSM.CompanyId, OSM.BranchId, BM.Name 'BranchName', SrNo, KapanId, KM.Name KapanName, SizeId, SM.Name SizeName, NumberId, NM.Name NumberName, TotalCts, Rate, Amount, Remarks, OSM.UpdatedDate from OpeningStockMaster OSM
LEFT JOIN KapanMaster KM ON KM.Id = OSM.KapanId
LEFT JOIN SizeMaster SM ON SM.Id = OSM.SizeId
LEFT JOIN NumberMaster NM ON NM.Id = OSM.NumberId
LEFT JOIN BranchMaster BM ON BM.Id = OSM.BranchId
WHERE OSM.CompanyId = @CompanyId and OSM.FinancialYearId = @FinancialYear

END
GO
/****** Object:  StoredProcedure [dbo].[getPaymentReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec getPaymentReport 'ff8d3c9b-957b-46d1-b661-560ae4a2433e','146c24c5-6663-4f3d-bdfd-80469275c898',0,'2023-09-01','2023-09-30',0
CREATE PROCEDURE [dbo].[getPaymentReport]
 @CompanyId as varchar(50),                  
 @FinancialYearId as varchar(50),          
 @CrDrType int,          
 @FromDate as date = '',          
 @ToDate as date = ''  ,        
 @ActionType INT = 0        
AS          
BEGIN          
IF @ActionType = 0        
 SELECT M.EntryDate, M.EntryTime, M.IsDelete, M.CrDrType, M.CompanyId, M.FinancialYearId, M.ApprovalType,     
 M.GroupId, M.Id, M.FromName, M.Amount, M.FromPartyId, M.ToPartyId, M.ChequeNo, M.ChequeDate, M.Remarks, M.UpdatedDate, M.UpdatedBy,   
 PM1.Name as ToName, M.SrNo 
 FROM (SELECT CAST(G.EntryDate as date) 'EntryDate', G.EntryTime, G.IsDelete, G.CrDrType, G.CompanyId, G.FinancialYearId, convert(varchar,G.ApprovalType) 'ApprovalType',     
 G.Id as GroupId, P.Id,P.Sr, PM.Name as FromName, P.Amount, P.FromPartyId, G.ToPartyId, P.ChequeNo, P.ChequeDate, G.Remarks, G.UpdatedDate, G.UpdatedBy, G.BillNo as SrNo
 FROM [PaymentMaster] as P   
 INNER JOIN GroupPaymentMaster as G ON P.GroupId = G.Id          
 INNER JOIN [PartyMaster] AS PM ON PM.Id = P.FromPartyId) AS M          
 INNER JOIN [PartyMaster] AS PM1 ON PM1.Id = M.ToPartyId          
 WHERE M.IsDelete = 0           
 AND (CAST(EntryDate as Date) >= @FromDate AND CAST(EntryDate as Date) <= @ToDate)           
 AND M.CompanyId = @CompanyId and M.FinancialYearId = @FinancialYearId AND M.CrDrType = @CrDrType  
 order by CAST(M.EntryDate as Date),M.EntryTime desc       
     
ELSE        
    
 SELECT     
  ISNULL(CAST(ROUND(SUM(Amount), 2) as FLOAT),0) TotalAmount    
 FROM         
 (    
  SELECT     
   P.Amount, G.IsDelete, G.CrDrType, G.CompanyId , G.FinancialYearId, CAST(G.EntryDate as date) 'EntryDate'        
  FROM [PaymentMaster] as P         
  INNER JOIN GroupPaymentMaster as G ON P.GroupId = G.Id          
  INNER JOIN [PartyMaster] AS PM ON PM.Id = P.FromPartyId    
 ) AS M          
 WHERE M.IsDelete = 0           
  AND (CAST(EntryDate as Date) >= @FromDate AND CAST(EntryDate as Date) <= @ToDate)           
  AND M.CompanyId = @CompanyId and M.FinancialYearId = @FinancialYearId AND M.CrDrType = @CrDrType          
END 
GO
/****** Object:  StoredProcedure [dbo].[GetPendingKapanMapping]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetPendingKapanMapping]          
          
@CompanyId as varchar(50),          
@BranchId as varchar(50),      
@FinancialYear as varchar(50),
@SrNo as varchar(50)=null,
@ActionType as int=0      
          
AS            
          
BEGIN            

if(@ActionType=0)          
Begin
	select x.PurchaseID,x.PurchaseDetailId,Date,x.SlipNo,x.SizeId,x.Size,x.NetWeight,  
	(x.NetWeight-X.Allocated)'AvailableCts','' as KapanId,'' as Remarks,0.00 as Cts        
	from  (    
	Select pm.Id'PurchaseID',p.ID'PurchaseDetailId',convert(datetime,pm.Date)'Date',pm.SlipNo,  
	p.NetWeight,p.SizeId,sm.Name'Size', isnull((select sum(k.Weight)         
	from KapanMappingMaster k           
	where ISNULL(k.TransferId,'0') = '0' and k.PurchaseDetailsId=p.Id and k.PurchaseMasterId=p.PurchaseId and k.SlipNo=pm.SlipNo),0)'Allocated'           
	from PurchaseDetails p          
	left join PurchaseMaster pm on pm.Id=p.PurchaseId          
	left join SizeMaster sm on sm.Id=p.SizeId          
	where pm.isDelete = 0 and pm.CompanyId=@CompanyId and pm.FinancialYearId=@FinancialYear      
	)x  where (x.NetWeight-X.Allocated)<>0       
	order by Date asc        
End
else
Begin
	select x.PurchaseID,x.PurchaseDetailId,Date,x.SlipNo,x.SizeId,x.Size,x.NetWeight,  
	x.NetWeight'AvailableCts',X.Allocated as Cts, KapanId, Remarks        
	from  (    
	Select pm.Id'PurchaseID',p.ID'PurchaseDetailId',convert(datetime,pm.Date)'Date',pm.SlipNo,  
	p.NetWeight,p.SizeId,sm.Name'Size',km.KapanId,km.Remarks, isnull((select sum(k.Weight)
	from KapanMappingMaster k           
	where ISNULL(k.TransferId,'0') = '0' and k.PurchaseDetailsId=p.Id and k.PurchaseMasterId=p.PurchaseId and k.SlipNo=pm.SlipNo),0)'Allocated'           
	from KapanMappingMaster km
	left join PurchaseDetails p on p.Id=km.PurchaseDetailsId 
	left join PurchaseMaster pm on pm.Id=km.PurchaseMasterId and pm.SlipNo=km.SlipNo       
	left join SizeMaster sm on sm.Id=p.SizeId            
	where pm.isDelete = 0 and pm.CompanyId=@CompanyId and pm.FinancialYearId=@FinancialYear      
	and km.Sr=@SrNo
	)x      
	order by Date asc       
End
          
END   
GO
/****** Object:  StoredProcedure [dbo].[GetPFReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetPFReport]
  
@CompanyId as varchar(50)='', 
@FinancialYear as varchar(50) ='',
@PFType as BIT

as  
BEGIN

	SELECT 'Purchase' Type, PM.CompanyId, PM.FinancialYearId, PMS.Id 'PartyId', PMS.Name 'PartyName', PMS1.Id 'BrokerId', PMS1.Name 'BrokerName', SM.Id 'SizeId', SM.name 'Size', '' 'Number', '' 'NumberId', PD.Weight, PD.NetWeight, PD.BuyingRate 'Rate', PD.Amount, PM.CreatedDate  from PurchaseMaster PM
		INNER JOIN PurchaseDetails PD ON PM.Id = PD.PurchaseId
		INNER JOIN PartyMaster PMS ON PMS.Id = PM.PartyId
		INNER JOIN PartyMaster PMS1 ON PMS1.Id = PM.BrokerageId
		INNER JOIN SizeMaster SM ON SM.Id = PD.SizeId
	WHERE PM.IsPF = @PFType AND PM.CompanyId = @CompanyId AND PM.FinancialYearId = @FinancialYear

	UNION

	SELECT 'Sales' Type, SM.CompanyId, SM.FinancialYearId, PM.Id 'PartyId', PM.Name 'PartyName', PM1.Id 'BrokerId', PM1.Name 'BrokerName', SM1.Id 'SizeId', SM1.name 'Size', NM.Name 'Number', NM.Id 'NumberId', SD.Weight, SD.NetWeight, SD.SaleRate 'Rate', SD.Amount, SM.CreatedDate  from SalesMaster SM
		INNER JOIN SalesDetails SD ON SM.Id = SD.SalesId
		INNER JOIN PartyMaster PM ON PM.Id = SM.PartyId
		INNER JOIN PartyMaster PM1 ON PM1.Id = SM.BrokerageId
		INNER JOIN SizeMaster SM1 ON SM1.Id = SD.SizeId
		INNER JOIN NumberMaster NM ON NM.Id = SD.NumberSizeId
	WHERE SM.IsPF = @PFType AND SM.CompanyId = @CompanyId AND SM.FinancialYearId = @FinancialYear
END
GO
/****** Object:  StoredProcedure [dbo].[GetProfitAndLoss]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProfitAndLoss] 
	@CompanyId as varchar(50),
	@FinancialYearId as varchar(50),
	@ProfitLossType as int = 2
AS
BEGIN

IF @ProfitLossType = 2
BEGIN
	SELECT 'Debit' 'ColType', 'Purchase' 'Type', ISNULL(SUM(LBM.Balance),0) 'OpeningBalance', CAST(ISNULL(SUM(GrossTotal),0) as decimal(18,4)) 'Amount', (ISNULL(SUM(LBM.Balance),0) + CAST(ISNULL(SUM(GrossTotal),0) as decimal(18,4))) 'TotalPurchase' 
	from PurchaseMaster PM
	INNER JOIN LedgerBalanceManager LBM ON LBM.LedgerId = PM.PartyId
	WHERE PM.IsDelete=0 AND LBM.FinancialYearId = @FinancialYearId AND LBM.CompanyId = @CompanyId

	UNION

	SELECT 'Debit' 'ColType', 'Expense' 'Type', ISNULL(SUM(LBM.Balance), 0) 'OpeningBalance', CAST(ISNULL(SUM(Amount),0) as decimal(18,4)) 'Amount', (ISNULL(SUM(LBM.Balance), 0) + CAST(ISNULL(SUM(Amount),0) as decimal(18,4))) 'TotalExpense' FROM ExpenseDetails ED
	INNER JOIN LedgerBalanceManager LBM ON LBM.LedgerId = ED.PartyId
	WHERE ED.FinancialYearId = @FinancialYearId AND ED.CompanyId = @CompanyId

	UNION

	SELECT 'Credit' 'ColType', 'Sales' 'Type', ISNULL(SUM(LBM.Balance),0) 'OpeningBalance', CAST(ISNULL(SUM(GrossTotal),0) as decimal(18,4)) 'Amount', (ISNULL(SUM(LBM.Balance),0) + CAST(ISNULL(SUM(GrossTotal),0) as decimal(18,4))) 'TotalSales' from SalesMaster SM
	INNER JOIN LedgerBalanceManager LBM ON LBM.LedgerId = SM.PartyId
	WHERE SM.FinancialYearId = @FinancialYearId AND SM.CompanyId = @CompanyId
END
ELSE
BEGIN
	SELECT 'Debit' 'ColType', 'Purchase' 'Type', ISNULL(SUM(LBM.Balance),0) 'OpeningBalance', 0.0 'TotalPurchase', (ISNULL(SUM(LBM.Balance),0)) 'Amount' 
	FROM PartyMaster PM 
	INNER JOIN LedgerBalanceManager LBM ON PM.Id = LBM.LedgerId 
	WHERE PM.Type=1 AND LBM.FinancialYearId = @FinancialYearId AND LBM.CompanyId = @CompanyId


	UNION

	SELECT 'Debit' 'ColType', 'Expense' 'Type', ISNULL(SUM(LBM.Balance), 0) 'OpeningBalance', 0.0 'TotalExpense', (ISNULL(SUM(LBM.Balance), 0)) 'Amount' 
	FROM PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON LBM.LedgerId = PM.Id 
	Where PM.Type=3 AND LBM.FinancialYearId = @FinancialYearId AND LBM.CompanyId = @CompanyId

	UNION

	SELECT 'Credit' 'ColType', 'Sales' 'Type', ISNULL(SUM(LBM.Balance),0) 'OpeningBalance', 0.0 'TotalSales', (ISNULL(SUM(LBM.Balance),0)) 'Amount' 
	FROM PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON LBM.LedgerId = PM.Id 
	WHERE PM.Type=14 AND LBM.FinancialYearId = @FinancialYearId AND LBM.CompanyId = @CompanyId
END
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetPSSlipDetailsForPayment]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[GetPSSlipDetailsForPayment]   
        
@ActionType as int,      
@Company as varchar(50),  
@SrNo as int = 0           
        
as        
        
if(@ActionType=0)        
Begin      
 select * from(      
 select p.Id'PurchaseId',convert(varchar,convert(datetime,p.Date),103)'Date',p.PartyId,pm.Name'Party',      
 p.SlipNo,p.CompanyId,p.BranchId,        
 p.FinancialYearId,fm.Name'Year'      
 ,p.GrossTotal      
 ,p.GrossTotal-      
 --isnull((select sum(pd.Amount) from GroupPaymentMaster gp      
 --left join PaymentMaster pm on pm.GroupId=gp.Id      
 --left join PaymentDetails pd on pd.GroupId=gp.Id      
 --where gp.CrDrType=0 and gp.CompanyId=p.CompanyId --and gp.BranchId=p.BranchId      
 --and pm.FromPartyId=p.PartyId and pd.SlipNo=p.SlipNo and gp.IsDelete=0  
 --and gp.BillNo not in (@SrNo)),0) as RemainAmount 
  isnull((select sum(Amount) from (select distinct pd.SlipNo,gp.BillNo,pd.Amount from GroupPaymentMaster gp      
 left join PaymentMaster pm on pm.GroupId=gp.Id      
 left join PaymentDetails pd on pd.GroupId=gp.Id      
 where gp.CrDrType=0 and gp.CompanyId=p.CompanyId --and gp.BranchId=p.BranchId      
 and pm.FromPartyId=p.PartyId and pd.SlipNo=p.SlipNo and gp.IsDelete=0  
 and gp.BillNo not in (@SrNo))x) ,0) as RemainAmount          
 from PurchaseMaster p      
 left join PartyMaster pm on pm.Id=PartyId        
 left join FinancialYearMaster fm on fm.Id=p.FinancialYearId      
 where p.CompanyId=@Company AND p.IsDelete=0      
 )x where x.RemainAmount>0      
 order by x.SlipNo      
End      
else      
Begin      
 select * from(      
 select s.Id'PurchaseId',convert(varchar,convert(datetime,s.Date),103)'Date',s.PartyId,pm.Name'Party',      
 s.SlipNo,s.CompanyId,s.BranchId,        
 s.FinancialYearId,fm.Name'Year'      
 ,s.GrossTotal      
 ,s.GrossTotal-      
 --isnull((select sum(pd.Amount) from GroupPaymentMaster gp      
 --left join PaymentMaster pm on pm.GroupId=gp.Id      
 --left join PaymentDetails pd on pd.GroupId=gp.Id      
 --where gp.CrDrType=1 and gp.CompanyId=s.CompanyId --and gp.BranchId=s.BranchId      
 --and pm.FromPartyId=s.PartyId and pd.SlipNo=s.SlipNo and gp.IsDelete=0),0) as RemainAmount 
 isnull((select sum(Amount) from (select distinct pd.SlipNo,gp.BillNo,pd.Amount from GroupPaymentMaster gp      
 left join PaymentMaster pm on pm.GroupId=gp.Id      
 left join PaymentDetails pd on pd.GroupId=gp.Id      
 where gp.CrDrType=1 and gp.CompanyId=s.CompanyId --and gp.BranchId=p.BranchId      
 and pm.FromPartyId=s.PartyId and pd.SlipNo=s.SlipNo and gp.IsDelete=0  
 and gp.BillNo not in (@SrNo))x) ,0) as RemainAmount                  
 from SalesMaster s      
 left join PartyMaster pm on pm.Id=PartyId        
 left join FinancialYearMaster fm on fm.Id=s.FinancialYearId      
 where s.CompanyId=@Company AND s.IsDelete=0      
 )x where x.RemainAmount>0      
 order by x.SlipNo      
End 
GO
/****** Object:  StoredProcedure [dbo].[GetPurchaseDetailsForEdit]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetPurchaseDetailsForEdit]

@PurchaseId as varchar(50)

as 

select * from PurchaseMaster where Id=@PurchaseId

select * from PurchaseDetails where PurchaseId=@PurchaseId

GO
/****** Object:  StoredProcedure [dbo].[GetPurchaseReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC  [karmajew_DiamondTrading].[GetPurchaseReport_Temp]    'ff8d3c9b-957b-46d1-b661-560ae4a2433e','146c24c5-6663-4f3d-bdfd-80469275c898','','2021-05-01','2023-05-31', 1    
    
CREATE  PROCEDURE [dbo].[GetPurchaseReport]             
(    
@CompanyId as varchar(50),                    
@FinancialYearId as varchar(50),        
@CurrentWeek as varchar(50)='',       
@FromDate as date = '',      
@ToDate as date = '' ,     
@ActionType INT = 0    
)    
AS            
        
BEGIN              
IF @ActionType = 0     
    
IF(@CurrentWeek = '')      
BEGIN      
 SELECT LOWER(NEWID()) 'Id', M.* FROM (      
 SELECT Distinct KapanId, Name 'KapanName', T.* from (      
  select      
  CAST(PM.Date as date) Date, BM.Name 'BranchName', PM.Id 'PurId', PM.CompanyId, PM.FinancialYearId, PM.PurchaseBillNo, PM.SlipNo, PM.Time, PM.PartyId,           
   PAM.Name AS PartyName, PAM.MobileNo, PM.ByuerId as BuyerId, PAM1.Name AS BuyerName, PAM1.MobileNo AS BuyerMobileNo,           
   PM.BrokerageId, PAM2.Name AS BrokerName, PAM2.MobileNo AS BrokerMobileNo, PD.Amount 'Total',PD.Amount 'GrossTotal', PM.RoundUpAmount, PM.DueDays,           
   PM.DueDate, PM.PaymentDays, PM.PaymentDueDate, PM.IsPF, PM.IsSlip,PM.UpdatedDate, PM.UpdatedBy, PD.Weight,         
   SUM(PD.NetWeight) NetWeight, SUM(PD.LessDiscountPercentage) LessWeight, SUM(ROUND(PD.CVDAmount,0)) CVDAmount,         
   PD.BuyingRate, PM.Remarks, PM.Message, convert(varchar, PM.ApprovalType)'ApprovalType',convert(decimal(18,2),0) as AdjustAmount      
      
   from PurchaseMaster PM       
   INNER JOIN [PurchaseDetails] AS PD ON PM.Id = PD.PurchaseId            
   INNER JOIN [PartyMaster] AS PAM ON PAM.Id = PM.PartyId            
   INNER JOIN [PartyMaster] AS PAM1 ON PAM1.Id = PM.ByuerId            
   INNER JOIN [PartyMaster] AS PAM2 ON PAM2.Id = PM.BrokerageId        
   INNER JOIN BranchMaster BM ON PM.BranchId = BM.Id      
      
  where PM.IsDelete = 0 and PM.CompanyId=@CompanyId AND PM.FinancialYearId=@FinancialYearId       
  and (CAST(PM.Date as Date) >= @FromDate AND CAST(PM.Date as Date) <= @ToDate)       
      
  GROUP BY       
  PM.Date, PM.Id, PM.CompanyId, PM.FinancialYearId, PM.PurchaseBillNo, PM.SlipNo, PM.Time, PM.PartyId,           
  PAM.Name, PAM.MobileNo, PM.ByuerId, PAM1.Name, PAM1.MobileNo,           
  PM.BrokerageId, PAM2.Name, PAM2.MobileNo, PD.Amount, PM.RoundUpAmount, PM.DueDays,           
  PM.DueDate, PM.PaymentDays, PM.PaymentDueDate, PM.IsPF, PM.IsSlip,       
  PM.Remarks, PM.Message, PM.ApprovalType,BM.Name,PM.UpdatedDate, PM.UpdatedBy, PD.Weight, PD.BuyingRate      
       
 )T       
 LEFT JOIN KapanMappingMaster KMM ON KMM.PurchaseMasterId = T.PurId      
 LEFT JOIN KapanMaster KM ON KM.Id = KapanId      
 ) M      
 order by M.Date,M.Time,M.SlipNo desc      
END      
ELSE       
BEGIN      
SELECT LOWER(NEWID()) 'Id', M.* FROM (      
 SELECT Distinct KapanId, Name 'KapanName', T.* from (      
  select      
  CAST(PM.Date as date) Date, BM.Name 'BranchName', PM.Id 'PurId', PM.CompanyId, PM.FinancialYearId, PM.PurchaseBillNo, PM.SlipNo, PM.Time, PM.PartyId,           
   PAM.Name AS PartyName, PAM.MobileNo, PM.ByuerId as BuyerId, PAM1.Name AS BuyerName, PAM1.MobileNo AS BuyerMobileNo,           
   PM.BrokerageId, PAM2.Name AS BrokerName, PAM2.MobileNo AS BrokerMobileNo, PD.Amount 'Total',PD.Amount 'GrossTotal', PM.RoundUpAmount, PM.DueDays,           
   PM.DueDate, PM.PaymentDays, PM.PaymentDueDate, PM.IsPF, PM.IsSlip,PM.UpdatedDate, PM.UpdatedBy, PD.Weight,         
   SUM(PD.NetWeight) NetWeight, SUM(PD.LessDiscountPercentage) LessWeight, SUM(ROUND(PD.CVDAmount,0)) CVDAmount,         
   PD.BuyingRate, PM.Remarks, PM.Message, convert(varchar, PM.ApprovalType)'ApprovalType',convert(decimal(18,2),0) as AdjustAmount      
      
   from PurchaseMaster PM       
   INNER JOIN [PurchaseDetails] AS PD ON PM.Id = PD.PurchaseId            
   INNER JOIN [PartyMaster] AS PAM ON PAM.Id = PM.PartyId            
   INNER JOIN [PartyMaster] AS PAM1 ON PAM1.Id = PM.ByuerId            
   INNER JOIN [PartyMaster] AS PAM2 ON PAM2.Id = PM.BrokerageId        
   INNER JOIN BranchMaster BM ON PM.BranchId = BM.Id      
      
  where PM.IsDelete = 0 and PM.CompanyId=@CompanyId AND PM.FinancialYearId=@FinancialYearId       
  and (@CurrentWeek = '' or DATEPART(week, pm.PaymentDueDate)=@CurrentWeek)        
      
  GROUP BY       
  PM.Date, PM.Id, PM.CompanyId, PM.FinancialYearId, PM.PurchaseBillNo, PM.SlipNo, PM.Time, PM.PartyId,           
  PAM.Name, PAM.MobileNo, PM.ByuerId, PAM1.Name, PAM1.MobileNo,           
  PM.BrokerageId, PAM2.Name, PAM2.MobileNo, PD.Amount, PM.RoundUpAmount, PM.DueDays,           
  PM.DueDate, PM.PaymentDays, PM.PaymentDueDate, PM.IsPF, PM.IsSlip,       
  PM.Remarks, PM.Message, PM.ApprovalType,BM.Name,PM.UpdatedDate, PM.UpdatedBy, PD.Weight, PD.BuyingRate      
       
 )T       
 LEFT JOIN KapanMappingMaster KMM ON KMM.PurchaseMasterId = T.PurId      
 LEFT JOIN KapanMaster KM ON KM.Id = KapanId      
 ) M      
 order by M.Date,M.Time,M.SlipNo desc       
END      
    
ELSE    
    
IF(@CurrentWeek = '')      
BEGIN      
 SELECT ISNULL(ROUND(SUM(M.grossTotal),2),0) TotalAmount FROM 
 (      
	SELECT  T.* FROM 
	(      
		SELECT      
			PD.Amount 'GrossTotal', PM.Id 'PurId'
		FROM PurchaseMaster PM       
		INNER JOIN [PurchaseDetails] AS PD ON PM.Id = PD.PurchaseId            
		WHERE PM.IsDelete = 0 AND PM.CompanyId= @CompanyId AND PM.FinancialYearId= @FinancialYearId       
		and (CAST(PM.Date as Date) >= @FromDate AND CAST(PM.Date as Date) <= @ToDate)       
	) T       
	LEFT JOIN KapanMappingMaster KMM ON KMM.PurchaseMasterId = T.PurId      
	LEFT JOIN KapanMaster KM ON KM.Id = KapanId      
 ) M      
    
END      
ELSE       
BEGIN      
SELECT ISNULL(ROUND(SUM(M.grossTotal),2),0) TotalAmount FROM 
	(      
		SELECT  T.* FROM 
		(      
			SELECT
				PD.Amount 'GrossTotal',PM.Id 'PurId'
			FROM PurchaseMaster PM       
			INNER JOIN [PurchaseDetails] AS PD ON PM.Id = PD.PurchaseId            
			WHERE PM.IsDelete = 0 AND PM.CompanyId= @CompanyId AND PM.FinancialYearId= @FinancialYearId       
			AND (@CurrentWeek = '' OR DATEPART(week, pm.PaymentDueDate)= @CurrentWeek)        

		 )T       
		LEFT JOIN KapanMappingMaster KMM ON KMM.PurchaseMasterId = T.PurId      
 ) M      
    
END       
END 
GO
/****** Object:  StoredProcedure [dbo].[GetPurchaseSlipDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[GetPurchaseSlipDetail]
  
@Company as varchar(50),  
@SlipNo as varchar(50),  
@FinancialYear as varchar(50)
  
as  
  
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
where pm.CompanyId=@Company and pm.SlipNo=@SlipNo and pm.FinancialYearId=@FinancialYear  
)x  
GO
/****** Object:  StoredProcedure [dbo].[GetPurchaseSlipPrintList]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetPurchaseSlipPrintList]

@Company as varchar(50),
@FinancialYear as varchar(50)

as  
  
select SlipNo as Id,pm.SlipNo,
CONVERT(varchar,CONVERT(datetime, pm.Date),103)'Date',pm.PartyId,
party.Name'Party',
pm.BrokerageId,
party1.Name'Broker',
pm.FinancialYearId       
from PurchaseMaster pm
left join PartyMaster party on party.Id=pm.PartyId
left join PartyMaster party1 on party1.Id=pm.BrokerageId
where pm.AllowSlipPrint=1 
and pm.CompanyId=@Company and pm.FinancialYearId=@FinancialYear
order by pm.SlipNo
GO
/****** Object:  StoredProcedure [dbo].[GetReceivablePayableReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--GetReceivablePayableReport 'ff8d3c9b-957b-46d1-b661-560ae4a2433e','146c24c5-6663-4f3d-bdfd-80469275c898',2    
CREATE proc [dbo].[GetReceivablePayableReport]              
@CompanyId as varchar(50)='',         
@FinancialYear as varchar(50) ='',        
@Type int = 0        
AS          
BEGIN        
 Declare @tempTable TABLE(    
 PartyType int,     
 Type varchar(100),    
 SubType varchar(100),     
 Id varchar(100),     
 Name varchar(100),    
 CompanyId varchar(100),     
 FinancialYearId varchar(100),     
 LedgerId varchar(100),     
 OpeningBalance decimal(18,2),     
 PurchaseAmount decimal(18,2),     
 Brokerage decimal(18,2),    
 SalesAmount decimal(18,2),    
 PaymentFrom varchar(200),     
 PaymentTo varchar(200),     
 ReceiptFrom decimal(18,2),     
 ReceiptTo decimal(18,2),     
 ClosingBalance decimal(18,2))        
 INSERT @tempTable EXEC [GetLedgerBalanceReport] @CompanyId, @FinancialYear        
        
 IF @Type = 0        
 BEGIN    
        
 -- Payables        
        
   --Declare @tempTable TABLE(PartyType int, Type varchar(100), SubType varchar(100), Id varchar(100), Name varchar(100),CompanyId varchar(100), FinancialYearId varchar(100), LedgerId varchar(100), OpeningBalance decimal(18,2), PurchaseAmount decimal(18,2
  
    
--), ReceiptFrom decimal(18,2), ReceiptTo decimal(18,2), ClosingBalance decimal(18,2))        
   --INSERT @tempTable EXEC [GetLedgerBalanceReport] 'ff8d3c9b-957b-46d1-b661-560ae4a2433e', '146c24c5-6663-4f3d-bdfd-80469275c898'        
        
   SELECT * FROM (      
           
 SELECT * FROM (      
      
 SELECT     
  LOWER(NEWID()) 'Id', T.Type, T.PartyId, T.Name, (T.Total - (CASE WHEN Amount IS NULL THEN 0 ELSE Amount END)) 'Total', BrokerName, T.SlipNo, EntryDate     
 FROM (        
 SELECT     
  'Purchase' 'Type', PartyId, PM.Name, (SUM(GrossTotal) + SUM(LBM.Balance)) as Total, PM1.Name 'BrokerName', CAST(Date as Date) 'EntryDate', SlipNo     
 FROM PurchaseMaster PU        
 INNER JOIN PartyMaster PM on PU.PartyId = PM.Id        
 INNER JOIN LedgerBalanceManager LBM ON LBM.LedgerId = PU.PartyId        
 INNER JOIN PartyMaster PM1 ON PU.BrokerageId = PM1.Id        
 WHERE PM.IsDelete = 0 AND PM1.IsDelete = 0 AND PU.isDelete = 0 AND PU.CompanyId = @CompanyId AND PU.FinancialYearId = @FinancialYear AND GrossTotal > 0        
 GROUP BY PartyId, PM.Name, PM1.Name, SlipNo, PU.Date) T        
          
  LEFT JOIN        
        
  (    
  SELECT GPM.CompanyId, GPM.FinancialYearId, PY.FromPartyId 'PartyId', SUM(PY.Amount) 'Amount', PD.SlipNo     
  FROM GroupPaymentMaster GPM        
  INNER JOIN PaymentMaster PY ON GPM.Id = PY.GroupId 
  INNER JOIN PaymentDetails PD ON PD.PaymentId = PY.Id       
  WHERE GPM.CrDrType=0  AND GPM.IsDelete=0         
  Group By PY.FromPartyId,GPM.CompanyId, GPM.FinancialYearId, PD.SlipNo) M    ON T.PartyId = M.PartyId AND T.SlipNo = M.SlipNo      
 )     
 tempTable WHERE temptable.Total > 0      
        
    UNION        
           
    SELECT Id, Type, LedgerId 'PartyId', Name, ClosingBalance 'Total', '' 'BrokerName', '' SlipNo, CAST(CURRENT_TIMESTAMP as Date) 'EntryDate' from @tempTable         
    WHERE PartyType = 10 AND ClosingBalance > 0 AND ClosingBalance <> 0        
        
    )T        
        
   Order By SlipNo ASC        
 END        
 ELSE        
 BEGIN        
        
 --Receivables        
        
  --Declare @tempTable TABLE(PartyType int, Type varchar(100), SubType varchar(100), Id varchar(100), Name varchar(100),CompanyId varchar(100), FinancialYearId varchar(100), LedgerId varchar(100), OpeningBalance decimal(18,2), PurchaseAmount decimal(18,2)
  
    
--, ReceiptFrom decimal(18,2), ReceiptTo decimal(18,2), ClosingBalance decimal(18,2))        
  --INSERT @tempTable EXEC [GetLedgerBalanceReport] 'ff8d3c9b-957b-46d1-b661-560ae4a2433e', '146c24c5-6663-4f3d-bdfd-80469275c898'        
        
	SELECT * FROM (       
      
		SELECT * FROM (      
         
		   SELECT LOWER(NEWID()) 'Id', T.Type, T.PartyId, T.Name, (Total - (CASE WHEN Amount IS NULL THEN 0 ELSE Amount END)) 'Total', EntryDate, T.SlipNo, BrokerName 
		   FROM (      
           
			  SELECT 'Sales' 'Type', PartyId, PM.Name, SUM(GrossTotal) + SUM(LBM.Balance) as Total, SlipNo, CAST(Date as Date) 'EntryDate', PM1.Name 'BrokerName' from SalesMaster SA        
			   INNER JOIN PartyMaster PM on SA.PartyId = PM.Id        
			   INNER JOIN LedgerBalanceManager LBM ON LBM.LedgerId = SA.PartyId        
			   INNER JOIN PartyMaster PM1 ON SA.BrokerageId = PM1.Id        
			   WHERE PM.IsDelete = 0 AND PM1.IsDelete = 0 AND SA.IsDelete = 0 AND SA.CompanyId = @CompanyId AND SA.FinancialYearId = @FinancialYear AND GrossTotal > 0        
			  GROUP BY PartyId, PM.Name, SlipNo, Date, PM1.Name
			) T        
        
		  LEFT JOIN                
		  (
			SELECT GPM.CompanyId, GPM.FinancialYearId, PY.FromPartyId 'PartyId', SUM(PY.Amount) 'Amount', PD.SlipNo
			FROM GroupPaymentMaster GPM        
				INNER JOIN PaymentMaster PY ON GPM.Id = PY.GroupId  
				INNER JOIN PaymentDetails PD ON PD.PaymentId = PY.Id      
			WHERE GPM.CrDrType=1 AND GPM.IsDelete=0 Group By GPM.CompanyId, GPM.FinancialYearId, PY.FromPartyId, PD.SlipNo ) M        
           
			ON T.PartyId = M.PartyId AND T.SlipNo = M.SlipNo    
      
		) tempTable WHERE Total > 0
        
		UNION        
              
		SELECT Id, Type, LedgerId 'PartyId', Name, ClosingBalance 'Total', CAST(CURRENT_TIMESTAMP as Date) 'EntryDate', '' SlipNo, '' 'BrokerName' from @tempTable         
		WHERE PartyType = 10 AND ClosingBalance < 0 AND ClosingBalance <> 0

		--UNION --LOAN GIVEN should be listed in Recevables		

	)T Order By SlipNo ASC        

 END           
END

--select * from loanMaster where companyId='a7265ea2-8fbf-4fb0-bd7e-ed8d09cccdd1' and LoanType=2
GO
/****** Object:  StoredProcedure [dbo].[GetRejectInOutReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRejectInOutReport]   
 @CompanyId as varchar(50),          
 @FinancialYearId as varchar(50),
 @RejectionType as int /*Rejection In = 1, Rejecton Out = 2*/
AS  
BEGIN  

	Select CAST(RIOM.EntryDate as Date) 'EntryDate', RIOM.TransType, RIOM.Id, RIOM.SrNo, RIOM.CompanyId, RIOM.BranchId, RIOM.FinancialYearId, RIOM.PartyId, PM.Name 'PartyName', RIOM.BrokerageId, PM1.Name 'BrokerName',    
		RIOM.SlipNo, RIOM.SizeId, ISNULL(SM.Name, '') 'SizeName', RIOM.Rate, RIOM.TotalCarat, RIOM.Amount, RIOM.Remarks, RIOM.CharniSizeId, ISNULL(SM1.Name,'') 'CharniSizeName',  
		RIOM.GalaSizeId, ISNULL(SM2.Name, '') 'GalaSizeName', RIOM.NumberSizeId, ISNULL(SM3.Name, '') 'NumberSizeName', RIOM.PurityId, ISNULL(PUM.Name, '') 'PurityName',
		RIOM.Image1, RIOM.Image2, RIOM.Image3 from RejectionInOutMaster RIOM
		
		INNER JOIN PartyMaster PM ON  PM.Id = RIOM.PartyId
		INNER JOIN PartyMaster PM1 ON PM1.Id = RIOM.BrokerageId
		LEFT JOIN SizeMaster SM ON SM.Id = RIOM.SizeId
		LEFT JOIN SizeMaster SM1 ON SM1.Id = RIOM.CharniSizeId
		LEFT JOIN SizeMaster SM2 ON SM2.Id = RIOM.GalaSizeId
		LEFT JOIN SizeMaster SM3 ON SM3.Id = RIOM.NumberSizeId
		LEFT JOIN PurityMaster PUM ON PUM.Id = RIOM.PurityId
	
	WHERE RIOM.TransType=@RejectionType
	AND RIOM.CompanyId = @CompanyId AND RIOM.FinancialYearId = @FinancialYearId

END
GO
/****** Object:  StoredProcedure [dbo].[GetRejectionSendReceiveDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC GetRejectionSendReceiveDetail 'ff8d3c9b-957b-46d1-b661-560ae4a2433e','146c24c5-6663-4f3d-bdfd-80469275c898',null,2  
CREATE proc [dbo].[GetRejectionSendReceiveDetail]                
                
@CompanyId as varchar(50),                                     
@FinancialYear as varchar(50),      
@PartyId as varchar(50),      
@TransType as int                    
                
as                
           
if(@TransType=2)      
Begin     
 select distinct p.SlipNo
 into #tempSlipNos from PurchaseMaster p      
 left join PurchaseDetails pd on pd.PurchaseId=p.Id      
 where p.PartyId=@PartyId 
       
 select x.*,x.RejectedWeight-x.ReturnCts'Available',      
 k.Name'Kapan',s.Name'Size','Purchase' as ProcessType from(      
 select convert(varchar,p.SlipNo) as SlipNo,pd.KapanId,pd.ShapeId,pd.SizeId,pd.PurityId,p.CompanyId,p.FinancialYearId,pd.BuyingRate'Rate',      
 pd.RejectedWeight,      
 isnull((select sum(TotalCarat) from RejectionInOutMaster r      
 where r.SlipNo=p.SlipNo and r.SizeId=pd.SizeId and TransType=2 and ProcessType='Purchase'     
 group by r.SlipNo),0)+
 (select sum(b.RejectionWeight)
 from BoilProcessMaster b
 where b.BoilType=1 and b.RejectionWeight<>0
 and b.SlipNo=p.SlipNo)'ReturnCts',      
 convert(varchar,p.SlipNo)+pd.KapanId+pd.ShapeId+pd.SizeId+pd.PurityId'Id'       
 from PurchaseMaster p      
 left join PurchaseDetails pd on pd.PurchaseId=p.Id      
 where p.SlipNo in (select SlipNo from #tempSlipNos)
 )x      
 left join KapanMaster k on k.Id=x.KapanId      
 left join SizeMaster s on s.Id=x.SizeId      
 where x.RejectedWeight-x.ReturnCts>0 
 union 
 select x.*,x.RejectedWeight-x.ReturnCts'Available',      
 k.Name'Kapan',s.Name'Size','Boil' as ProcessType from(
 select b.SlipNo,b.KapanId,b.ShapeId,b.SizeId,b.PurityId,b.CompanyId,b.FinancialYearId,
 '0' as Rate,sum(b.RejectionWeight) as RejectedWeight,
 isnull((select sum(TotalCarat) from RejectionInOutMaster r      
 where r.SlipNo=b.SlipNo and r.SizeId=b.SizeId and TransType=2 and ProcessType='Boil'     
 group by r.SlipNo),0)'ReturnCts', 
  convert(varchar,b.SlipNo)+b.KapanId+b.ShapeId+b.SizeId+b.PurityId'Id'  
 from BoilProcessMaster b
 where b.BoilType=1 and b.RejectionWeight<>0
 and b.SlipNo in (select SlipNo from #tempSlipNos)
 group by b.SlipNo,b.KapanId,b.ShapeId,b.SizeId,b.PurityId,b.CompanyId,b.FinancialYearId)x
 left join KapanMaster k on k.Id=x.KapanId      
 left join SizeMaster s on s.Id=x.SizeId      
 where x.RejectedWeight-x.ReturnCts>0     
End    
else    
Begin           
 select x.*,x.RejectedWeight-x.ReturnCts'Available',      
 k.Name'Kapan',sm.Name'Size','Purchase' as ProcessType from(      
 select convert(varchar,s.SlipNo) as SlipNo,sd.KapanId,sd.ShapeId,sd.SizeId,sd.PurityId,s.CompanyId,s.FinancialYearId,sd.SaleRate'Rate',      
 sd.RejectedWeight,      
 isnull((select sum(TotalCarat) from RejectionInOutMaster r      
 where r.SlipNo=s.SlipNo and r.SizeId=sd.SizeId and TransType=1      
 group by r.SlipNo),0)'ReturnCts',      
 convert(varchar,s.SlipNo)+sd.KapanId+sd.ShapeId+sd.SizeId+sd.PurityId'Id'       
 from SalesMaster s      
 left join SalesDetails sd on sd.SalesId=s.Id      
 where s.PartyId=@PartyId      
 )x      
 left join KapanMaster k on k.Id=x.KapanId      
 left join SizeMaster sm on sm.Id=x.SizeId      
 where x.RejectedWeight-x.ReturnCts>0      
End    
    
    
    
GO
/****** Object:  StoredProcedure [dbo].[GetSalaryReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSalaryReport]   
 @CompanyId as varchar(50),          
 @FinancialYearId as varchar(50)
AS  
BEGIN  
	SELECT SM.SrNo, SD.Id, SM.Id 'SalaryMasterId', SD.Sr, SM.CompanyId, BranchId, '' 'BranchName', FinancialYearId, SalaryMonthDateTime, MonthDays, Holidays, Remarks, FromPartyId, PM.Name 'FromPartyName', SalaryMonth, AdvanceAmount,
		BonusAmount, TotalAmount, OTPlusHrs, OTPlusRate, OTPlusAmount, OTMinusHrs, OTMinusRate,OTMinusAmount, RoundOfAmount, SalaryAmount, ToPartyId, PM1.Name 'ToPartyName', WorkedDays, WorkingDays  FROM SalaryMaster SM 
		INNER JOIN SalaryDetails SD ON SM.Id = SD.SalaryMasterId 
		LEFT JOIN PartyMaster PM ON PM.Id = SM.FromPartyId
		INNER JOIN PartyMaster PM1 ON PM1.Id = SD.ToPartyId
		WHERE SM.CompanyId = @CompanyId AND SM.FinancialYearId = @FinancialYearId
END
GO
/****** Object:  StoredProcedure [dbo].[GetSalesItemDetails]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetSalesItemDetails]     
                      
@ActionType as numeric,                      
@CompanyId as varchar(50),                              
@BranchId as varchar(50),                          
@FinancialYear as varchar(50)                        
                      
as                      
                      
if(@ActionType=3)      --Charni                
Begin                      
 select c.CompanyId,c.FinancialYearId,KapanId,k.Name'Kapan',ShapeId,s.Name'Shape',SizeId,sz.Name'Size',PurityId,p.Name'Purity',CharniSizeId,sz1.Name'CharniSize',''GalaNumberId,''GalaSize,''NumberSize,''NumberSizeId,                      
 sum(CharniWeight)-isnull((                      
 select sum(Weight) from SalesMaster sm                      
 left join SalesDetails s on s.SalesId=sm.Id                      
 where s.Category=3                      
 and sm.CompanyId=c.CompanyId and sm.BranchId=c.BranchId                       
 and sm.FinancialYearId=c.FinancialYearId                      
 and s.KapanId=c.KapanId and s.ShapeId=c.ShapeId and s.SizeId=c.SizeId and s.PurityId=c.PurityId                      
 and s.CharniSizeId=c.CharniSizeId),0)'Weight',                      
 KapanId+ShapeId+SizeId+CharniSizeId'Id'                      
 from CharniProcessMaster c                      
 left join KapanMaster k on k.Id=c.KapanId                      
 left join ShapeMaster s on s.Id=c.ShapeId                      
 left join SizeMaster sz on sz.Id=c.SizeId                      
 left join SizeMaster sz1 on sz1.Id=c.CharniSizeId                      
 left join PurityMaster p on p.Id=c.PurityId                      
 where CharniType=2                      
 and c.CompanyId=@CompanyId and c.BranchId=@BranchId and c.FinancialYearId=@FinancialYear                      
 group by c.CompanyId,c.FinancialYearId,KapanId,k.Name,ShapeId,s.Name,SizeId,sz.Name,PurityId,p.Name,CharniSizeId,sz1.Name,c.BranchId                      
End                      
else if(@ActionType=0)      --Number                
Begin                      
 --select n.CompanyId,n.FinancialYearId,KapanId,k.Name'Kapan',ShapeId,s.Name'Shape',SizeId,sz.Name'Size',PurityId,p.Name'Purity',''GalaNumberId,''GalaSize,nm.Name'NumberSize',n.NumberId'NumberSizeId',                    
 --n.CharniSizeId,sz1.Name'CharniSize',                    
 --sum(NumberWeight)-isnull((                      
 --select sum(Weight) from SalesMaster sm                      
 --left join SalesDetails s on s.SalesId=sm.Id                      
 --where s.Category=0                      
 --and sm.CompanyId=n.CompanyId --and sm.BranchId=n.BranchId                       
 --and sm.FinancialYearId=n.FinancialYearId                      
 --and s.KapanId=n.KapanId and s.ShapeId=n.ShapeId and s.SizeId=n.SizeId and s.PurityId=n.PurityId                      
 --and s.NumberSizeId=n.NumberId                    
 --and s.CharniSizeId=n.CharniSizeId),0)'Weight',                      
 --KapanId+ShapeId+SizeId+n.NumberId+n.CharniSizeId'Id'                      
 --from NumberProcessMaster n                      
 --left join KapanMaster k on k.Id=n.KapanId                      
 --left join ShapeMaster s on s.Id=n.ShapeId                      
 --left join SizeMaster sz on sz.Id=n.SizeId                      
 --left join NumberMaster nm on nm.Id=n.NumberId                      
 --left join PurityMaster p on p.Id=n.PurityId                      
 --left join SizeMaster sz1 on sz1.Id=n.CharniSizeId                      
 --where NumberProcessType=2                      
 ----and n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYear                      
 --group by n.CompanyId,n.FinancialYearId,KapanId,k.Name,ShapeId,s.Name,SizeId,sz.Name,PurityId,p.Name,NumberId,nm.Name,n.CharniSizeId,sz1.Name--,n.BranchId                      
 select * from(              
 select n.CompanyId,n.FinancialYearId,ShapeId,isnull(s.Name,'N/A')'Shape',                
 ''KapanId,''Kapan,''SizeId,''Size,''PurityId,''Purity,                
''GalaNumberId,''GalaSize,nm.Name'NumberSize',n.NumberId'NumberSizeId',                    
 n.CharniSizeId,sz1.Name'CharniSize',            
 sum(NumberWeight)-isnull((                      
 select sum(sd.Weight) from SalesDetailsSummary sd                                     
 where sd.Category=0              
 and sd.ShapeId=n.ShapeId            
 and sd.CompanyId=n.CompanyId and sd.BranchId=n.BranchId                       
 and sd.FinancialYearId=n.FinancialYearId                      
 and sd.NumberSizeId=n.NumberId                    
 and sd.CharniSizeId=n.CharniSizeId),0)'AvailableWeight',                      
 ShapeId+n.NumberId+n.CharniSizeId'Id'                
 from NumberProcessMaster n                      
 left join ShapeMaster s on s.Id=n.ShapeId                      
 left join NumberMaster nm on nm.Id=n.NumberId                      
 left join SizeMaster sz1 on sz1.Id=n.CharniSizeId                      
 where NumberProcessType in (2,3,4)            
 and n.CompanyId=@CompanyId and n.BranchId=@BranchId and n.FinancialYearId=@FinancialYear                      
 group by n.CompanyId,ShapeId,s.Name,n.FinancialYearId,NumberId,nm.Name,n.CharniSizeId,sz1.Name,n.BranchId                
 )x              
 where AvailableWeight>0              
End                      
else if(@ActionType=4)    --Gala                  
Begin                      
 select g.CompanyId,g.FinancialYearId,KapanId,k.Name'Kapan',ShapeId,s.Name'Shape',SizeId,sz.Name'Size',PurityId,p.Name'Purity',GalaNumberId,gm.Name'GalaSize',                  
 g.CharniSizeId,sz1.Name as 'CharniSize',''NumberSize,''NumberSizeId,                      
 sum(GalaWeight)-isnull((                      
 select sum(Weight) from SalesMaster sm                      
 left join SalesDetails s on s.SalesId=sm.Id                      
 where s.Category=4                      
 and sm.CompanyId=g.CompanyId and sm.BranchId=g.BranchId                       
 and sm.FinancialYearId=g.FinancialYearId                      
 and s.KapanId=g.KapanId and s.ShapeId=g.ShapeId and s.SizeId=g.SizeId and s.PurityId=g.PurityId                      
 and s.GalaSizeId=g.GalaNumberId and s.CharniSizeId=g.CharniSizeId),0)'Weight',                      
 KapanId+ShapeId+SizeId+g.GalaNumberId+g.CharniSizeId'Id'                      
 from GalaProcessMaster g                      
 left join KapanMaster k on k.Id=g.KapanId                      
 left join ShapeMaster s on s.Id=g.ShapeId                      
 left join SizeMaster sz on sz.Id=g.SizeId                      
 left join GalaMaster gm on gm.Id=g.GalaNumberId                      
 left join PurityMaster p on p.Id=g.PurityId                      
 left join SizeMaster sz1 on sz1.Id=g.CharniSizeId                    
 where GalaProcessType=2                      
 and g.CompanyId=@CompanyId and g.BranchId=@BranchId and g.FinancialYearId=@FinancialYear                      
 group by g.CompanyId,g.FinancialYearId,KapanId,k.Name,ShapeId,s.Name,SizeId,sz.Name,PurityId,p.Name,GalaNumberId,gm.Name,g.CharniSizeId,sz1.Name,g.BranchId                      
End                      
else if(@ActionType=2)      --Boil                
Begin                      
 select b.CompanyId,b.FinancialYearId,KapanId,k.Name'Kapan',ShapeId,s.Name'Shape',SizeId,sz.Name'Size',PurityId,p.Name'Purity',''GalaNumberId,''GalaSize,''CharniSizeId,''CharniSize,''NumberSize,''NumberSizeId,                      
 sum(Weight)-isnull((                      
 select sum(Weight) from SalesMaster sm                      
 left join SalesDetails s on s.SalesId=sm.Id                      
 where s.Category=2                      
 and sm.CompanyId=b.CompanyId and sm.BranchId=b.BranchId                       
 and sm.FinancialYearId=b.FinancialYearId                      
 and s.KapanId=b.KapanId and s.ShapeId=b.ShapeId and s.SizeId=b.SizeId and s.PurityId=b.PurityId),0)'Weight',                      
 KapanId+ShapeId+SizeId'Id'                      
 from BoilProcessMaster b                      
 left join KapanMaster k on k.Id=b.KapanId                      
 left join ShapeMaster s on s.Id=b.ShapeId                      
 left join SizeMaster sz on sz.Id=b.SizeId                      
 left join PurityMaster p on p.Id=b.PurityId                      
 where BoilType=2         
 and b.CompanyId=@CompanyId and b.BranchId=@BranchId and b.FinancialYearId=@FinancialYear                      
 group by b.CompanyId,b.FinancialYearId,KapanId,k.Name,ShapeId,s.Name,SizeId,sz.Name,PurityId,p.Name,b.BranchId                      
End        
else if(@ActionType=1)      --Kapan                
Begin        
 select CompanyId,FinancialYearId,KapanId,Kapan,ShapeId,Shape,SizeId,Size,PurityId,Purity,GalaNumberId,GalaSize,CharniSizeId,CharniSize,NumberSize,NumberSizeId        
 ,KapanId+ShapeId+SizeId+PurityId'Id'        
 ,(sum(NetWeight)-sum(UsedWeight))        
  -isnull((select sum(LessWeight)+sum(NetWeight)+sum(TipWeight)         
 from SalesMaster sm        
 left join SalesDetails sd on sd.SalesId=sm.Id        
where sd.Category=1        
and sm.CompanyId=y.CompanyId and sm.FinancialYearId=y.FinancialYearId and sd.KapanId=y.KapanId and sd.ShapeId=y.ShapeId        
and sd.SizeId=y.SizeId and sd.PurityId=y.PurityId),0)'Weight'            
from(                
select x.* from(                
 select pm.CompanyId,pm.FinancialYearId,km.KapanId,k.Name'Kapan',pd.ShapeId,s.Name'Shape',pd.SizeId,sm.Name'Size',pd.PurityId,p.Name'Purity',''GalaNumberId,''GalaSize,''CharniSizeId,''CharniSize,''NumberSize,''NumberSizeId,                      
 sum(km.Weight)'NetWeight',isnull((select sum(AssignWeight)                  
from AccountToAssortDetails a                
left join AccountToAssortMaster am on am.Id=a.AccountToAssortMasterId                
where                     
AccountToAssortType=0                               
and a.SlipNo=convert(varchar,pm.SlipNo) and a.PurchaseDetailsId=pd.Id and a.ShapeId=pd.ShapeId and a.SizeId=pd.SizeId and a.PurityId=pd.PurityId                
and am.FinancialYearId=pm.FinancialYearId                
),0)'UsedWeight'        
from KapanMappingMaster km                
left join PurchaseDetails pd on pd.Id=km.PurchaseDetailsId                
left join PurchaseMaster pm on pm.Id=pd.PurchaseId                
left join KapanMaster k on k.Id=km.KapanId                
left join ShapeMaster s on s.Id=pd.ShapeId                
left join SizeMaster sm on sm.Id=pd.SizeId                
left join PurityMaster p on p.Id=pd.PurityId              
where pm.CompanyId=@CompanyId and pm.FinancialYearId=@FinancialYear  --Removed the branchid condition as per riddesh              
group by pm.CompanyId,km.KapanId,pm.SlipNo,k.Name,pd.ShapeId,s.Name,pd.SizeId,sm.Name,pd.PurityId,p.Name,pm.FinancialYearId,pd.Id                
)x                
            
union            
        
 select o.CompanyId,o.FinancialYearId,o.KapanId,k.Name'Kapan',        
 ShapeId,'N/A' as 'Shape', (case when SizeId='' then '00000000-0000-0000-0000-000000000000' else SizeId end)'SizeId',isnull(s.Name,'N/A')'Size',PurityId,'N/A' as 'Purity',        
 ''GalaNumberId,''GalaSize,''CharniSizeId,''CharniSize,''NumberSize,''NumberSizeId,                      
 sum(TotalCts)'NetWeight',isnull((select sum(AssignWeight)                  
from AccountToAssortDetails a                
left join AccountToAssortMaster am on am.Id=a.AccountToAssortMasterId                
where                     
AccountToAssortType=0                               
and a.SlipNo=0 and a.ShapeId=o.ShapeId and a.SizeId=o.SizeId and a.PurityId=o.PurityId                
and am.FinancialYearId=o.FinancialYearId                
),0)'UsedWeight'        
from OpeningStockMaster o            
left join KapanMaster k on k.Id=o.KapanId            
left join SizeMaster s on s.Id=o.SizeId            
where Category=1            
and o.CompanyId=@CompanyId and FinancialYearId=@FinancialYear            
group by o.CompanyId,o.KapanId,k.Name,ShapeId,SizeId,s.Name,PurityId,FinancialYearId            
)y            
where (NetWeight-UsedWeight)<>0        
group by CompanyId,FinancialYearId,KapanId,Kapan,ShapeId,Shape,SizeId,Size,PurityId,Purity,GalaNumberId,GalaSize,CharniSizeId,CharniSize,NumberSize,NumberSizeId        
      
union      
select x.CompanyId,FinancialYearId,KapanId,k.Name'Kapan',ShapeId,s.Name as 'Shape',      
SizeId,sz.Name as 'Size',PurityId,p.Name as 'Purity',      
''GalaNumberId,''GalaSize,''CharniSizeId,''CharniSize,''NumberSize,''NumberSizeId,      
x.CompanyId+KapanId+ShapeId+SizeId+PurityId+FinancialYearId'Id',      
sum(NetWeight)'Weight'      
from(        
--Boil        
select b.CompanyId,KapanId,SlipNo,ShapeId,        
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,            
FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',            
sum(Weight) as 'Weight',0 as 'RejectedWeight',            
0 as 'UsedWeight',            
KapanId+ShapeId+SizeId+PurityId+FinancialYearId'Id'            
from BoilProcessMaster b            
where BoilType=2            
and b.CompanyId=@CompanyId and FinancialYearId=@FinancialYear            
group by b.CompanyId,KapanId,SlipNo,ShapeId,SizeId,PurityId,FinancialYearId        
        
union         
--Charni        
select c.CompanyId,KapanId,SlipNo,ShapeId,        
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,            
FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',            
sum(Weight) as 'Weight',0 as 'RejectedWeight',            
0 as 'UsedWeight',            
KapanId+ShapeId+SizeId+PurityId+FinancialYearId'Id'            
from CharniProcessMaster c            
where CharniType=2            
and c.CompanyId=@CompanyId and FinancialYearId=@FinancialYear            
group by c.CompanyId,KapanId,SlipNo,ShapeId,SizeId,PurityId,FinancialYearId        
        
union        
--Gala        
select g.CompanyId,KapanId,SlipNo,ShapeId,        
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,            
FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',            
sum(Weight) as 'Weight',0 as 'RejectedWeight',            
0 as 'UsedWeight',            
KapanId+ShapeId+SizeId+PurityId+FinancialYearId'Id'            
from GalaProcessMaster g        
where GalaProcessType=2            
and g.CompanyId=@CompanyId and FinancialYearId=@FinancialYear            
group by g.CompanyId,KapanId,SlipNo,ShapeId,SizeId,PurityId,FinancialYearId,Id        
        
)x        
left join KapanMaster k on k.Id=x.KapanId            
left join ShapeMaster s on s.Id=x.ShapeId        
left join SizeMaster sz on sz.Id=x.SizeId            
left join PurityMaster p on p.Id=x.PurityId        
group by x.CompanyId,KapanId,k.Name,ShapeId,s.Name,SizeId,sz.Name,PurityId,p.Name,FinancialYearId        
      
End   
GO
/****** Object:  StoredProcedure [dbo].[GetSalesReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSalesReport]               
	@CompanyId as varchar(50),                      
	@FinancialYearId as varchar(50),            
	@FromDate as date = '',             
	@ToDate as date = '' ,        
	@ActionType INT = 0        
AS              
BEGIN              
IF @ActionType = 0             
            
	SELECT 
		SM.Id,
		BM.Name 'BranchName', 
		SM.CompanyId, 
		SM.FinancialYearId,           
		(case when SD.Category=1 then ISNULL(KM.Name,'') else ISNULL(N.Name,'') end) 'KapanName', 
		SM.SaleBillNo,           
		SM.SlipNo, 
		CAST(SM.Date as date) Date, 
		SM.Time, 
		SM.PartyId, 
		PAM.Name AS PartyName, 
		PAM.MobileNo,           
		SM.SalerId as SalerId, 
		PAM1.Name AS SalerName, 
		PAM1.MobileNo AS SalerMobileNo,             
		SM.BrokerageId, 
		PAM2.Name AS BrokerName, 
		PAM2.MobileNo AS BrokerMobileNo,             
		SM.Total, 
		SD.Amount 'GrossTotal', 
		SM.DueDays,SM.DueDate,
		SM.PaymentDays, 
		SM.PaymentDueDate, 
		SM.IsPF, 
		SM.IsSlip,             
		SM.UpdatedDate,
		SM.UpdatedBy, '' 'KapanId', 
		SD.Weight Weight,
		SD.SaleRate SaleRate, 
		SM.Remarks, 
		SM.Message,             
		SUM(ROUND(SD.CVDAmount,0)) 'CVDAmount', 
		SUM(SD.LessDiscountPercentage) 'LessWeight', 
		SD.NetWeight NetWeight, 
		SM.RoundUpAmount,            
		CONVERT(varchar, SM.ApprovalType)'ApprovalType'                
	FROM [SalesMaster] AS SM               
	INNER JOIN [SalesDetails] AS SD ON SM.Id = SD.SalesId              
	INNER JOIN [PartyMaster] AS PAM ON PAM.Id = SM.PartyId              
	INNER JOIN [PartyMaster] AS PAM1 ON PAM1.Id = SM.SalerId              
	INNER JOIN [PartyMaster] AS PAM2 ON PAM2.Id = SM.BrokerageId              
	LEFT JOIN BranchMaster AS BM ON SM.BranchId = BM.Id            
	LEFT JOIN [KapanMaster] AS KM ON KM.Id = SD.KapanId           
	LEFT JOIN [NumberMaster] AS N ON N.Id=SD.NumberSizeId             
	 WHERE SM.IsDelete = 0             
	AND (CAST(SM.Date as Date) >= @FromDate 
	AND CAST(SM.Date as Date) <= @ToDate)             
	AND SM.CompanyId = @CompanyId 
	AND SM.FinancialYearId = @FinancialYearId    
            
 GROUP BY            
	SM.Id, SM.CompanyId, SM.FinancialYearId, SM.SaleBillNo, SM.SlipNo, SM.Date, SM.Time, SM.PartyId, 
	PAM.Name, PAM.MobileNo, SM.SalerId, PAM1.Name, PAM1.MobileNo,             
	SM.BrokerageId, PAM2.Name, PAM2.MobileNo,SD.SaleRate,SD.NetWeight,            
	SM.Total,SD.Amount, SM.DueDays,SM.DueDate, SM.PaymentDays, SM.PaymentDueDate, SM.IsPF, SM.IsSlip,             
	SM.UpdatedDate, SM.UpdatedBy, SM.Remarks, SM.Message,            
	SM.RoundUpAmount, SM.ApprovalType, BM.Name, KM.Name, N.Name, SD.Category, SD.Weight  
 ORDER BY 
	SM.Date,
	SM.Time,
	SM.SlipNo DESC         
        
ELSE        
        
             
 SELECT       
 ISNULL(ROUND(SUM(SD.Amount),2), 0) TotalAmount      
 FROM [SalesMaster] AS SM               
 INNER JOIN [SalesDetails] AS SD ON SM.Id = SD.SalesId                      
 WHERE   
 SM.IsDelete = 0             
 and (CAST(SM.Date as Date) >= @FromDate AND CAST(SM.Date as Date) <= @ToDate)             
 and SM.CompanyId=@CompanyId AND SM.FinancialYearId=@FinancialYearId           
END 
GO
/****** Object:  StoredProcedure [dbo].[GetSalesSlipDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[GetSalesSlipDetail]
  
@Company as varchar(50),  
@SlipNo as varchar(50),  
@FinancialYear as varchar(50)
  
as  
  
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
where sm.CompanyId=@Company and sm.SlipNo=@SlipNo and sm.FinancialYearId=@FinancialYear  
)x  
GO
/****** Object:  StoredProcedure [dbo].[GetSlipDetail]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[GetSlipDetail]  
  
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
 convert(decimal(18,2),p.CVDCharge)'CVDCharge',--convert(decimal(18,2),(((p.Weight-p.TipWeight)*p.CVDCharge)))'CVDCharge',    
 pm.DueDays,pm.PaymentDays     
 from PurchaseDetails p  
 left join PurchaseMaster pm on pm.Id=p.PurchaseId    
 left join PartyMaster party on party.Id=pm.PartyId  
 left join PartyMaster party1 on party1.Id=pm.BrokerageId     
 where pm.CompanyId=@Company and pm.SlipNo=@SlipNo and pm.FinancialYearId=@FinancialYear    
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
 convert(decimal(18,2),s.CVDCharge)'CVDCharge',--convert(decimal(18,2),(((s.Weight-s.TipWeight)*s.CVDCharge)))'CVDCharge',    
 sm.DueDays,sm.PaymentDays     
 from SalesDetails s  
 left join SalesMaster sm on sm.Id=s.SalesId  
 left join PartyMaster party on party.Id=sm.PartyId  
 left join PartyMaster party1 on party1.Id=sm.BrokerageId     
 where sm.CompanyId=@Company and sm.SlipNo=@SlipNo and sm.FinancialYearId=@FinancialYear    
 )x   
End
GO
/****** Object:  StoredProcedure [dbo].[GetStockReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetStockReport]  
  
@CompanyId as varchar(50)='',     
@FinancialYear as varchar(50) =''     
  
as  
BEGIN

SELECT BranchName, Type, ISNULL(TotalWeight,0) TotalWeight, kapanid, name 'Kapan', Size, GalaNumber, NumberId, Number, ISNULL(SUM(AvailableWeight),0) AvailableWeight, SUM(Rate) Rate, SUM(Amount) Amount from 
(
	SELECT SUM(TotalWeight) TotalWeight, Name, Id from 
			(SELECT SUM(PD.Weight) 'TotalWeight', KM.Name, KM.Id from PurchaseMaster PM
			INNER JOIN PurchaseDetails PD ON PM.Id = PD.PurchaseId 
			INNER JOIN KapanMappingMaster KMM ON KMM.PurchaseMasterId = PM.Id --GROUP By Pm.SlipNO
			INNER JOIN KapanMaster KM ON KMM.KapanId = KM.Id
			GROUP By KM.Name, Km.Id

			UNION

			select TotalCts 'TotalWeight', KM.Name, KM.Id from OpeningStockMaster OSM
			INNER JOIN KapanMaster KM ON OSM.KapanId = KM.Id
			WHERE OSM.Category = 1) t
			GROUP By Name, Id
)mappingmaster

RIGHT JOIN (

		SELECT BranchName,  Type, '' KapanId, '' Kapan, SizeId, Size, GalaNumberId, GalaNumber, NumberId, Number, SUM(AvailableWeight) 'AvailableWeight', SUM(Rate) 'Rate', SUM(Amount) Amount  FROM
		(
			Select * from 
			(
				--BOIL SEND
				select 'ST' 'BranchName', 'BoilSend' Type,KapanId, Kapan, SizeId, Size, '' GalaNumberId, '' GalaNumber, '' NumberId, '' Number, AvailableWeight,0 Rate, 0 Amount from(  
				select pm.SlipNo,pm.CompanyId,pm.BranchId,ad.PurchaseDetailsId,am.KapanId,k.Name'Kapan',pd.ShapeId,s.Name'Shape',  
				pd.SizeId,sm.Name'Size',pd.PurityId,p.Name'Purity',pm.FinancialYearId,
				sum(ad.AssignWeight)'NetWeight',sum(pd.TIPWeight)'TIPWeight',sum(pd.LessWeight)'LessWeight',    
				(sum(ad.AssignWeight)+sum(pd.TIPWeight)+sum(pd.LessWeight))'Weight',sum(pd.RejectedWeight)'RejectedWeight',  
				sum(ad.AssignWeight)-isnull((select sum(b.Weight)    
				from BoilProcessMaster b  
				where       
				BoilType=0                 
				and b.SlipNo=pm.SlipNo and b.PurchaseDetailsId=ad.PurchaseDetailsId and b.KapanId=am.KapanId and b.ShapeId=pd.ShapeId and b.SizeId=pd.SizeId and b.PurityId=pd.PurityId  
				and b.FinancialYearId=pm.FinancialYearId  
				),0)'AvailableWeight',  
				convert(varchar,pm.SlipNo)+am.KapanId+pd.ShapeId+pd.SizeId+pd.PurityId+pm.FinancialYearId+ad.PurchaseDetailsId'Id'  
				from AccountToAssortMaster am  
				left join AccountToAssortDetails ad on ad.AccountToAssortMasterId=am.Id  
				left join PurchaseDetails pd on pd.Id=ad.PurchaseDetailsId  
				left join PurchaseMaster pm on pm.Id=pd.PurchaseId  
				left join KapanMaster k on k.Id=am.KapanId  
				left join ShapeMaster s on s.Id=pd.ShapeId  
				left join SizeMaster sm on sm.Id=pd.SizeId  
				left join PurityMaster p on p.Id=pd.PurityId  
				--where pm.CompanyId=@CompanyId and pm.FinancialYearId=@FinancialYear  
				group by pm.SlipNo,am.KapanId,k.Name,pd.ShapeId,s.Name,pd.SizeId,sm.Name,pd.PurityId,p.Name,pm.FinancialYearId,ad.PurchaseDetailsId, pm.CompanyId, pm.BranchId  
				)x  
				where x.AvailableWeight<>0

				UNION

				--convert(varchar,BoilNo)+KapanId+ShapeId+SizeId+PurityId'Id'
				select 'ST' 'BranchName', 'BoilReceive' Type, KapanId, Kapan, SizeId, Size, '' GalaNumberId, '' GalaNumber, '' NumberId, '' Number, AvailableWeight,0 Rate, 0 Amount
				 from(      
				select BoilNo,KapanId,Kapan,ShapeID,Shape,SizeID,Size,PurityId,Purity,sum(Weight)-x.ReceivedWeight'AvailableWeight',       
				STUFF(      
				(SELECT ',' + convert(varchar,b1.SlipNo)      
				FROM BoilProcessMaster b1      
				WHERE BoilType=0 and b1.BoilNo = x.BoilNo and b1.KapanId=x.KapanId and b1.ShapeId=x.ShapeID and b1.SizeID=x.SizeID and b1.PurityId=x.PurityId
				FOR XML PATH('')),1,1,'')'SlipNo',sum(x.Weight)'TotalWeight'      
				from         
				(select BoilNo,SlipNo,EntryDate,b.KapanId,k.Name'Kapan',b.ShapeId,s.Name'Shape',b.SizeId,sz.Name'Size',b.PurityId,p.Name'Purity',        
				Weight,isnull((select sum(Weight)+sum(LossWeight) from BoilProcessMaster b1        
				where b1.BoilType=1 and b1.BoilNo=b.BoilNo and        
				b1.KapanId=b.KapanId and b1.ShapeId=b.ShapeId and b1.SizeId=b.SizeId and b1.PurityId=b.PurityId and b1.FinancialYearId=b.FinancialYearId
				),0)'ReceivedWeight',              
				b.KapanId+b.ShapeId+b.SizeId+b.PurityId+CONVERT(nvarchar(10),b.BoilNo) as 'ID'               
				from BoilProcessMaster b              
				left join KapanMaster k on k.Id=b.KapanId
				left join ShapeMaster s on s.Id=b.ShapeId
				left join SizeMaster sz on sz.Id=b.SizeId
				left join PurityMaster p on p.Id=b.PurityId
				where BoilType=0 --Send
				--	and b.HandOverToId=@ReceivedFrom and b.CompanyId=@CompanyId and b.FinancialYearId=@FinancialYear
				)x      
				group by BoilNo,KapanId,Kapan,ShapeID,Shape,SizeID,Size,PurityId,Purity,x.ReceivedWeight        
				)y      
				where AvailableWeight <> 0 

				UNION

				-- CHARNI SEND      
				select 'ST' 'BranchName', 'CharniSend' Type, KapanId, Kapan, SizeId, Size,'' GalaNumberId, '' GalaNumber, '' NumberId, '' Number, AvailableWeight,0 Rate, 0 Amount from(      
				select SlipNo,BoilNo,KapanId,Kapan,ShapeID,Shape,SizeID,Size,PurityId,Purity,ID,SUM(Weight)'Weight',FinancialYearId,      
				SUM(Weight)-isnull((select sum(c.Weight) from CharniProcessMaster c         
				where CharniType=0  
				and c.CompanyId=x.CompanyId 
				--and c.BranchId=x.BranchId 
				and c.SlipNo=x.SlipNo and c.KapanId=x.KapanId and c.ShapeId=x.ShapeId and c.SizeId=x.SizeId
				and c.PurityId=x.PurityId and c.FinancialYearId=x.FinancialYearId and c.BoilJangadNo=x.BoilNo
				),0)
				-isnull((select sum(b1.Weight) from BoilProcessMaster b1        
				where b1.CompanyId=x.CompanyId 
				--and b1.BranchId=x.BranchId 
				and b1.KapanId=x.KapanId and b1.ShapeId=x.ShapeId 
				and b1.SizeId=x.SizeId and b1.PurityId=x.PurityId and b1.SlipNo=x.SlipNo and b1.BoilNo=x.BoilNo and b1.FinancialYearId=x.FinancialYearId
				and b1.BoilType=2),0)'AvailableWeight'
				from(          
				select b.SlipNo,b.JangadNo,b.BoilNo,b.KapanId,k.Name'Kapan',b.ShapeId,s.Name'Shape',b.SizeId,sz.Name'Size',b.PurityId,p.Name'Purity',
				b.Weight,b.FinancialYearId,b.CompanyId,b.BranchId,          
				CONVERT(nvarchar(10),b.SlipNo)+b.KapanId+b.ShapeId+b.SizeId+b.PurityId+convert(varchar,b.BoilNo) as 'ID'           
				from BoilProcessMaster b          
				left join KapanMaster k on k.Id=b.KapanId
				left join ShapeMaster s on s.Id=b.ShapeId
				left join SizeMaster sz on sz.Id=b.SizeId
				left join PurityMaster p on p.Id=b.PurityId
				where 
				--b.CompanyId=@CompanyId and b.FinancialYearId=@FinancialYear and
				b.BoilNo in (          
				select * from(          
				select max(b1.BoilNo) as id from BoilProcessMaster b1        
				where b1.CompanyId=b.CompanyId 
				and b1.KapanId=b.KapanId and b1.ShapeId=b.ShapeId 
				and b1.SizeId=b.SizeId and b1.PurityId=b.PurityId and b1.FinancialYearId=b.FinancialYearId
				group by b1.BoilNo)x)          
				and BoilType=1
				--and b.BoilNo not in (select distinct c.BoilJangadNo from CharniProcessMaster c where c.CompanyId=b.CompanyId and c.BranchId=b.BranchId 
				--and c.KapanId=b.KapanId and c.ShapeId=b.ShapeId and c.SizeId=b.SizeId and c.PurityId=b.PurityId and c.FinancialYearId=b.FinancialYearId)      
				)x      
				group by SlipNo,BoilNo,KapanId,Kapan,ShapeId,Shape,SizeID,Size,PurityId,Purity,ID,FinancialYearId,CompanyId,BranchId
				)y      
				where AvailableWeight<>0 

				UNION

				--Charni Receive
				select 'ST' 'BranchName', 'CharniReceive' Type, KapanId, Kapan, SizeId, Size, '' GalaNumberId, '' GalaNumber, '' NumberId, '' Number, AvailableWeight,0 Rate, 0 Amount from(            
				select y.SlipNo,y.CharniNo,y.EntryDate,y.BoilJangadNo,y.KapanId,y.Kapan,y.ShapeID,y.Shape,y.SizeID,y.Size,y.PurityId,y.Purity,
				y.Weight,y.ID,y.FinancialYearId,            
				y.Weight-isnull((select sum(c1.CharniWeight)+sum(c1.LossWeight)+sum(c1.RejectionWeight) from CharniProcessMaster c1               
				where c1.CharniType = 1
				and c1.CompanyId=y.CompanyId 
				--and c1.BranchId=y.BranchId 
				and c1.SlipNo=y.SlipNo and c1.KapanId=y.KapanId and c1.ShapeId=y.ShapeID            
				and c1.SizeId=y.SizeID and c1.PurityId=y.PurityId and c1.FinancialYearId=y.FinancialYearId and c1.BoilJangadNo=y.BoilJangadNo            
				and c1.CharniNo=y.CharniNo
				),0)'AvailableWeight'                   
				from(            
				select c.SlipNo,c.CharniNo,c.EntryDate,c.BoilJangadNo,c.KapanId,k.Name'Kapan',c.ShapeId,s.Name'Shape',c.SizeId,sz.Name'Size',c.PurityId,p.Name'Purity',
				sum(c.Weight)'Weight',c.FinancialYearId,c.CompanyId,c.BranchId,            
				c.SlipNo+c.KapanId+c.ShapeId+c.SizeId+c.PurityId+CONVERT(nvarchar(10),c.CharniNo) as 'ID'                   
				from CharniProcessMaster c                  
				left join KapanMaster k on k.Id=c.KapanId
				left join ShapeMaster s on s.Id=c.ShapeId
				left join SizeMaster sz on sz.Id=c.SizeId
				left join PurityMaster p on p.Id=c.PurityId
				where c.CharniType=0 
				--and c.HandOverToId=@ReceivedFrom and c.CompanyId=@CompanyId and c.FinancialYearId=@FinancialYear
				group by c.SlipNo,c.CharniNo,c.EntryDate,c.BoilJangadNo,c.KapanId,k.Name,c.ShapeId,s.Name,c.SizeId,sz.Name,c.PurityId,p.Name,c.FinancialYearId,c.CompanyId,c.BranchId            
				)y            
				)z where AvailableWeight<>0 


				UNION

				-- GALA SEND
				select 'ST' 'BranchName', 'GalaSend' Type, KapanId, Kapan, CharniSizeId 'SizeId', CharniSize 'Size', '' GalaNumberId, '' GalaNumber, '' NumberId, '' Number, AvailableWeight,0 Rate, 0 Amount
				from (          
				select   
				STUFF(        
				(SELECT ',' + convert(nvarchar(MAX),c1.SlipNo)        
				FROM CharniProcessMaster c1  
				WHERE c1.CompanyId=c.CompanyId 
				--and c1.BranchId=c.BranchId 
				and c1.FinancialYearId=c.FinancialYearId and c1.CharniType=c.CharniType 
				and c1.KapanId=c.KapanId and c1.ShapeId=c.ShapeId and c1.SizeId=c.SizeId and c1.PurityId=c.PurityId and c1.CharniSizeId=c.CharniSizeId
				order by c1.SlipNo
				for xml path(''),TYPE).value('.', 'varchar(MAX)'),1,1,'') AS SlipNo,  
				c.KapanId,k.Name'Kapan',c.ShapeId,s.Name'Shape',c.SizeId,sz.Name'Size',c.PurityId,p.Name'Purity',c.FinancialYearId,c.CharniSizeId,s1.Name'CharniSize',          
				sum(c.CharniWeight)'Weight',sum(c.CharniWeight)
				-isnull((select sum(g.Weight)         
				from GalaProcessMaster g         
				where g.CompanyId=c.CompanyId --and g.BranchId=c.BranchId 
				and g.GalaProcessType=0 and g.KapanId=c.KapanId and g.ShapeId=c.ShapeId and g.SizeId=c.SizeId and g.PurityId=c.PurityId and g.CharniSizeId=c.CharniSizeId
				and g.FinancialYearId=c.FinancialYearId),0)
				-isnull((select sum(c2.CharniWeight) FROM CharniProcessMaster c2  
				WHERE c2.CompanyId=c.CompanyId and c2.FinancialYearId=c.FinancialYearId --and c2.BranchId=c.BranchId 
				and c2.KapanId=c.KapanId and c2.ShapeId=c.ShapeId and c2.SizeId=c.SizeId and c2.PurityId=c.PurityId and c2.CharniSizeId=c.CharniSizeId 
				and c2.CharniType=2),0)'AvailableWeight',          
				c.CompanyId+c.FinancialYearId+c.KapanId+c.ShapeId+c.SizeId+c.PurityId+c.CharniSizeId as 'ID' --+c.BranchId          
				from CharniProcessMaster c          
				left join KapanMaster k on k.Id=c.KapanId
				left join ShapeMaster s on s.Id=c.ShapeId
				left join SizeMaster s1 on s1.Id=c.CharniSizeId
				left join SizeMaster sz on sz.Id=c.SizeId
				left join PurityMaster p on p.Id=c.PurityId
				where c.CharniType=1
				--and c.CompanyId=@CompanyId and c.FinancialYearId=@FinancialYear
				group by c.KapanId,k.Name,c.ShapeId,s.Name,c.SizeId,sz.Name,c.PurityId,p.Name,c.CharniType,c.CompanyId,c.FinancialYearId,c.CharniSizeId,s1.Name--,c.BranchId
				)x          
				where AvailableWeight<>0   

				UNION

				select 'ST' 'BranchName', 'GalaReceive' Type, KapanId, Kapan, CharniSizeId 'SizeId', CharniSize 'Size', '' GalaNumberId, '' GalaNumber, '' NumberId, '' Number, AvailableWeight,0 Rate, 0 Amount from(            
				select g.GalaNo,g.KapanId,k.Name'Kapan',g.ShapeId,s.Name'Shape',g.SizeId,sz.Name'Size',g.PurityId,p.Name'Purity',        
				sum(g.Weight)'Weight',g.FinancialYearId,g.CharniSizeId,sz1.Name'CharniSize',    
				sum(g.Weight)-isnull((select sum(g1.GalaWeight)+sum(g1.LossWeight)+sum(g1.RejectionWeight) from GalaProcessMaster g1                 
				where g1.GalaProcessType=1                   
				and g1.CompanyId=g.CompanyId 
				--and g1.BranchId=g.BranchId 
				and g1.KapanId=g.KapanId and g1.ShapeId=g.ShapeId  
				and g1.SizeId=g.SizeId and g1.PurityId=g.PurityId and g1.FinancialYearId=g.FinancialYearId          
				and g1.GalaNo=g.GalaNo and g1.CharniSizeId=g.CharniSizeId 
				),0)'AvailableWeight',        
				STUFF(            
				(SELECT ',' + convert(nvarchar(max),g1.SlipNo)            
				FROM GalaProcessMaster g1            
				WHERE g1.GalaProcessType=0 and g1.CompanyId=g.CompanyId 
				--and g1.BranchId=g.BranchId 
				and g1.FinancialYearId=g.FinancialYearId and  
				g1.KapanId=g.KapanId and g1.GalaNo = g.GalaNo and g1.KapanId=g.KapanId and g1.ShapeId=g.ShapeId and g1.SizeId=g.SizeId and g1.PurityId=g.PurityId and g1.CharniSizeId=g.CharniSizeId        
				FOR XML PATH('')),1,1,'') AS SlipNo,             
				g.KapanId+g.ShapeId+g.SizeId+g.PurityId+CONVERT(nvarchar(10),g.GalaNo)+g.CharniSizeId as 'ID'             
				from GalaProcessMaster g            
				left join KapanMaster k on k.Id=g.KapanId  
				left join ShapeMaster s on s.Id=g.ShapeId  
				left join SizeMaster sz on sz.Id=g.SizeId
				left join SizeMaster sz1 on sz1.Id=g.CharniSizeId
				left join PurityMaster p on p.Id=g.PurityId  
				where g.GalaProcessType=0   
				--and g.HandOverToId=@ReceivedFrom and g.CompanyId=@CompanyId and g.FinancialYearId=@FinancialYear   
				group by g.GalaNo,g.KapanId,k.Name,g.ShapeId,s.Name,g.SizeId,sz.Name,g.PurityId,p.Name,g.FinancialYearId,g.CompanyId,g.CharniSizeId,sz1.Name--,g.BranchId  
				)x          
				where AvailableWeight<>0 

				UNION

				--NUmber Send
				select 'ST' 'BranchName', 'NumberSend' Type, KapanId, Kapan, CharniSizeId 'SizeId', CharniSize 'Size', GalaNumberId, GalaNumber,'' NumberId, '' Number, AvailableWeight,0 Rate, 0 Amount from(            
				select       
				STUFF(            
				(SELECT ',' + convert(nvarchar(MAX),g1.SlipNo)            
				FROM GalaProcessMaster g1      
				WHERE g1.GalaProcessType=g.GalaProcessType and g1.CompanyId=g.CompanyId --and g1.BranchId=g.BranchId     
				and g1.FinancialYearId=g.FinancialYearId    
				and g1.KapanId=g.KapanId and g1.ShapeId=g.ShapeId and g1.SizeId=g.SizeId    
				and g1.PurityId=g.PurityId and g1.GalaNumberID=g.GalaNumberId and g1.CharniSizeId=g.CharniSizeId    
				order by g1.SlipNo      
				for xml path(''),TYPE).value('.', 'varchar(MAX)'),1,1,'') AS SlipNo,      
				g.KapanId,k.Name'Kapan',g.ShapeId,s.Name'Shape',g.SizeId,sz.Name'Size',g.PurityId,p.Name'Purity',    
				g.GalaNumberId,gm.Name'GalaNumber',g.FinancialYearId,g.CharniSizeId,sz1.Name'CharniSize',            
				sum(g.GalaWeight)'Weight',sum(g.GalaWeight)-isnull((select sum(n.Weight)           
				from NumberProcessMaster n           
				where n.NumberProcessType=0 and n.CompanyId=g.CompanyId --and n.BranchId=g.BranchId     
				and n.FinancialYearId=g.FinancialYearId    
				and n.KapanId=g.KapanId and n.ShapeId=g.ShapeId and n.SizeId=g.SizeId    
				and n.PurityId=g.PurityId and n.GalaNumberID=g.GalaNumberId
				and n.CharniSizeId=g.CharniSizeId),0)    
				-isnull((select sum(GalaWeight)    
				FROM GalaProcessMaster g2      
				WHERE g2.CompanyId=g.CompanyId --and g2.BranchId=g.BranchId     
				and g2.FinancialYearId=g.FinancialYearId    
				and g2.KapanId=g.KapanId and g2.ShapeId=g.ShapeId and g2.SizeId=g.SizeId    
				and g2.PurityId=g.PurityId and g2.GalaNumberID=g.GalaNumberId and g2.GalaProcessType=2 and g2.CharniSizeId=g.CharniSizeId),0)'AvailableWeight',            
				g.KapanId+g.ShapeId+g.SizeId+g.PurityId+g.GalaNumberId+g.CompanyId+g.FinancialYearId+g.CharniSizeId as 'ID'         --+g.BranchId    
				from GalaProcessMaster g            
				left join KapanMaster k on k.Id=g.KapanId    
				left join ShapeMaster s on s.Id=g.ShapeId    
				left join SizeMaster sz on sz.Id=g.SizeId    
				left join PurityMaster p on p.Id=g.PurityId    
				left join GalaMaster gm on gm.Id=g.GalaNumberID            
				left join SizeMaster sz1 on sz1.Id=g.CharniSizeId
				where g.GalaProcessType=1      
				--and g.CompanyId=@CompanyId and g.FinancialYearId=@FinancialYear    
				group by g.KapanId,k.Name,g.ShapeId,s.Name,g.SizeId,sz.Name,g.PurityId,p.Name,gm.Name,g.GalaProcessType,g.CompanyId,g.FinancialYearId,g.GalaNumberId,g.CharniSizeId,sz1.Name--,g.BranchId    
				)x             
			where AvailableWeight<>0) Pending

			UNION

			--Number Receive    
			select 'ST' 'BranchName', 'NumberReceive' Type, KapanId, Kapan, CharniSizeId 'SizeId', CharniSize 'Size', GalaNumberId, GalaNumber, '' NumberId, '' Number, AvailableWeight,0 Rate, 0 Amount 
			FROM(          
				select n.NumberNo,n.KapanId,k.Name'Kapan',n.ShapeId,s.Name'Shape',n.SizeId,sz.Name'Size',n.PurityId,p.Name'Purity',    
				n.GalaNumberID,gm.Name'GalaNumber',sum(n.Weight)'Weight',n.FinancialYearId,n.CharniSizeId,sz1.Name'CharniSize',            
				sum(n.Weight)-isnull(
				(select sum(n1.NumberWeight)+sum(n1.LossWeight)+sum(n1.RejectionWeight) from NumberProcessMaster n1          
					where n1.NumberProcessType =1    
					and n1.NumberNo = n.NumberNo and n1.CompanyId=n.CompanyId --and n1.BranchId=n.BranchId   
					and n1.FinancialYearId=n.FinancialYearId    
					and n1.GalaNumberId=n.GalaNumberId and n1.KapanId=n.KapanId and n1.ShapeId=n.ShapeId and n1.SizeId=n.SizeId and n1.PurityId=n.PurityId    
					and n1.CharniSizeId=n.CharniSizeId),0
				)'AvailableWeight',         
				STUFF(            
					(SELECT ',' + convert(varchar,n1.SlipNo)            
					FROM NumberProcessMaster n1            
						Where n1.NumberProcessType=0 and n1.NumberNo = n.NumberNo and n1.CompanyId=n.CompanyId --and n1.BranchId=n.BranchId   
						and n1.FinancialYearId=n.FinancialYearId    
						and n1.GalaNumberId=n.GalaNumberId and n1.KapanId=n.KapanId and n1.ShapeId=n.ShapeId and n1.SizeId=n.SizeId and n1.PurityId=n.PurityId
						and n1.CharniSizeId=n.CharniSizeId
						FOR XML PATH('')),1,1,''
					) AS SlipNo,          
					n.KapanId+n.ShapeId+n.SizeId+n.PurityId+CONVERT(nvarchar(10),n.NumberNo)+n.GalaNumberID+n.CharniSizeId as 'ID'             
					from NumberProcessMaster n            
					left join KapanMaster k on k.Id=n.KapanId    
					left join ShapeMaster s on s.Id=n.ShapeId    
					left join SizeMaster sz on sz.Id=n.SizeId    
					left join PurityMaster p on p.Id=n.PurityId    
					left join GalaMaster gm on gm.Id=n.GalaNumberID            
					left join SizeMaster sz1 on sz1.Id=n.CharniSizeId
					left join NumberMaster nm on nm.Id = n.NumberId
					where n.NumberProcessType=0  
					--and n.HandOverToId=@ReceivedFrom and n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYear    
					group by n.NumberNo,n.KapanId,k.Name,n.ShapeId,s.Name,n.SizeId,sz.Name,n.PurityId,p.Name,n.GalaNumberID,gm.Name,n.FinancialYearId,n.CompanyId,n.CharniSizeId,sz1.Name--,n.BranchId          
			)x            
			where AvailableWeight<>0 

			UNION

			-- Assort Receive 
			select 'ST' 'BranchName', 'AssortReceive' Type, KapanId, Kapan, CharniSizeId 'SizeId', CharniSize 'Size', '' GalaNumberId, '' GalaNumber, NumberId, Number, AvailableWeight,0 Rate, 0 Amount from(            
			select       
			STUFF(            
			(SELECT ',' + convert(nvarchar(MAX),n1.SlipNo)            
			FROM NumberProcessMaster n1      
			WHERE n1.NumberProcessType=n.NumberProcessType and n1.CompanyId=n.CompanyId --and n1.BranchId=n.BranchId     
			and n1.FinancialYearId=n.FinancialYearId    
			and n1.KapanId=n.KapanId and n1.ShapeId=n.ShapeId and n1.SizeId=n.SizeId    
			and n1.PurityId=n.PurityId and n1.NumberID=n.NumberID and isnull(n1.CharniSizeId,'')=isnull(n.CharniSizeId,'')   
			order by n1.SlipNo      
			for xml path(''),TYPE).value('.', 'varchar(MAX)'),1,1,'') AS SlipNo,      
			n.KapanId,k.Name'Kapan',n.ShapeId,s.Name'Shape',n.SizeId,sz.Name'Size',n.PurityId,p.Name'Purity',    
			n.NumberId,nm.Name'Number',n.FinancialYearId,n.CharniSizeId,sz1.Name'CharniSize',            
			sum(n.NumberWeight)'Weight',    
			sum(n.NumberWeight)-isnull((select sum(n2.NumberWeight)    
			FROM NumberProcessMaster n2      
			WHERE n2.CompanyId=n.CompanyId --and n2.BranchId=n.BranchId     
			and n2.FinancialYearId=n.FinancialYearId    
			and n2.KapanId=n.KapanId and n2.ShapeId=n.ShapeId and n2.SizeId=n.SizeId    
			and n2.PurityId=n.PurityId and n2.NumberId=n.NumberId   
			and n2.CharniSizeId=n.CharniSizeId and n2.NumberProcessType=2),0)'AvailableWeight',            
			n.KapanId+n.ShapeId+n.SizeId+n.PurityId+n.CompanyId+n.FinancialYearId+n.NumberId+n.CharniSizeId as 'ID'         --+n.BranchId    
			from NumberProcessMaster n     
			left join KapanMaster k on k.Id=n.KapanId    
			left join ShapeMaster s on s.Id=n.ShapeId    
			left join SizeMaster sz on sz.Id=n.SizeId    
			left join PurityMaster p on p.Id=n.PurityId            
			left join NumberMaster nm on nm.Id=n.NumberID    
			left join SizeMaster sz1 on sz1.Id=n.CharniSizeId  
			where n.NumberProcessType=1
			--and n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYear    
			group by n.KapanId,k.Name,n.ShapeId,s.Name,n.SizeId,sz.Name,n.PurityId,p.Name,n.CompanyId,n.FinancialYearId,n.NumberId,nm.Name,n.NumberProcessType,n.CharniSizeId,sz1.Name--,n.BranchId    
			)x             
			where AvailableWeight<>0 

			UNION

			-- Opening Stock 
			select 'ST' 'BranchName', 'OpeningStock' Type, KapanId, Kapan, CharniSizeId 'SizeId', CharniSize 'Size', '' GalaNumberId, '' GalaNumber, NumberId, Number, AvailableWeight,0 Rate, 0 Amount from(            
			select       
			STUFF(            
			(SELECT ',' + convert(nvarchar(MAX),n1.SlipNo)            
			FROM NumberProcessMaster n1      
			WHERE n1.NumberProcessType=n.NumberProcessType and n1.CompanyId=n.CompanyId --and n1.BranchId=n.BranchId     
			and n1.FinancialYearId=n.FinancialYearId    
			and n1.KapanId=n.KapanId and n1.ShapeId=n.ShapeId and n1.SizeId=n.SizeId    
			and n1.PurityId=n.PurityId and n1.NumberID=n.NumberID and isnull(n1.CharniSizeId,'')=isnull(n.CharniSizeId,'')   
			order by n1.SlipNo      
			for xml path(''),TYPE).value('.', 'varchar(MAX)'),1,1,'') AS SlipNo,      
			n.KapanId,k.Name'Kapan',n.ShapeId,s.Name'Shape',n.SizeId,sz.Name'Size',n.PurityId,p.Name'Purity',    
			n.NumberId,nm.Name'Number',n.FinancialYearId,n.CharniSizeId,sz1.Name'CharniSize',            
			sum(n.NumberWeight)'Weight',    
			sum(n.NumberWeight)-isnull((select sum(n2.NumberWeight)    
			FROM NumberProcessMaster n2      
			WHERE n2.CompanyId=n.CompanyId --and n2.BranchId=n.BranchId     
			and n2.FinancialYearId=n.FinancialYearId    
			and n2.KapanId=n.KapanId and n2.ShapeId=n.ShapeId and n2.SizeId=n.SizeId    
			and n2.PurityId=n.PurityId and n2.NumberId=n.NumberId   
			and n2.CharniSizeId=n.CharniSizeId and n2.NumberProcessType=2),0)'AvailableWeight',            
			n.KapanId+n.ShapeId+n.SizeId+n.PurityId+n.CompanyId+n.FinancialYearId+n.NumberId+n.CharniSizeId as 'ID'         --+n.BranchId    
			from NumberProcessMaster n     
			left join KapanMaster k on k.Id=n.KapanId    
			left join ShapeMaster s on s.Id=n.ShapeId    
			left join SizeMaster sz on sz.Id=n.SizeId    
			left join PurityMaster p on p.Id=n.PurityId            
			left join NumberMaster nm on nm.Id=n.NumberID    
			left join SizeMaster sz1 on sz1.Id=n.CharniSizeId  
			where n.NumberProcessType = 4     
			--and n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYear    
			group by n.KapanId,k.Name,n.ShapeId,s.Name,n.SizeId,sz.Name,n.PurityId,p.Name,n.CompanyId,n.FinancialYearId,n.NumberId,nm.Name,n.NumberProcessType,n.CharniSizeId,sz1.Name--,n.BranchId    
			)x             
			where AvailableWeight<>0 

			UNION

			-- Get Sales Weight
			SELECT BM.Name 'BranchName', 'OpeningStock' Type, '' KapanId, '' Kapan, CharniSizeId 'SizeId', 
			SM.Name Size, GalaSizeId 'GalaNumberId', '' GalaNumber, NumberSizeId 'NumberId', NM.Name Number, 
			(0-SUM(Weight)) 'AvailableWeight',0 Rate, 0 Amount FROM SalesDetails SD
				INNER JOIN SalesMaster SMM ON SMM.Id = SD.SalesId
				INNER JOIN BranchMaster BM ON BM.Id = SMM.BranchId
				INNER JOIN SizeMaster SM ON SM.Id = SD.CharniSizeId
				INNER JOIN NumberMaster NM on NM.Id = SD.NumberSizeId
				Group BY CharniSizeId, SM.Name, GalaSizeId, NumberSizeId, NM.Name, BM.Name

		)temp GRoUP BY Type, SizeId, Size, GalaNumberId, GalaNumber, NumberId, Number, BranchName	

		UNION		

		-- Get KAPAN CONT
		select BM.Name 'BranchName', 'KapanOpenStock' Type, KapanId, KM.name Kapan, SizeId, SM.Name Size, '' GalaNumberId, '' GalaNumber, 
		NumberId, '' Number, TotalCts 'AvailableWeight',Rate, Amount  from OpeningStockMaster OSM
		INNER JOIN BranchMaster BM ON BM.Id = OSM.BranchId
		LEFT JOIN KapanMaster KM ON OSM.KapanId = KM.Id
		LEFT JOIN SizeMaster SM ON SM.Id = OSM.SizeId
		WHERE OSM.Category = 1
) p
 
ON mappingmaster.Id = p.KapanId

GROUP by TotalWeight, name, kapanid, Kapan, Size, GalaNumber, Type, NumberId, Number, BranchName

END
GO
/****** Object:  StoredProcedure [dbo].[GetTransferCategoryList]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Exec GetTransferCategoryList 'c444ca9f-03ec-493f-9447-4e1bf15eefbf','8e34d261-0a6b-44ac-9f86-89d5fdd5ef56'
CREATE proc [dbo].[GetTransferCategoryList]  
  
@CompanyId as varchar(50),                  
@FinancialYear as varchar(50)              
          
as    
  
select * from(  
select distinct KapanId'ID',Kapan'Name',1 as CategoryID,'Kapan' as Category  
from(          
select * from(          
select km.KapanId,k.Name'Kapan',  
(sum(km.Weight)+sum(pd.TIPWeight)+sum(pd.LessWeight))'Weight',sum(pd.RejectedWeight)'RejectedWeight',          
isnull((select sum(AssignWeight)            
from AccountToAssortDetails a          
left join AccountToAssortMaster am on am.Id=a.AccountToAssortMasterId          
where               
AccountToAssortType=0                         
and a.SlipNo=convert(varchar,pm.SlipNo) and a.PurchaseDetailsId=pd.Id and a.ShapeId=pd.ShapeId and a.SizeId=pd.SizeId and a.PurityId=pd.PurityId          
and am.FinancialYearId=pm.FinancialYearId          
),0)'UsedWeight',      
convert(varchar,pm.SlipNo)+km.KapanId+pd.ID+pd.ShapeId+pd.SizeId+pd.PurityId+pm.FinancialYearId'Id'          
from KapanMappingMaster km          
left join PurchaseDetails pd on pd.Id=km.PurchaseDetailsId          
left join PurchaseMaster pm on pm.Id=pd.PurchaseId          
left join KapanMaster k on k.Id=km.KapanId          
where pm.CompanyId=@CompanyId and pm.FinancialYearId=@FinancialYear  --Removed the branchid condition as per riddesh        
group by km.KapanId,pm.SlipNo,k.Name,pd.ShapeId,pd.SizeId,pd.PurityId,pm.FinancialYearId,pd.Id,pd.PurchaseId          
)x          
      
union      
      
select KapanId,k.Name'Kapan',    
sum(TotalCts) as 'Weight','0' as 'RejectedWeight',      
isnull((select sum(AssignWeight)            
from AccountToAssortDetails a          
left join AccountToAssortMaster am on am.Id=a.AccountToAssortMasterId          
where               
AccountToAssortType=0                         
and a.SlipNo=0 and a.ShapeId=o.ShapeId and a.SizeId=o.SizeId and a.PurityId=o.PurityId          
and am.FinancialYearId=o.FinancialYearId          
),0)'UsedWeight',      
KapanId+ShapeId+SizeId+PurityId+o.FinancialYearId'Id'      
from OpeningStockMaster o      
left join KapanMaster k on k.Id=o.KapanId      
where Category=1      
and o.CompanyId=@CompanyId and o.FinancialYearId=@FinancialYear      
group by KapanId,k.Name,ShapeId,SizeId,PurityId,o.FinancialYearId     


union
select KapanId,k.Name'Kapan',
sum(NetWeight)'Weight','0' as 'RejectedWeight',0 as 'UsedWeight',KapanId as 'Id'
from(  
--Boil  
select b.CompanyId,KapanId,SlipNo,ShapeId,  
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,      
b.FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',      
sum(Weight) as 'Weight',0 as 'RejectedWeight',      
0 as 'UsedWeight',      
KapanId+ShapeId+SizeId+PurityId+b.FinancialYearId'Id'      
from BoilProcessMaster b      
where BoilType=2      
and b.CompanyId=@CompanyId and b.FinancialYearId=@FinancialYear      
group by b.CompanyId,KapanId,SlipNo,ShapeId,SizeId,PurityId,b.FinancialYearId  
  
union   
--Charni  
select c.CompanyId,KapanId,SlipNo,ShapeId,  
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,      
c.FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',      
sum(Weight) as 'Weight',0 as 'RejectedWeight',      
0 as 'UsedWeight',      
KapanId+ShapeId+SizeId+PurityId+c.FinancialYearId'Id'      
from CharniProcessMaster c      
where CharniType=2      
and c.CompanyId=@CompanyId and c.FinancialYearId=@FinancialYear      
group by c.CompanyId,KapanId,SlipNo,ShapeId,SizeId,PurityId,c.FinancialYearId  
  
union  
--Gala  
select g.CompanyId,KapanId,SlipNo,ShapeId,  
'' as 'PurchsaeDetailId','' as 'PurchaseMasterId',SizeId,PurityId,      
g.FinancialYearId,sum(Weight) as 'NetWeight',0 as 'TipWeight',0 as 'LessWeight',      
sum(Weight) as 'Weight',0 as 'RejectedWeight',      
0 as 'UsedWeight',      
KapanId+ShapeId+SizeId+PurityId+g.FinancialYearId'Id'      
from GalaProcessMaster g  
where GalaProcessType=2      
and g.CompanyId=@CompanyId and g.FinancialYearId=@FinancialYear      
group by g.CompanyId,KapanId,SlipNo,ShapeId,SizeId,PurityId,g.FinancialYearId,Id  
  
)x  
left join KapanMaster k on k.Id=x.KapanId      
group by KapanId,k.Name
)y      
where ((Weight+RejectedWeight)-UsedWeight)<>0  
  
union  
  
select distinct CharniSizeId'ID',CharniSize'Name',0 as CategoryID, 'Number' as Category from(      
 select          
 n.CharniSizeId,sz1.Name'CharniSize',            
 sum(NumberWeight)-isnull((              
 select sum(Weight) from SalesMaster sm              
 left join SalesDetails s on s.SalesId=sm.Id              
 where s.Category=0              
 and sm.CompanyId=n.CompanyId --and sm.BranchId=n.BranchId               
 and sm.FinancialYearId=n.FinancialYearId              
 and s.NumberSizeId=n.NumberId            
 and s.CharniSizeId=n.CharniSizeId),0)'Weight',              
 ShapeId+n.NumberId+n.CharniSizeId'Id'        
 from NumberProcessMaster n              
 left join ShapeMaster s on s.Id=n.ShapeId              
 left join NumberMaster nm on nm.Id=n.NumberId              
 left join SizeMaster sz1 on sz1.Id=n.CharniSizeId              
 where NumberProcessType in (2,3,4)    
 and n.CompanyId=@CompanyId and n.FinancialYearId=@FinancialYear              
 group by n.CompanyId,ShapeId,s.Name,n.FinancialYearId,NumberId,nm.Name,n.CharniSizeId,sz1.Name        
 )x      
 where Weight>0    
 )z  
order by Category
GO
/****** Object:  StoredProcedure [dbo].[GetTypeDetails]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetTypeDetails]  
  
as  

select Id,Name,1 as 'Type' from KapanMaster where IsDelete=0 and IsStatus=1
union
select Id,Name,0 as 'Type' from NumberMaster where IsDelete=0
GO
/****** Object:  StoredProcedure [dbo].[GetWeeklyPurchaseReport]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetWeeklyPurchaseReport]    
    
 @ActionType as int,    
 @CompanyId as varchar(50),                
 @FinancialYearId as varchar(50)        
    
AS        
    
if(@ActionType=0)    
BEGIN    
 select convert(varchar,Week)'WeekNo', convert(varchar,Week_Start_Date,103) + ' | ' + convert(varchar,Week_End_Date,103)'Period', sum(GrossTotal)'Amount',  
 convert(varchar,Week_Start_Date,112)'Week_Start_Date',convert(varchar,Week_End_Date,112)'Week_End_Date'   
 from(    
 SELECT DATEPART(week, pm.PaymentDueDate) AS Week    
 ,DATEADD(DAY, 2 - DATEPART(WEEKDAY, pm.PaymentDueDate), CAST(pm.PaymentDueDate AS DATE)) [Week_Start_Date]    
 ,DATEADD(DAY, 8 - DATEPART(WEEKDAY, pm.PaymentDueDate), CAST(pm.PaymentDueDate AS DATE)) [Week_End_Date],PM.GrossTotal    
  FROM [PurchaseMaster] AS PM     
  WHERE PM.CompanyId=@CompanyId AND PM.FinancialYearId=@FinancialYearId  AND PM.IsDelete = 0    
  )x    
  group by Week,Week_Start_Date,Week_End_Date    
 END
GO
/****** Object:  StoredProcedure [dbo].[Validate_Records]    Script Date: 11-03-2024 11:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Validate_Records]
	@Id NVARCHAR(50),
	@ActionId as int  
AS
BEGIN
	DECLARE @Count INT = 0;
	IF @ActionId = 1 -- Company Master Validation
	BEGIN	
		SELECT @Count = @Count + COUNT(Id) FROM BranchMaster WHERE CompanyId=@Id;
		IF @Count = 0
		BEGIN 
			DELETE FROM CompanyMaster WHERE Id=@Id;
		END
	END
	ELSE IF @ActionId = 2 -- Branch Master Validation
	BEGIN
		SELECT @Count = @Count + COUNT(Id) FROM GroupPaymentMaster WHERE BranchId=@Id;

		IF @Count = 0
		BEGIN
			DELETE FROM BranchMaster WHERE Id=@Id;
		END

	END
	ELSE IF @ActionId = 3 -- FinancialYear Master Validation
	BEGIN
		SELECT @Count = @Count + COUNT(Id) FROM GroupPaymentMaster WHERE FinancialYearId=@Id;

		IF @Count = 0
		BEGIN
			DELETE FROM FinancialYearMaster WHERE Id=@Id;
		END

	END
	ELSE IF @ActionId = 4 -- Party Master Validation
	BEGIN
		SELECT @Count = @Count + COUNT(Id) FROM SalaryDetails WHERE ToPartyId=@Id;
		SELECT @Count = @Count + COUNT(Id) FROM PurchaseMaster WHERE PartyId=@Id;
		SELECT @Count = @Count + COUNT(Id) FROM SalesMaster WHERE PartyId=@Id;

		IF @Count = 0
		BEGIN
			DELETE FROM PartyMaster WHERE Id=@Id;
		END

	END
	ELSE IF @ActionId = 5 -- SizeId Master Validation
	BEGIN		
		SELECT @Count = @Count + COUNT(Id) FROM PurchaseDetails WHERE SizeId=@Id;
		SELECT @Count = @Count + COUNT(Id) FROM SalesDetails WHERE SizeId=@Id;

		IF @Count = 0
		BEGIN
			DELETE FROM SizeMaster WHERE Id=@Id;
		END

	END
	ELSE IF @ActionId = 6 -- PurityId Master Validation
	BEGIN		
		SELECT @Count = @Count + COUNT(Id) FROM PurchaseDetails WHERE PurityId=@Id;
		SELECT @Count = @Count + COUNT(Id) FROM SalesDetails WHERE PurityId=@Id;

		IF @Count = 0
		BEGIN
			DELETE FROM PurityMaster WHERE Id=@Id;
		END

	END
	ELSE IF @ActionId = 7 -- ShapeId Master Validation
	BEGIN		
		SELECT @Count = @Count + COUNT(Id) FROM PurchaseDetails WHERE ShapeId=@Id;
		SELECT @Count = @Count + COUNT(Id) FROM SalesDetails WHERE ShapeId=@Id;
		
		IF @Count = 0
		BEGIN
			DELETE FROM ShapeMaster WHERE Id=@Id;
		END
	END
	ELSE IF @ActionId = 8 -- Gala Master Validation
	BEGIN		
		SELECT @Count = @Count + COUNT(Id) FROM SalesDetails WHERE GalaSizeId=@Id;
		IF @Count = 0
		BEGIN
			DELETE FROM GalaMaster WHERE Id=@Id;
		END
	END
	ELSE IF @ActionId = 9 -- NumberMaster Validation
	BEGIN		
		SELECT @Count = @Count + COUNT(Id) FROM SalesDetails WHERE NumberSizeId=@Id;
		IF @Count = 0
		BEGIN
			DELETE FROM NumberMaster WHERE Id=@Id;
		END
	END
	ELSE IF @ActionId = 10 -- CurrencyMaster Validation
	BEGIN		
		SELECT @Count = @Count + COUNT(Id) FROM PurchaseMaster WHERE CurrencyId=@Id;
		SELECT @Count = @Count + COUNT(Id) FROM SalesMaster WHERE CurrencyId=@Id;
		IF @Count = 0
		BEGIN
			DELETE FROM CurrencyMaster WHERE Id=@Id;
		END
	END
	ELSE IF @ActionId = 11 -- BrokerageMaster Validation
	BEGIN		
		SELECT @Count = @Count + COUNT(Id) FROM PartyMaster WHERE BrokerageId=@Id;
		SELECT @Count = @Count + COUNT(Id) FROM PurchaseMaster WHERE BrokerageId=@Id;
		SELECT @Count = @Count + COUNT(Id) FROM SalesMaster WHERE BrokerageId=@Id;
		IF @Count = 0
		BEGIN
			DELETE FROM BrokerageMaster WHERE Id=@Id;
		END
	END
	ELSE IF @ActionId = 12 -- LessWeightMasters Validation
	BEGIN		
		SELECT @Count = @Count + COUNT(Id) FROM BranchMaster WHERE LessWeightId=@Id;
		IF @Count = 0
		BEGIN
			DELETE FROM LessWeightDetails WHERE LessWeightId=@Id;
			DELETE FROM LessWeightMasters WHERE Id=@Id;
		END
	END
	ELSE IF @ActionId = 13 -- UserMaster Validation
	BEGIN		
		SELECT @Count = @Count + COUNT(Id) FROM GroupPaymentMaster WHERE CreatedBy=@Id OR UpdatedBy=@Id;
		SELECT @Count = @Count + COUNT(Id) FROM PartyMaster WHERE CreatedBy=@Id OR UpdatedBy=@Id;
		SELECT @Count = @Count + COUNT(Id) FROM SalesMaster WHERE CreatedBy=@Id OR UpdatedBy=@Id;
		SELECT @Count = @Count + COUNT(Id) FROM PurchaseMaster WHERE CreatedBy=@Id OR UpdatedBy=@Id;

		IF @Count = 0
		BEGIN
			DELETE FROM [UserPermissionChild] WHERE UserId=@Id;
			DELETE FROM [UserCompanyMappings] WHERE UserId=@Id;		
			DELETE FROM UserMaster WHERE Id=@Id;
		END
	END
	ELSE IF @ActionId = 14 -- KapanMaster Validation
	BEGIN		
		SELECT @Count = @Count + COUNT(Id) FROM KapanMappingMaster WHERE KapanId=@Id;
		SELECT @Count = @Count + COUNT(Id) FROM OpeningStockMaster WHERE KapanId=@Id;

		IF @Count = 0
		BEGIN
			DELETE FROM KapanMaster WHERE Id=@Id;
		END
	END

	SELECT @Count 'STATUS';
END

-- Select * from CompanyMaster
-- Select * from BranchMaster
-- Select * from SizeMaster
-- Select * from PartyMaster
-- Select * from FinancialyearMaster
-- Select * from GroupPaymentMaster
-- Select * from PaymentMaster
-- Select * from PartyMaster
-- Select * from SalaryDetails
-- Select * from PurchaseMaster
-- Select * from PurchaseDetails
-- Select * from SalesMaster
-- Select * from SalesDetails
-- Select * FROM LessWeightMasters
-- Select * from UserMaster
-- Select * FROM KapanMappingMaster
-- Select * FROM OpeningStockMaster
-- Select * FROM KapanMaster

-- EXEC [Validate_Records] '5ef91694-11db-4fa0-bf19-9e01688ed316', 4
GO

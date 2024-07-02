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
 (case when PD.LessWeight > 0 then PD.Amount/PD.NetWeight else PD.BuyingRate end) as 'Rate', PD.Amount as Amount,'Inward' as Category, 1 as CategoryId,1 as Records    
 FROM KapanMappingMaster KM                    
 Left JOIN [PurchaseMaster] AS PM ON PM.Id=KM.PurchaseMasterId                    
 Left JOIN [PurchaseDetails] AS PD ON PD.Id=KM.PurchaseDetailsId AND PM.Id = PD.PurchaseId                        
 Left JOIN [PartyMaster] AS PAM ON PAM.Id = PM.PartyId                     
 where KM.KapanId=@KapanId and isnull(KM.TransferType,'')=''                   
                    
 union                    
                    
 --Kapan Stock Transfer details                    
 select 2 as Id,Date,'','TF' as OperationType,Size,Kapan'Kapan',Weight,Rate,Weight*Rate,'Inward' as Category, 1 as CategoryId, 1 as Records from(                    
 select t.Date,k.Weight'Weight',s.Name as Size,                    
(case when n.TransferId<>'' then '('+s.Name+') '+nm.Name else (select top 1 km1.Name from KapanMappingMaster k1 left join KapanMaster km1 on km1.Id=k1.KapanId where k1.TransferId=k.TransferId and k1.TransferEntryId=k.TransferEntryId and TransferType='TransferedFrom') end)'Kapan',                    
(select top 1 k1.TransferCaratRate from KapanMappingMaster k1 where k1.TransferId=k.TransferId and k1.TransferEntryId=k.TransferEntryId and TransferType='TransferedTo')'Rate'                    
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
 (case when n.TransferId<>'' then '('+s.Name+') '+nm.Name else (select top 1 km1.Name from OpeningStockMaster o1 left join KapanMaster km1 on km1.Id=o1.KapanId where o1.TransferId=o.TransferId and o1.TransferEntryId=o.TransferEntryId and TransferType='TransferedFrom') end)'Kapan',                    
 (select top 1 o1.TransferCaratRate from OpeningStockMaster o1 where o1.TransferId=o.TransferId and o1.TransferEntryId=o.TransferEntryId and TransferType='TransferedTo')'Rate'                    
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
 --Rejection receive
 SELECT 4 as Id,CAST(R.EntryDate as date) Date, R.SlipNo,'' as OperationType,'' as Size,                    
 PAM.Name + ' (Rej)' AS Party, R.TotalCarat as NetWeight,
 R.Rate as 'Rate', R.Amount as Amount,'Inward' as Category, 1 as CategoryId,1 as Records    
 From RejectionInOutMaster R              
 Left JOIN [SalesDetails] AS SD ON SD.Id=R.PurchaseSaleDetailsId 
 Left JOIN [SalesMaster] AS SM ON SM.Id=SD.SalesId     
 Left JOIN [PartyMaster] AS PAM ON PAM.Id = SM.PartyId                     
 where R.PurchaseSaleDetailsId=SD.Id and R.TransType=1 and R.ProcessType='Sale'
 and sd.RejectedWeight = 0
 and SD.KapanId=@KapanId

 
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
 where NumberProcessType in (2,5)                    
 and KapanId=@KapanId                    
                    
 union         
                  
 select 2 as Id,Date,'','TT' as OperationType,Size,        
 Kapan'Kapan', Weight,Rate,Weight*Rate,'Outward' as Category, 2 as CategoryId, 1 as Records from(         
 select id,Date,sum(Weight) as 'Weight',Size,Kapan,Rate from(                
 select t.id,t.Date,k.Weight*-1'Weight',s.Name as Size,        
 (case when ISNULL(n.TransferId, '')<>'' then '('+s.Name+') '+nm.Name else (select top 1 km1.Name from KapanMappingMaster k1 left join KapanMaster km1 on km1.Id=k1.KapanId where k1.TransferId=k.TransferId and k1.TransferEntryId=k.TransferEntryId and TransferType='TransferedTo') end)'Kapan',      
 (select top 1 k1.TransferCaratRate from KapanMappingMaster k1 where k1.TransferId=k.TransferId and k1.TransferEntryId=k.TransferEntryId and TransferType='TransferedFrom')'Rate'              
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
 (case when ISNULL(n.TransferId, '')<>'' then '('+s.Name+') '+nm.Name else (select top 1 km1.Name from OpeningStockMaster o1 left join KapanMaster km1 on km1.Id=o1.KapanId where o1.TransferId=o.TransferId and o1.TransferEntryId=o.TransferEntryId and TransferType='TransferedTo') end)'Kapan',               
 (select top 1 o1.TransferCaratRate from OpeningStockMaster o1 where o1.TransferId=o.TransferId and o1.TransferEntryId=o.TransferEntryId and TransferType='TransferedFrom')'Rate'              
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
 --select 3 as Id,r.EntryDate,r.SlipNo,'Rej.' as OperationType,'' as Size,        
 --PAM.Name as Party,r.TotalCarat,r.Rate,r.Amount ,'Outward' as Category, 2 as CategoryId, 1 as Records                    
 --from RejectionInOutMaster r                    
 --left join PurchaseMaster p on p.SlipNo=r.SlipNo     
 --left join PurchaseDetails pd on pd.PurchaseId=p.Id 
 --Left JOIN [PartyMaster] AS PAM ON PAM.Id = r.PartyId                         
 --where pd.RejectedWeight=0 and r.ProcessType='Boil'                
 --and r.KapanId=@KapanId

 --Rejection Out
 SELECT 3 as Id,CAST(R.EntryDate as date) Date, R.SlipNo,'' as OperationType,'' as Size,                    
 PAM.Name + ' (Rej)' AS Party, R.TotalCarat as NetWeight,
 R.Rate as 'Rate', R.Amount as Amount,'Outward' as Category, 2 as CategoryId,1 as Records    
 From RejectionInOutMaster R
 left join KapanMappingMaster KM ON km.PurchaseDetailsId = R.PurchaseSaleDetailsId
 Left JOIN [PurchaseMaster] AS PM ON PM.Id=KM.PurchaseMasterId                    
 Left JOIN [PurchaseDetails] AS PD ON PD.Id=KM.PurchaseDetailsId AND PM.Id = PD.PurchaseId                        
 Left JOIN [PartyMaster] AS PAM ON PAM.Id = PM.PartyId                     
 where R.PurchaseSaleDetailsId=pd.Id and R.TransType=2 and R.ProcessType='Purchase'
 and pd.RejectedWeight = 0
 and KM.KapanId=@KapanId and isnull(KM.TransferType,'')=''
                 
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
 where KM.KapanId=@KapanId and isnull(KM.TransferType,'')='')y  
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
--EXEC GetRejectionSendReceiveDetail '5a30662f-c88c-48db-a87f-f607645507e4','146c24c5-6663-4f3d-bdfd-80469275c898',2  
CREATE proc [dbo].[GetRejectionSendReceiveDetail]                
                
@CompanyId as varchar(50),                                     
@FinancialYear as varchar(50),      
@TransType as int                    
                
as                
           
if(@TransType=2)      
Begin     
 --select distinct p.SlipNo
 --into #tempSlipNos from PurchaseMaster p      
 --left join PurchaseDetails pd on pd.PurchaseId=p.Id      
 --where p.PartyId=@PartyId 
       
 select x.*,x.RejectedWeight-x.ReturnCts'Available',      
 k.Name'Kapan',s.Name'Size',n.Name'Number','Purchase' as ProcessType from( 
 
 select convert(varchar,p.SlipNo) as SlipNo,pd.KapanId,pd.ShapeId,pd.SizeId,pd.PurityId,p.CompanyId,p.FinancialYearId,pd.BuyingRate'Rate',      
 (case when pd.RejectedWeight = 0 then pd.Netweight else pd.RejectedWeight end)'RejectedWeight',      
 isnull((select sum(TotalCarat) from RejectionInOutMaster r      
 where r.PurchaseSaleDetailsId=pd.Id and TransType=2 and ProcessType='Purchase'
 group by r.SlipNo),0)'ReturnCts',
 --(select sum(b.RejectionWeight)
 --from BoilProcessMaster b
 --where b.BoilType=1 and b.RejectionWeight<>0
 --and b.SlipNo=p.SlipNo)'ReturnCts',
 --convert(decimal(18,4),0) as ReturnCts,
 p.BrokerageId,p.PartyId,pd.NumberId,
 pd.Id'Id',
 pd.Id as PurchaseSaleDetailsId
 from PurchaseMaster p      
 left join PurchaseDetails pd on pd.PurchaseId=p.Id      
 where p.CompanyId=@CompanyId and p.FinancialYearId=@FinancialYear
 and p.isDelete=0
 --where p.SlipNo in (select SlipNo from #tempSlipNos)
 )x      
 left join KapanMaster k on k.Id=x.KapanId      
 left join SizeMaster s on s.Id=x.SizeId 
 left join NumberMaster n on n.Id=x.NumberId
 --where x.RejectedWeight-x.ReturnCts>0 
 --union 
 --select x.*,x.RejectedWeight-x.ReturnCts'Available',      
 --k.Name'Kapan',s.Name'Size','Boil' as ProcessType from(
 --select b.SlipNo,b.KapanId,b.ShapeId,b.SizeId,b.PurityId,b.CompanyId,b.FinancialYearId,
 --'0' as Rate,sum(b.RejectionWeight) as RejectedWeight,
 --isnull((select sum(TotalCarat) from RejectionInOutMaster r      
 --where r.SlipNo=b.SlipNo and r.SizeId=b.SizeId and TransType=2 and ProcessType='Boil'     
 --group by r.SlipNo),0)'ReturnCts', 
 -- convert(varchar,b.SlipNo)+b.KapanId+b.ShapeId+b.SizeId+b.PurityId'Id'  
 --from BoilProcessMaster b
 --where b.BoilType=1 and b.RejectionWeight<>0
 ----and b.SlipNo in (select SlipNo from #tempSlipNos)
 --group by b.SlipNo,b.KapanId,b.ShapeId,b.SizeId,b.PurityId,b.CompanyId,b.FinancialYearId)x
 --left join KapanMaster k on k.Id=x.KapanId      
 --left join SizeMaster s on s.Id=x.SizeId      
 --where x.RejectedWeight-x.ReturnCts>0     
End    
else    
Begin           
 select x.*,x.RejectedWeight-x.ReturnCts'Available',      
 k.Name'Kapan',sm.Name'Size',n.Name'Number','Sale' as ProcessType from(      
 select convert(varchar,s.SlipNo) as SlipNo,sd.KapanId,sd.ShapeId,sd.SizeId,sd.PurityId,s.CompanyId,s.FinancialYearId,sd.SaleRate'Rate',      
 (case when sd.RejectedWeight = 0 then sd.Netweight else sd.RejectedWeight end) 'RejectedWeight',
 s.BrokerageId,s.PartyId,sd.NumberSizeId as NumberId,
 isnull((select sum(TotalCarat) from RejectionInOutMaster r      
 where r.PurchaseSaleDetailsId=sd.Id and TransType=1      
 group by r.SlipNo),0)'ReturnCts',      
 sd.Id'Id',
 sd.Id as PurchaseSaleDetailsId
 from SalesMaster s      
 left join SalesDetails sd on sd.SalesId=s.Id   
 where s.CompanyId=@CompanyId and s.FinancialYearId=@FinancialYear
 and s.isDelete=0
 --where s.PartyId=@PartyId      
 )x      
 left join KapanMaster k on k.Id=x.KapanId      
 left join SizeMaster sm on sm.Id=x.SizeId  
 left join NumberMaster n on n.Id=x.NumberId
 --where x.RejectedWeight-x.ReturnCts>0      
End
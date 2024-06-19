CREATE Proc GetPSSlipDetailsForPayment   
        
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
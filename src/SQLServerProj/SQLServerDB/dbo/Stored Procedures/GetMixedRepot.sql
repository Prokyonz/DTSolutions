CREATE PROCEDURE [GetMixedRepot]   
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
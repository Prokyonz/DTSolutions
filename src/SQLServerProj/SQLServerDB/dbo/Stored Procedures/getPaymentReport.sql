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
	 M.GroupId, M.Id, ISNULL(M.FromName, '[PARTY DELETED]') 'FromName', M.Amount, M.FromPartyId, M.ToPartyId, M.ChequeNo, M.ChequeDate, M.Remarks, M.UpdatedDate, M.UpdatedBy,   
	 PM1.Name as ToName, M.SrNo 
	 FROM 
	 (
		SELECT CAST(G.EntryDate as date) 'EntryDate', G.EntryTime, G.IsDelete, G.CrDrType, G.CompanyId, G.FinancialYearId, convert(varchar,G.ApprovalType) 'ApprovalType',     
		 G.Id as GroupId, P.Id,P.Sr, PM.Name as FromName, P.Amount, P.FromPartyId, G.ToPartyId, P.ChequeNo, P.ChequeDate, G.Remarks, G.UpdatedDate, G.UpdatedBy, G.BillNo as SrNo
		 FROM [PaymentMaster] as P   
		 INNER JOIN GroupPaymentMaster as G ON P.GroupId = G.Id          
		 LEFT JOIN [PartyMaster] AS PM ON PM.Id = P.FromPartyId
	 ) AS M          
	 INNER JOIN [PartyMaster] AS PM1 ON PM1.Id = M.ToPartyId          
	 WHERE M.IsDelete = 0           
	 AND (CAST(EntryDate as Date) >= @FromDate AND CAST(EntryDate as Date) <= @ToDate)           
	 AND M.CompanyId = @CompanyId and M.FinancialYearId = @FinancialYearId AND M.CrDrType = @CrDrType  
	 order by CAST(M.EntryDate as Date),M.EntryTime desc       
     
ELSE            
	SELECT ISNULL(CAST(ROUND(SUM(Amount), 2) as FLOAT),0) TotalAmount    
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
   
CREATE PROCEDURE [dbo].[GetLoanReport]   
 @CompanyId varchar(50)   
AS  
BEGIN  
 SELECT CAST(L.EntryDate as Date) EntryDate, EntryTime, L.id, L.Sr, L.CompanyId, C.Name as CompanyName, CASE WHEN LoanType = 1 THEN 'Received' ELSE 'GIVEN' END 'LoanType', PartyId, P.Name as PartyName, CashBankPartyId, P1.Name 'CashBankName', Amount, 
 CASE 
	WHEN DuratonType = 1 THEN 'Daily'
	WHEN DuratonType = 2 THEN 'Monthly'
	WHEN DuratonType = 3 THEN '3 Month'
	WHEN DuratonType = 4 THEN '6 Month'
	WHEN DuratonType = 5 THEN '12 Monthly'
 END AS 'DurationName', 
 DuratonType,
 StartDate, EndDate, InterestRate, TotalInterest, NetAmount, Remarks, L.IsDelete, L.CreatedDate, L.UpdatedDate, L.CreatedBy, L.UpdatedBy 
 FROM LoanMaster as L
 INNER JOIN PartyMaster as P ON L.PartyId = P.Id   
 INNER JOIN PartyMaster as P1 ON L.CashBankPartyId = P1.Id  
 INNER JOIN CompanyMaster as C ON L.CompanyId = C.Id  
 WHERE C.Id = @CompanyId AND L.IsDelete=0  
 ORDER BY Sr  
END
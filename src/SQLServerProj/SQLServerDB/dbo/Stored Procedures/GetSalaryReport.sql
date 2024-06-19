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
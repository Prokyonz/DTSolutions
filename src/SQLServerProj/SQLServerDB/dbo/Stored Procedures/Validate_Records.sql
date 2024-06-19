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
			DELETE FROM CompanyOptions Where CompanyMasterId=@Id;
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
		SELECT @Count = @Count + COUNT(PM.Id) From GroupPaymentMaster GP INNER JOIN PaymentMaster PM ON GP.Id = PM.GroupId WHERE PM.FromPartyId=@Id;	

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
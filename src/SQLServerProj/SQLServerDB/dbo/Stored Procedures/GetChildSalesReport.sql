--EXEC [dbo].[GetChildSalesReport] 'b732545f-638d-4bd8-b9ca-d8c072a2bcc9'
CREATE PROCEDURE [dbo].[GetChildSalesReport]   
 @SalesId as varchar(50)          
AS  
BEGIN  
SELECT SD.*, SM.Name 'ShapeName', PM.Name 'PurityName', ISNULL(SZM.Name, SZM1.Name) 'SizeName', SZM1.Name 'CharniSizeName', GM.Name 'GalaSizeName', NM.Name 'NumberSizeName' FROM SalesDetails SD
	LEFT JOIN ShapeMaster SM ON SM.Id = SD.ShapeId
	LEFT JOIN SizeMaster SZM ON SZM.Id = SD.SizeId
	LEFT JOIN PurityMaster PM ON PM.Id = SD.PurityId
	LEFT JOIN GalaMaster GM ON GM.Id = SD.GalaSizeId
	LEFT JOIN NumberMaster NM ON NM.Id = SD.NumberSizeId
	LEFT JOIN SizeMaster SZM1 ON SZM1.Id = SD.CharniSizeId
	WHERE SD.SalesId = @SalesId
END
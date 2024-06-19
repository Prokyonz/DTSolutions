CREATE PROCEDURE [GetChildPurchaseReport]   
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
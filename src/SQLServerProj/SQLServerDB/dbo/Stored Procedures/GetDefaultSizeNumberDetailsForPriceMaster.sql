CREATE proc [GetDefaultSizeNumberDetailsForPriceMaster]

as

select ''CompanyId,s.Id'SizeId',S.Name'Size',n.Id'NumberId',N.Name'Number',0.00'Price' from SizeMaster s
cross join NumberMaster n
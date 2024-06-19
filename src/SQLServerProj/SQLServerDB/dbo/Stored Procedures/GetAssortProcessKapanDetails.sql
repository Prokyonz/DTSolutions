
CREATE proc [GetAssortProcessKapanDetails]

@CompanyId as varchar(50),        
@BranchId as varchar(50)   

as

select distinct k.* from AccountToAssortMaster a
left join KapanMaster k on k.Id=a.KapanId
where k.IsStatus=1 and a.CompanyId=@CompanyId and a.BranchId=@BranchId
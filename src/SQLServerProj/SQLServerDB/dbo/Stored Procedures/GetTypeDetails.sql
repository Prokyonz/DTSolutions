CREATE proc [GetTypeDetails]  
  
as  

select Id,Name,1 as 'Type' from KapanMaster where IsDelete=0 and IsStatus=1
union
select Id,Name,0 as 'Type' from NumberMaster where IsDelete=0
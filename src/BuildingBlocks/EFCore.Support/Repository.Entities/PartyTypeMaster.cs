using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class PartyTypeMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int Buyer = 0;
        public static int Seller = 1;
        public static int Broker = 2;
        public static int Other = 3;

        public static List<PartyTypeMaster> GetAllPartyType()
        {
            List<PartyTypeMaster> partyTypeMaster = new List<PartyTypeMaster>
            {
                new PartyTypeMaster {Id = Buyer, Name = "Buyer" },
                new PartyTypeMaster {Id = Seller, Name = "Seller" },
                new PartyTypeMaster {Id = Broker, Name = "Broker" },
                new PartyTypeMaster {Id = Other, Name = "Other" }
            };
            return partyTypeMaster;
        }
    }

    public class UserTypeMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int User = 0;
        public static int Buyer = 1;
        public static int Seller = 2;
        public static int Broker = 3;
        public static int Other = 4;

        public static List<UserTypeMaster> GetAllUserType()
        {
            List<UserTypeMaster> userTypeMaster = new List<UserTypeMaster>
            {
                new UserTypeMaster {Id = User, Name = "User" },
                new UserTypeMaster {Id = Buyer, Name = "Buyer" },
                new UserTypeMaster {Id = Seller, Name = "Seller" },
                new UserTypeMaster {Id = Broker, Name = "Broker" },
                new UserTypeMaster {Id = Other, Name = "Other" }
            };
            return userTypeMaster;
        }
    }

    public class DepartmentMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int Account = 0;
        public static int Production = 1;
        public static int Other = 2;

        public static List<DepartmentMaster> GetAllDepartment()
        {
            List<DepartmentMaster> departmentMaster = new List<DepartmentMaster>
            {
                new DepartmentMaster {Id = Account, Name = "Account" },
                new DepartmentMaster {Id = Production, Name = "Production" },
                new DepartmentMaster {Id = Other, Name = "Other" }
            };
            return departmentMaster;
        }
    }

    public class DesignationMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int Accountant = 0;
        public static int Other = 1;

        public static List<DesignationMaster> GetAllDesignation()
        {
            List<DesignationMaster> designationMaster = new List<DesignationMaster>
            {
                new DesignationMaster {Id = Accountant, Name = "Accountant" },
                new DesignationMaster {Id = Other, Name = "Other" }
            };
            return designationMaster;
        }
    }
}

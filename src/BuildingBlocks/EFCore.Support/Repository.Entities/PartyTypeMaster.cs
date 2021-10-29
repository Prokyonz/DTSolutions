using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class PartyTypeMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int None = 0;
        public static int Party = 1;
        public static int Employee = 2;
        public static int Expense = 3;
        public static int Bank = 4;
        public static int Cash = 5;

        public static int Buyer = 6;
        public static int Seller = 7;
        public static int Broker = 8;
        public static int Other = 9;

        //public static List<PartyTypeMaster> GetAllPartyType()
        //{
        //    List<PartyTypeMaster> partyTypeMaster = new List<PartyTypeMaster>
        //    {
        //        new PartyTypeMaster {Id = Buyer, Name = "Buyer" },
        //        new PartyTypeMaster {Id = Seller, Name = "Seller" },
        //        new PartyTypeMaster {Id = Broker, Name = "Broker" },
        //        new PartyTypeMaster {Id = Other, Name = "Other" }
        //    };
        //    return partyTypeMaster;
        //}

        public static List<PartyTypeMaster> GetAllMainLedgerType()
        {
            List<PartyTypeMaster> partyTypeMaster = new List<PartyTypeMaster>
            {
                new PartyTypeMaster {Id = Party, Name = "Party" },
                new PartyTypeMaster {Id = Employee, Name = "Employee" },
                new PartyTypeMaster {Id = Expense, Name = "Expense" },
                new PartyTypeMaster {Id = Bank, Name = "Bank" },
                new PartyTypeMaster {Id = Cash, Name = "Cash" }
            };
            return partyTypeMaster;
        }

        public static List<PartyTypeMaster> GetAllSubLedgerType()
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

    public class DepartmentMaster1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int Boil = 1;
        public static int Charni = 2;
        public static int Gala = 3;
        public static int Number = 4;

        public static List<DepartmentMaster> GetAllDepartment()
        {
            List<DepartmentMaster> departmentMaster = new List<DepartmentMaster>
            {
                new DepartmentMaster {Id = Boil, Name = "Boil" },
                new DepartmentMaster {Id = Charni, Name = "Charni" },
                new DepartmentMaster {Id = Gala, Name = "Gala" },
                new DepartmentMaster {Id = Number, Name = "Number" }
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

    public class CategoryMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int Number = 0;
        public static int Kapan = 1;
        public static int Boil = 2;
        public static int Charni = 3;
        public static int Gala = 4;

        public static List<CategoryMaster> GetAllCategory()
        {
            List<CategoryMaster> categoryMaster = new List<CategoryMaster>
            {
                new CategoryMaster {Id = Number, Name = "Number" },
                new CategoryMaster {Id = Kapan, Name = "Kapan" },
                new CategoryMaster {Id = Boil, Name = "Boil" },
                new CategoryMaster {Id = Charni, Name = "Charni" },
                new CategoryMaster {Id = Gala, Name = "Gala" }
            };
            return categoryMaster;
        }
    }
}

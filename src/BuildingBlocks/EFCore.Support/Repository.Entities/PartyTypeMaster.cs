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
        public static int PartyBuy = 1;        
        public static int Employee = 2;
        public static int Expense = 3;
        public static int Bank = 4;
        public static int Cash = 5;
        public static int DirectIncome = 6;
        public static int InDirectIncome = 7;
        public static int Asset = 8;
        public static int Deposit = 9;
        public static int Uchina = 10;
        public static int CapitalAccount = 11;
        public static int Investment = 12;
        public static int Loan = 13;
        public static int PartySale = 14;

        public static int Buyer = 6;
        public static int Seller = 7;
        public static int Broker = 8;
        public static int Other = 9;
        public static int Process = 15;
        public static int Salaried = 16;


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

        public static List<PartyTypeMaster> GetAllMainLedgerType(bool IsCashBankAccount = false)
        {
            List<PartyTypeMaster> partyTypeMaster;
            if (IsCashBankAccount)
            {
                partyTypeMaster = new List<PartyTypeMaster>
                {
                    new PartyTypeMaster {Id = Bank, Name = "Bank" },
                    new PartyTypeMaster {Id = Cash, Name = "Cash" }
                };
            }
            else
            {
                partyTypeMaster = new List<PartyTypeMaster>
                {
                    new PartyTypeMaster { Id = PartyBuy, Name = "Party-Buy" },
                    new PartyTypeMaster { Id = PartySale, Name = "Party-Sale" },
                    new PartyTypeMaster { Id = Employee, Name = "Employee" },
                    new PartyTypeMaster { Id = DirectIncome, Name = "Direct Income" },
                    new PartyTypeMaster { Id = InDirectIncome, Name = "In-Direct Income" },
                    new PartyTypeMaster { Id = Asset, Name = "Asset" },
                    new PartyTypeMaster { Id = Deposit, Name = "Deposit" },
                    new PartyTypeMaster { Id = Uchina, Name = "Uchina" },
                    new PartyTypeMaster { Id = CapitalAccount, Name = "Capital Account" },
                    new PartyTypeMaster { Id = Investment, Name = "Investment" },
                    new PartyTypeMaster { Id = Expense, Name = "Expense" },
                    new PartyTypeMaster { Id = Loan, Name = "Loan" },
                    new PartyTypeMaster { Id = Bank, Name = "Bank" },
                    new PartyTypeMaster { Id = Cash, Name = "Cash" }
                };
            }
            return partyTypeMaster;
        }

        public static List<PartyTypeMaster> GetAllSubLedgerType()
        {
            List<PartyTypeMaster> partyTypeMaster = new List<PartyTypeMaster>
            {
                new PartyTypeMaster {Id = Buyer, Name = "Buyer" },
                new PartyTypeMaster {Id = Seller, Name = "Seller" },
                new PartyTypeMaster {Id = Broker, Name = "Broker" },
                new PartyTypeMaster { Id = Process, Name = "Process" },
                new PartyTypeMaster {Id = Other, Name = "Other" },
                new PartyTypeMaster {Id = Salaried, Name = "Salaried" }
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

    public class ReceiveCategoryMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int ReceivedCts = 0;
        public static int LossCts = 1;
        public static int ReturnRejCts = 2;

        public static List<ReceiveCategoryMaster> GetAllCategory()
        {
            List<ReceiveCategoryMaster> categoryMasters = new List<ReceiveCategoryMaster>
            {
                new ReceiveCategoryMaster {Id = ReceivedCts, Name = "Received Cts" },
                new ReceiveCategoryMaster {Id = LossCts, Name = "Loss Cts" },
                new ReceiveCategoryMaster {Id = ReturnRejCts, Name = "Return Rej Cts" }
            };
            return categoryMasters;
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
        public static int Jangad = 5;

        public static List<CategoryMaster> GetAllCategory()
        {
            List<CategoryMaster> categoryMaster = new List<CategoryMaster>
            {
                new CategoryMaster {Id = Number, Name = "Number" },
                new CategoryMaster {Id = Kapan, Name = "Kapan" },
                //new CategoryMaster {Id = Jangad, Name = "Jangad" },
                //new CategoryMaster {Id = Boil, Name = "Boil" },
                //new CategoryMaster {Id = Charni, Name = "Charni" },
                //new CategoryMaster {Id = Gala, Name = "Gala" }
            };
            return categoryMaster;
        }
    }

    public class TransferCategoryMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int Number = 0;
        public static int Kapan = 1;

        public static List<TransferCategoryMaster> GetAllTransferCategory()
        {
            List<TransferCategoryMaster> transferCategoryMaster = new List<TransferCategoryMaster>
            {
                new TransferCategoryMaster {Id = Number, Name = "Number" },
                new TransferCategoryMaster {Id = Kapan, Name = "Kapan" }
            };
            return transferCategoryMaster;
        }
    }

    public class CaratCategoryMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int None = 0;
        public static int CharniCarat = 1;
        public static int GalaCarat = 2;
        public static int NumberCarat = 3;

        public static List<CaratCategoryMaster> GetAllCaratCategory()
        {
            List<CaratCategoryMaster> caratCategoryMaster = new List<CaratCategoryMaster>
            {
                new CaratCategoryMaster {Id = None, Name = "None" },
                new CaratCategoryMaster {Id = CharniCarat, Name = "Charni Ct" },
                new CaratCategoryMaster {Id = GalaCarat, Name = "Gala Ct" },
                new CaratCategoryMaster {Id = NumberCarat, Name = "Number Ct" }
            };
            return caratCategoryMaster;
        }
    }

    public class OpeningStockCategoryMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int Number = 0;
        public static int Kapan = 1;

        public static List<OpeningStockCategoryMaster> GetAllCategory()
        {
            List<OpeningStockCategoryMaster> openingStockCategoryMasters = new List<OpeningStockCategoryMaster>
            {
                new OpeningStockCategoryMaster {Id = Number, Name = "Number" },
                new OpeningStockCategoryMaster {Id = Kapan, Name = "Kapan" }
            };
            return openingStockCategoryMasters;
        }
    }

    public class PriceMasterCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int Number = 0;
        public static int PF = 1;
        public static int Export = 2;

        public static List<PriceMasterCategory> GetAllCategory()
        {
            List<PriceMasterCategory> openingStockCategoryMasters = new List<PriceMasterCategory>
            {
                new PriceMasterCategory {Id = Number, Name = "Number" },
                new PriceMasterCategory {Id = PF, Name = "PF" },
                new PriceMasterCategory {Id = Export, Name = "Export" }
            };
            return openingStockCategoryMasters;
        }
    }

    public class SlipType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int Purchase = 0;
        public static int Sale = 1;

        public static List<SlipType> GetSlipTypes()
        {
            List<SlipType> slipTypes = new List<SlipType>
            {
                new SlipType {Id = Purchase, Name = "Purchase" },
                new SlipType {Id = Sale, Name = "Sale" },
            };
            return slipTypes;
        }
    }
}

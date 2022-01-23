using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondTrading
{
    public class LoanType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    internal static class Common
    {
        public const string AppName = "Diamond Trading";
        public static string DefaultGuid = "00000000-0000-0000-0000-000000000000";
        public static string LoginUserID = "00000000-0000-0000-0000-000000000000";
        public static string LoginUserName = "Demo User";

        public static bool RememberComapnyYearSelection = false;
        public static string LoginCompany = "00000000-0000-0000-0000-000000000000";
        public static string LoginCompanyName = "Demo Company";

        public static string LoginBranch = "00000000-0000-0000-0000-000000000000";
        public static string LoginBranchName = "Demo Branch";

        public static string LoginFinancialYear = "00000000-0000-0000-0000-000000000000";
        public static string LoginFinancialYearName = "0000-0000";

        public static string FormTitle="|| શ્રીજી ||";
        public static bool PrintPurchaseSlip = false;
        public static bool PrintPurchasePF = false;
        public static bool AllowToSelectPurchaseDueDate = false;

        public static List<UserPermissionChild> UserPermissionChildren
        {
            get;
            set;
        }
        #region "Default Values"
        public static string DefaultShape = "00000000-0000-0000-0000-000000000000";
        public static string DefaultSize = "00000000-0000-0000-0000-000000000000";
        public static string DefaultPurity = "00000000-0000-0000-0000-000000000000";
        #endregion

        public static System.Globalization.CultureInfo AppUICultInfo
        {
            get;
            set;
        }

        public static List<LoanType> GetLoanType()
        {
            List<LoanType> loanType = new List<LoanType>
            {
                new LoanType {Id = 1, Name = "Receive" },
                new LoanType {Id = 2, Name = "Given" }
            };
            return loanType;
        }

        public static List<LoanType> GetLoanDuration()
        {
            List<LoanType> loanType = new List<LoanType>
            {
                new LoanType {Id = 1, Name = "Daily" },
                new LoanType {Id = 2, Name = "Monthly" },
                new LoanType {Id = 3, Name = "3 Month" },
                new LoanType {Id = 4, Name = "6 Month" },
                new LoanType {Id = 5, Name = "12 Monthly" }
            };
            return loanType;
        }

        internal static DataTable GetPaymentType
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("PTypeID");
                dt.Columns.Add("PTypeName");

                dt.Rows.Add(1,"CASH");
                dt.Rows.Add(2, "BANK");

                return dt;
            }

        }
        public static void MoveToNextControl(object sender, KeyEventArgs e, Form form)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (form.ActiveControl.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                {
                    if (((DevExpress.XtraEditors.LookUpEdit)form.ActiveControl).IsPopupOpen)
                        return;
                }

                if (form.ActiveControl.Parent.GetType() == typeof(DevExpress.XtraGrid.GridControl) ||
                    (form.ActiveControl.Parent.Parent != null && form.ActiveControl.Parent.Parent.GetType() == typeof(DevExpress.XtraGrid.GridControl)))
                    return;

                form.SelectNextControl(form.ActiveControl, true, true, true, true);
            }
        }

        public static void LoadRegistry()
        {
            try
            {
                #region "ComapnyYearSelection"
                RememberComapnyYearSelection = Convert.ToBoolean(RegistryHelper.GetSettings(RegistryHelper.MainSection, RegistryHelper.RememberCompanyYearSelection, "false"));
                LoginCompany = RegistryHelper.GetSettings(RegistryHelper.MainSection, RegistryHelper.LoginCompany, Common.LoginCompany.ToString());
                LoginBranch = RegistryHelper.GetSettings(RegistryHelper.MainSection, RegistryHelper.LoginBranch, Common.LoginBranch.ToString());
                LoginFinancialYear = RegistryHelper.GetSettings(RegistryHelper.MainSection, RegistryHelper.LoginFinancialYear, Common.LoginFinancialYear.ToString());

                LoginCompanyName = RegistryHelper.GetSettings(RegistryHelper.MainSection, RegistryHelper.LoginCompanyName, Common.LoginCompanyName.ToString());
                LoginBranchName = RegistryHelper.GetSettings(RegistryHelper.MainSection, RegistryHelper.LoginBranchName, Common.LoginBranchName.ToString());
                LoginFinancialYearName = RegistryHelper.GetSettings(RegistryHelper.MainSection, RegistryHelper.LoginFinancialYearName, Common.LoginFinancialYear.ToString());

                #endregion
                #region "FrmOption"
                FormTitle = RegistryHelper.GetSettings(RegistryHelper.OtherSection, RegistryHelper.FormTitle, "|| શ્રીજી ||");

                PrintPurchaseSlip = Convert.ToBoolean(RegistryHelper.GetSettings(RegistryHelper.OtherSection, RegistryHelper.PrintPurchaseSlip, "false"));
                PrintPurchasePF = Convert.ToBoolean(RegistryHelper.GetSettings(RegistryHelper.OtherSection, RegistryHelper.PrintPurchasePF, "false"));
                AllowToSelectPurchaseDueDate = Convert.ToBoolean(RegistryHelper.GetSettings(RegistryHelper.OtherSection, RegistryHelper.AllowToSelectPurchaseDueDate, "false"));
                #endregion "FrmOption"
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error : " + Ex.Message.ToString(), "[Options]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}

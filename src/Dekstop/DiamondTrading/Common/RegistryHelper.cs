using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondTrading
{
    internal class RegistryHelper
    {
        public static readonly string RecSection = "InfoLogs\\" + Common.AppName;
        public const string MainSection = "Main";
        public const string OtherSection = "Other";
        public static string ReportLayouts(string GridViewName)
        {
            return RecSection+"\\ReportLayouts\\" + GridViewName;
        }

        #region "Registry Name"
        public const string RememberLogin = "RememberLogin";
        public const string LoginUserName = "LoginUserName";
        public const string LoginPwd = "LoginPwd";
        #endregion

        #region "CompanyYearSelection"
        public const string RememberCompanyYearSelection = "RememberCompanyYearSelection";
        public const string TranscationDateSelection = "TranscationDateSelection";
        public const string LoginCompany = "LoginCompany";
        public const string LoginBranch = "LoginBranch";
        public const string LoginFinancialYear = "LoginFinancialYear";

        public const string LoginCompanyName = "LoginCompanyName";
        public const string LoginBranchName = "LoginBranchName";
        public const string LoginFinancialYearName = "LoginFinancialYearName";
        #endregion

        #region "FrmOther"
        public const string FormTitle = "FormTitle";
        public const string PrintPurchaseSlip = "PrintPurchaseSlip";
        public const string PrintPurchasePF = "PrintPurchasePF";
        public const string AllowToSelectPurchaseDueDate = "AllowToSelectPurchaseDueDate";
        #endregion "FrmOther"

        public static void DeleteSettings()
        {
            string MainSec = RecSection + "\\ReportLayouts";

            Registry.CurrentUser.DeleteSubKeyTree(MainSec, false);
        }
        
        public static void SaveSettings(string SubSection, string Key, string Value)
        {
            string MainSec = "Software\\" + RecSection;
            RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(MainSec);

            if (RegKey == null)
                return;

            RegistryKey SubRegKey = RegKey.CreateSubKey(SubSection);
            if (SubRegKey == null)
                return;

            try
            {
                if (Value == null)
                    Value = string.Empty;
                SubRegKey.SetValue(Key, Value);
            }
            catch (Exception ex)
            {
                throw new Exception("RH:1 " + ex.Message);
            }
            finally
            {
                SubRegKey.Close();
                RegKey.Close();
            }
        }

        public static string GetSettings(string SubSection, string Key, string Default)
        {
            string MainSec = "Software\\" + RecSection;

            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(MainSec);

            if (RegKey != null)
            {
                RegistryKey SubRegKey = RegKey.OpenSubKey(SubSection);

                if (SubRegKey != null)
                {
                    object obj = SubRegKey.GetValue(Key, Default);

                    SubRegKey.Close();
                    RegKey.Close();

                    if (obj != null)
                    {
                        if (!(obj is string))
                        {
                            return Default;
                        }
                        return Convert.ToString(obj);
                    }
                    return Default;
                }
                return Default;
            }
            return Default;
        }
    }
}

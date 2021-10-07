using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondTrading
{
    internal static class Common
    {
        public const string AppName = "Diamond Trading";
        public static Guid DefaultGuid = Guid.Parse("00000000-0000-0000-0000-000000000000");
        public static Guid LoginUserID = Guid.Parse("00000000-0000-0000-0000-000000000000");
        public static string LoginUserName = "Demo User";

        public static string FormTitle="|| શ્રીજી ||";
        public static bool PrintPurchaseSlip = false;
        public static bool AllowToSelectPurchaseDueDate = false;

        public static System.Globalization.CultureInfo AppUICultInfo
        {
            get;
            set;
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
                #region "FrmOption"
                FormTitle = RegistryHelper.GetSettings(RegistryHelper.OtherSection, RegistryHelper.FormTitle, "|| શ્રીજી ||");

                PrintPurchaseSlip = Convert.ToBoolean(RegistryHelper.GetSettings(RegistryHelper.OtherSection, RegistryHelper.PrintPurchaseSlip, "false"));
                AllowToSelectPurchaseDueDate = Convert.ToBoolean(RegistryHelper.GetSettings(RegistryHelper.OtherSection, RegistryHelper.AllowToSelectPurchaseDueDate, "false"));
                #endregion "FrmOption"
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error : " + Ex.Message.ToString(), "[Options]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

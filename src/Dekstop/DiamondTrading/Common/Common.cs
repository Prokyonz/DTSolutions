using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondTrading
{
    internal static class Common
    {
        public const string AppName = "Diamond Trading";
        public static void MoveToNextControl(object sender, KeyEventArgs e, Form form)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (form.ActiveControl.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                {
                    if (((DevExpress.XtraEditors.LookUpEdit)form.ActiveControl).IsPopupOpen)
                        return;
                }

                form.SelectNextControl(form.ActiveControl, true, true, true, true);
            }
        }
    }
}

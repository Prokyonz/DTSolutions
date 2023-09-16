using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondTrading
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string cultureInfo = "en-US";
            //1 - en-US, 2 - zh-CN

            int languageMode = Convert.ToInt32(RegistryHelper.GetSettings(RegistryHelper.MainSection, RegistryHelper.LoginLanguage, "1"));

            if (languageMode == 2)
                cultureInfo = "zh-CN";
        
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureInfo);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureInfo);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmLogin mainForm = new FrmLogin();
            Application.Run(mainForm);

            // Check if the application needs to be restarted
            if (mainForm.NeedsRestart)
            {
                // Restart the application
                Application.Restart();
            }

            //Application.Run(new Transaction.FrmTakePicture());
        }
    }
}

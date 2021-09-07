using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondTrading
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frmMain = new frmMain();
            frmMain.Show();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            FluentSplashScreenOptions options = new FluentSplashScreenOptions();
            options.LogoImageOptions.Image = Properties.Resources.logo;
            options.Title = "Diamond Trading";
            options.Subtitle = "Diamond Tranding & Account Management Software";
            options.RightFooter = "Starting...";
            options.LeftFooter = "Copyright @ 2021" + Environment.NewLine + "All Rights reserved.";
            options.LoadingIndicatorType = FluentLoadingIndicatorType.Dots;
            options.Opacity = 150;
            options.OpacityColor = Color.DodgerBlue;

            SplashScreenManager.ShowFluentSplashScreen(options, parentForm: this, useFadeIn: true, useFadeOut: true);

            Thread.Sleep(5000);
            SplashScreenManager.CloseForm();

        }
    }
}
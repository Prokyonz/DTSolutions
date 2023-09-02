using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using EFCore.SQL.Repository;
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
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        private readonly UserMasterRepository _userMasterRepository;

        public FrmLogin()
        {
            InitializeComponent();
            _userMasterRepository = new UserMasterRepository();
        }

        public void FillLanguageBox()
        {
            lueLanguage.Properties.DataSource = Common.GetLanguageType;
            lueLanguage.Properties.DisplayMember = "Name";
            lueLanguage.Properties.ValueMember = "Id";            
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //Set cursor position to center
                Screen screen = Screen.FromControl(this);
                this.Cursor = new Cursor(Cursor.Current.Handle);
                Cursor.Position = new Point(screen.Bounds.Width /2, screen.Bounds.Height/2);
                Cursor.Clip = new Rectangle(this.Location, this.Size);
                this.Cursor = Cursors.WaitCursor;

                if (txtUsername.Text.Trim().Length==0)
                {
                    txtUsername.Focus();
                    return;
                }
                if (txtPassword.Text.Trim().Length == 0)
                {
                    txtPassword.Focus();
                    return;
                }
                
                var data = await _userMasterRepository.Login(txtUsername.Text, txtPassword.Text);
                if (data.UserMaster != null)
                {
                    SaveRegistrySettings();
                    this.Hide();
                    Common.LoginUserID = data.UserMaster.Id;
                    Common.LoginUserName = data.UserMaster.Name;
                    Common.LoginLanguage = lueLanguage.EditValue.ToString();
                    FrmMain frmMain = new FrmMain();
                    frmMain.Show();
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = AppMessages.GetString(AppMessageID.InvalidUsername_Password);
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Error : " + Ex.Message.ToString() + " | " + Ex.StackTrace.ToString(), "[" + this.Text + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void SaveRegistrySettings()
        {
            RegistryHelper.SaveSettings(RegistryHelper.MainSection, RegistryHelper.RememberLogin, chkRememberMe.Checked.ToString());
            if (chkRememberMe.Checked)
            {
                RegistryHelper.SaveSettings(RegistryHelper.MainSection, RegistryHelper.LoginUserName, DataSecurity.EncryptString(txtUsername.Text,SecurityType.Password));
                RegistryHelper.SaveSettings(RegistryHelper.MainSection, RegistryHelper.LoginPwd, DataSecurity.EncryptString(txtPassword.Text, SecurityType.Password));
                RegistryHelper.SaveSettings(RegistryHelper.MainSection, RegistryHelper.LoginLanguage, lueLanguage.EditValue.ToString());
            }
        }

        private void LoadRegistrySettings()
        {
            chkRememberMe.Checked=Convert.ToBoolean(RegistryHelper.GetSettings(RegistryHelper.MainSection, RegistryHelper.RememberLogin, "false"));
            if(chkRememberMe.Checked)
            { 
                txtUsername.Text = DataSecurity.DecryptString(RegistryHelper.GetSettings(RegistryHelper.MainSection, RegistryHelper.LoginUserName, ""),SecurityType.Password);
                txtPassword.Text = DataSecurity.DecryptString(RegistryHelper.GetSettings(RegistryHelper.MainSection, RegistryHelper.LoginPwd, ""), SecurityType.Password);
                lueLanguage.EditValue = Convert.ToInt32(RegistryHelper.GetSettings(RegistryHelper.MainSection, RegistryHelper.LoginLanguage, "1"));
                btnLogin.Focus();
                btnLogin.Select();
            }
            else
            {
                txtUsername.Focus();
                txtUsername.Select();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            FluentSplashScreenOptions options = new FluentSplashScreenOptions();
            options.LogoImageOptions.Image = Properties.Resources.logo;
            options.Title = "Diamond Trading";
            options.Subtitle = "Diamond Tranding & Account Management Software";
            options.RightFooter = "Starting...";
            options.LeftFooter = "Copyright @ " + DateTime.Now.Year + " "  + Environment.NewLine + "All Rights reserved.";
            options.LoadingIndicatorType = FluentLoadingIndicatorType.Dots;
            options.Opacity = 150;
            options.OpacityColor = Color.DodgerBlue;

            SplashScreenManager.ShowFluentSplashScreen(options, parentForm: this, useFadeIn: true, useFadeOut: true);

            Thread.Sleep(1000);
            SplashScreenManager.CloseForm();
            FillLanguageBox();
            LoadRegistrySettings();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            Common.MoveToNextControl(sender, e, this);
        }
    }
}
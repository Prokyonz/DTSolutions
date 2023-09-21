
namespace DiamondTrading
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lueLanguage = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblError = new System.Windows.Forms.Label();
            this.chkRememberMe = new DevExpress.XtraEditors.CheckEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueLanguage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRememberMe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLogin.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnLogin.Appearance.Font")));
            this.btnLogin.Appearance.Options.UseBackColor = true;
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.btnLogin.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl1.Appearance.Font")));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Name = "labelControl1";
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl2.Appearance.Font")));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Name = "labelControl2";
            // 
            // labelControl3
            // 
            resources.ApplyResources(this.labelControl3, "labelControl3");
            this.labelControl3.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl3.Appearance.Font")));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Name = "labelControl3";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnCancel.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnCancel.Appearance.Font")));
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelControl2
            // 
            resources.ApplyResources(this.panelControl2, "panelControl2");
            this.panelControl2.Appearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.panelControl2.Appearance.Options.UseBorderColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl2.Controls.Add(this.lueLanguage);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.lblError);
            this.panelControl2.Controls.Add(this.chkRememberMe);
            this.panelControl2.Controls.Add(this.pictureEdit1);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Controls.Add(this.txtUsername);
            this.panelControl2.Controls.Add(this.txtPassword);
            this.panelControl2.Controls.Add(this.btnLogin);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Name = "panelControl2";
            // 
            // lueLanguage
            // 
            resources.ApplyResources(this.lueLanguage, "lueLanguage");
            this.lueLanguage.Name = "lueLanguage";
            this.lueLanguage.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lueLanguage.Properties.Appearance.Font")));
            this.lueLanguage.Properties.Appearance.Options.UseFont = true;
            this.lueLanguage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lueLanguage.Properties.Buttons"))))});
            this.lueLanguage.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueLanguage.Properties.Columns"), resources.GetString("lueLanguage.Properties.Columns1"), ((int)(resources.GetObject("lueLanguage.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("lueLanguage.Properties.Columns3"))), resources.GetString("lueLanguage.Properties.Columns4"), ((bool)(resources.GetObject("lueLanguage.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("lueLanguage.Properties.Columns6"))), ((DevExpress.Data.ColumnSortOrder)(resources.GetObject("lueLanguage.Properties.Columns7"))), ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("lueLanguage.Properties.Columns8")))),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueLanguage.Properties.Columns9"), resources.GetString("lueLanguage.Properties.Columns10"), ((int)(resources.GetObject("lueLanguage.Properties.Columns11"))), ((DevExpress.Utils.FormatType)(resources.GetObject("lueLanguage.Properties.Columns12"))), resources.GetString("lueLanguage.Properties.Columns13"), ((bool)(resources.GetObject("lueLanguage.Properties.Columns14"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("lueLanguage.Properties.Columns15"))), ((DevExpress.Data.ColumnSortOrder)(resources.GetObject("lueLanguage.Properties.Columns16"))), ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("lueLanguage.Properties.Columns17"))))});
            this.lueLanguage.Properties.NullText = resources.GetString("lueLanguage.Properties.NullText");
            // 
            // labelControl4
            // 
            resources.ApplyResources(this.labelControl4, "labelControl4");
            this.labelControl4.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl4.Appearance.Font")));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Name = "labelControl4";
            // 
            // lblError
            // 
            resources.ApplyResources(this.lblError, "lblError");
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Name = "lblError";
            // 
            // chkRememberMe
            // 
            resources.ApplyResources(this.chkRememberMe, "chkRememberMe");
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.Properties.Appearance.ForeColor = System.Drawing.Color.LightSlateGray;
            this.chkRememberMe.Properties.Appearance.Options.UseForeColor = true;
            this.chkRememberMe.Properties.Caption = resources.GetString("chkRememberMe.Properties.Caption");
            this.chkRememberMe.Properties.DisplayValueChecked = resources.GetString("chkRememberMe.Properties.DisplayValueChecked");
            this.chkRememberMe.Properties.DisplayValueGrayed = resources.GetString("chkRememberMe.Properties.DisplayValueGrayed");
            this.chkRememberMe.Properties.DisplayValueUnchecked = resources.GetString("chkRememberMe.Properties.DisplayValueUnchecked");
            this.chkRememberMe.Properties.GlyphVerticalAlignment = ((DevExpress.Utils.VertAlignment)(resources.GetObject("chkRememberMe.Properties.GlyphVerticalAlignment")));
            // 
            // pictureEdit1
            // 
            resources.ApplyResources(this.pictureEdit1, "pictureEdit1");
            this.pictureEdit1.EditValue = global::DiamondTrading.Properties.Resources.Lock;
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // txtUsername
            // 
            resources.ApplyResources(this.txtUsername, "txtUsername");
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("txtUsername.Properties.Appearance.Font")));
            this.txtUsername.Properties.Appearance.Options.UseFont = true;
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("txtPassword.Properties.Appearance.Font")));
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.PasswordChar = '*';
            // 
            // FrmLogin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.LookAndFeel.SkinName = "Office 2019 White";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueLanguage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRememberMe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.CheckEdit chkRememberMe;
        private System.Windows.Forms.Label lblError;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lueLanguage;
    }
}

namespace DiamondTrading.Master
{
    partial class frmUserMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserMaster));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtConfrmPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtHomeNo = new DevExpress.XtraEditors.TextEdit();
            this.txtMobileNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtAddress2 = new DevExpress.XtraEditors.MemoEdit();
            this.txtAddress = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.grdPermissionDetails = new DevExpress.XtraGrid.GridControl();
            this.grvPermissionDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn43 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfrmPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHomeNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPermissionDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermissionDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.Controls.Add(this.txtUserName);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl10);
            this.groupControl1.Controls.Add(this.txtConfrmPassword);
            this.groupControl1.Controls.Add(this.txtPassword);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("txtUserName.Properties.Appearance.Font")));
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // labelControl7
            // 
            resources.ApplyResources(this.labelControl7, "labelControl7");
            this.labelControl7.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl7.Appearance.Font")));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Name = "labelControl7";
            // 
            // labelControl10
            // 
            resources.ApplyResources(this.labelControl10, "labelControl10");
            this.labelControl10.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl10.Appearance.Font")));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Name = "labelControl10";
            // 
            // txtConfrmPassword
            // 
            resources.ApplyResources(this.txtConfrmPassword, "txtConfrmPassword");
            this.txtConfrmPassword.Name = "txtConfrmPassword";
            this.txtConfrmPassword.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("txtConfrmPassword.Properties.Appearance.Font")));
            this.txtConfrmPassword.Properties.Appearance.Options.UseFont = true;
            this.txtConfrmPassword.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConfrmPassword.Properties.PasswordChar = '*';
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("txtPassword.Properties.Appearance.Font")));
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassword.Properties.PasswordChar = '*';
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl1.Appearance.Font")));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Name = "labelControl1";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("txtName.Properties.Appearance.Font")));
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl2.Appearance.Font")));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Name = "labelControl2";
            // 
            // groupControl2
            // 
            resources.ApplyResources(this.groupControl2, "groupControl2");
            this.groupControl2.Controls.Add(this.txtHomeNo);
            this.groupControl2.Controls.Add(this.txtMobileNo);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.txtAddress2);
            this.groupControl2.Controls.Add(this.txtAddress);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Name = "groupControl2";
            // 
            // txtHomeNo
            // 
            resources.ApplyResources(this.txtHomeNo, "txtHomeNo");
            this.txtHomeNo.Name = "txtHomeNo";
            this.txtHomeNo.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("txtHomeNo.Properties.Appearance.Font")));
            this.txtHomeNo.Properties.Appearance.Options.UseFont = true;
            // 
            // txtMobileNo
            // 
            resources.ApplyResources(this.txtMobileNo, "txtMobileNo");
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("txtMobileNo.Properties.Appearance.Font")));
            this.txtMobileNo.Properties.Appearance.Options.UseFont = true;
            // 
            // labelControl5
            // 
            resources.ApplyResources(this.labelControl5, "labelControl5");
            this.labelControl5.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl5.Appearance.Font")));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Name = "labelControl5";
            // 
            // labelControl6
            // 
            resources.ApplyResources(this.labelControl6, "labelControl6");
            this.labelControl6.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl6.Appearance.Font")));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Name = "labelControl6";
            // 
            // txtAddress2
            // 
            resources.ApplyResources(this.txtAddress2, "txtAddress2");
            this.txtAddress2.Name = "txtAddress2";
            // 
            // txtAddress
            // 
            resources.ApplyResources(this.txtAddress, "txtAddress");
            this.txtAddress.Name = "txtAddress";
            // 
            // labelControl3
            // 
            resources.ApplyResources(this.labelControl3, "labelControl3");
            this.labelControl3.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl3.Appearance.Font")));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Name = "labelControl3";
            // 
            // labelControl4
            // 
            resources.ApplyResources(this.labelControl4, "labelControl4");
            this.labelControl4.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl4.Appearance.Font")));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Name = "labelControl4";
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.Name = "btnReset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupControl3
            // 
            resources.ApplyResources(this.groupControl3, "groupControl3");
            this.groupControl3.Controls.Add(this.grdPermissionDetails);
            this.groupControl3.Name = "groupControl3";
            // 
            // grdPermissionDetails
            // 
            resources.ApplyResources(this.grdPermissionDetails, "grdPermissionDetails");
            this.grdPermissionDetails.EmbeddedNavigator.AccessibleDescription = resources.GetString("grdPermissionDetails.EmbeddedNavigator.AccessibleDescription");
            this.grdPermissionDetails.EmbeddedNavigator.AccessibleName = resources.GetString("grdPermissionDetails.EmbeddedNavigator.AccessibleName");
            this.grdPermissionDetails.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("grdPermissionDetails.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.grdPermissionDetails.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("grdPermissionDetails.EmbeddedNavigator.Anchor")));
            this.grdPermissionDetails.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grdPermissionDetails.EmbeddedNavigator.BackgroundImage")));
            this.grdPermissionDetails.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("grdPermissionDetails.EmbeddedNavigator.BackgroundImageLayout")));
            this.grdPermissionDetails.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("grdPermissionDetails.EmbeddedNavigator.ImeMode")));
            this.grdPermissionDetails.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("grdPermissionDetails.EmbeddedNavigator.MaximumSize")));
            this.grdPermissionDetails.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("grdPermissionDetails.EmbeddedNavigator.TextLocation")));
            this.grdPermissionDetails.EmbeddedNavigator.ToolTip = resources.GetString("grdPermissionDetails.EmbeddedNavigator.ToolTip");
            this.grdPermissionDetails.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("grdPermissionDetails.EmbeddedNavigator.ToolTipIconType")));
            this.grdPermissionDetails.EmbeddedNavigator.ToolTipTitle = resources.GetString("grdPermissionDetails.EmbeddedNavigator.ToolTipTitle");
            this.grdPermissionDetails.MainView = this.grvPermissionDetails;
            this.grdPermissionDetails.Name = "grdPermissionDetails";
            this.grdPermissionDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPermissionDetails,
            this.gridView6});
            // 
            // grvPermissionDetails
            // 
            resources.ApplyResources(this.grvPermissionDetails, "grvPermissionDetails");
            this.grvPermissionDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn2});
            this.grvPermissionDetails.GridControl = this.grdPermissionDetails;
            this.grvPermissionDetails.Name = "grvPermissionDetails";
            this.grvPermissionDetails.OptionsBehavior.Editable = false;
            this.grvPermissionDetails.OptionsSelection.MultiSelect = true;
            this.grvPermissionDetails.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvPermissionDetails.OptionsView.ShowAutoFilterRow = true;
            this.grvPermissionDetails.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            resources.ApplyResources(this.gridColumn3, "gridColumn3");
            this.gridColumn3.FieldName = "Id";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn1
            // 
            resources.ApplyResources(this.gridColumn1, "gridColumn1");
            this.gridColumn1.FieldName = "DisplayName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AllowInHeaderSearch = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridColumn2
            // 
            resources.ApplyResources(this.gridColumn2, "gridColumn2");
            this.gridColumn2.FieldName = "KeyName";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridView6
            // 
            resources.ApplyResources(this.gridView6, "gridView6");
            this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn43});
            this.gridView6.GridControl = this.grdPermissionDetails;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsBehavior.Editable = false;
            this.gridView6.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn43
            // 
            resources.ApplyResources(this.gridColumn43, "gridColumn43");
            this.gridColumn43.FieldName = "Id";
            this.gridColumn43.Name = "gridColumn43";
            // 
            // frmUserMaster
            // 
            resources.ApplyResources(this, "$this");
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserMaster";
            this.Load += new System.EventHandler(this.frmUserMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUserMaster_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfrmPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHomeNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPermissionDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermissionDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txtHomeNo;
        private DevExpress.XtraEditors.TextEdit txtMobileNo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MemoEdit txtAddress2;
        private DevExpress.XtraEditors.MemoEdit txtAddress;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtConfrmPassword;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl grdPermissionDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPermissionDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn43;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}
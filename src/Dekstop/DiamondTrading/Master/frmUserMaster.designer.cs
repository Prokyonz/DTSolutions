
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
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtUserName);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl10);
            this.groupControl1.Controls.Add(this.txtConfrmPassword);
            this.groupControl1.Controls.Add(this.txtPassword);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(710, 137);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "User Account Details";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(355, 47);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Properties.BeepOnError = false;
            this.txtUserName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserName.Size = new System.Drawing.Size(343, 26);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(355, 28);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(66, 14);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "User Name*";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(355, 79);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(103, 14);
            this.labelControl10.TabIndex = 10;
            this.labelControl10.Text = "Confirm Password*";
            // 
            // txtConfrmPassword
            // 
            this.txtConfrmPassword.Location = new System.Drawing.Point(355, 99);
            this.txtConfrmPassword.Name = "txtConfrmPassword";
            this.txtConfrmPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtConfrmPassword.Properties.Appearance.Options.UseFont = true;
            this.txtConfrmPassword.Properties.BeepOnError = false;
            this.txtConfrmPassword.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConfrmPassword.Size = new System.Drawing.Size(343, 26);
            this.txtConfrmPassword.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(6, 99);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.BeepOnError = false;
            this.txtPassword.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassword.Size = new System.Drawing.Size(343, 26);
            this.txtPassword.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(6, 79);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 14);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Password*";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 47);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Properties.BeepOnError = false;
            this.txtName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.Size = new System.Drawing.Size(343, 26);
            this.txtName.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(6, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Name*";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtHomeNo);
            this.groupControl2.Controls.Add(this.txtMobileNo);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.txtAddress2);
            this.groupControl2.Controls.Add(this.txtAddress);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Location = new System.Drawing.Point(11, 155);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(710, 151);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Basic Details";
            // 
            // txtHomeNo
            // 
            this.txtHomeNo.Location = new System.Drawing.Point(356, 119);
            this.txtHomeNo.Name = "txtHomeNo";
            this.txtHomeNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtHomeNo.Properties.Appearance.Options.UseFont = true;
            this.txtHomeNo.Size = new System.Drawing.Size(343, 22);
            this.txtHomeNo.TabIndex = 8;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(7, 119);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMobileNo.Properties.Appearance.Options.UseFont = true;
            this.txtMobileNo.Size = new System.Drawing.Size(343, 22);
            this.txtMobileNo.TabIndex = 7;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(356, 98);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(51, 14);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Home No";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(7, 98);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(53, 14);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Mobile No";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(356, 50);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(343, 42);
            this.txtAddress2.TabIndex = 6;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(7, 50);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(343, 42);
            this.txtAddress.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(356, 29);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Address2";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(7, 29);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Address";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(484, 516);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(565, 516);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "&Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(646, 516);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.grdPermissionDetails);
            this.groupControl3.Location = new System.Drawing.Point(11, 312);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(710, 198);
            this.groupControl3.TabIndex = 9;
            this.groupControl3.Text = "Permissions";
            // 
            // grdPermissionDetails
            // 
            this.grdPermissionDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPermissionDetails.Location = new System.Drawing.Point(2, 23);
            this.grdPermissionDetails.MainView = this.gridView5;
            this.grdPermissionDetails.Name = "grdPermissionDetails";
            this.grdPermissionDetails.Size = new System.Drawing.Size(706, 173);
            this.grdPermissionDetails.TabIndex = 5;
            this.grdPermissionDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView5,
            this.gridView6});
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn1});
            this.gridView5.GridControl = this.grdPermissionDetails;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsBehavior.Editable = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Id";
            this.gridColumn3.FieldName = "Id";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Permission Name";
            this.gridColumn1.FieldName = "DisplayName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridView6
            // 
            this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn43});
            this.gridView6.GridControl = this.grdPermissionDetails;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsBehavior.Editable = false;
            this.gridView6.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn43
            // 
            this.gridColumn43.Caption = "Id";
            this.gridColumn43.FieldName = "Id";
            this.gridColumn43.Name = "gridColumn43";
            // 
            // frmUserMaster
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(735, 551);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New User";
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
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
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
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn43;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}
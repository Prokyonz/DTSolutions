
namespace DiamondTrading
{
    partial class FrmCompanyYearSelection
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.checkRemember = new DevExpress.XtraEditors.CheckEdit();
            this.lookUpFinancialYear = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpBranch = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkRemember.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpFinancialYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 17F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.LightSlateGray;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(40, 17);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(364, 28);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Current Company/Branch/Year";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 150);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(73, 14);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Financial Year";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 14);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Company";
            // 
            // btnOk
            // 
            this.btnOk.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnOk.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnOk.Appearance.Options.UseBackColor = true;
            this.btnOk.Appearance.Options.UseFont = true;
            this.btnOk.Location = new System.Drawing.Point(5, 223);
            this.btnOk.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.btnOk.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(392, 33);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(13, 101);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(37, 14);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "Branch";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl1.Controls.Add(this.checkRemember);
            this.panelControl1.Controls.Add(this.lookUpFinancialYear);
            this.panelControl1.Controls.Add(this.lookUpBranch);
            this.panelControl1.Controls.Add(this.lookUpCompany);
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.btnOk);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(412, 272);
            this.panelControl1.TabIndex = 16;
            // 
            // checkRemember
            // 
            this.pictureEdit1.EditValue = global::DiamondTrading.Properties.Resources.DefaultSelection;
            this.pictureEdit1.Location = new System.Drawing.Point(1, 10);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(40, 37);
            this.pictureEdit1.TabIndex = 16;
            // 
            // lookUpFinancialYear
            // 
            this.lookUpFinancialYear.EditValue = "Select Financial Year";
            this.lookUpFinancialYear.Location = new System.Drawing.Point(12, 170);
            this.lookUpFinancialYear.Name = "lookUpFinancialYear";
            this.lookUpFinancialYear.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpFinancialYear.Properties.Appearance.Options.UseFont = true;
            this.lookUpFinancialYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpFinancialYear.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StartDate", "SartDate"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EndDate", "EndDate")});
            this.lookUpFinancialYear.Size = new System.Drawing.Size(385, 22);
            this.lookUpFinancialYear.TabIndex = 3;
            // 
            // lookUpBranch
            // 
            this.lookUpBranch.EditValue = "<Select Branch>";
            this.lookUpBranch.Location = new System.Drawing.Point(12, 121);
            this.lookUpBranch.Name = "lookUpBranch";
            this.lookUpBranch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpBranch.Properties.Appearance.Options.UseFont = true;
            this.lookUpBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpBranch.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Branch Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RegistrationNo", "Registration No")});
            this.lookUpBranch.Size = new System.Drawing.Size(385, 22);
            this.lookUpBranch.TabIndex = 2;
            // 
            // lookUpCompany
            // 
            this.lookUpCompany.EditValue = "Select Company";
            this.lookUpCompany.Location = new System.Drawing.Point(13, 74);
            this.lookUpCompany.Name = "lookUpCompany";
            this.lookUpCompany.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpCompany.Properties.Appearance.Options.UseFont = true;
            this.lookUpCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Company Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RegistrationNo", "Registraton No")});
            this.lookUpCompany.Size = new System.Drawing.Size(385, 22);
            this.lookUpCompany.TabIndex = 1;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::DiamondTrading.Properties.Resources.DefaultSelection;
            this.pictureEdit1.Location = new System.Drawing.Point(1, 10);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(40, 37);
            this.pictureEdit1.TabIndex = 16;
            // 
            // FrmCompanyYearSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 299);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompanyYearSelection";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company/Year Selection";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkRemember.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpFinancialYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        public DevExpress.XtraEditors.LookUpEdit lookUpCompany;
        public DevExpress.XtraEditors.LookUpEdit lookUpFinancialYear;
        public DevExpress.XtraEditors.LookUpEdit lookUpBranch;
        private DevExpress.XtraEditors.CheckEdit checkRemember;
    }
}
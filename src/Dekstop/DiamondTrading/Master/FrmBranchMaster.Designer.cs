
namespace DiamondTrading.Master
{
    partial class FrmBranchMaster
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
            this.lueParentCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.txtBranchName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtOfficeNo = new DevExpress.XtraEditors.TextEdit();
            this.txtMobileNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtAddress2 = new DevExpress.XtraEditors.MemoEdit();
            this.txtAddress = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtRegistrationNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtPancardNo = new DevExpress.XtraEditors.TextEdit();
            this.txtGSTNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.txtTermsCondition = new DevExpress.XtraEditors.MemoEdit();
            this.txtNotes = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.lueLessWeightGroup = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtTipWeight = new DevExpress.XtraEditors.TextEdit();
            this.txtCVDWeight = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueParentCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranchName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficeNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegistrationNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPancardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGSTNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTermsCondition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueLessWeightGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCVDWeight.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lueParentCompany);
            this.groupControl1.Controls.Add(this.txtBranchName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(711, 86);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Branch Name";
            // 
            // lueParentCompany
            // 
            this.lueParentCompany.Location = new System.Drawing.Point(8, 49);
            this.lueParentCompany.Name = "lueParentCompany";
            this.lueParentCompany.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lueParentCompany.Properties.Appearance.Options.UseFont = true;
            this.lueParentCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueParentCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Company Name", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "CompanyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueParentCompany.Size = new System.Drawing.Size(193, 26);
            this.lueParentCompany.TabIndex = 1;
            // 
            // txtBranchName
            // 
            this.txtBranchName.Location = new System.Drawing.Point(207, 49);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtBranchName.Properties.Appearance.Options.UseFont = true;
            this.txtBranchName.Properties.BeepOnError = false;
            this.txtBranchName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBranchName.Size = new System.Drawing.Size(491, 26);
            this.txtBranchName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(207, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Name*";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(7, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Parent Company*";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtOfficeNo);
            this.groupControl2.Controls.Add(this.txtMobileNo);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.txtAddress2);
            this.groupControl2.Controls.Add(this.txtAddress);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Location = new System.Drawing.Point(12, 105);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(711, 149);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Basic Details";
            // 
            // txtOfficeNo
            // 
            this.txtOfficeNo.Location = new System.Drawing.Point(356, 119);
            this.txtOfficeNo.Name = "txtOfficeNo";
            this.txtOfficeNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtOfficeNo.Properties.Appearance.Options.UseFont = true;
            this.txtOfficeNo.Size = new System.Drawing.Size(342, 22);
            this.txtOfficeNo.TabIndex = 7;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(7, 119);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMobileNo.Properties.Appearance.Options.UseFont = true;
            this.txtMobileNo.Size = new System.Drawing.Size(343, 22);
            this.txtMobileNo.TabIndex = 5;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(356, 99);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(51, 14);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Office No";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(7, 99);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(53, 14);
            this.labelControl6.TabIndex = 4;
            this.labelControl6.Text = "Mobile No";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(356, 50);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(342, 42);
            this.txtAddress2.TabIndex = 3;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(7, 50);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(343, 42);
            this.txtAddress.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(356, 30);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Address2";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(7, 30);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Address";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txtRegistrationNo);
            this.groupControl3.Controls.Add(this.labelControl9);
            this.groupControl3.Controls.Add(this.txtPancardNo);
            this.groupControl3.Controls.Add(this.txtGSTNo);
            this.groupControl3.Controls.Add(this.labelControl7);
            this.groupControl3.Controls.Add(this.labelControl8);
            this.groupControl3.Location = new System.Drawing.Point(13, 261);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(349, 129);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Registration Details";
            // 
            // txtRegistrationNo
            // 
            this.txtRegistrationNo.Location = new System.Drawing.Point(7, 49);
            this.txtRegistrationNo.Name = "txtRegistrationNo";
            this.txtRegistrationNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtRegistrationNo.Properties.Appearance.Options.UseFont = true;
            this.txtRegistrationNo.Size = new System.Drawing.Size(335, 22);
            this.txtRegistrationNo.TabIndex = 1;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(7, 30);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(135, 14);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "Registration/Gumasta No";
            // 
            // txtPancardNo
            // 
            this.txtPancardNo.Location = new System.Drawing.Point(171, 97);
            this.txtPancardNo.Name = "txtPancardNo";
            this.txtPancardNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPancardNo.Properties.Appearance.Options.UseFont = true;
            this.txtPancardNo.Size = new System.Drawing.Size(171, 22);
            this.txtPancardNo.TabIndex = 5;
            // 
            // txtGSTNo
            // 
            this.txtGSTNo.Location = new System.Drawing.Point(7, 97);
            this.txtGSTNo.Name = "txtGSTNo";
            this.txtGSTNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtGSTNo.Properties.Appearance.Options.UseFont = true;
            this.txtGSTNo.Size = new System.Drawing.Size(160, 22);
            this.txtGSTNo.TabIndex = 3;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(171, 78);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(62, 14);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "Pancard No";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(7, 78);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(42, 14);
            this.labelControl8.TabIndex = 2;
            this.labelControl8.Text = "GST No";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.txtTermsCondition);
            this.groupControl4.Controls.Add(this.txtNotes);
            this.groupControl4.Controls.Add(this.labelControl12);
            this.groupControl4.Controls.Add(this.labelControl13);
            this.groupControl4.Location = new System.Drawing.Point(13, 398);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(710, 126);
            this.groupControl4.TabIndex = 3;
            this.groupControl4.Text = "Other Details";
            // 
            // txtTermsCondition
            // 
            this.txtTermsCondition.Location = new System.Drawing.Point(356, 50);
            this.txtTermsCondition.Name = "txtTermsCondition";
            this.txtTermsCondition.Size = new System.Drawing.Size(341, 69);
            this.txtTermsCondition.TabIndex = 3;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(7, 50);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(343, 69);
            this.txtNotes.TabIndex = 1;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(356, 29);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(106, 14);
            this.labelControl12.TabIndex = 2;
            this.labelControl12.Text = "Terms && Conditions";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(7, 29);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(32, 14);
            this.labelControl13.TabIndex = 0;
            this.labelControl13.Text = "Notes";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(484, 531);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(565, 531);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "&Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(646, 531);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.lueLessWeightGroup);
            this.groupControl5.Controls.Add(this.labelControl10);
            this.groupControl5.Controls.Add(this.txtTipWeight);
            this.groupControl5.Controls.Add(this.txtCVDWeight);
            this.groupControl5.Controls.Add(this.labelControl11);
            this.groupControl5.Controls.Add(this.labelControl14);
            this.groupControl5.Location = new System.Drawing.Point(368, 260);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(355, 130);
            this.groupControl5.TabIndex = 6;
            this.groupControl5.Text = "Advanced Options";
            // 
            // lueLessWeightGroup
            // 
            this.lueLessWeightGroup.Location = new System.Drawing.Point(7, 46);
            this.lueLessWeightGroup.Name = "lueLessWeightGroup";
            this.lueLessWeightGroup.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueLessWeightGroup.Properties.Appearance.Options.UseFont = true;
            this.lueLessWeightGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueLessWeightGroup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Less Weight Group Name", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "LessWeightGroupID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueLessWeightGroup.Size = new System.Drawing.Size(335, 22);
            this.lueLessWeightGroup.TabIndex = 6;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(7, 30);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(104, 14);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "Less Weight Group";
            // 
            // txtTipWeight
            // 
            this.txtTipWeight.Location = new System.Drawing.Point(171, 97);
            this.txtTipWeight.Name = "txtTipWeight";
            this.txtTipWeight.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtTipWeight.Properties.Appearance.Options.UseFont = true;
            this.txtTipWeight.Size = new System.Drawing.Size(171, 22);
            this.txtTipWeight.TabIndex = 5;
            // 
            // txtCVDWeight
            // 
            this.txtCVDWeight.Location = new System.Drawing.Point(7, 97);
            this.txtCVDWeight.Name = "txtCVDWeight";
            this.txtCVDWeight.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCVDWeight.Properties.Appearance.Options.UseFont = true;
            this.txtCVDWeight.Size = new System.Drawing.Size(160, 22);
            this.txtCVDWeight.TabIndex = 3;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(171, 78);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(61, 14);
            this.labelControl11.TabIndex = 4;
            this.labelControl11.Text = "Tip Weight";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Location = new System.Drawing.Point(7, 78);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(67, 14);
            this.labelControl14.TabIndex = 2;
            this.labelControl14.Text = "CVD Weight";
            // 
            // FrmBranchMaster
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(735, 575);
            this.Controls.Add(this.groupControl5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBranchMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Branch";
            this.Load += new System.EventHandler(this.frmBranchMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBranchMaster_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueParentCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranchName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficeNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegistrationNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPancardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGSTNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTermsCondition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueLessWeightGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCVDWeight.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtBranchName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txtOfficeNo;
        private DevExpress.XtraEditors.TextEdit txtMobileNo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MemoEdit txtAddress2;
        private DevExpress.XtraEditors.MemoEdit txtAddress;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.TextEdit txtRegistrationNo;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtPancardNo;
        private DevExpress.XtraEditors.TextEdit txtGSTNo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.MemoEdit txtTermsCondition;
        private DevExpress.XtraEditors.MemoEdit txtNotes;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LookUpEdit lueParentCompany;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtTipWeight;
        private DevExpress.XtraEditors.TextEdit txtCVDWeight;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LookUpEdit lueLessWeightGroup;
    }
}
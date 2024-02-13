
namespace DiamondTrading
{
    partial class FrmOptions
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtabGeneral = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtFormTitle = new DevExpress.XtraEditors.TextEdit();
            this.xtabAdvanced = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtMinusOTHourRate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPlusOTHourRate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDayHours = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.rdbHours = new System.Windows.Forms.RadioButton();
            this.rdbDays = new System.Windows.Forms.RadioButton();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.checkEditClearReportLayout = new DevExpress.XtraEditors.CheckEdit();
            this.chkPrintPF = new DevExpress.XtraEditors.CheckEdit();
            this.chkAllowToSelectPaymentDueDate = new DevExpress.XtraEditors.CheckEdit();
            this.chkPrintSlip = new DevExpress.XtraEditors.CheckEdit();
            this.xtabOther = new DevExpress.XtraTab.XtraTabPage();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.txtSlipPrinterName = new DevExpress.XtraEditors.TextEdit();
            this.billPrintModelTableAdapter1 = new DiamondTrading.karmajew_DiamondTradingLiveDataSetTableAdapters.BillPrintModelTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormTitle.Properties)).BeginInit();
            this.xtabAdvanced.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinusOTHourRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlusOTHourRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDayHours.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditClearReportLayout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintPF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowToSelectPaymentDueDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintSlip.Properties)).BeginInit();
            this.xtabOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSlipPrinterName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtabGeneral;
            this.xtraTabControl1.Size = new System.Drawing.Size(298, 344);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtabGeneral,
            this.xtabAdvanced,
            this.xtabOther});
            // 
            // xtabGeneral
            // 
            this.xtabGeneral.Controls.Add(this.groupControl1);
            this.xtabGeneral.Name = "xtabGeneral";
            this.xtabGeneral.Size = new System.Drawing.Size(296, 321);
            this.xtabGeneral.Text = "General";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtFormTitle);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(290, 60);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Form Title";
            // 
            // txtFormTitle
            // 
            this.txtFormTitle.Location = new System.Drawing.Point(5, 26);
            this.txtFormTitle.Name = "txtFormTitle";
            this.txtFormTitle.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtFormTitle.Properties.Appearance.Options.UseFont = true;
            this.txtFormTitle.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFormTitle.Size = new System.Drawing.Size(280, 26);
            this.txtFormTitle.TabIndex = 3;
            this.txtFormTitle.TextChanged += new System.EventHandler(this.txtFormTitle_TextChanged);
            // 
            // xtabAdvanced
            // 
            this.xtabAdvanced.Controls.Add(this.groupControl3);
            this.xtabAdvanced.Controls.Add(this.groupControl2);
            this.xtabAdvanced.Name = "xtabAdvanced";
            this.xtabAdvanced.Size = new System.Drawing.Size(296, 321);
            this.xtabAdvanced.Text = "Advanced";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txtMinusOTHourRate);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.txtPlusOTHourRate);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Controls.Add(this.txtDayHours);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.rdbHours);
            this.groupControl3.Controls.Add(this.rdbDays);
            this.groupControl3.Controls.Add(this.labelControl11);
            this.groupControl3.Location = new System.Drawing.Point(3, 135);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(290, 139);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "Salary Settings";
            this.groupControl3.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl3_Paint);
            // 
            // txtMinusOTHourRate
            // 
            this.txtMinusOTHourRate.EditValue = "0";
            this.txtMinusOTHourRate.Location = new System.Drawing.Point(115, 107);
            this.txtMinusOTHourRate.Name = "txtMinusOTHourRate";
            this.txtMinusOTHourRate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMinusOTHourRate.Properties.Appearance.Options.UseFont = true;
            this.txtMinusOTHourRate.Properties.Appearance.Options.UseTextOptions = true;
            this.txtMinusOTHourRate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtMinusOTHourRate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtMinusOTHourRate.Properties.MaskSettings.Set("mask", "f");
            this.txtMinusOTHourRate.Size = new System.Drawing.Size(58, 20);
            this.txtMinusOTHourRate.TabIndex = 8;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(9, 110);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(94, 14);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "(-)OT Hour Rate:";
            // 
            // txtPlusOTHourRate
            // 
            this.txtPlusOTHourRate.EditValue = "0";
            this.txtPlusOTHourRate.Location = new System.Drawing.Point(115, 80);
            this.txtPlusOTHourRate.Name = "txtPlusOTHourRate";
            this.txtPlusOTHourRate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtPlusOTHourRate.Properties.Appearance.Options.UseFont = true;
            this.txtPlusOTHourRate.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPlusOTHourRate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtPlusOTHourRate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtPlusOTHourRate.Properties.MaskSettings.Set("mask", "f");
            this.txtPlusOTHourRate.Size = new System.Drawing.Size(58, 20);
            this.txtPlusOTHourRate.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(9, 83);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(98, 14);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "(+)OT Hour Rate:";
            // 
            // txtDayHours
            // 
            this.txtDayHours.EditValue = "0";
            this.txtDayHours.Location = new System.Drawing.Point(115, 53);
            this.txtDayHours.Name = "txtDayHours";
            this.txtDayHours.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtDayHours.Properties.Appearance.Options.UseFont = true;
            this.txtDayHours.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDayHours.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtDayHours.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtDayHours.Properties.MaskSettings.Set("mask", "f");
            this.txtDayHours.Size = new System.Drawing.Size(58, 20);
            this.txtDayHours.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(9, 56);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Day Hours:";
            // 
            // rdbHours
            // 
            this.rdbHours.AutoSize = true;
            this.rdbHours.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbHours.Location = new System.Drawing.Point(223, 26);
            this.rdbHours.Name = "rdbHours";
            this.rdbHours.Size = new System.Drawing.Size(56, 18);
            this.rdbHours.TabIndex = 2;
            this.rdbHours.Text = "Hours";
            this.rdbHours.UseVisualStyleBackColor = true;
            // 
            // rdbDays
            // 
            this.rdbDays.AutoSize = true;
            this.rdbDays.Checked = true;
            this.rdbDays.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDays.Location = new System.Drawing.Point(164, 26);
            this.rdbDays.Name = "rdbDays";
            this.rdbDays.Size = new System.Drawing.Size(50, 18);
            this.rdbDays.TabIndex = 1;
            this.rdbDays.TabStop = true;
            this.rdbDays.Text = "Days";
            this.rdbDays.UseVisualStyleBackColor = true;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(9, 28);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(149, 14);
            this.labelControl11.TabIndex = 0;
            this.labelControl11.Text = "Salary calculation based on:";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.checkEditClearReportLayout);
            this.groupControl2.Controls.Add(this.chkPrintPF);
            this.groupControl2.Controls.Add(this.chkAllowToSelectPaymentDueDate);
            this.groupControl2.Controls.Add(this.chkPrintSlip);
            this.groupControl2.Location = new System.Drawing.Point(3, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(290, 126);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Purchase Entry Settings";
            // 
            // checkEditClearReportLayout
            // 
            this.checkEditClearReportLayout.Location = new System.Drawing.Point(9, 96);
            this.checkEditClearReportLayout.Name = "checkEditClearReportLayout";
            this.checkEditClearReportLayout.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEditClearReportLayout.Properties.Appearance.Options.UseFont = true;
            this.checkEditClearReportLayout.Properties.Caption = "Delete all report layout.";
            this.checkEditClearReportLayout.Size = new System.Drawing.Size(233, 18);
            this.checkEditClearReportLayout.TabIndex = 3;
            this.checkEditClearReportLayout.CheckedChanged += new System.EventHandler(this.checkEditClearReportLayout_CheckedChanged);
            // 
            // chkPrintPF
            // 
            this.chkPrintPF.Location = new System.Drawing.Point(9, 50);
            this.chkPrintPF.Name = "chkPrintPF";
            this.chkPrintPF.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintPF.Properties.Appearance.Options.UseFont = true;
            this.chkPrintPF.Properties.Caption = "Print PF";
            this.chkPrintPF.Size = new System.Drawing.Size(75, 18);
            this.chkPrintPF.TabIndex = 1;
            this.chkPrintPF.CheckedChanged += new System.EventHandler(this.chkPrintPF_CheckedChanged);
            // 
            // chkAllowToSelectPaymentDueDate
            // 
            this.chkAllowToSelectPaymentDueDate.Location = new System.Drawing.Point(9, 72);
            this.chkAllowToSelectPaymentDueDate.Name = "chkAllowToSelectPaymentDueDate";
            this.chkAllowToSelectPaymentDueDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllowToSelectPaymentDueDate.Properties.Appearance.Options.UseFont = true;
            this.chkAllowToSelectPaymentDueDate.Properties.Caption = "Allow to select Payment Due Date";
            this.chkAllowToSelectPaymentDueDate.Size = new System.Drawing.Size(233, 18);
            this.chkAllowToSelectPaymentDueDate.TabIndex = 2;
            this.chkAllowToSelectPaymentDueDate.CheckedChanged += new System.EventHandler(this.chkAllowToSelectPaymentDueDate_CheckedChanged);
            // 
            // chkPrintSlip
            // 
            this.chkPrintSlip.Location = new System.Drawing.Point(9, 27);
            this.chkPrintSlip.Name = "chkPrintSlip";
            this.chkPrintSlip.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintSlip.Properties.Appearance.Options.UseFont = true;
            this.chkPrintSlip.Properties.Caption = "Print Slip";
            this.chkPrintSlip.Size = new System.Drawing.Size(75, 18);
            this.chkPrintSlip.TabIndex = 0;
            this.chkPrintSlip.CheckedChanged += new System.EventHandler(this.chkPrintSlip_CheckedChanged);
            // 
            // xtabOther
            // 
            this.xtabOther.Controls.Add(this.groupControl4);
            this.xtabOther.Name = "xtabOther";
            this.xtabOther.Size = new System.Drawing.Size(296, 321);
            this.xtabOther.Text = "Other";
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(215, 350);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 9;
            this.btnApply.Text = "&Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(134, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(53, 350);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "&OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.txtSlipPrinterName);
            this.groupControl4.Location = new System.Drawing.Point(3, 5);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(290, 60);
            this.groupControl4.TabIndex = 2;
            this.groupControl4.Text = "Slip Printer Name";
            // 
            // txtSlipPrinterName
            // 
            this.txtSlipPrinterName.Location = new System.Drawing.Point(5, 26);
            this.txtSlipPrinterName.Name = "txtSlipPrinterName";
            this.txtSlipPrinterName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtSlipPrinterName.Properties.Appearance.Options.UseFont = true;
            this.txtSlipPrinterName.Size = new System.Drawing.Size(280, 26);
            this.txtSlipPrinterName.TabIndex = 3;
            this.txtSlipPrinterName.TextChanged += new System.EventHandler(this.txtSlipPrinterName_TextChanged);
            // 
            // billPrintModelTableAdapter1
            // 
            this.billPrintModelTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 381);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.xtraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::DiamondTrading.Properties.Resources.option_16;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.FrmOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtabGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFormTitle.Properties)).EndInit();
            this.xtabAdvanced.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinusOTHourRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlusOTHourRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDayHours.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditClearReportLayout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintPF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowToSelectPaymentDueDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintSlip.Properties)).EndInit();
            this.xtabOther.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSlipPrinterName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtabGeneral;
        private DevExpress.XtraTab.XtraTabPage xtabAdvanced;
        private DevExpress.XtraTab.XtraTabPage xtabOther;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtFormTitle;
        private DevExpress.XtraEditors.SimpleButton btnApply;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.CheckEdit chkAllowToSelectPaymentDueDate;
        private DevExpress.XtraEditors.CheckEdit chkPrintSlip;
        private DevExpress.XtraEditors.CheckEdit chkPrintPF;
        private DevExpress.XtraEditors.CheckEdit checkEditClearReportLayout;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.RadioButton rdbHours;
        private System.Windows.Forms.RadioButton rdbDays;
        private DevExpress.XtraEditors.TextEdit txtMinusOTHourRate;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPlusOTHourRate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDayHours;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.TextEdit txtSlipPrinterName;
        private karmajew_DiamondTradingLiveDataSetTableAdapters.BillPrintModelTableAdapter billPrintModelTableAdapter1;
    }
}
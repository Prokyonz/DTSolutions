
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.chkAllowToSelectPaymentDueDate = new DevExpress.XtraEditors.CheckEdit();
            this.chkPrintSlip = new DevExpress.XtraEditors.CheckEdit();
            this.xtabOther = new DevExpress.XtraTab.XtraTabPage();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.chkPrintPF = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormTitle.Properties)).BeginInit();
            this.xtabAdvanced.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowToSelectPaymentDueDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintSlip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintPF.Properties)).BeginInit();
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
            this.txtFormTitle.Properties.BeepOnError = false;
            this.txtFormTitle.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFormTitle.Size = new System.Drawing.Size(280, 26);
            this.txtFormTitle.TabIndex = 3;
            this.txtFormTitle.TextChanged += new System.EventHandler(this.txtFormTitle_TextChanged);
            // 
            // xtabAdvanced
            // 
            this.xtabAdvanced.Controls.Add(this.groupControl2);
            this.xtabAdvanced.Name = "xtabAdvanced";
            this.xtabAdvanced.Size = new System.Drawing.Size(296, 321);
            this.xtabAdvanced.Text = "Advanced";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.chkPrintPF);
            this.groupControl2.Controls.Add(this.chkAllowToSelectPaymentDueDate);
            this.groupControl2.Controls.Add(this.chkPrintSlip);
            this.groupControl2.Location = new System.Drawing.Point(3, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(290, 103);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Purchase Entry Settings";
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowToSelectPaymentDueDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintSlip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintPF.Properties)).EndInit();
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
    }
}
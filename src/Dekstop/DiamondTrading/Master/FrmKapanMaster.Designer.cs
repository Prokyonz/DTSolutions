
namespace DiamondTrading.Master
{
    partial class FrmKapanMaster
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
            this.txtDetails = new DevExpress.XtraEditors.MemoEdit();
            this.tglIsActive = new DevExpress.XtraEditors.ToggleSwitch();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtKapanName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtKapanExpense = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetails.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKapanName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKapanExpense.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txtKapanExpense);
            this.groupControl1.Controls.Add(this.txtDetails);
            this.groupControl1.Controls.Add(this.tglIsActive);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtKapanName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(9, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(345, 202);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Kapan Details";
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(10, 102);
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(324, 42);
            this.txtDetails.TabIndex = 4;
            // 
            // tglIsActive
            // 
            this.tglIsActive.EditValue = true;
            this.tglIsActive.Location = new System.Drawing.Point(200, 27);
            this.tglIsActive.Name = "tglIsActive";
            this.tglIsActive.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tglIsActive.Properties.Appearance.Options.UseFont = true;
            this.tglIsActive.Properties.OffText = "In-Active";
            this.tglIsActive.Properties.OnText = "Active";
            this.tglIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tglIsActive.Size = new System.Drawing.Size(134, 19);
            this.tglIsActive.TabIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(10, 82);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 14);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Details";
            // 
            // txtKapanName
            // 
            this.txtKapanName.Location = new System.Drawing.Point(10, 48);
            this.txtKapanName.Name = "txtKapanName";
            this.txtKapanName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtKapanName.Properties.Appearance.Options.UseFont = true;
            this.txtKapanName.Properties.BeepOnError = false;
            this.txtKapanName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKapanName.Size = new System.Drawing.Size(324, 26);
            this.txtKapanName.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(10, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Name*";
            // 
            // txtKapanExpense
            // 
            this.txtKapanExpense.Location = new System.Drawing.Point(10, 168);
            this.txtKapanExpense.Name = "txtKapanExpense";
            this.txtKapanExpense.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtKapanExpense.Properties.Appearance.Options.UseFont = true;
            this.txtKapanExpense.Properties.BeepOnError = false;
            this.txtKapanExpense.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtKapanExpense.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txtKapanExpense.Properties.MaskSettings.Set("mask", "f");
            this.txtKapanExpense.Size = new System.Drawing.Size(97, 22);
            this.txtKapanExpense.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(279, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(198, 215);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "&Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(117, 215);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(10, 151);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(83, 14);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Kapan Expense";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(113, 171);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 14);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "(In Percentage)";
            // 
            // FrmKapanMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(368, 247);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmKapanMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Kapan";
            this.Load += new System.EventHandler(this.FrmKapanMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmKapanMaster_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetails.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKapanName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKapanExpense.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtKapanName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtKapanExpense;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ToggleSwitch tglIsActive;
        private DevExpress.XtraEditors.MemoEdit txtDetails;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
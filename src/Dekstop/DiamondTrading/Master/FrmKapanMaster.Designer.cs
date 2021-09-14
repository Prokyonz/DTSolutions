
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
            this.txtCaratLimit = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.grpCaratLimit = new DevExpress.XtraEditors.GroupControl();
            this.chkCaratLimit = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetails.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKapanName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaratLimit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCaratLimit)).BeginInit();
            this.grpCaratLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCaratLimit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtDetails);
            this.groupControl1.Controls.Add(this.tglIsActive);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtKapanName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(9, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(345, 157);
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
            // txtCaratLimit
            // 
            this.txtCaratLimit.Location = new System.Drawing.Point(10, 43);
            this.txtCaratLimit.Name = "txtCaratLimit";
            this.txtCaratLimit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCaratLimit.Properties.Appearance.Options.UseFont = true;
            this.txtCaratLimit.Size = new System.Drawing.Size(97, 22);
            this.txtCaratLimit.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(279, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(198, 248);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "&Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(117, 248);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpCaratLimit
            // 
            this.grpCaratLimit.Controls.Add(this.labelControl6);
            this.grpCaratLimit.Controls.Add(this.txtCaratLimit);
            this.grpCaratLimit.Enabled = false;
            this.grpCaratLimit.Location = new System.Drawing.Point(9, 167);
            this.grpCaratLimit.Name = "grpCaratLimit";
            this.grpCaratLimit.Size = new System.Drawing.Size(345, 73);
            this.grpCaratLimit.TabIndex = 2;
            // 
            // chkCaratLimit
            // 
            this.chkCaratLimit.Location = new System.Drawing.Point(19, 169);
            this.chkCaratLimit.Name = "chkCaratLimit";
            this.chkCaratLimit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCaratLimit.Properties.Appearance.Options.UseFont = true;
            this.chkCaratLimit.Properties.Caption = "Set Carat Limit";
            this.chkCaratLimit.Size = new System.Drawing.Size(128, 18);
            this.chkCaratLimit.TabIndex = 1;
            this.chkCaratLimit.CheckedChanged += new System.EventHandler(this.chkCaratLimit_CheckedChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(10, 26);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(64, 14);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Carate Limit";
            // 
            // FrmKapanMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 281);
            this.Controls.Add(this.chkCaratLimit);
            this.Controls.Add(this.grpCaratLimit);
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
            ((System.ComponentModel.ISupportInitialize)(this.txtCaratLimit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCaratLimit)).EndInit();
            this.grpCaratLimit.ResumeLayout(false);
            this.grpCaratLimit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCaratLimit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtKapanName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtCaratLimit;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ToggleSwitch tglIsActive;
        private DevExpress.XtraEditors.MemoEdit txtDetails;
        private DevExpress.XtraEditors.GroupControl grpCaratLimit;
        private DevExpress.XtraEditors.CheckEdit chkCaratLimit;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}
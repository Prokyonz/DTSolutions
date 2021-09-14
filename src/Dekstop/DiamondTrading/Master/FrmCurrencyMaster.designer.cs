
namespace DiamondTrading.Master
{
    partial class FrmCurrencyMaster
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
            this.txtShortName = new DevExpress.XtraEditors.TextEdit();
            this.txtRate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCurrencyName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrencyName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtShortName);
            this.groupControl1.Controls.Add(this.txtRate);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtCurrencyName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(9, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(345, 136);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Currency Details";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(10, 99);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtShortName.Properties.Appearance.Options.UseFont = true;
            this.txtShortName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShortName.Size = new System.Drawing.Size(221, 22);
            this.txtShortName.TabIndex = 3;
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(237, 99);
            this.txtRate.Name = "txtRate";
            this.txtRate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtRate.Properties.Appearance.Options.UseFont = true;
            this.txtRate.Size = new System.Drawing.Size(97, 22);
            this.txtRate.TabIndex = 5;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(237, 82);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(32, 14);
            this.labelControl6.TabIndex = 4;
            this.labelControl6.Text = "Rate*";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(10, 82);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 14);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Short Name*";
            // 
            // txtCurrencyName
            // 
            this.txtCurrencyName.Location = new System.Drawing.Point(10, 48);
            this.txtCurrencyName.Name = "txtCurrencyName";
            this.txtCurrencyName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtCurrencyName.Properties.Appearance.Options.UseFont = true;
            this.txtCurrencyName.Properties.BeepOnError = false;
            this.txtCurrencyName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCurrencyName.Size = new System.Drawing.Size(324, 26);
            this.txtCurrencyName.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(10, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Name*";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(279, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(198, 147);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "&Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(117, 147);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmCurrencyMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 182);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCurrencyMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Currency";
            this.Load += new System.EventHandler(this.FrmCurrencyMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCurrencyMaster_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrencyName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtCurrencyName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtRate;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtShortName;
    }
}
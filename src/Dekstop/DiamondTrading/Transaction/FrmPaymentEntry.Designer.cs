
namespace DiamondTrading.Transaction
{
    partial class FrmPaymentEntry
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
            this.lblFormTitle = new DevExpress.XtraEditors.LabelControl();
            this.lueCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtSerialNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.grpGroup1 = new DevExpress.XtraEditors.GroupControl();
            this.grdPurchaseDetails = new DevExpress.XtraGrid.GridControl();
            this.grvPurchaseDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colParty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoParty = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoTxtEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grpGroup2 = new DevExpress.XtraEditors.GroupControl();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtLedgerBalance = new DevExpress.XtraEditors.TextEdit();
            this.lueLeadger = new DevExpress.XtraEditors.LookUpEdit();
            this.dtTime = new DevExpress.XtraEditors.DateEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.dtDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lueCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGroup1)).BeginInit();
            this.grpGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPurchaseDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoParty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoTxtEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGroup2)).BeginInit();
            this.grpGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLedgerBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLeadger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.lblFormTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblFormTitle.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblFormTitle.Appearance.Options.UseFont = true;
            this.lblFormTitle.Appearance.Options.UseForeColor = true;
            this.lblFormTitle.Appearance.Options.UseTextOptions = true;
            this.lblFormTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblFormTitle.Location = new System.Drawing.Point(0, 2);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(626, 23);
            this.lblFormTitle.TabIndex = 23;
            this.lblFormTitle.Text = "|| શ્રીજી ||";
            this.lblFormTitle.UseMnemonic = false;
            this.lblFormTitle.Click += new System.EventHandler(this.lblFormTitle_Click);
            // 
            // lueCompany
            // 
            this.lueCompany.Location = new System.Drawing.Point(170, 31);
            this.lueCompany.Name = "lueCompany";
            this.lueCompany.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueCompany.Properties.Appearance.Options.UseFont = true;
            this.lueCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "CommisionID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShortName", "Short Name", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueCompany.Properties.NullText = "";
            this.lueCompany.Size = new System.Drawing.Size(299, 22);
            this.lueCompany.TabIndex = 1;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(11, 61);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(61, 16);
            this.labelControl12.TabIndex = 2;
            this.labelControl12.Text = "Serial No :";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.EditValue = "0";
            this.txtSerialNo.Enabled = false;
            this.txtSerialNo.Location = new System.Drawing.Point(75, 59);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNo.Properties.Appearance.Options.UseFont = true;
            this.txtSerialNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtSerialNo.Size = new System.Drawing.Size(97, 24);
            this.txtSerialNo.TabIndex = 3;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(11, 105);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(62, 16);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Account* :";
            // 
            // grpGroup1
            // 
            this.grpGroup1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGroup1.AppearanceCaption.Options.UseFont = true;
            this.grpGroup1.Controls.Add(this.grdPurchaseDetails);
            this.grpGroup1.Location = new System.Drawing.Point(11, 158);
            this.grpGroup1.Name = "grpGroup1";
            this.grpGroup1.Size = new System.Drawing.Size(606, 269);
            this.grpGroup1.TabIndex = 26;
            this.grpGroup1.Text = "Particulars Details";
            // 
            // grdPurchaseDetails
            // 
            this.grdPurchaseDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPurchaseDetails.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPurchaseDetails.Location = new System.Drawing.Point(2, 23);
            this.grdPurchaseDetails.MainView = this.grvPurchaseDetails;
            this.grdPurchaseDetails.Name = "grdPurchaseDetails";
            this.grdPurchaseDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoTxtEdit,
            this.repoParty});
            this.grdPurchaseDetails.Size = new System.Drawing.Size(602, 244);
            this.grdPurchaseDetails.TabIndex = 0;
            this.grdPurchaseDetails.UseEmbeddedNavigator = true;
            this.grdPurchaseDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPurchaseDetails});
            // 
            // grvPurchaseDetails
            // 
            this.grvPurchaseDetails.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.grvPurchaseDetails.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvPurchaseDetails.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPurchaseDetails.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvPurchaseDetails.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.grvPurchaseDetails.Appearance.Row.Options.UseFont = true;
            this.grvPurchaseDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colParty,
            this.colAmount});
            this.grvPurchaseDetails.GridControl = this.grdPurchaseDetails;
            this.grvPurchaseDetails.Name = "grvPurchaseDetails";
            this.grvPurchaseDetails.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvPurchaseDetails.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvPurchaseDetails.OptionsView.ShowGroupPanel = false;
            // 
            // colParty
            // 
            this.colParty.Caption = "Particulars";
            this.colParty.ColumnEdit = this.repoParty;
            this.colParty.FieldName = "Party";
            this.colParty.Name = "colParty";
            this.colParty.Visible = true;
            this.colParty.VisibleIndex = 0;
            this.colParty.Width = 567;
            // 
            // repoParty
            // 
            this.repoParty.AutoHeight = false;
            this.repoParty.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoParty.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Category"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "CategoryId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repoParty.Name = "repoParty";
            this.repoParty.NullText = "";
            // 
            // colAmount
            // 
            this.colAmount.Caption = "Amount";
            this.colAmount.ColumnEdit = this.repoTxtEdit;
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 1;
            this.colAmount.Width = 223;
            // 
            // repoTxtEdit
            // 
            this.repoTxtEdit.AutoHeight = false;
            this.repoTxtEdit.BeepOnError = true;
            this.repoTxtEdit.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.repoTxtEdit.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.repoTxtEdit.MaskSettings.Set("mask", "f");
            this.repoTxtEdit.Name = "repoTxtEdit";
            // 
            // grpGroup2
            // 
            this.grpGroup2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGroup2.AppearanceCaption.Options.UseFont = true;
            this.grpGroup2.Controls.Add(this.txtRemark);
            this.grpGroup2.Location = new System.Drawing.Point(11, 433);
            this.grpGroup2.Name = "grpGroup2";
            this.grpGroup2.Size = new System.Drawing.Size(606, 83);
            this.grpGroup2.TabIndex = 27;
            this.grpGroup2.Text = "Remark";
            // 
            // txtRemark
            // 
            this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemark.Location = new System.Drawing.Point(10, 29);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(586, 47);
            this.txtRemark.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(563, 534);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReset
            // 
            this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Appearance.Options.UseFont = true;
            this.btnReset.Location = new System.Drawing.Point(482, 534);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 21);
            this.btnReset.TabIndex = 29;
            this.btnReset.Text = "&Reset";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(401, 534);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "&Save";
            // 
            // txtLedgerBalance
            // 
            this.txtLedgerBalance.EditValue = "0";
            this.txtLedgerBalance.Enabled = false;
            this.txtLedgerBalance.Location = new System.Drawing.Point(78, 124);
            this.txtLedgerBalance.Name = "txtLedgerBalance";
            this.txtLedgerBalance.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtLedgerBalance.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLedgerBalance.Properties.Appearance.Options.UseBackColor = true;
            this.txtLedgerBalance.Properties.Appearance.Options.UseFont = true;
            this.txtLedgerBalance.Properties.Appearance.Options.UseTextOptions = true;
            this.txtLedgerBalance.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtLedgerBalance.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtLedgerBalance.Size = new System.Drawing.Size(109, 20);
            this.txtLedgerBalance.TabIndex = 7;
            // 
            // lueLeadger
            // 
            this.lueLeadger.Location = new System.Drawing.Point(78, 103);
            this.lueLeadger.Name = "lueLeadger";
            this.lueLeadger.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueLeadger.Properties.Appearance.Options.UseFont = true;
            this.lueLeadger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueLeadger.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Party Name", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "PartyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShortName", "Short Name", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueLeadger.Properties.NullText = "";
            this.lueLeadger.Size = new System.Drawing.Size(275, 22);
            this.lueLeadger.TabIndex = 6;
            this.lueLeadger.EditValueChanged += new System.EventHandler(this.lueLeadger_EditValueChanged);
            // 
            // dtTime
            // 
            this.dtTime.EditValue = null;
            this.dtTime.Enabled = false;
            this.dtTime.Location = new System.Drawing.Point(529, 83);
            this.dtTime.Name = "dtTime";
            this.dtTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTime.Properties.Appearance.Options.UseFont = true;
            this.dtTime.Properties.Appearance.Options.UseTextOptions = true;
            this.dtTime.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.dtTime.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.dtTime.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.dtTime.Properties.BeepOnError = false;
            this.dtTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.dtTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTime.Properties.DisplayFormat.FormatString = "t";
            this.dtTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTime.Properties.EditFormat.FormatString = "t";
            this.dtTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTime.Properties.MaskSettings.Set("mask", "t");
            this.dtTime.Size = new System.Drawing.Size(88, 20);
            this.dtTime.TabIndex = 8;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(479, 63);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(43, 16);
            this.labelControl8.TabIndex = 6;
            this.labelControl8.Text = "Date* :";
            // 
            // dtDate
            // 
            this.dtDate.EditValue = null;
            this.dtDate.Location = new System.Drawing.Point(529, 61);
            this.dtDate.Name = "dtDate";
            this.dtDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Properties.Appearance.Options.UseFont = true;
            this.dtDate.Properties.BeepOnError = false;
            this.dtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate.Properties.MaskSettings.Set("mask", "d");
            this.dtDate.Size = new System.Drawing.Size(88, 22);
            this.dtDate.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(103, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 16);
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "Company :";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lueCompany);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl12);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.lblFormTitle);
            this.panelControl1.Controls.Add(this.grpGroup1);
            this.panelControl1.Controls.Add(this.lueLeadger);
            this.panelControl1.Controls.Add(this.grpGroup2);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.dtTime);
            this.panelControl1.Controls.Add(this.txtSerialNo);
            this.panelControl1.Controls.Add(this.txtLedgerBalance);
            this.panelControl1.Controls.Add(this.dtDate);
            this.panelControl1.Location = new System.Drawing.Point(10, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(628, 526);
            this.panelControl1.TabIndex = 32;
            // 
            // FrmPaymentEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 565);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPaymentEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAYMENT";
            this.Load += new System.EventHandler(this.FrmPaymentEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGroup1)).EndInit();
            this.grpGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPurchaseDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoParty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoTxtEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGroup2)).EndInit();
            this.grpGroup2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLedgerBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLeadger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblFormTitle;
        private DevExpress.XtraEditors.LookUpEdit lueCompany;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtSerialNo;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.GroupControl grpGroup1;
        private DevExpress.XtraGrid.GridControl grdPurchaseDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPurchaseDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colParty;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoParty;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoTxtEdit;
        private DevExpress.XtraEditors.GroupControl grpGroup2;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtLedgerBalance;
        private DevExpress.XtraEditors.LookUpEdit lueLeadger;
        private DevExpress.XtraEditors.DateEdit dtTime;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.DateEdit dtDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
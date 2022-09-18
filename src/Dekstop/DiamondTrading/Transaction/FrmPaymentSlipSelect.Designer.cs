
namespace DiamondTrading.Transaction
{
    partial class FrmPaymentSlipSelect
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
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.grpGroup1 = new DevExpress.XtraEditors.GroupControl();
            this.grdPaymentDetails = new DevExpress.XtraGrid.GridControl();
            this.grvPaymentDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSlipNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPartyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranchId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinancialYearId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoTxtEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repoParty = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.tglIsAutoMap = new DevExpress.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.grpGroup1)).BeginInit();
            this.grpGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPaymentDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoTxtEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoParty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglIsAutoMap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(655, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Appearance.Options.UseFont = true;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(574, 340);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 21);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "&Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // grpGroup1
            // 
            this.grpGroup1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGroup1.AppearanceCaption.Options.UseFont = true;
            this.grpGroup1.Controls.Add(this.grdPaymentDetails);
            this.grpGroup1.Location = new System.Drawing.Point(12, 24);
            this.grpGroup1.Name = "grpGroup1";
            this.grpGroup1.Size = new System.Drawing.Size(716, 307);
            this.grpGroup1.TabIndex = 12;
            this.grpGroup1.Text = "Particulars Details";
            // 
            // grdPaymentDetails
            // 
            this.grdPaymentDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPaymentDetails.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPaymentDetails.Location = new System.Drawing.Point(2, 23);
            this.grdPaymentDetails.MainView = this.grvPaymentDetails;
            this.grdPaymentDetails.Name = "grdPaymentDetails";
            this.grdPaymentDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoTxtEdit,
            this.repoParty,
            this.repositoryItemButtonEdit1});
            this.grdPaymentDetails.Size = new System.Drawing.Size(712, 282);
            this.grdPaymentDetails.TabIndex = 0;
            this.grdPaymentDetails.UseEmbeddedNavigator = true;
            this.grdPaymentDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPaymentDetails});
            // 
            // grvPaymentDetails
            // 
            this.grvPaymentDetails.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.grvPaymentDetails.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvPaymentDetails.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPaymentDetails.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvPaymentDetails.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.grvPaymentDetails.Appearance.Row.Options.UseFont = true;
            this.grvPaymentDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colSlipNo,
            this.colPartyId,
            this.colParty,
            this.colCompanyId,
            this.colBranchId,
            this.colFinancialYearId,
            this.colYear,
            this.colTAmount,
            this.colAAmount,
            this.colAmount});
            this.grvPaymentDetails.GridControl = this.grdPaymentDetails;
            this.grvPaymentDetails.Name = "grvPaymentDetails";
            this.grvPaymentDetails.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvPaymentDetails.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvPaymentDetails.OptionsView.ShowFooter = true;
            this.grvPaymentDetails.OptionsView.ShowGroupPanel = false;
            // 
            // colDate
            // 
            this.colDate.Caption = "Date";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.OptionsColumn.AllowEdit = false;
            this.colDate.Width = 84;
            // 
            // colSlipNo
            // 
            this.colSlipNo.Caption = "SlipNo";
            this.colSlipNo.FieldName = "SlipNo";
            this.colSlipNo.Name = "colSlipNo";
            this.colSlipNo.OptionsColumn.AllowEdit = false;
            this.colSlipNo.Visible = true;
            this.colSlipNo.VisibleIndex = 0;
            this.colSlipNo.Width = 79;
            // 
            // colPartyId
            // 
            this.colPartyId.Caption = "PartyId";
            this.colPartyId.FieldName = "PartyId";
            this.colPartyId.Name = "colPartyId";
            // 
            // colParty
            // 
            this.colParty.Caption = "Party";
            this.colParty.FieldName = "Party";
            this.colParty.Name = "colParty";
            this.colParty.OptionsColumn.AllowEdit = false;
            this.colParty.Width = 256;
            // 
            // colCompanyId
            // 
            this.colCompanyId.Caption = "CompanyId";
            this.colCompanyId.FieldName = "CompanyId";
            this.colCompanyId.Name = "colCompanyId";
            // 
            // colBranchId
            // 
            this.colBranchId.Caption = "BranchId";
            this.colBranchId.FieldName = "BranchId";
            this.colBranchId.Name = "colBranchId";
            // 
            // colFinancialYearId
            // 
            this.colFinancialYearId.Caption = "FinancialYearId";
            this.colFinancialYearId.FieldName = "FinancialYearId";
            this.colFinancialYearId.Name = "colFinancialYearId";
            // 
            // colYear
            // 
            this.colYear.Caption = "Year";
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            this.colYear.OptionsColumn.AllowEdit = false;
            this.colYear.Width = 89;
            // 
            // colTAmount
            // 
            this.colTAmount.Caption = "T Amount";
            this.colTAmount.FieldName = "GrossTotal";
            this.colTAmount.Name = "colTAmount";
            this.colTAmount.OptionsColumn.AllowEdit = false;
            this.colTAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GrossTotal", "{0:0.##}")});
            this.colTAmount.Width = 89;
            // 
            // colAAmount
            // 
            this.colAAmount.Caption = "A Amount";
            this.colAAmount.FieldName = "RemainAmount";
            this.colAAmount.Name = "colAAmount";
            this.colAAmount.OptionsColumn.AllowEdit = false;
            this.colAAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RemainAmount", "{0:0.##}")});
            this.colAAmount.Visible = true;
            this.colAAmount.VisibleIndex = 1;
            this.colAAmount.Width = 89;
            // 
            // colAmount
            // 
            this.colAmount.Caption = "Amount";
            this.colAmount.ColumnEdit = this.repoTxtEdit;
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:0.##}")});
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 2;
            this.colAmount.Width = 104;
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
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.repositoryItemButtonEdit1.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.repositoryItemButtonEdit1.MaskSettings.Set("mask", "f");
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // tglIsAutoMap
            // 
            this.tglIsAutoMap.Location = new System.Drawing.Point(596, 2);
            this.tglIsAutoMap.Name = "tglIsAutoMap";
            this.tglIsAutoMap.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tglIsAutoMap.Properties.Appearance.Options.UseFont = true;
            this.tglIsAutoMap.Properties.OffText = "Automap Off";
            this.tglIsAutoMap.Properties.OnText = "Automap On";
            this.tglIsAutoMap.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tglIsAutoMap.Size = new System.Drawing.Size(134, 19);
            this.tglIsAutoMap.TabIndex = 13;
            this.tglIsAutoMap.Toggled += new System.EventHandler(this.tglIsAutoMap_Toggled);
            // 
            // FrmPaymentSlipSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(740, 373);
            this.Controls.Add(this.tglIsAutoMap);
            this.Controls.Add(this.grpGroup1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPaymentSlipSelect";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Slip Select";
            ((System.ComponentModel.ISupportInitialize)(this.grpGroup1)).EndInit();
            this.grpGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPaymentDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoTxtEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoParty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglIsAutoMap.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.GroupControl grpGroup1;
        private DevExpress.XtraGrid.GridControl grdPaymentDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPaymentDetails;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoParty;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoTxtEdit;
        private DevExpress.XtraEditors.ToggleSwitch tglIsAutoMap;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSlipNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPartyId;
        private DevExpress.XtraGrid.Columns.GridColumn colParty;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyId;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchId;
        private DevExpress.XtraGrid.Columns.GridColumn colFinancialYearId;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colTAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colAAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
    }
}
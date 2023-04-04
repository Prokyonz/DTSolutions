
namespace DiamondTrading.Process
{
    partial class FrmChildNumberReport
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
            DevExpress.Utils.SimpleContextButton simpleContextButton1 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton2 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton3 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton4 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton5 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton6 = new DevExpress.Utils.SimpleContextButton();
            this.grdNumberReportMaster = new DevExpress.XtraGrid.GridControl();
            this.gvNumberReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdNumbeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdChildId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdOperationType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdKapan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.InwardNetWeightCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.InwardRateCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.InwardAmountCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OutwardNetWeightCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OutwardRateCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OutwardAmountCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolClosingNetWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolClosingRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolClosingAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdNumberReportMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNumberReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // grdNumberReportMaster
            // 
            this.grdNumberReportMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNumberReportMaster.Location = new System.Drawing.Point(0, 0);
            this.grdNumberReportMaster.MainView = this.gvNumberReport;
            this.grdNumberReportMaster.Name = "grdNumberReportMaster";
            this.grdNumberReportMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox2,
            this.repositoryItemImageComboBox2});
            this.grdNumberReportMaster.Size = new System.Drawing.Size(800, 450);
            this.grdNumberReportMaster.TabIndex = 5;
            this.grdNumberReportMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNumberReport});
            // 
            // gvNumberReport
            // 
            this.gvNumberReport.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.gvNumberReport.Appearance.FooterPanel.Options.UseFont = true;
            this.gvNumberReport.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.gvNumberReport.Appearance.GroupFooter.Options.UseFont = true;
            this.gvNumberReport.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.gvNumberReport.Appearance.Row.Options.UseFont = true;
            this.gvNumberReport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdNumbeName,
            this.grdChildId,
            this.grdOperationType,
            this.grdSize,
            this.grdKapan,
            this.grdCategory,
            this.grdBranch,
            this.InwardNetWeightCol,
            this.InwardRateCol,
            this.InwardAmountCol,
            this.OutwardNetWeightCol,
            this.OutwardRateCol,
            this.OutwardAmountCol,
            this.gcolClosingNetWeight,
            this.gcolClosingRate,
            this.gcolClosingAmount});
            this.gvNumberReport.GridControl = this.grdNumberReportMaster;
            this.gvNumberReport.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InwardNetWeight", this.InwardNetWeightCol, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "InwardRate", this.InwardRateCol, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InwardAmount", this.InwardAmountCol, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutwardNetWeight", this.OutwardNetWeightCol, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "OutwardRate", this.OutwardRateCol, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutwardAmount", this.OutwardAmountCol, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ClosingNetWeight", this.gcolClosingNetWeight, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "ClosingRate", this.gcolClosingRate, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ClosingAmount", this.gcolClosingAmount, "{0:0.##}")});
            this.gvNumberReport.Name = "gvNumberReport";
            this.gvNumberReport.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gvNumberReport.OptionsBehavior.Editable = false;
            this.gvNumberReport.OptionsView.ShowFooter = true;
            // 
            // grdNumbeName
            // 
            this.grdNumbeName.Caption = "Number";
            this.grdNumbeName.FieldName = "Number";
            this.grdNumbeName.Name = "grdNumbeName";
            this.grdNumbeName.Visible = true;
            this.grdNumbeName.VisibleIndex = 3;
            this.grdNumbeName.Width = 46;
            // 
            // grdChildId
            // 
            this.grdChildId.Caption = "Id";
            this.grdChildId.FieldName = "Id";
            this.grdChildId.Name = "grdChildId";
            this.grdChildId.Width = 34;
            // 
            // grdOperationType
            // 
            this.grdOperationType.Caption = "Operation Type";
            this.grdOperationType.FieldName = "OperationType";
            this.grdOperationType.Name = "grdOperationType";
            this.grdOperationType.Visible = true;
            this.grdOperationType.VisibleIndex = 0;
            this.grdOperationType.Width = 72;
            // 
            // grdSize
            // 
            this.grdSize.Caption = "Size";
            this.grdSize.FieldName = "Size";
            this.grdSize.Name = "grdSize";
            this.grdSize.Visible = true;
            this.grdSize.VisibleIndex = 2;
            this.grdSize.Width = 32;
            // 
            // grdKapan
            // 
            this.grdKapan.Caption = "Kapan";
            this.grdKapan.FieldName = "Kapan";
            this.grdKapan.Name = "grdKapan";
            this.grdKapan.Visible = true;
            this.grdKapan.VisibleIndex = 4;
            this.grdKapan.Width = 39;
            // 
            // grdCategory
            // 
            this.grdCategory.Caption = "Category";
            this.grdCategory.FieldName = "Category";
            this.grdCategory.Name = "grdCategory";
            this.grdCategory.Visible = true;
            this.grdCategory.VisibleIndex = 5;
            this.grdCategory.Width = 48;
            // 
            // grdBranch
            // 
            this.grdBranch.Caption = "Branch";
            this.grdBranch.FieldName = "BranchName";
            this.grdBranch.Name = "grdBranch";
            this.grdBranch.Visible = true;
            this.grdBranch.VisibleIndex = 1;
            this.grdBranch.Width = 49;
            // 
            // InwardNetWeightCol
            // 
            this.InwardNetWeightCol.Caption = "Inward Weight";
            this.InwardNetWeightCol.FieldName = "InwardNetWeight";
            this.InwardNetWeightCol.Name = "InwardNetWeightCol";
            this.InwardNetWeightCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InwardNetWeight", "{0:0.##}")});
            this.InwardNetWeightCol.Visible = true;
            this.InwardNetWeightCol.VisibleIndex = 6;
            this.InwardNetWeightCol.Width = 81;
            // 
            // InwardRateCol
            // 
            this.InwardRateCol.Caption = "Inward Rate";
            this.InwardRateCol.FieldName = "InwardRate";
            this.InwardRateCol.Name = "InwardRateCol";
            this.InwardRateCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "InwardRate", "{0:0.##}")});
            this.InwardRateCol.Visible = true;
            this.InwardRateCol.VisibleIndex = 7;
            this.InwardRateCol.Width = 71;
            // 
            // InwardAmountCol
            // 
            this.InwardAmountCol.Caption = "Inward Amount";
            this.InwardAmountCol.FieldName = "InwardAmount";
            this.InwardAmountCol.Name = "InwardAmountCol";
            this.InwardAmountCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InwardAmount", "{0:0.##}")});
            this.InwardAmountCol.Visible = true;
            this.InwardAmountCol.VisibleIndex = 8;
            this.InwardAmountCol.Width = 81;
            // 
            // OutwardNetWeightCol
            // 
            this.OutwardNetWeightCol.Caption = "Outward Weight";
            this.OutwardNetWeightCol.FieldName = "OutwardNetWeight";
            this.OutwardNetWeightCol.Name = "OutwardNetWeightCol";
            this.OutwardNetWeightCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutwardNetWeight", "{0:0.##}")});
            this.OutwardNetWeightCol.Visible = true;
            this.OutwardNetWeightCol.VisibleIndex = 9;
            this.OutwardNetWeightCol.Width = 89;
            // 
            // OutwardRateCol
            // 
            this.OutwardRateCol.Caption = "Outward Rate";
            this.OutwardRateCol.FieldName = "OutwardRate";
            this.OutwardRateCol.Name = "OutwardRateCol";
            this.OutwardRateCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "OutwardRate", "{0:0.##}")});
            this.OutwardRateCol.Visible = true;
            this.OutwardRateCol.VisibleIndex = 10;
            this.OutwardRateCol.Width = 79;
            // 
            // OutwardAmountCol
            // 
            this.OutwardAmountCol.Caption = "Outward Amount";
            this.OutwardAmountCol.FieldName = "OutwardAmount";
            this.OutwardAmountCol.Name = "OutwardAmountCol";
            this.OutwardAmountCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutwardAmount", "{0:0.##}")});
            this.OutwardAmountCol.Visible = true;
            this.OutwardAmountCol.VisibleIndex = 11;
            this.OutwardAmountCol.Width = 94;
            // 
            // gcolClosingNetWeight
            // 
            this.gcolClosingNetWeight.Caption = "Closing Net Weight";
            this.gcolClosingNetWeight.FieldName = "ClosingNetWeight";
            this.gcolClosingNetWeight.Name = "gcolClosingNetWeight";
            this.gcolClosingNetWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ClosingNetWeight", "{0:0.##}")});
            this.gcolClosingNetWeight.Visible = true;
            this.gcolClosingNetWeight.VisibleIndex = 12;
            this.gcolClosingNetWeight.Width = 80;
            // 
            // gcolClosingRate
            // 
            this.gcolClosingRate.Caption = "Closing Rate";
            this.gcolClosingRate.FieldName = "ClosingRate";
            this.gcolClosingRate.Name = "gcolClosingRate";
            this.gcolClosingRate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "ClosingRate", "{0:0.##}")});
            this.gcolClosingRate.Visible = true;
            this.gcolClosingRate.VisibleIndex = 13;
            this.gcolClosingRate.Width = 70;
            // 
            // gcolClosingAmount
            // 
            this.gcolClosingAmount.Caption = "Closing Amount";
            this.gcolClosingAmount.FieldName = "ClosingAmount";
            this.gcolClosingAmount.Name = "gcolClosingAmount";
            this.gcolClosingAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ClosingAmount", "{0:0.##}")});
            this.gcolClosingAmount.Visible = true;
            this.gcolClosingAmount.VisibleIndex = 14;
            this.gcolClosingAmount.Width = 97;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            simpleContextButton1.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton1.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton1.Id = new System.Guid("54721bc4-12c7-44e4-b1f0-3eed0f0a527f");
            simpleContextButton1.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton1.Name = "Pending";
            simpleContextButton2.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton2.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton2.Id = new System.Guid("ef446b4e-752a-4c31-8bf4-d810bb6e9d15");
            simpleContextButton2.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton2.Name = "Approved";
            simpleContextButton3.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton3.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton3.Id = new System.Guid("e82ded0a-e804-44ad-872c-5d9ec8dd7edd");
            simpleContextButton3.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton3.Name = "Reject";
            this.repositoryItemComboBox2.ContextButtons.Add(simpleContextButton1);
            this.repositoryItemComboBox2.ContextButtons.Add(simpleContextButton2);
            this.repositoryItemComboBox2.ContextButtons.Add(simpleContextButton3);
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            this.repositoryItemComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            simpleContextButton4.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton4.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton4.Id = new System.Guid("1a85506e-04a5-4c54-82b1-95c309d2d2c0");
            simpleContextButton4.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton4.Name = "Pending";
            simpleContextButton5.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton5.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton5.Id = new System.Guid("e3c978b9-43c4-4559-b2ae-e2fde3a38a31");
            simpleContextButton5.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton5.Name = "Approved";
            simpleContextButton6.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton6.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton6.Id = new System.Guid("91d3c9e8-3e9f-4b9c-b5d6-a06ff32a7a2e");
            simpleContextButton6.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton6.Name = "Reject";
            this.repositoryItemImageComboBox2.ContextButtons.Add(simpleContextButton4);
            this.repositoryItemImageComboBox2.ContextButtons.Add(simpleContextButton5);
            this.repositoryItemImageComboBox2.ContextButtons.Add(simpleContextButton6);
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // FrmChildNumberReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grdNumberReportMaster);
            this.Name = "FrmChildNumberReport";
            this.Text = "FrmChildNumberReport";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmChildNumberReport_FormClosed);
            this.Load += new System.EventHandler(this.FrmChildNumberReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdNumberReportMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNumberReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdNumberReportMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNumberReport;
        private DevExpress.XtraGrid.Columns.GridColumn grdBranch;
        private DevExpress.XtraGrid.Columns.GridColumn InwardNetWeightCol;
        private DevExpress.XtraGrid.Columns.GridColumn InwardRateCol;
        private DevExpress.XtraGrid.Columns.GridColumn InwardAmountCol;
        private DevExpress.XtraGrid.Columns.GridColumn OutwardNetWeightCol;
        private DevExpress.XtraGrid.Columns.GridColumn OutwardRateCol;
        private DevExpress.XtraGrid.Columns.GridColumn OutwardAmountCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraGrid.Columns.GridColumn grdChildId;
        private DevExpress.XtraGrid.Columns.GridColumn grdOperationType;
        private DevExpress.XtraGrid.Columns.GridColumn grdSize;
        private DevExpress.XtraGrid.Columns.GridColumn grdKapan;
        private DevExpress.XtraGrid.Columns.GridColumn grdCategory;
        private DevExpress.XtraGrid.Columns.GridColumn grdNumbeName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolClosingNetWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gcolClosingRate;
        private DevExpress.XtraGrid.Columns.GridColumn gcolClosingAmount;
    }
}
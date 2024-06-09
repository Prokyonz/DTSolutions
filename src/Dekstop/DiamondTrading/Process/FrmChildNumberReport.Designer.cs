
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
            DevExpress.Utils.SimpleContextButton simpleContextButton13 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton14 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton15 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton16 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton17 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton18 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton19 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton20 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton21 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton22 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton23 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton24 = new DevExpress.Utils.SimpleContextButton();
            this.grdNumberReportMaster = new DevExpress.XtraGrid.GridControl();
            this.gvNumberReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdNumbeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdChildId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdOperationType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumberDate = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.grdGroupedStockReports = new DevExpress.XtraGrid.GridControl();
            this.grvGroupedStockReports = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdColId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn110 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdNumberReportMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNumberReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupedStockReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGroupedStockReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
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
            this.colNumberDate,
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
            this.grdNumbeName.VisibleIndex = 4;
            this.grdNumbeName.Width = 49;
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
            this.grdOperationType.Caption = "Operation/Party/Number";
            this.grdOperationType.FieldName = "OperationType";
            this.grdOperationType.Name = "grdOperationType";
            this.grdOperationType.Visible = true;
            this.grdOperationType.VisibleIndex = 0;
            this.grdOperationType.Width = 69;
            // 
            // colNumberDate
            // 
            this.colNumberDate.Caption = "Date";
            this.colNumberDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.colNumberDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNumberDate.FieldName = "Date";
            this.colNumberDate.Name = "colNumberDate";
            this.colNumberDate.Visible = true;
            this.colNumberDate.VisibleIndex = 1;
            this.colNumberDate.Width = 56;
            // 
            // grdSize
            // 
            this.grdSize.Caption = "Size";
            this.grdSize.FieldName = "Size";
            this.grdSize.Name = "grdSize";
            this.grdSize.Visible = true;
            this.grdSize.VisibleIndex = 3;
            this.grdSize.Width = 46;
            // 
            // grdKapan
            // 
            this.grdKapan.Caption = "Kapan";
            this.grdKapan.FieldName = "Kapan";
            this.grdKapan.Name = "grdKapan";
            this.grdKapan.Visible = true;
            this.grdKapan.VisibleIndex = 5;
            this.grdKapan.Width = 27;
            // 
            // grdCategory
            // 
            this.grdCategory.Caption = "Category";
            this.grdCategory.FieldName = "Category";
            this.grdCategory.Name = "grdCategory";
            this.grdCategory.Visible = true;
            this.grdCategory.VisibleIndex = 6;
            this.grdCategory.Width = 34;
            // 
            // grdBranch
            // 
            this.grdBranch.Caption = "Branch";
            this.grdBranch.FieldName = "BranchName";
            this.grdBranch.Name = "grdBranch";
            this.grdBranch.Visible = true;
            this.grdBranch.VisibleIndex = 2;
            this.grdBranch.Width = 50;
            // 
            // InwardNetWeightCol
            // 
            this.InwardNetWeightCol.Caption = "Inward Weight";
            this.InwardNetWeightCol.FieldName = "InwardNetWeight";
            this.InwardNetWeightCol.Name = "InwardNetWeightCol";
            this.InwardNetWeightCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InwardNetWeight", "{0:0.##}")});
            this.InwardNetWeightCol.Visible = true;
            this.InwardNetWeightCol.VisibleIndex = 7;
            this.InwardNetWeightCol.Width = 59;
            // 
            // InwardRateCol
            // 
            this.InwardRateCol.Caption = "Inward Rate";
            this.InwardRateCol.FieldName = "InwardRate";
            this.InwardRateCol.Name = "InwardRateCol";
            this.InwardRateCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "InwardRate", "{0:0.##}")});
            this.InwardRateCol.Visible = true;
            this.InwardRateCol.VisibleIndex = 8;
            this.InwardRateCol.Width = 51;
            // 
            // InwardAmountCol
            // 
            this.InwardAmountCol.Caption = "Inward Amount";
            this.InwardAmountCol.FieldName = "InwardAmount";
            this.InwardAmountCol.Name = "InwardAmountCol";
            this.InwardAmountCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InwardAmount", "{0:0.##}")});
            this.InwardAmountCol.Visible = true;
            this.InwardAmountCol.VisibleIndex = 9;
            this.InwardAmountCol.Width = 59;
            // 
            // OutwardNetWeightCol
            // 
            this.OutwardNetWeightCol.Caption = "Outward Weight";
            this.OutwardNetWeightCol.FieldName = "OutwardNetWeight";
            this.OutwardNetWeightCol.Name = "OutwardNetWeightCol";
            this.OutwardNetWeightCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutwardNetWeight", "{0:0.##}")});
            this.OutwardNetWeightCol.Visible = true;
            this.OutwardNetWeightCol.VisibleIndex = 10;
            this.OutwardNetWeightCol.Width = 66;
            // 
            // OutwardRateCol
            // 
            this.OutwardRateCol.Caption = "Outward Rate";
            this.OutwardRateCol.FieldName = "OutwardRate";
            this.OutwardRateCol.Name = "OutwardRateCol";
            this.OutwardRateCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "OutwardRate", "{0:0.##}")});
            this.OutwardRateCol.Visible = true;
            this.OutwardRateCol.VisibleIndex = 11;
            this.OutwardRateCol.Width = 57;
            // 
            // OutwardAmountCol
            // 
            this.OutwardAmountCol.Caption = "Outward Amount";
            this.OutwardAmountCol.FieldName = "OutwardAmount";
            this.OutwardAmountCol.Name = "OutwardAmountCol";
            this.OutwardAmountCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutwardAmount", "{0:0.##}")});
            this.OutwardAmountCol.Visible = true;
            this.OutwardAmountCol.VisibleIndex = 12;
            this.OutwardAmountCol.Width = 70;
            // 
            // gcolClosingNetWeight
            // 
            this.gcolClosingNetWeight.Caption = "Closing Net Weight";
            this.gcolClosingNetWeight.FieldName = "ClosingNetWeight";
            this.gcolClosingNetWeight.Name = "gcolClosingNetWeight";
            this.gcolClosingNetWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ClosingNetWeight", "{0:0.##}")});
            this.gcolClosingNetWeight.Visible = true;
            this.gcolClosingNetWeight.VisibleIndex = 13;
            this.gcolClosingNetWeight.Width = 58;
            // 
            // gcolClosingRate
            // 
            this.gcolClosingRate.Caption = "Closing Rate";
            this.gcolClosingRate.FieldName = "ClosingRate";
            this.gcolClosingRate.Name = "gcolClosingRate";
            this.gcolClosingRate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "ClosingRate", "{0:0.##}")});
            this.gcolClosingRate.Visible = true;
            this.gcolClosingRate.VisibleIndex = 14;
            this.gcolClosingRate.Width = 50;
            // 
            // gcolClosingAmount
            // 
            this.gcolClosingAmount.Caption = "Closing Amount";
            this.gcolClosingAmount.FieldName = "ClosingAmount";
            this.gcolClosingAmount.Name = "gcolClosingAmount";
            this.gcolClosingAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ClosingAmount", "{0:0.##}")});
            this.gcolClosingAmount.Visible = true;
            this.gcolClosingAmount.VisibleIndex = 15;
            this.gcolClosingAmount.Width = 105;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            simpleContextButton13.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton13.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton13.Id = new System.Guid("54721bc4-12c7-44e4-b1f0-3eed0f0a527f");
            simpleContextButton13.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton13.Name = "Pending";
            simpleContextButton14.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton14.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton14.Id = new System.Guid("ef446b4e-752a-4c31-8bf4-d810bb6e9d15");
            simpleContextButton14.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton14.Name = "Approved";
            simpleContextButton15.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton15.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton15.Id = new System.Guid("e82ded0a-e804-44ad-872c-5d9ec8dd7edd");
            simpleContextButton15.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton15.Name = "Reject";
            this.repositoryItemComboBox2.ContextButtons.Add(simpleContextButton13);
            this.repositoryItemComboBox2.ContextButtons.Add(simpleContextButton14);
            this.repositoryItemComboBox2.ContextButtons.Add(simpleContextButton15);
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            this.repositoryItemComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            simpleContextButton16.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton16.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton16.Id = new System.Guid("1a85506e-04a5-4c54-82b1-95c309d2d2c0");
            simpleContextButton16.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton16.Name = "Pending";
            simpleContextButton17.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton17.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton17.Id = new System.Guid("e3c978b9-43c4-4559-b2ae-e2fde3a38a31");
            simpleContextButton17.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton17.Name = "Approved";
            simpleContextButton18.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton18.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton18.Id = new System.Guid("91d3c9e8-3e9f-4b9c-b5d6-a06ff32a7a2e");
            simpleContextButton18.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton18.Name = "Reject";
            this.repositoryItemImageComboBox2.ContextButtons.Add(simpleContextButton16);
            this.repositoryItemImageComboBox2.ContextButtons.Add(simpleContextButton17);
            this.repositoryItemImageComboBox2.ContextButtons.Add(simpleContextButton18);
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // grdGroupedStockReports
            // 
            this.grdGroupedStockReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGroupedStockReports.Location = new System.Drawing.Point(0, 0);
            this.grdGroupedStockReports.MainView = this.grvGroupedStockReports;
            this.grdGroupedStockReports.Name = "grdGroupedStockReports";
            this.grdGroupedStockReports.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemImageComboBox1});
            this.grdGroupedStockReports.Size = new System.Drawing.Size(800, 450);
            this.grdGroupedStockReports.TabIndex = 6;
            this.grdGroupedStockReports.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGroupedStockReports});
            this.grdGroupedStockReports.DoubleClick += new System.EventHandler(this.grdGroupedStockReports_DoubleClick);
            // 
            // grvGroupedStockReports
            // 
            this.grvGroupedStockReports.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grvGroupedStockReports.Appearance.FooterPanel.Options.UseFont = true;
            this.grvGroupedStockReports.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grvGroupedStockReports.Appearance.GroupFooter.Options.UseFont = true;
            this.grvGroupedStockReports.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.grvGroupedStockReports.Appearance.Row.Options.UseFont = true;
            this.grvGroupedStockReports.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdColId,
            this.gridColumn110,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.grvGroupedStockReports.GridControl = this.grdGroupedStockReports;
            this.grvGroupedStockReports.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InwardNetWeight", this.gridColumn6, "SUM={0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "InwardRate", this.gridColumn7, "AVG={0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InwardAmount", this.gridColumn8, "SUM={0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutwardNetWeight", this.gridColumn9, "SUM={0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "OutwardRate", this.gridColumn10, "AVG={0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutwardAmount", this.gridColumn11, "SUM={0:0.##}")});
            this.grvGroupedStockReports.Name = "grvGroupedStockReports";
            this.grvGroupedStockReports.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.grvGroupedStockReports.OptionsBehavior.Editable = false;
            this.grvGroupedStockReports.OptionsView.ShowFooter = true;
            // 
            // grdColId
            // 
            this.grdColId.Caption = "Id";
            this.grdColId.FieldName = "Id";
            this.grdColId.Name = "grdColId";
            this.grdColId.Width = 46;
            // 
            // gridColumn110
            // 
            this.gridColumn110.Caption = "Kapan";
            this.gridColumn110.FieldName = "Name";
            this.gridColumn110.Name = "gridColumn110";
            this.gridColumn110.Visible = true;
            this.gridColumn110.VisibleIndex = 0;
            this.gridColumn110.Width = 361;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Kapan Id";
            this.gridColumn3.FieldName = "KapanId";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Width = 41;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Kapan Name";
            this.gridColumn4.FieldName = "Name";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Kapan", "Rec = {0}")});
            this.gridColumn4.Width = 111;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Party";
            this.gridColumn5.FieldName = "Party";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Total Weight";
            this.gridColumn6.FieldName = "TotalWeight";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "{0:0.##}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 220;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Rate";
            this.gridColumn7.FieldName = "Rate";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "Rate", "{0:0.##}")});
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 168;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Total Amount";
            this.gridColumn8.FieldName = "TotalAmount";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmount", "{0:0.##}")});
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 233;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Outward Weight";
            this.gridColumn9.FieldName = "OutwardNetWeight";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutwardNetWeight", "{0:0.##}")});
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Outward Rate";
            this.gridColumn10.FieldName = "OutwardRate";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "OutwardRate", "{0:0.##}")});
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Outward Amount";
            this.gridColumn11.FieldName = "OutwardAmount";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutwardAmount", "{0:0.##}")});
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            simpleContextButton19.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton19.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton19.Id = new System.Guid("54721bc4-12c7-44e4-b1f0-3eed0f0a527f");
            simpleContextButton19.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton19.Name = "Pending";
            simpleContextButton20.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton20.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton20.Id = new System.Guid("ef446b4e-752a-4c31-8bf4-d810bb6e9d15");
            simpleContextButton20.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton20.Name = "Approved";
            simpleContextButton21.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton21.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton21.Id = new System.Guid("e82ded0a-e804-44ad-872c-5d9ec8dd7edd");
            simpleContextButton21.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton21.Name = "Reject";
            this.repositoryItemComboBox1.ContextButtons.Add(simpleContextButton19);
            this.repositoryItemComboBox1.ContextButtons.Add(simpleContextButton20);
            this.repositoryItemComboBox1.ContextButtons.Add(simpleContextButton21);
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            simpleContextButton22.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton22.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton22.Id = new System.Guid("1a85506e-04a5-4c54-82b1-95c309d2d2c0");
            simpleContextButton22.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton22.Name = "Pending";
            simpleContextButton23.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton23.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton23.Id = new System.Guid("e3c978b9-43c4-4559-b2ae-e2fde3a38a31");
            simpleContextButton23.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton23.Name = "Approved";
            simpleContextButton24.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton24.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton24.Id = new System.Guid("91d3c9e8-3e9f-4b9c-b5d6-a06ff32a7a2e");
            simpleContextButton24.ImageOptionsCollection.ItemNormal.UseDefaultImage = true;
            simpleContextButton24.Name = "Reject";
            this.repositoryItemImageComboBox1.ContextButtons.Add(simpleContextButton22);
            this.repositoryItemImageComboBox1.ContextButtons.Add(simpleContextButton23);
            this.repositoryItemImageComboBox1.ContextButtons.Add(simpleContextButton24);
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // FrmChildNumberReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grdGroupedStockReports);
            this.Controls.Add(this.grdNumberReportMaster);
            this.Name = "FrmChildNumberReport";
            this.Text = "FrmChildNumberReport";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmChildNumberReport_FormClosed);
            this.Load += new System.EventHandler(this.FrmChildNumberReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdNumberReportMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNumberReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupedStockReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGroupedStockReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colNumberDate;
        private DevExpress.XtraGrid.GridControl grdGroupedStockReports;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGroupedStockReports;
        private DevExpress.XtraGrid.Columns.GridColumn grdColId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn110;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
    }
}
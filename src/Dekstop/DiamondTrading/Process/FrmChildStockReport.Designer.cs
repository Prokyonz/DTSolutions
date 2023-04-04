
namespace DiamondTrading.Process
{
    partial class FrmChildStockReport
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
            this.grdStockReportMaster = new DevExpress.XtraGrid.GridControl();
            this.gvStockReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn142 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn149 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.grdStockReportMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStockReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // grdStockReportMaster
            // 
            this.grdStockReportMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStockReportMaster.Location = new System.Drawing.Point(0, 0);
            this.grdStockReportMaster.MainView = this.gvStockReport;
            this.grdStockReportMaster.Name = "grdStockReportMaster";
            this.grdStockReportMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox2,
            this.repositoryItemImageComboBox2});
            this.grdStockReportMaster.Size = new System.Drawing.Size(800, 450);
            this.grdStockReportMaster.TabIndex = 4;
            this.grdStockReportMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStockReport});
            // 
            // gvStockReport
            // 
            this.gvStockReport.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.gvStockReport.Appearance.FooterPanel.Options.UseFont = true;
            this.gvStockReport.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.gvStockReport.Appearance.GroupFooter.Options.UseFont = true;
            this.gvStockReport.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.gvStockReport.Appearance.Row.Options.UseFont = true;
            this.gvStockReport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn142,
            this.gridColumn149,
            this.gridColumn1,
            this.gridColumn2,
            this.InwardNetWeightCol,
            this.InwardRateCol,
            this.InwardAmountCol,
            this.OutwardNetWeightCol,
            this.OutwardRateCol,
            this.OutwardAmountCol,
            this.gcolClosingNetWeight,
            this.gcolClosingRate,
            this.gcolClosingAmount});
            this.gvStockReport.GridControl = this.grdStockReportMaster;
            this.gvStockReport.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InwardNetWeight", this.InwardNetWeightCol, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "InwardRate", this.InwardRateCol, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InwardAmount", this.InwardAmountCol, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutwardNetWeight", this.OutwardNetWeightCol, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "OutwardRate", this.OutwardRateCol, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutwardAmount", this.OutwardAmountCol, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ClosingNetWeight", this.gcolClosingNetWeight, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "ClosingRate", this.gcolClosingRate, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ClosingAmount", this.gcolClosingAmount, "{0:0.##}")});
            this.gvStockReport.Name = "gvStockReport";
            this.gvStockReport.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gvStockReport.OptionsBehavior.Editable = false;
            this.gvStockReport.OptionsView.ShowFooter = true;
            // 
            // gridColumn142
            // 
            this.gridColumn142.Caption = "Kapan Id";
            this.gridColumn142.FieldName = "KapanId";
            this.gridColumn142.Name = "gridColumn142";
            this.gridColumn142.Width = 41;
            // 
            // gridColumn149
            // 
            this.gridColumn149.Caption = "Kapan Name";
            this.gridColumn149.FieldName = "Name";
            this.gridColumn149.Name = "gridColumn149";
            this.gridColumn149.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Kapan", "Total = {0}")});
            this.gridColumn149.Visible = true;
            this.gridColumn149.VisibleIndex = 0;
            this.gridColumn149.Width = 100;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Operation Type";
            this.gridColumn1.FieldName = "Party";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 97;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Branch";
            this.gridColumn2.FieldName = "BranchName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 65;
            // 
            // InwardNetWeightCol
            // 
            this.InwardNetWeightCol.Caption = "Inward Weight";
            this.InwardNetWeightCol.FieldName = "InwardNetWeight";
            this.InwardNetWeightCol.Name = "InwardNetWeightCol";
            this.InwardNetWeightCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InwardNetWeight", "{0:0.##}")});
            this.InwardNetWeightCol.Visible = true;
            this.InwardNetWeightCol.VisibleIndex = 3;
            this.InwardNetWeightCol.Width = 83;
            // 
            // InwardRateCol
            // 
            this.InwardRateCol.Caption = "Inward Rate";
            this.InwardRateCol.FieldName = "InwardRate";
            this.InwardRateCol.Name = "InwardRateCol";
            this.InwardRateCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "InwardRate", "{0:0.##}")});
            this.InwardRateCol.Visible = true;
            this.InwardRateCol.VisibleIndex = 4;
            this.InwardRateCol.Width = 69;
            // 
            // InwardAmountCol
            // 
            this.InwardAmountCol.Caption = "Inward Amount";
            this.InwardAmountCol.FieldName = "InwardAmount";
            this.InwardAmountCol.Name = "InwardAmountCol";
            this.InwardAmountCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InwardAmount", "{0:0.##}")});
            this.InwardAmountCol.Visible = true;
            this.InwardAmountCol.VisibleIndex = 5;
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
            this.OutwardNetWeightCol.VisibleIndex = 6;
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
            this.OutwardRateCol.VisibleIndex = 7;
            this.OutwardRateCol.Width = 74;
            // 
            // OutwardAmountCol
            // 
            this.OutwardAmountCol.Caption = "Outward Amount";
            this.OutwardAmountCol.FieldName = "OutwardAmount";
            this.OutwardAmountCol.Name = "OutwardAmountCol";
            this.OutwardAmountCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutwardAmount", "{0:0.##}")});
            this.OutwardAmountCol.Visible = true;
            this.OutwardAmountCol.VisibleIndex = 8;
            this.OutwardAmountCol.Width = 89;
            // 
            // gcolClosingNetWeight
            // 
            this.gcolClosingNetWeight.Caption = "Closing Net Weight";
            this.gcolClosingNetWeight.FieldName = "ClosingNetWeight";
            this.gcolClosingNetWeight.Name = "gcolClosingNetWeight";
            this.gcolClosingNetWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ClosingNetWeight", "{0:0.##}")});
            this.gcolClosingNetWeight.Visible = true;
            this.gcolClosingNetWeight.VisibleIndex = 9;
            this.gcolClosingNetWeight.Width = 111;
            // 
            // gcolClosingRate
            // 
            this.gcolClosingRate.Caption = "Closing Rate";
            this.gcolClosingRate.FieldName = "ClosingRate";
            this.gcolClosingRate.Name = "gcolClosingRate";
            this.gcolClosingRate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "ClosingRate", "{0:0.##}")});
            this.gcolClosingRate.Visible = true;
            this.gcolClosingRate.VisibleIndex = 10;
            this.gcolClosingRate.Width = 73;
            // 
            // gcolClosingAmount
            // 
            this.gcolClosingAmount.Caption = "Closing Amount";
            this.gcolClosingAmount.FieldName = "ClosingAmount";
            this.gcolClosingAmount.Name = "gcolClosingAmount";
            this.gcolClosingAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ClosingAmount", "{0:0.##}")});
            this.gcolClosingAmount.Visible = true;
            this.gcolClosingAmount.VisibleIndex = 11;
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
            // FrmChildStockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grdStockReportMaster);
            this.Name = "FrmChildStockReport";
            this.Text = "FrmChildStockReport";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmChildStockReport_FormClosed);
            this.Load += new System.EventHandler(this.FrmChildStockReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdStockReportMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStockReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdStockReportMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStockReport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn142;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn149;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn InwardNetWeightCol;
        private DevExpress.XtraGrid.Columns.GridColumn InwardRateCol;
        private DevExpress.XtraGrid.Columns.GridColumn InwardAmountCol;
        private DevExpress.XtraGrid.Columns.GridColumn OutwardNetWeightCol;
        private DevExpress.XtraGrid.Columns.GridColumn OutwardRateCol;
        private DevExpress.XtraGrid.Columns.GridColumn OutwardAmountCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gcolClosingNetWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gcolClosingRate;
        private DevExpress.XtraGrid.Columns.GridColumn gcolClosingAmount;
    }
}
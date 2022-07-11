
namespace DiamondTrading.Reports
{
    partial class FrmWeeklyPurchaseDetailReport
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
            this.grdWeeklyPurchaseDetails = new DevExpress.XtraGrid.GridControl();
            this.grvWeeklyPurchaseDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnPurId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurBillNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurSlipNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurPartyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurKapanId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurKapanName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurPartyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurMobileNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurBuyerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurBuyerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurBuyerMobileNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurBrokerageId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurcBrokerageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurBrokerMobileNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurBuyingRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurPaymentDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn109 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn110 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn113 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn114 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn116 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn122 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdjustAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.grdChildTransMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView14 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdWeeklyPurchaseDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWeeklyPurchaseDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChildTransMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView14)).BeginInit();
            this.SuspendLayout();
            // 
            // grdWeeklyPurchaseDetails
            // 
            this.grdWeeklyPurchaseDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWeeklyPurchaseDetails.Location = new System.Drawing.Point(0, 0);
            this.grdWeeklyPurchaseDetails.MainView = this.grvWeeklyPurchaseDetails;
            this.grdWeeklyPurchaseDetails.Name = "grdWeeklyPurchaseDetails";
            this.grdWeeklyPurchaseDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemImageComboBox1,
            this.repositoryItemTextEdit1});
            this.grdWeeklyPurchaseDetails.Size = new System.Drawing.Size(1112, 521);
            this.grdWeeklyPurchaseDetails.TabIndex = 3;
            this.grdWeeklyPurchaseDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvWeeklyPurchaseDetails,
            this.grdChildTransMaster,
            this.gridView14});
            // 
            // grvWeeklyPurchaseDetails
            // 
            this.grvWeeklyPurchaseDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnPurId,
            this.gridColumnPurBillNo,
            this.gridColumnPurSlipNo,
            this.gridColumnPurPartyId,
            this.gridColumnPurDate,
            this.gridColumnPurKapanId,
            this.gridColumnPurKapanName,
            this.gridColumnPurPartyName,
            this.gridColumnPurMobileNo,
            this.gridColumnPurBuyerId,
            this.gridColumnPurBuyerName,
            this.gridColumnPurBuyerMobileNo,
            this.gridColumnPurBrokerageId,
            this.gridColumnPurcBrokerageName,
            this.gridColumnPurBrokerMobileNo,
            this.gridColumnPurWeight,
            this.gridColumnPurBuyingRate,
            this.gridColumnPurTotal,
            this.gridColumnPurPaymentDays,
            this.gridColumnPurUpdatedDate,
            this.gridColumn109,
            this.gridColumn110,
            this.gridColumn113,
            this.gridColumn114,
            this.gridColumn116,
            this.gridColumn122,
            this.colAdjustAmount});
            this.grvWeeklyPurchaseDetails.GridControl = this.grdWeeklyPurchaseDetails;
            this.grvWeeklyPurchaseDetails.Name = "grvWeeklyPurchaseDetails";
            this.grvWeeklyPurchaseDetails.OptionsView.ShowFooter = true;
            this.grvWeeklyPurchaseDetails.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnPurSlipNo, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gridColumnPurId
            // 
            this.gridColumnPurId.Caption = "Id";
            this.gridColumnPurId.FieldName = "Id";
            this.gridColumnPurId.Name = "gridColumnPurId";
            // 
            // gridColumnPurBillNo
            // 
            this.gridColumnPurBillNo.Caption = "Bll No";
            this.gridColumnPurBillNo.FieldName = "PurchaseBillNo";
            this.gridColumnPurBillNo.Name = "gridColumnPurBillNo";
            this.gridColumnPurBillNo.Width = 41;
            // 
            // gridColumnPurSlipNo
            // 
            this.gridColumnPurSlipNo.Caption = "Slip No";
            this.gridColumnPurSlipNo.FieldName = "SlipNo";
            this.gridColumnPurSlipNo.Name = "gridColumnPurSlipNo";
            this.gridColumnPurSlipNo.OptionsColumn.AllowEdit = false;
            this.gridColumnPurSlipNo.OptionsColumn.ReadOnly = true;
            this.gridColumnPurSlipNo.OptionsColumn.TabStop = false;
            this.gridColumnPurSlipNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "SlipNo", "Total={0}")});
            this.gridColumnPurSlipNo.Visible = true;
            this.gridColumnPurSlipNo.VisibleIndex = 1;
            this.gridColumnPurSlipNo.Width = 66;
            // 
            // gridColumnPurPartyId
            // 
            this.gridColumnPurPartyId.Caption = "Party";
            this.gridColumnPurPartyId.FieldName = "PartyId";
            this.gridColumnPurPartyId.Name = "gridColumnPurPartyId";
            this.gridColumnPurPartyId.Width = 46;
            // 
            // gridColumnPurDate
            // 
            this.gridColumnPurDate.Caption = "Date";
            this.gridColumnPurDate.FieldName = "Date";
            this.gridColumnPurDate.Name = "gridColumnPurDate";
            this.gridColumnPurDate.OptionsColumn.AllowEdit = false;
            this.gridColumnPurDate.OptionsColumn.ReadOnly = true;
            this.gridColumnPurDate.OptionsColumn.TabStop = false;
            this.gridColumnPurDate.Visible = true;
            this.gridColumnPurDate.VisibleIndex = 0;
            this.gridColumnPurDate.Width = 88;
            // 
            // gridColumnPurKapanId
            // 
            this.gridColumnPurKapanId.Caption = "KapanId";
            this.gridColumnPurKapanId.FieldName = "KapanId";
            this.gridColumnPurKapanId.Name = "gridColumnPurKapanId";
            // 
            // gridColumnPurKapanName
            // 
            this.gridColumnPurKapanName.Caption = "Kapan Name";
            this.gridColumnPurKapanName.FieldName = "KapanName";
            this.gridColumnPurKapanName.Name = "gridColumnPurKapanName";
            this.gridColumnPurKapanName.OptionsColumn.AllowEdit = false;
            this.gridColumnPurKapanName.OptionsColumn.ReadOnly = true;
            this.gridColumnPurKapanName.OptionsColumn.TabStop = false;
            this.gridColumnPurKapanName.Visible = true;
            this.gridColumnPurKapanName.VisibleIndex = 4;
            this.gridColumnPurKapanName.Width = 77;
            // 
            // gridColumnPurPartyName
            // 
            this.gridColumnPurPartyName.Caption = "Party Name";
            this.gridColumnPurPartyName.FieldName = "PartyName";
            this.gridColumnPurPartyName.Name = "gridColumnPurPartyName";
            this.gridColumnPurPartyName.OptionsColumn.AllowEdit = false;
            this.gridColumnPurPartyName.OptionsColumn.ReadOnly = true;
            this.gridColumnPurPartyName.OptionsColumn.TabStop = false;
            this.gridColumnPurPartyName.Visible = true;
            this.gridColumnPurPartyName.VisibleIndex = 2;
            this.gridColumnPurPartyName.Width = 103;
            // 
            // gridColumnPurMobileNo
            // 
            this.gridColumnPurMobileNo.Caption = "Mob No";
            this.gridColumnPurMobileNo.FieldName = "MobileNo";
            this.gridColumnPurMobileNo.Name = "gridColumnPurMobileNo";
            this.gridColumnPurMobileNo.Width = 57;
            // 
            // gridColumnPurBuyerId
            // 
            this.gridColumnPurBuyerId.Caption = "Buyer Id";
            this.gridColumnPurBuyerId.FieldName = "ByuerId";
            this.gridColumnPurBuyerId.Name = "gridColumnPurBuyerId";
            // 
            // gridColumnPurBuyerName
            // 
            this.gridColumnPurBuyerName.Caption = "Buy Name";
            this.gridColumnPurBuyerName.FieldName = "BuyerName";
            this.gridColumnPurBuyerName.Name = "gridColumnPurBuyerName";
            this.gridColumnPurBuyerName.Width = 50;
            // 
            // gridColumnPurBuyerMobileNo
            // 
            this.gridColumnPurBuyerMobileNo.Caption = "Mob No";
            this.gridColumnPurBuyerMobileNo.FieldName = "BuyerMobileNo";
            this.gridColumnPurBuyerMobileNo.Name = "gridColumnPurBuyerMobileNo";
            this.gridColumnPurBuyerMobileNo.Width = 57;
            // 
            // gridColumnPurBrokerageId
            // 
            this.gridColumnPurBrokerageId.Caption = "Broker";
            this.gridColumnPurBrokerageId.FieldName = "BrokerageId";
            this.gridColumnPurBrokerageId.Name = "gridColumnPurBrokerageId";
            this.gridColumnPurBrokerageId.Width = 62;
            // 
            // gridColumnPurcBrokerageName
            // 
            this.gridColumnPurcBrokerageName.Caption = "Brok. Name";
            this.gridColumnPurcBrokerageName.FieldName = "BrokerName";
            this.gridColumnPurcBrokerageName.Name = "gridColumnPurcBrokerageName";
            this.gridColumnPurcBrokerageName.OptionsColumn.AllowEdit = false;
            this.gridColumnPurcBrokerageName.OptionsColumn.ReadOnly = true;
            this.gridColumnPurcBrokerageName.Visible = true;
            this.gridColumnPurcBrokerageName.VisibleIndex = 3;
            this.gridColumnPurcBrokerageName.Width = 104;
            // 
            // gridColumnPurBrokerMobileNo
            // 
            this.gridColumnPurBrokerMobileNo.Caption = "Mob No";
            this.gridColumnPurBrokerMobileNo.FieldName = "BrokerMobileNo";
            this.gridColumnPurBrokerMobileNo.Name = "gridColumnPurBrokerMobileNo";
            this.gridColumnPurBrokerMobileNo.Width = 57;
            // 
            // gridColumnPurWeight
            // 
            this.gridColumnPurWeight.Caption = "Cts";
            this.gridColumnPurWeight.FieldName = "Weight";
            this.gridColumnPurWeight.Name = "gridColumnPurWeight";
            this.gridColumnPurWeight.UnboundDataType = typeof(decimal);
            this.gridColumnPurWeight.Width = 46;
            // 
            // gridColumnPurBuyingRate
            // 
            this.gridColumnPurBuyingRate.Caption = "Buy Rate";
            this.gridColumnPurBuyingRate.FieldName = "BuyingRate";
            this.gridColumnPurBuyingRate.Name = "gridColumnPurBuyingRate";
            this.gridColumnPurBuyingRate.OptionsColumn.AllowEdit = false;
            this.gridColumnPurBuyingRate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnPurBuyingRate.OptionsColumn.ReadOnly = true;
            this.gridColumnPurBuyingRate.OptionsColumn.TabStop = false;
            this.gridColumnPurBuyingRate.Visible = true;
            this.gridColumnPurBuyingRate.VisibleIndex = 6;
            this.gridColumnPurBuyingRate.Width = 60;
            // 
            // gridColumnPurTotal
            // 
            this.gridColumnPurTotal.Caption = "Total";
            this.gridColumnPurTotal.FieldName = "GrossTotal";
            this.gridColumnPurTotal.Name = "gridColumnPurTotal";
            this.gridColumnPurTotal.OptionsColumn.AllowEdit = false;
            this.gridColumnPurTotal.OptionsColumn.ReadOnly = true;
            this.gridColumnPurTotal.OptionsColumn.TabStop = false;
            this.gridColumnPurTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GrossTotal", "{0:0.##}")});
            this.gridColumnPurTotal.Visible = true;
            this.gridColumnPurTotal.VisibleIndex = 12;
            this.gridColumnPurTotal.Width = 51;
            // 
            // gridColumnPurPaymentDays
            // 
            this.gridColumnPurPaymentDays.Caption = "Pay Days";
            this.gridColumnPurPaymentDays.FieldName = "PaymentDays";
            this.gridColumnPurPaymentDays.Name = "gridColumnPurPaymentDays";
            this.gridColumnPurPaymentDays.OptionsColumn.AllowEdit = false;
            this.gridColumnPurPaymentDays.OptionsColumn.ReadOnly = true;
            this.gridColumnPurPaymentDays.OptionsColumn.TabStop = false;
            this.gridColumnPurPaymentDays.Visible = true;
            this.gridColumnPurPaymentDays.VisibleIndex = 10;
            this.gridColumnPurPaymentDays.Width = 62;
            // 
            // gridColumnPurUpdatedDate
            // 
            this.gridColumnPurUpdatedDate.Caption = "Due Date";
            this.gridColumnPurUpdatedDate.FieldName = "PaymentDueDate";
            this.gridColumnPurUpdatedDate.Name = "gridColumnPurUpdatedDate";
            this.gridColumnPurUpdatedDate.OptionsColumn.AllowEdit = false;
            this.gridColumnPurUpdatedDate.OptionsColumn.ReadOnly = true;
            this.gridColumnPurUpdatedDate.OptionsColumn.TabStop = false;
            this.gridColumnPurUpdatedDate.Visible = true;
            this.gridColumnPurUpdatedDate.VisibleIndex = 11;
            this.gridColumnPurUpdatedDate.Width = 60;
            // 
            // gridColumn109
            // 
            this.gridColumn109.Caption = "Net Cts";
            this.gridColumn109.FieldName = "NetWeight";
            this.gridColumn109.Name = "gridColumn109";
            this.gridColumn109.OptionsColumn.AllowEdit = false;
            this.gridColumn109.OptionsColumn.ReadOnly = true;
            this.gridColumn109.OptionsColumn.TabStop = false;
            this.gridColumn109.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetWeight", "{0:0.##}")});
            this.gridColumn109.Visible = true;
            this.gridColumn109.VisibleIndex = 5;
            this.gridColumn109.Width = 49;
            // 
            // gridColumn110
            // 
            this.gridColumn110.Caption = "RoundUp";
            this.gridColumn110.FieldName = "RoundUpAmount";
            this.gridColumn110.Name = "gridColumn110";
            this.gridColumn110.Width = 57;
            // 
            // gridColumn113
            // 
            this.gridColumn113.Caption = "CVD Amt";
            this.gridColumn113.FieldName = "CVDAmount";
            this.gridColumn113.Name = "gridColumn113";
            this.gridColumn113.OptionsColumn.AllowEdit = false;
            this.gridColumn113.OptionsColumn.ReadOnly = true;
            this.gridColumn113.OptionsColumn.TabStop = false;
            this.gridColumn113.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CVDAmount", "{0:0.##}")});
            this.gridColumn113.Visible = true;
            this.gridColumn113.VisibleIndex = 8;
            this.gridColumn113.Width = 66;
            // 
            // gridColumn114
            // 
            this.gridColumn114.Caption = "Less";
            this.gridColumn114.FieldName = "LessWeight";
            this.gridColumn114.Name = "gridColumn114";
            this.gridColumn114.OptionsColumn.AllowEdit = false;
            this.gridColumn114.OptionsColumn.ReadOnly = true;
            this.gridColumn114.OptionsColumn.TabStop = false;
            this.gridColumn114.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LessWeight", "{0:0.##}")});
            this.gridColumn114.Visible = true;
            this.gridColumn114.VisibleIndex = 7;
            this.gridColumn114.Width = 36;
            // 
            // gridColumn116
            // 
            this.gridColumn116.Caption = "Due Days";
            this.gridColumn116.FieldName = "DueDays";
            this.gridColumn116.Name = "gridColumn116";
            this.gridColumn116.OptionsColumn.AllowEdit = false;
            this.gridColumn116.OptionsColumn.ReadOnly = true;
            this.gridColumn116.OptionsColumn.TabStop = false;
            this.gridColumn116.Visible = true;
            this.gridColumn116.VisibleIndex = 9;
            this.gridColumn116.Width = 56;
            // 
            // gridColumn122
            // 
            this.gridColumn122.Caption = "PurId";
            this.gridColumn122.FieldName = "PurId";
            this.gridColumn122.Name = "gridColumn122";
            // 
            // colAdjustAmount
            // 
            this.colAdjustAmount.Caption = "Adjust Amount";
            this.colAdjustAmount.ColumnEdit = this.repositoryItemTextEdit1;
            this.colAdjustAmount.FieldName = "AdjustAmount";
            this.colAdjustAmount.Name = "colAdjustAmount";
            this.colAdjustAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AdjustAmount", "{0:0.##}")});
            this.colAdjustAmount.Visible = true;
            this.colAdjustAmount.VisibleIndex = 13;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
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
            this.repositoryItemComboBox1.ContextButtons.Add(simpleContextButton1);
            this.repositoryItemComboBox1.ContextButtons.Add(simpleContextButton2);
            this.repositoryItemComboBox1.ContextButtons.Add(simpleContextButton3);
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
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
            this.repositoryItemImageComboBox1.ContextButtons.Add(simpleContextButton4);
            this.repositoryItemImageComboBox1.ContextButtons.Add(simpleContextButton5);
            this.repositoryItemImageComboBox1.ContextButtons.Add(simpleContextButton6);
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // grdChildTransMaster
            // 
            this.grdChildTransMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8});
            this.grdChildTransMaster.GridControl = this.grdWeeklyPurchaseDetails;
            this.grdChildTransMaster.Name = "grdChildTransMaster";
            this.grdChildTransMaster.OptionsBehavior.Editable = false;
            this.grdChildTransMaster.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Id";
            this.gridColumn8.FieldName = "Id";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridView14
            // 
            this.gridView14.GridControl = this.grdWeeklyPurchaseDetails;
            this.gridView14.Name = "gridView14";
            // 
            // FrmWeeklyPurchaseDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 521);
            this.Controls.Add(this.grdWeeklyPurchaseDetails);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWeeklyPurchaseDetailReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weekly Purchase Detail Report";
            this.Load += new System.EventHandler(this.FrmWeeklyPurchaseDetailReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmWeeklyPurchaseDetailReport_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdWeeklyPurchaseDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWeeklyPurchaseDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChildTransMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView14)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdWeeklyPurchaseDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView grvWeeklyPurchaseDetails;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurBillNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurSlipNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurPartyId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurKapanId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurKapanName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurPartyName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurMobileNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurBuyerId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurBuyerName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurBuyerMobileNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurBrokerageId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurcBrokerageName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurBrokerMobileNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurBuyingRate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurTotal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurPaymentDays;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn109;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn110;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn113;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn114;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn116;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn122;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Views.Grid.GridView grdChildTransMaster;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView14;
        private DevExpress.XtraGrid.Columns.GridColumn colAdjustAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}
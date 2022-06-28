
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
            this.grdTransactionMaster = new DevExpress.XtraGrid.GridControl();
            this.grvTransMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.gridColumnPurRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPurApprovalType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn109 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn110 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn113 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn114 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn116 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn122 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.grdChildTransMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView14 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactionMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChildTransMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView14)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTransactionMaster
            // 
            this.grdTransactionMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTransactionMaster.Location = new System.Drawing.Point(0, 0);
            this.grdTransactionMaster.MainView = this.grvTransMaster;
            this.grdTransactionMaster.Name = "grdTransactionMaster";
            this.grdTransactionMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemImageComboBox1});
            this.grdTransactionMaster.Size = new System.Drawing.Size(1112, 521);
            this.grdTransactionMaster.TabIndex = 3;
            this.grdTransactionMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTransMaster,
            this.grdChildTransMaster,
            this.gridView14});
            // 
            // grvTransMaster
            // 
            this.grvTransMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridColumnPurRemarks,
            this.gridColumnPurUpdatedDate,
            this.gridColumnPurMessage,
            this.gridColumnPurApprovalType,
            this.gridColumn109,
            this.gridColumn110,
            this.gridColumn113,
            this.gridColumn114,
            this.gridColumn116,
            this.gridColumn122});
            this.grvTransMaster.GridControl = this.grdTransactionMaster;
            this.grvTransMaster.Name = "grvTransMaster";
            this.grvTransMaster.OptionsBehavior.Editable = false;
            this.grvTransMaster.OptionsBehavior.ReadOnly = true;
            this.grvTransMaster.OptionsView.AllowCellMerge = true;
            this.grvTransMaster.OptionsView.ShowFooter = true;
            this.grvTransMaster.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
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
            this.gridColumnPurKapanName.Visible = true;
            this.gridColumnPurKapanName.VisibleIndex = 4;
            this.gridColumnPurKapanName.Width = 77;
            // 
            // gridColumnPurPartyName
            // 
            this.gridColumnPurPartyName.Caption = "Party Name";
            this.gridColumnPurPartyName.FieldName = "PartyName";
            this.gridColumnPurPartyName.Name = "gridColumnPurPartyName";
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
            this.gridColumnPurBuyingRate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnPurBuyingRate.Visible = true;
            this.gridColumnPurBuyingRate.VisibleIndex = 6;
            this.gridColumnPurBuyingRate.Width = 60;
            // 
            // gridColumnPurTotal
            // 
            this.gridColumnPurTotal.Caption = "Total";
            this.gridColumnPurTotal.FieldName = "GrossTotal";
            this.gridColumnPurTotal.Name = "gridColumnPurTotal";
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
            this.gridColumnPurPaymentDays.Visible = true;
            this.gridColumnPurPaymentDays.VisibleIndex = 10;
            this.gridColumnPurPaymentDays.Width = 62;
            // 
            // gridColumnPurRemarks
            // 
            this.gridColumnPurRemarks.Caption = "Remarks";
            this.gridColumnPurRemarks.FieldName = "Remarks";
            this.gridColumnPurRemarks.Name = "gridColumnPurRemarks";
            this.gridColumnPurRemarks.Visible = true;
            this.gridColumnPurRemarks.VisibleIndex = 13;
            this.gridColumnPurRemarks.Width = 64;
            // 
            // gridColumnPurUpdatedDate
            // 
            this.gridColumnPurUpdatedDate.Caption = "Due Date";
            this.gridColumnPurUpdatedDate.FieldName = "PaymentDueDate";
            this.gridColumnPurUpdatedDate.Name = "gridColumnPurUpdatedDate";
            this.gridColumnPurUpdatedDate.Visible = true;
            this.gridColumnPurUpdatedDate.VisibleIndex = 11;
            this.gridColumnPurUpdatedDate.Width = 60;
            // 
            // gridColumnPurMessage
            // 
            this.gridColumnPurMessage.Caption = "Message";
            this.gridColumnPurMessage.FieldName = "Message";
            this.gridColumnPurMessage.Name = "gridColumnPurMessage";
            this.gridColumnPurMessage.Visible = true;
            this.gridColumnPurMessage.VisibleIndex = 14;
            this.gridColumnPurMessage.Width = 63;
            // 
            // gridColumnPurApprovalType
            // 
            this.gridColumnPurApprovalType.Caption = "Approval Type";
            this.gridColumnPurApprovalType.FieldName = "ApprovalType";
            this.gridColumnPurApprovalType.Name = "gridColumnPurApprovalType";
            this.gridColumnPurApprovalType.Width = 56;
            // 
            // gridColumn109
            // 
            this.gridColumn109.Caption = "Net Cts";
            this.gridColumn109.FieldName = "NetWeight";
            this.gridColumn109.Name = "gridColumn109";
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
            this.gridColumn113.Visible = true;
            this.gridColumn113.VisibleIndex = 8;
            this.gridColumn113.Width = 66;
            // 
            // gridColumn114
            // 
            this.gridColumn114.Caption = "Less";
            this.gridColumn114.FieldName = "LessWeight";
            this.gridColumn114.Name = "gridColumn114";
            this.gridColumn114.Visible = true;
            this.gridColumn114.VisibleIndex = 7;
            this.gridColumn114.Width = 36;
            // 
            // gridColumn116
            // 
            this.gridColumn116.Caption = "Due Days";
            this.gridColumn116.FieldName = "DueDays";
            this.gridColumn116.Name = "gridColumn116";
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
            this.grdChildTransMaster.GridControl = this.grdTransactionMaster;
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
            this.gridView14.GridControl = this.grdTransactionMaster;
            this.gridView14.Name = "gridView14";
            // 
            // FrmWeeklyPurchaseDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 521);
            this.Controls.Add(this.grdTransactionMaster);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWeeklyPurchaseDetailReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weekly Purchase Detail Report";
            this.Load += new System.EventHandler(this.FrmWeeklyPurchaseDetailReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactionMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChildTransMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView14)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdTransactionMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTransMaster;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurRemarks;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurMessage;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPurApprovalType;
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
    }
}
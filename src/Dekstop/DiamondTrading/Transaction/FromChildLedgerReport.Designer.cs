
namespace DiamondTrading.Transaction
{
    partial class FromChildLedgerReport
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControlChildLedgerReport = new DevExpress.XtraGrid.GridControl();
            this.grvChildLedgerReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEntryType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFromPartyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFromPartyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnToPartyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnToPartyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDebit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlChildLedgerReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChildLedgerReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlChildLedgerReport
            // 
            this.gridControlChildLedgerReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlChildLedgerReport.Location = new System.Drawing.Point(0, 0);
            this.gridControlChildLedgerReport.MainView = this.grvChildLedgerReport;
            this.gridControlChildLedgerReport.Name = "gridControlChildLedgerReport";
            this.gridControlChildLedgerReport.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit2});
            this.gridControlChildLedgerReport.Size = new System.Drawing.Size(800, 451);
            this.gridControlChildLedgerReport.TabIndex = 7;
            this.gridControlChildLedgerReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChildLedgerReport});
            // 
            // grvChildLedgerReport
            // 
            this.grvChildLedgerReport.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grvChildLedgerReport.Appearance.FooterPanel.Options.UseFont = true;
            this.grvChildLedgerReport.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grvChildLedgerReport.Appearance.GroupFooter.Options.UseFont = true;
            this.grvChildLedgerReport.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grvChildLedgerReport.Appearance.Row.Options.UseFont = true;
            this.grvChildLedgerReport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnDate,
            this.gridColumnEntryType,
            this.gridColumnFromPartyId,
            this.gridColumnFromPartyName,
            this.gridColumnToPartyId,
            this.gridColumnToPartyName,
            this.gridColumnDebit,
            this.gridColumnCredit});
            this.grvChildLedgerReport.GridControl = this.gridControlChildLedgerReport;
            this.grvChildLedgerReport.Name = "grvChildLedgerReport";
            this.grvChildLedgerReport.OptionsView.ShowFooter = true;
            this.grvChildLedgerReport.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.grvChildLedgerReport_CustomSummaryCalculate);
            // 
            // gridColumnDate
            // 
            this.gridColumnDate.Caption = "Entry Date";
            this.gridColumnDate.FieldName = "Date";
            this.gridColumnDate.Name = "gridColumnDate";
            this.gridColumnDate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Date", "Total = {0}")});
            this.gridColumnDate.Visible = true;
            this.gridColumnDate.VisibleIndex = 0;
            this.gridColumnDate.Width = 107;
            // 
            // gridColumnEntryType
            // 
            this.gridColumnEntryType.Caption = "Entry Type";
            this.gridColumnEntryType.FieldName = "EntryType";
            this.gridColumnEntryType.Name = "gridColumnEntryType";
            this.gridColumnEntryType.Visible = true;
            this.gridColumnEntryType.VisibleIndex = 1;
            this.gridColumnEntryType.Width = 110;
            // 
            // gridColumnFromPartyId
            // 
            this.gridColumnFromPartyId.Caption = "From PartyId";
            this.gridColumnFromPartyId.FieldName = "FromPartyId";
            this.gridColumnFromPartyId.Name = "gridColumnFromPartyId";
            this.gridColumnFromPartyId.Width = 168;
            // 
            // gridColumnFromPartyName
            // 
            this.gridColumnFromPartyName.Caption = "From PartyName";
            this.gridColumnFromPartyName.FieldName = "FromPartyName";
            this.gridColumnFromPartyName.Name = "gridColumnFromPartyName";
            this.gridColumnFromPartyName.Visible = true;
            this.gridColumnFromPartyName.VisibleIndex = 2;
            this.gridColumnFromPartyName.Width = 242;
            // 
            // gridColumnToPartyId
            // 
            this.gridColumnToPartyId.Caption = "To PartyId";
            this.gridColumnToPartyId.FieldName = "ToPartyId";
            this.gridColumnToPartyId.Name = "gridColumnToPartyId";
            this.gridColumnToPartyId.Width = 143;
            // 
            // gridColumnToPartyName
            // 
            this.gridColumnToPartyName.Caption = "To PartyName";
            this.gridColumnToPartyName.FieldName = "ToPartyName";
            this.gridColumnToPartyName.Name = "gridColumnToPartyName";
            this.gridColumnToPartyName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ToPartyName", "Closing Balance = {0}")});
            this.gridColumnToPartyName.Visible = true;
            this.gridColumnToPartyName.VisibleIndex = 3;
            this.gridColumnToPartyName.Width = 379;
            // 
            // gridColumnDebit
            // 
            this.gridColumnDebit.Caption = "Debit";
            this.gridColumnDebit.FieldName = "Debit";
            this.gridColumnDebit.Name = "gridColumnDebit";
            this.gridColumnDebit.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debit", "{0:0.##}")});
            this.gridColumnDebit.Visible = true;
            this.gridColumnDebit.VisibleIndex = 4;
            this.gridColumnDebit.Width = 104;
            // 
            // gridColumnCredit
            // 
            this.gridColumnCredit.Caption = "Credit";
            this.gridColumnCredit.FieldName = "Credit";
            this.gridColumnCredit.Name = "gridColumnCredit";
            this.gridColumnCredit.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", "{0:0.##}")});
            this.gridColumnCredit.Visible = true;
            this.gridColumnCredit.VisibleIndex = 5;
            this.gridColumnCredit.Width = 119;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            editorButtonImageOptions2.Image = global::DiamondTrading.Properties.Resources.View_16;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // FromChildLedgerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControlChildLedgerReport);
            this.Name = "FromChildLedgerReport";
            this.Text = "FromChildLedgerReport";
            this.Load += new System.EventHandler(this.FromChildLedgerReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlChildLedgerReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChildLedgerReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlChildLedgerReport;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChildLedgerReport;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEntryType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFromPartyId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFromPartyName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnToPartyId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnToPartyName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDebit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCredit;
    }
}
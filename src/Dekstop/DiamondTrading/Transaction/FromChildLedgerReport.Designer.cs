
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions4 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
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
            this.gridColumnChildSlipNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnChildRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exportExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlChildLedgerReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChildLedgerReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlChildLedgerReport
            // 
            this.gridControlChildLedgerReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlChildLedgerReport.Location = new System.Drawing.Point(0, 24);
            this.gridControlChildLedgerReport.MainView = this.grvChildLedgerReport;
            this.gridControlChildLedgerReport.Name = "gridControlChildLedgerReport";
            this.gridControlChildLedgerReport.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit2});
            this.gridControlChildLedgerReport.Size = new System.Drawing.Size(973, 443);
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
            this.gridColumnCredit,
            this.gridColumnChildSlipNo,
            this.gridColumnChildRemarks});
            this.grvChildLedgerReport.GridControl = this.gridControlChildLedgerReport;
            this.grvChildLedgerReport.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debit", this.gridColumnDebit, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", this.gridColumnCredit, "")});
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
            this.gridColumnDate.VisibleIndex = 1;
            this.gridColumnDate.Width = 60;
            // 
            // gridColumnEntryType
            // 
            this.gridColumnEntryType.Caption = "Entry Type";
            this.gridColumnEntryType.FieldName = "EntryType";
            this.gridColumnEntryType.Name = "gridColumnEntryType";
            this.gridColumnEntryType.Visible = true;
            this.gridColumnEntryType.VisibleIndex = 2;
            this.gridColumnEntryType.Width = 62;
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
            this.gridColumnFromPartyName.VisibleIndex = 3;
            this.gridColumnFromPartyName.Width = 104;
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
            this.gridColumnToPartyName.Visible = true;
            this.gridColumnToPartyName.VisibleIndex = 4;
            this.gridColumnToPartyName.Width = 128;
            // 
            // gridColumnDebit
            // 
            this.gridColumnDebit.Caption = "Debit";
            this.gridColumnDebit.FieldName = "Debit";
            this.gridColumnDebit.Name = "gridColumnDebit";
            this.gridColumnDebit.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debit", "{0:0.##}")});
            this.gridColumnDebit.Visible = true;
            this.gridColumnDebit.VisibleIndex = 6;
            this.gridColumnDebit.Width = 76;
            // 
            // gridColumnCredit
            // 
            this.gridColumnCredit.Caption = "Credit";
            this.gridColumnCredit.FieldName = "Credit";
            this.gridColumnCredit.Name = "gridColumnCredit";
            this.gridColumnCredit.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", "{0:0.##}")});
            this.gridColumnCredit.Visible = true;
            this.gridColumnCredit.VisibleIndex = 7;
            this.gridColumnCredit.Width = 74;
            // 
            // gridColumnChildSlipNo
            // 
            this.gridColumnChildSlipNo.Caption = "SlipNo";
            this.gridColumnChildSlipNo.FieldName = "SlipNo";
            this.gridColumnChildSlipNo.Name = "gridColumnChildSlipNo";
            this.gridColumnChildSlipNo.Visible = true;
            this.gridColumnChildSlipNo.VisibleIndex = 0;
            this.gridColumnChildSlipNo.Width = 42;
            // 
            // gridColumnChildRemarks
            // 
            this.gridColumnChildRemarks.Caption = "Remarks";
            this.gridColumnChildRemarks.FieldName = "Remarks";
            this.gridColumnChildRemarks.Name = "gridColumnChildRemarks";
            this.gridColumnChildRemarks.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Remarks", "Closing Balance = {0}")});
            this.gridColumnChildRemarks.Visible = true;
            this.gridColumnChildRemarks.VisibleIndex = 5;
            this.gridColumnChildRemarks.Width = 139;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            editorButtonImageOptions4.Image = global::DiamondTrading.Properties.Resources.View_16;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions4, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, serializableAppearanceObject14, serializableAppearanceObject15, serializableAppearanceObject16, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportExcelToolStripMenuItem,
            this.exportPDFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(973, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exportExcelToolStripMenuItem
            // 
            this.exportExcelToolStripMenuItem.Name = "exportExcelToolStripMenuItem";
            this.exportExcelToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.exportExcelToolStripMenuItem.Text = "Export Excel";
            this.exportExcelToolStripMenuItem.Click += new System.EventHandler(this.exportExcelToolStripMenuItem_Click);
            // 
            // exportPDFToolStripMenuItem
            // 
            this.exportPDFToolStripMenuItem.Name = "exportPDFToolStripMenuItem";
            this.exportPDFToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.exportPDFToolStripMenuItem.Text = "Export PDF";
            this.exportPDFToolStripMenuItem.Click += new System.EventHandler(this.exportPDFToolStripMenuItem_Click);
            // 
            // FromChildLedgerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 467);
            this.Controls.Add(this.gridControlChildLedgerReport);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FromChildLedgerReport";
            this.Text = "FromChildLedgerReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FromChildLedgerReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FromChildLedgerReport_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlChildLedgerReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChildLedgerReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnChildSlipNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnChildRemarks;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportPDFToolStripMenuItem;
    }
}
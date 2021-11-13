
namespace DiamondTrading.Process
{
    partial class FrmBoilSend
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
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.dtTime = new DevExpress.XtraEditors.DateEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.grpGroup2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblFormTitle = new DevExpress.XtraEditors.LabelControl();
            this.grpGroup1 = new DevExpress.XtraEditors.GroupControl();
            this.grdParticularsDetails = new DevExpress.XtraGrid.GridControl();
            this.grvParticularsDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSlipNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoSlipNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACarat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBoilCarat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoTxtEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colSizeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShapeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurityId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseDetailsId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSlipNo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoPayType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repoSize = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repoPurity = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repoKapan = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.txtSerialNo = new DevExpress.XtraEditors.TextEdit();
            this.dtDate = new DevExpress.XtraEditors.DateEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lueKapan = new DevExpress.XtraEditors.LookUpEdit();
            this.lueSendto = new DevExpress.XtraEditors.LookUpEdit();
            this.lueReceiveFrom = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dtTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGroup2)).BeginInit();
            this.grpGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpGroup1)).BeginInit();
            this.grpGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdParticularsDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvParticularsDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSlipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoTxtEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoPayType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoPurity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoKapan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueKapan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSendto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueReceiveFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(479, 31);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(43, 16);
            this.labelControl8.TabIndex = 3;
            this.labelControl8.Text = "Date* :";
            // 
            // dtTime
            // 
            this.dtTime.EditValue = null;
            this.dtTime.Enabled = false;
            this.dtTime.Location = new System.Drawing.Point(529, 51);
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
            this.dtTime.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(564, 539);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReset
            // 
            this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Appearance.Options.UseFont = true;
            this.btnReset.Location = new System.Drawing.Point(483, 539);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 21);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "&Reset";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(402, 539);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // grpGroup2
            // 
            this.grpGroup2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGroup2.AppearanceCaption.Options.UseFont = true;
            this.grpGroup2.Controls.Add(this.txtRemark);
            this.grpGroup2.Location = new System.Drawing.Point(11, 433);
            this.grpGroup2.Name = "grpGroup2";
            this.grpGroup2.Size = new System.Drawing.Size(606, 83);
            this.grpGroup2.TabIndex = 13;
            this.grpGroup2.Text = "Remark";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(11, 29);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(61, 16);
            this.labelControl12.TabIndex = 1;
            this.labelControl12.Text = "Serial No :";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(11, 76);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(102, 16);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "Received From* :";
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
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "|| શ્રીજી ||";
            this.lblFormTitle.UseMnemonic = false;
            // 
            // grpGroup1
            // 
            this.grpGroup1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGroup1.AppearanceCaption.Options.UseFont = true;
            this.grpGroup1.Controls.Add(this.grdParticularsDetails);
            this.grpGroup1.Location = new System.Drawing.Point(11, 161);
            this.grpGroup1.Name = "grpGroup1";
            this.grpGroup1.Size = new System.Drawing.Size(606, 266);
            this.grpGroup1.TabIndex = 12;
            this.grpGroup1.Text = "Particulars Details";
            // 
            // grdParticularsDetails
            // 
            this.grdParticularsDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdParticularsDetails.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdParticularsDetails.Location = new System.Drawing.Point(2, 23);
            this.grdParticularsDetails.MainView = this.grvParticularsDetails;
            this.grdParticularsDetails.Name = "grdParticularsDetails";
            this.grdParticularsDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoPayType,
            this.repoSize,
            this.repoPurity,
            this.repoKapan,
            this.repoTxtEdit,
            this.repoSlipNo});
            this.grdParticularsDetails.Size = new System.Drawing.Size(602, 241);
            this.grdParticularsDetails.TabIndex = 1;
            this.grdParticularsDetails.UseEmbeddedNavigator = true;
            this.grdParticularsDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvParticularsDetails});
            // 
            // grvParticularsDetails
            // 
            this.grvParticularsDetails.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.grvParticularsDetails.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvParticularsDetails.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvParticularsDetails.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvParticularsDetails.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.grvParticularsDetails.Appearance.Row.Options.UseFont = true;
            this.grvParticularsDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSlipNo,
            this.colSize,
            this.colACarat,
            this.colBoilCarat,
            this.colSizeId,
            this.colShapeId,
            this.colPurityId,
            this.colPurchaseDetailsId,
            this.colSlipNo1});
            this.grvParticularsDetails.GridControl = this.grdParticularsDetails;
            this.grvParticularsDetails.Name = "grvParticularsDetails";
            this.grvParticularsDetails.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvParticularsDetails.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvParticularsDetails.OptionsView.ShowFooter = true;
            this.grvParticularsDetails.OptionsView.ShowGroupPanel = false;
            this.grvParticularsDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvParticularsDetails_CellValueChanged);
            // 
            // colSlipNo
            // 
            this.colSlipNo.Caption = "Slip No";
            this.colSlipNo.ColumnEdit = this.repoSlipNo;
            this.colSlipNo.FieldName = "SlipNo";
            this.colSlipNo.Name = "colSlipNo";
            this.colSlipNo.Visible = true;
            this.colSlipNo.VisibleIndex = 0;
            this.colSlipNo.Width = 259;
            // 
            // repoSlipNo
            // 
            this.repoSlipNo.AutoHeight = false;
            this.repoSlipNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoSlipNo.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SlipNo", "SlipNo", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KapanId", "KapanId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kapan", "Kapan", 60, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShapeId", "ShapeId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Shape", "Shape", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SizeId", "SizeId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurityId", "PurityId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Purity", "Purity", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FinancialYearId", "FinancialYearId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Weight", "Weight", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AvailableWeight", "A Weight", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repoSlipNo.Name = "repoSlipNo";
            this.repoSlipNo.NullText = "";
            // 
            // colSize
            // 
            this.colSize.Caption = "Size";
            this.colSize.FieldName = "Size";
            this.colSize.Name = "colSize";
            this.colSize.OptionsColumn.AllowEdit = false;
            this.colSize.Visible = true;
            this.colSize.VisibleIndex = 1;
            this.colSize.Width = 301;
            // 
            // colACarat
            // 
            this.colACarat.Caption = "A Carat";
            this.colACarat.FieldName = "AvailableWeight";
            this.colACarat.Name = "colACarat";
            this.colACarat.OptionsColumn.AllowEdit = false;
            this.colACarat.Visible = true;
            this.colACarat.VisibleIndex = 2;
            this.colACarat.Width = 116;
            // 
            // colBoilCarat
            // 
            this.colBoilCarat.Caption = "Boil Cts";
            this.colBoilCarat.ColumnEdit = this.repoTxtEdit;
            this.colBoilCarat.FieldName = "BoilCarat";
            this.colBoilCarat.Name = "colBoilCarat";
            this.colBoilCarat.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:0.##}")});
            this.colBoilCarat.Visible = true;
            this.colBoilCarat.VisibleIndex = 3;
            this.colBoilCarat.Width = 114;
            // 
            // repoTxtEdit
            // 
            this.repoTxtEdit.AutoHeight = false;
            this.repoTxtEdit.BeepOnError = true;
            this.repoTxtEdit.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.repoTxtEdit.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.repoTxtEdit.MaskSettings.Set("mask", "f3");
            this.repoTxtEdit.Name = "repoTxtEdit";
            // 
            // colSizeId
            // 
            this.colSizeId.Caption = "SizeId";
            this.colSizeId.FieldName = "SizeId";
            this.colSizeId.Name = "colSizeId";
            // 
            // colShapeId
            // 
            this.colShapeId.Caption = "ShapeId";
            this.colShapeId.FieldName = "ShapeId";
            this.colShapeId.Name = "colShapeId";
            // 
            // colPurityId
            // 
            this.colPurityId.Caption = "PurityId";
            this.colPurityId.FieldName = "PurityId";
            this.colPurityId.Name = "colPurityId";
            // 
            // colPurchaseDetailsId
            // 
            this.colPurchaseDetailsId.Caption = "PurchaseDetailsId";
            this.colPurchaseDetailsId.FieldName = "PurchaseDetailsId";
            this.colPurchaseDetailsId.Name = "colPurchaseDetailsId";
            // 
            // colSlipNo1
            // 
            this.colSlipNo1.Caption = "SlipNo";
            this.colSlipNo1.FieldName = "SlipNo1";
            this.colSlipNo1.Name = "colSlipNo1";
            // 
            // repoPayType
            // 
            this.repoPayType.AutoHeight = false;
            this.repoPayType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoPayType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Shape", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "ShapeID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repoPayType.Name = "repoPayType";
            this.repoPayType.ValueMember = "Guid";
            // 
            // repoSize
            // 
            this.repoSize.AutoHeight = false;
            this.repoSize.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoSize.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Size", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "SizeID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repoSize.Name = "repoSize";
            // 
            // repoPurity
            // 
            this.repoPurity.AutoHeight = false;
            this.repoPurity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoPurity.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Purity", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "PurityID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repoPurity.Name = "repoPurity";
            // 
            // repoKapan
            // 
            this.repoKapan.AutoHeight = false;
            this.repoKapan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoKapan.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Kapan", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "KapanID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repoKapan.Name = "repoKapan";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.EditValue = "0";
            this.txtSerialNo.Enabled = false;
            this.txtSerialNo.Location = new System.Drawing.Point(75, 26);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNo.Properties.Appearance.Options.UseFont = true;
            this.txtSerialNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtSerialNo.Size = new System.Drawing.Size(97, 24);
            this.txtSerialNo.TabIndex = 2;
            // 
            // dtDate
            // 
            this.dtDate.EditValue = null;
            this.dtDate.Location = new System.Drawing.Point(529, 29);
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
            this.dtDate.TabIndex = 4;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lueKapan);
            this.panelControl1.Controls.Add(this.lueSendto);
            this.panelControl1.Controls.Add(this.lueReceiveFrom);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl12);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.lblFormTitle);
            this.panelControl1.Controls.Add(this.grpGroup1);
            this.panelControl1.Controls.Add(this.grpGroup2);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.dtTime);
            this.panelControl1.Controls.Add(this.txtSerialNo);
            this.panelControl1.Controls.Add(this.dtDate);
            this.panelControl1.Location = new System.Drawing.Point(11, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(628, 526);
            this.panelControl1.TabIndex = 0;
            // 
            // lueKapan
            // 
            this.lueKapan.Location = new System.Drawing.Point(119, 131);
            this.lueKapan.Name = "lueKapan";
            this.lueKapan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueKapan.Properties.Appearance.Options.UseFont = true;
            this.lueKapan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueKapan.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "KapanID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueKapan.Properties.NullText = "";
            this.lueKapan.Size = new System.Drawing.Size(274, 22);
            this.lueKapan.TabIndex = 11;
            this.lueKapan.EditValueChanged += new System.EventHandler(this.lueKapan_EditValueChanged);
            // 
            // lueSendto
            // 
            this.lueSendto.Location = new System.Drawing.Point(119, 102);
            this.lueSendto.Name = "lueSendto";
            this.lueSendto.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueSendto.Properties.Appearance.Options.UseFont = true;
            this.lueSendto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSendto.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "PartyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueSendto.Properties.NullText = "";
            this.lueSendto.Size = new System.Drawing.Size(274, 22);
            this.lueSendto.TabIndex = 9;
            // 
            // lueReceiveFrom
            // 
            this.lueReceiveFrom.Location = new System.Drawing.Point(119, 73);
            this.lueReceiveFrom.Name = "lueReceiveFrom";
            this.lueReceiveFrom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueReceiveFrom.Properties.Appearance.Options.UseFont = true;
            this.lueReceiveFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueReceiveFrom.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "PartyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueReceiveFrom.Properties.NullText = "";
            this.lueReceiveFrom.Size = new System.Drawing.Size(274, 22);
            this.lueReceiveFrom.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(11, 134);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(71, 16);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Kapan No* :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(11, 105);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 16);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Send To* :";
            // 
            // FrmBoilSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(650, 565);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBoilSend";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BOIL SEND";
            this.Load += new System.EventHandler(this.FrmBoilSend_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBoilSend_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGroup2)).EndInit();
            this.grpGroup2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpGroup1)).EndInit();
            this.grpGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdParticularsDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvParticularsDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSlipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoTxtEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoPayType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoPurity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoKapan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueKapan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSendto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueReceiveFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.DateEdit dtTime;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.GroupControl grpGroup2;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblFormTitle;
        private DevExpress.XtraEditors.GroupControl grpGroup1;
        private DevExpress.XtraEditors.TextEdit txtSerialNo;
        private DevExpress.XtraEditors.DateEdit dtDate;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lueSendto;
        private DevExpress.XtraEditors.LookUpEdit lueReceiveFrom;
        private DevExpress.XtraEditors.LookUpEdit lueKapan;
        private DevExpress.XtraGrid.GridControl grdParticularsDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView grvParticularsDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colSlipNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoSlipNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSize;
        private DevExpress.XtraGrid.Columns.GridColumn colACarat;
        private DevExpress.XtraGrid.Columns.GridColumn colBoilCarat;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoTxtEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colSizeId;
        private DevExpress.XtraGrid.Columns.GridColumn colShapeId;
        private DevExpress.XtraGrid.Columns.GridColumn colPurityId;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseDetailsId;
        private DevExpress.XtraGrid.Columns.GridColumn colSlipNo1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoPayType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoSize;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoPurity;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoKapan;
    }
}
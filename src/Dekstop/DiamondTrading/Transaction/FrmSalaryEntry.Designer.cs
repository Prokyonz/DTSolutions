
namespace DiamondTrading.Transaction
{
    partial class FrmSalaryEntry
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
            this.components = new System.ComponentModel.Container();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.lueCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblFormTitle = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.dtTime = new DevExpress.XtraEditors.DateEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.txtSerialNo = new DevExpress.XtraEditors.TextEdit();
            this.dtDate = new DevExpress.XtraEditors.DateEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtWorkingDays = new DevExpress.XtraEditors.TextEdit();
            this.lueMonth = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.grpGroup1 = new DevExpress.XtraEditors.GroupControl();
            this.grdParticularsDetails = new DevExpress.XtraGrid.GridControl();
            this.grvParticularsDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoEmployee = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSalaryAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoTxtEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnWorkedDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoWorkedDays = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colOTPlusHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOTPlusRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAdvanceAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoAdvanceAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colBonus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRound = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOTMinusHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOTMinusRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOTPlusAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOTMinusAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoWorkingDays = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grpGroup2 = new DevExpress.XtraEditors.GroupControl();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.lueLeadger = new DevExpress.XtraEditors.LookUpEdit();
            this.txtLedgerBalance = new DevExpress.XtraEditors.TextEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lueCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkingDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGroup1)).BeginInit();
            this.grpGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdParticularsDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvParticularsDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoTxtEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoWorkedDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoAdvanceAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoWorkingDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGroup2)).BeginInit();
            this.grpGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLeadger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLedgerBalance.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(198, 34);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(70, 16);
            this.labelControl13.TabIndex = 1;
            this.labelControl13.Text = "Company* :";
            // 
            // lueCompany
            // 
            this.lueCompany.Location = new System.Drawing.Point(280, 31);
            this.lueCompany.Name = "lueCompany";
            this.lueCompany.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueCompany.Properties.Appearance.Options.UseFont = true;
            this.lueCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "PartyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueCompany.Properties.NullText = "";
            this.lueCompany.Size = new System.Drawing.Size(363, 26);
            this.lueCompany.TabIndex = 2;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(11, 62);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(61, 16);
            this.labelControl12.TabIndex = 3;
            this.labelControl12.Text = "Serial No :";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(109, 67);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(62, 16);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Account* :";
            this.labelControl6.Visible = false;
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
            this.lblFormTitle.Size = new System.Drawing.Size(884, 23);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "|| શ્રીજી ||";
            this.lblFormTitle.UseMnemonic = false;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(733, 62);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(43, 16);
            this.labelControl8.TabIndex = 5;
            this.labelControl8.Text = "Date* :";
            // 
            // dtTime
            // 
            this.dtTime.EditValue = null;
            this.dtTime.Enabled = false;
            this.dtTime.Location = new System.Drawing.Point(783, 82);
            this.dtTime.Name = "dtTime";
            this.dtTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTime.Properties.Appearance.Options.UseFont = true;
            this.dtTime.Properties.Appearance.Options.UseTextOptions = true;
            this.dtTime.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.dtTime.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.dtTime.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
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
            this.dtTime.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(819, 524);
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
            this.btnReset.Location = new System.Drawing.Point(738, 524);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 21);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "&Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.EditValue = "0";
            this.txtSerialNo.Enabled = false;
            this.txtSerialNo.Location = new System.Drawing.Point(75, 58);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNo.Properties.Appearance.Options.UseFont = true;
            this.txtSerialNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtSerialNo.Size = new System.Drawing.Size(97, 24);
            this.txtSerialNo.TabIndex = 4;
            // 
            // dtDate
            // 
            this.dtDate.EditValue = null;
            this.dtDate.Location = new System.Drawing.Point(783, 59);
            this.dtDate.Name = "dtDate";
            this.dtDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Properties.Appearance.Options.UseFont = true;
            this.dtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate.Properties.MaskSettings.Set("mask", "d");
            this.dtDate.Size = new System.Drawing.Size(88, 22);
            this.dtDate.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(657, 524);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtWorkingDays);
            this.panelControl1.Controls.Add(this.lueMonth);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.grpGroup1);
            this.panelControl1.Controls.Add(this.grpGroup2);
            this.panelControl1.Controls.Add(this.lueLeadger);
            this.panelControl1.Controls.Add(this.txtLedgerBalance);
            this.panelControl1.Controls.Add(this.labelControl13);
            this.panelControl1.Controls.Add(this.lueCompany);
            this.panelControl1.Controls.Add(this.labelControl12);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.lblFormTitle);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.dtTime);
            this.panelControl1.Controls.Add(this.txtSerialNo);
            this.panelControl1.Controls.Add(this.dtDate);
            this.panelControl1.Location = new System.Drawing.Point(10, 1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(884, 516);
            this.panelControl1.TabIndex = 0;
            // 
            // txtWorkingDays
            // 
            this.txtWorkingDays.EditValue = "0";
            this.txtWorkingDays.Location = new System.Drawing.Point(109, 138);
            this.txtWorkingDays.Name = "txtWorkingDays";
            this.txtWorkingDays.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkingDays.Properties.Appearance.Options.UseFont = true;
            this.txtWorkingDays.Properties.Appearance.Options.UseTextOptions = true;
            this.txtWorkingDays.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtWorkingDays.Size = new System.Drawing.Size(138, 22);
            this.txtWorkingDays.TabIndex = 15;
            // 
            // lueMonth
            // 
            this.lueMonth.Location = new System.Drawing.Point(109, 109);
            this.lueMonth.Name = "lueMonth";
            this.lueMonth.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueMonth.Properties.Appearance.Options.UseFont = true;
            this.lueMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMonth.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Month", "Month", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueMonth.Properties.NullText = "";
            this.lueMonth.Size = new System.Drawing.Size(138, 22);
            this.lueMonth.TabIndex = 13;
            this.lueMonth.EditValueChanged += new System.EventHandler(this.lueMonth_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(9, 141);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(95, 16);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "Working Days* :";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(9, 112);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 16);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Month* :";
            // 
            // grpGroup1
            // 
            this.grpGroup1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGroup1.AppearanceCaption.Options.UseFont = true;
            this.grpGroup1.Controls.Add(this.grdParticularsDetails);
            this.grpGroup1.Location = new System.Drawing.Point(11, 168);
            this.grpGroup1.Name = "grpGroup1";
            this.grpGroup1.Size = new System.Drawing.Size(860, 248);
            this.grpGroup1.TabIndex = 16;
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
            this.repoTxtEdit,
            this.repoEmployee,
            this.repoWorkingDays,
            this.repoWorkedDays,
            this.repoAdvanceAmount});
            this.grdParticularsDetails.Size = new System.Drawing.Size(856, 223);
            this.grdParticularsDetails.TabIndex = 0;
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
            this.colName,
            this.colSalaryAmount,
            this.gridColumnWorkedDays,
            this.colOTPlusHours,
            this.colOTPlusRate,
            this.gridColumnAdvanceAmount,
            this.colBonus,
            this.colRound,
            this.colTotal,
            this.colOTMinusHours,
            this.colOTMinusRate,
            this.colOTPlusAmount,
            this.colOTMinusAmount});
            this.grvParticularsDetails.GridControl = this.grdParticularsDetails;
            this.grvParticularsDetails.Name = "grvParticularsDetails";
            this.grvParticularsDetails.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvParticularsDetails.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvParticularsDetails.OptionsView.ShowFooter = true;
            this.grvParticularsDetails.OptionsView.ShowGroupPanel = false;
            this.grvParticularsDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvParticularsDetails_CellValueChanged);
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.ColumnEdit = this.repoEmployee;
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Name", "Total: {0}")});
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 115;
            // 
            // repoEmployee
            // 
            this.repoEmployee.AutoHeight = false;
            this.repoEmployee.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoEmployee.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "EmployeeId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Salary", "Salary", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repoEmployee.Name = "repoEmployee";
            this.repoEmployee.NullText = "";
            // 
            // colSalaryAmount
            // 
            this.colSalaryAmount.Caption = "Salary";
            this.colSalaryAmount.ColumnEdit = this.repoTxtEdit;
            this.colSalaryAmount.FieldName = "SalaryAmount";
            this.colSalaryAmount.Name = "colSalaryAmount";
            this.colSalaryAmount.Visible = true;
            this.colSalaryAmount.VisibleIndex = 1;
            this.colSalaryAmount.Width = 92;
            // 
            // repoTxtEdit
            // 
            this.repoTxtEdit.AutoHeight = false;
            this.repoTxtEdit.BeepOnError = true;
            this.repoTxtEdit.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.repoTxtEdit.MaskSettings.Set("mask", "n");
            this.repoTxtEdit.Name = "repoTxtEdit";
            // 
            // gridColumnWorkedDays
            // 
            this.gridColumnWorkedDays.Caption = "Worked Days";
            this.gridColumnWorkedDays.ColumnEdit = this.repoWorkedDays;
            this.gridColumnWorkedDays.FieldName = "WorkedDays";
            this.gridColumnWorkedDays.Name = "gridColumnWorkedDays";
            this.gridColumnWorkedDays.Visible = true;
            this.gridColumnWorkedDays.VisibleIndex = 2;
            this.gridColumnWorkedDays.Width = 104;
            // 
            // repoWorkedDays
            // 
            this.repoWorkedDays.AutoHeight = false;
            this.repoWorkedDays.Name = "repoWorkedDays";
            // 
            // colOTPlusHours
            // 
            this.colOTPlusHours.Caption = "(+)OT Hours";
            this.colOTPlusHours.ColumnEdit = this.repoTxtEdit;
            this.colOTPlusHours.FieldName = "OTPlusHours";
            this.colOTPlusHours.Name = "colOTPlusHours";
            this.colOTPlusHours.Visible = true;
            this.colOTPlusHours.VisibleIndex = 5;
            this.colOTPlusHours.Width = 92;
            // 
            // colOTPlusRate
            // 
            this.colOTPlusRate.Caption = "(+)OT Rate";
            this.colOTPlusRate.ColumnEdit = this.repoTxtEdit;
            this.colOTPlusRate.FieldName = "OTPlusRate";
            this.colOTPlusRate.Name = "colOTPlusRate";
            this.colOTPlusRate.Visible = true;
            this.colOTPlusRate.VisibleIndex = 6;
            this.colOTPlusRate.Width = 87;
            // 
            // gridColumnAdvanceAmount
            // 
            this.gridColumnAdvanceAmount.Caption = "Adv. Amount";
            this.gridColumnAdvanceAmount.ColumnEdit = this.repoAdvanceAmount;
            this.gridColumnAdvanceAmount.FieldName = "AdvanceAmount";
            this.gridColumnAdvanceAmount.Name = "gridColumnAdvanceAmount";
            this.gridColumnAdvanceAmount.Width = 107;
            // 
            // repoAdvanceAmount
            // 
            this.repoAdvanceAmount.AutoHeight = false;
            this.repoAdvanceAmount.Name = "repoAdvanceAmount";
            // 
            // colBonus
            // 
            this.colBonus.Caption = "Bonus";
            this.colBonus.ColumnEdit = this.repoTxtEdit;
            this.colBonus.FieldName = "Bonus";
            this.colBonus.Name = "colBonus";
            this.colBonus.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Bonus", "{0:0.##}")});
            this.colBonus.Width = 54;
            // 
            // colRound
            // 
            this.colRound.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colRound.AppearanceCell.Options.UseBackColor = true;
            this.colRound.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colRound.AppearanceHeader.Options.UseBackColor = true;
            this.colRound.Caption = "Round (+/-)";
            this.colRound.DisplayFormat.FormatString = "n";
            this.colRound.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRound.FieldName = "Round";
            this.colRound.Name = "colRound";
            this.colRound.OptionsColumn.AllowEdit = false;
            this.colRound.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Round", "{0:0}")});
            this.colRound.Visible = true;
            this.colRound.VisibleIndex = 7;
            this.colRound.Width = 105;
            // 
            // colTotal
            // 
            this.colTotal.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colTotal.AppearanceCell.Options.UseBackColor = true;
            this.colTotal.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colTotal.AppearanceHeader.Options.UseBackColor = true;
            this.colTotal.Caption = "Total";
            this.colTotal.DisplayFormat.FormatString = "n";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:0}")});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 8;
            this.colTotal.Width = 149;
            // 
            // colOTMinusHours
            // 
            this.colOTMinusHours.Caption = "(-)OT Hours";
            this.colOTMinusHours.ColumnEdit = this.repoTxtEdit;
            this.colOTMinusHours.FieldName = "OTMinusHours";
            this.colOTMinusHours.Name = "colOTMinusHours";
            this.colOTMinusHours.Visible = true;
            this.colOTMinusHours.VisibleIndex = 3;
            this.colOTMinusHours.Width = 84;
            // 
            // colOTMinusRate
            // 
            this.colOTMinusRate.Caption = "(-)OT Rate";
            this.colOTMinusRate.ColumnEdit = this.repoTxtEdit;
            this.colOTMinusRate.FieldName = "OTMinusRate";
            this.colOTMinusRate.Name = "colOTMinusRate";
            this.colOTMinusRate.Visible = true;
            this.colOTMinusRate.VisibleIndex = 4;
            this.colOTMinusRate.Width = 72;
            // 
            // colOTPlusAmount
            // 
            this.colOTPlusAmount.Caption = "(+)OT Amount";
            this.colOTPlusAmount.FieldName = "OTPlusAmount";
            this.colOTPlusAmount.Name = "colOTPlusAmount";
            // 
            // colOTMinusAmount
            // 
            this.colOTMinusAmount.Caption = "(-)OT Amount";
            this.colOTMinusAmount.FieldName = "OTMinusAmount";
            this.colOTMinusAmount.Name = "colOTMinusAmount";
            // 
            // repoWorkingDays
            // 
            this.repoWorkingDays.AutoHeight = false;
            this.repoWorkingDays.Name = "repoWorkingDays";
            // 
            // grpGroup2
            // 
            this.grpGroup2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGroup2.AppearanceCaption.Options.UseFont = true;
            this.grpGroup2.Controls.Add(this.txtRemark);
            this.grpGroup2.Location = new System.Drawing.Point(11, 422);
            this.grpGroup2.Name = "grpGroup2";
            this.grpGroup2.Size = new System.Drawing.Size(860, 83);
            this.grpGroup2.TabIndex = 17;
            this.grpGroup2.Text = "Remark";
            // 
            // txtRemark
            // 
            this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemark.Location = new System.Drawing.Point(10, 29);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemark.Size = new System.Drawing.Size(840, 47);
            this.txtRemark.TabIndex = 0;
            // 
            // lueLeadger
            // 
            this.lueLeadger.Location = new System.Drawing.Point(178, 64);
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
            this.lueLeadger.Size = new System.Drawing.Size(532, 22);
            this.lueLeadger.TabIndex = 9;
            this.lueLeadger.Visible = false;
            // 
            // txtLedgerBalance
            // 
            this.txtLedgerBalance.EditValue = "0";
            this.txtLedgerBalance.Enabled = false;
            this.txtLedgerBalance.Location = new System.Drawing.Point(178, 88);
            this.txtLedgerBalance.Name = "txtLedgerBalance";
            this.txtLedgerBalance.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtLedgerBalance.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLedgerBalance.Properties.Appearance.Options.UseBackColor = true;
            this.txtLedgerBalance.Properties.Appearance.Options.UseFont = true;
            this.txtLedgerBalance.Properties.Appearance.Options.UseTextOptions = true;
            this.txtLedgerBalance.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtLedgerBalance.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtLedgerBalance.Size = new System.Drawing.Size(147, 20);
            this.txtLedgerBalance.TabIndex = 10;
            this.txtLedgerBalance.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmSalaryEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(906, 553);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSalaryEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salary Entry";
            this.Load += new System.EventHandler(this.FrmSalaryEntry_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSalaryEntry_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lueCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkingDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGroup1)).EndInit();
            this.grpGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdParticularsDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvParticularsDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoTxtEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoWorkedDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoAdvanceAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoWorkingDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGroup2)).EndInit();
            this.grpGroup2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLeadger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLedgerBalance.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LookUpEdit lueCompany;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblFormTitle;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.DateEdit dtTime;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.TextEdit txtSerialNo;
        private DevExpress.XtraEditors.DateEdit dtDate;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit lueLeadger;
        private DevExpress.XtraEditors.TextEdit txtLedgerBalance;
        private DevExpress.XtraEditors.GroupControl grpGroup1;
        private DevExpress.XtraGrid.GridControl grdParticularsDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView grvParticularsDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn colSalaryAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoTxtEdit;
        private DevExpress.XtraEditors.GroupControl grpGroup2;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.LookUpEdit lueMonth;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtWorkingDays;
        private DevExpress.XtraGrid.Columns.GridColumn colOTPlusHours;
        private DevExpress.XtraGrid.Columns.GridColumn colOTPlusRate;
        private DevExpress.XtraGrid.Columns.GridColumn colRound;
        private DevExpress.XtraGrid.Columns.GridColumn colBonus;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoWorkingDays;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnWorkedDays;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoWorkedDays;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAdvanceAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoAdvanceAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colOTMinusHours;
        private DevExpress.XtraGrid.Columns.GridColumn colOTMinusRate;
        private DevExpress.XtraGrid.Columns.GridColumn colOTPlusAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colOTMinusAmount;
        private System.Windows.Forms.Timer timer1;
    }
}
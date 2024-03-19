using DevExpress.XtraEditors;
using DiamondTrading.Master;
using EFCore.SQL.Repository;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondTrading
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        UserMasterRepository userMasterRepository;
        #region "FormEvents"

        public FrmMain()
        {
            InitializeComponent();            
        }

        private void accordionControlElement15_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlElementMaster);
            OpenMasterDetailsForm("CompanyMaster");
        }

        private async Task CheckPermission()
        {
            userMasterRepository = new UserMasterRepository();
            Common.UserPermissionChildren = await userMasterRepository.GetUserPermissions(Common.LoginUserID);

            for (int i = 0; i < Common.UserPermissionChildren.Count; i++)
            {
                switch (Common.UserPermissionChildren[i].KeyName)
                {
                    //Master Menu
                    case "company_master":
                        accordionControlElementMaster.Visible = true;
                        accrdianElementCompanyMaster.Visible = true;
                        barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "branch_master":                        
                        accordionControlElementMaster.Visible = true;
                        accrdianElementBranchMaster.Visible = true;
                        barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "ledger_master":
                        accordionControlElementMaster.Visible = true;
                        accrdianElementPartyMaster.Visible = true;
                        barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "kapan_master":
                        accordionControlElementMaster.Visible = true;
                        accrdianElementKapanMaster.Visible = true;
                        barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barBtnKapan.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "shape_master":
                        accordionControlElementMaster.Visible = true;
                        accrdianElementShapeMaster.Visible = true;
                        barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barBtnShape.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "size_master":
                        accordionControlElementMaster.Visible = true;
                        accrdianElementSizeMaster.Visible = true;
                        barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem12.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "purity_master":
                        accordionControlElementMaster.Visible = true;
                        accrdianElementPurityMaster.Visible = true;
                        barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "gala_master":
                        accordionControlElementMaster.Visible = true;
                        accrdianElementGalaMaster.Visible = true;
                        barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "number_master":
                        accordionControlElementMaster.Visible = true;
                        accrdianElementNumberMaster.Visible = true;
                        barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "currency_master":
                        accordionControlElementMaster.Visible = true;
                        accrdianElementCurrencyMaster.Visible = true;
                        barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem13.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "financial_year_master":
                        accordionControlElementMaster.Visible = true;
                        accrdianElementFinancialYearMaster.Visible = true;
                        barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "brokerage_master":
                        accordionControlElementMaster.Visible = true;
                        accrdianElementBrokerageMaster.Visible = true;
                        barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem14.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "less_weight_group_master":
                        accordionControlElementMaster.Visible = true;
                        accrdianElementLessWeightGroupMaster.Visible = true;
                        barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem15.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "user_master":
                        accordionControlElementMaster.Visible = true;
                        accrdianElementUserMaster.Visible = true;
                        barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "approval_master":
                        accordionControlElementMaster.Visible = true;
                        accrdianElementApprovalMaster.Visible = true;
                        barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barbtnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "price_master":
                        accordionControlElementMaster.Visible = true;
                        accrdianElementApprovalMaster.Visible = true;
                        barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem61.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "price_master_mobile":
                        accordionControlElementMaster.Visible = true;
                        accrdianElementApprovalMaster.Visible = true;
                        barButtonPriceMasterMobile.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonPriceMasterMobile.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;

                    //Transaction Menu

                    case "purchase":
                        accordionControlTransaction.Visible = true;
                        accordionControlPurchase.Visible = true;
                        barSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem18.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "sales":
                        accordionControlTransaction.Visible = true;
                        accordionControlSales.Visible = true;
                        barSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem19.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "payment":
                        accordionControlTransaction.Visible = true;
                        accordionControlPayment.Visible = true;
                        barSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem25.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "receipt":
                        accordionControlTransaction.Visible = true;
                        accordionControlReceipt.Visible = true;
                        barSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem26.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "contra":
                        accordionControlTransaction.Visible = true;
                        accordionControlContra.Visible = true;
                        barSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem20.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "expense":
                        accordionControlTransaction.Visible = true;
                        accordionControlExpense.Visible = true;
                        barSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem22.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "salary":
                        accordionControlTransaction.Visible = true;
                        accordionControlSalary.Visible = true;
                        barSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem48.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "loan":
                        accordionControlTransaction.Visible = true;
                        accordionControlLoan.Visible = true;
                        barSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem49.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;

                    //Process Menu

                    case "kapan_map":
                        barSubItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem21.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "assort_process":
                        barSubItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "boil_process":
                        barSubItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "charni_process":
                        barSubItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "gala_process":
                        barSubItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem11.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "number_process":
                        barSubItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem12.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;

                    //Utility Menu
                    case "transfer":
                        accordionControlUtility.Visible = true;
                        accordionControlTransfer.Visible = true;
                        barSubItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem27.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "calculator":
                        accordionControlUtility.Visible = true;
                        accordionControlCalculator.Visible = true;
                        barSubItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem28.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "options":
                        accordionControlUtility.Visible = true;
                        accordionControlOptions.Visible = true;
                        barSubItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem33.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "transfer_slip":
                        accordionControlUtility.Visible = true;
                        accordionControlOptions.Visible = true;
                        barSubItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "rejection":
                        accordionControlUtility.Visible = true;
                        accordionControlOptions.Visible = true;
                        barSubItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem13.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "jangad":
                        accordionControlUtility.Visible = true;
                        accordionControlOptions.Visible = true;
                        barSubItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem14.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "opening_stock":
                        accordionControlUtility.Visible = true;
                        accordionControlOptions.Visible = true;
                        barSubItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem62.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "gst_bill_print":
                        accordionControlUtility.Visible = true;
                        accordionControlOptions.Visible = true;
                        barSubItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonGSTBillPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;


                    //Reports Menu - Transaction

                    case "purchase_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem23.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "sales_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem24.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "payment_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem44.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "receipt_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem45.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "contra_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem46.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "expense_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem47.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "loan_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem52.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "mixed_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem53.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "pf_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem74.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "ledger_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem75.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "payable_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem77.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "receivable_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem78.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "cashbank_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem82.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "salary_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonSalaryReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "rejectionin_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonRejectionInReceive.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "rejectionout_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonRejectionOutSend.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "barButtonRejectionOutSend":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem78.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "kapanlagad_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem81.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "openingstock_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem73.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "weekly_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem76.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "balance_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem79.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "profit_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem80.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;                    

                    //Reports Menu - Slip Print
                    case "purchase_slip_print":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem57.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "sales_slip_print":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItem55.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;

                    //Reports Menu - Process Report
                    case "process_reports":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem15.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "jangad_reports":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barSubItem16.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    case "stock_report":
                        barSubItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonItemStockReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                }
            }

        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            await CheckPermission();

            DevExpress.XtraSplashScreen.FluentSplashScreenOptions options = new DevExpress.XtraSplashScreen.FluentSplashScreenOptions();
            options.LogoImageOptions.Image = Properties.Resources.user_64;
            options.Title = "Welcome " + Common.LoginUserName;
            options.Subtitle = "Good Morning";
            options.RightFooter = "Starting...";
            //options.LeftFooter = "Copyright @ 2021" + Environment.NewLine + "All Rights reserved.";
            options.LoadingIndicatorType = DevExpress.XtraSplashScreen.FluentLoadingIndicatorType.Dots;
            options.Opacity = 130;
            options.OpacityColor = Color.DodgerBlue;

            DevExpress.XtraSplashScreen.SplashScreenManager.ShowFluentSplashScreen(options, parentForm: this, useFadeIn: true, useFadeOut: true);

            System.Threading.Thread.Sleep(500);
            Common.LoadRegistry();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();

            //splashScreenManager1.ShowWaitForm();
            //System.Threading.Thread.Sleep(1800);
            //splashScreenManager1.CloseWaitForm();

            barLblUserName.Caption = Common.LoginUserName;
            this.BringToFront();
            FrmCompanyYearSelection frmCompanyYearSelection = new FrmCompanyYearSelection();
            frmCompanyYearSelection.BringToFront();
            if (frmCompanyYearSelection.ShowDialog() == DialogResult.OK)
            {
                this.Enabled = true;
                barBtnLoginCompany.Caption = Common.LoginCompanyName;
                barBtnLoginBranch.Caption = Common.LoginBranchName;
                barBtnLoginFinancialYear.Caption = Common.LoginFinancialYearName;
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barBtnShape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlElementMaster);
            OpenMasterDetailsForm("ShapeMaster");
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlElementMaster);
            OpenMasterDetailsForm("BranchMaster");
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlElementMaster);
            OpenMasterDetailsForm("PurityMaster");
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlElementMaster);
            OpenMasterDetailsForm("SizeMaster");
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlElementMaster);
            OpenMasterDetailsForm("LessWeightGroupMaster");
        }

        private void accrdianElementCompanyMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("CompanyMaster");
        }

        private void accrdianElementBranchMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("BranchMaster");
        }

        private void accrdianElementShapeMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("ShapeMaster");
        }

        private void accrdianElementSizeMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("SizeMaster");
        }

        private void accrdianElementPurityMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("PurityMaster");
        }

        private void accrdianElementLessWeightGroupMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("LessWeightGroupMaster");
        }

        private void accordionControlElementMaster_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlElementMaster);
            OpenMasterDetailsForm("GalaMaster");
        }

        private void accrdianElementGalaMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("GalaMaster");
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlElementMaster);
            OpenMasterDetailsForm("NumberMaster");
        }

        private void accrdianElementNumberMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("NumberMaster");
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlElementMaster);
            OpenMasterDetailsForm("FinancialYearMaster");
        }

        private void accrdianElementFinancialYearMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("FinancialYearMaster");
        }

        private void accordionControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlElementMaster);
            OpenMasterDetailsForm("BrokerageMaster");
        }

        private void accrdianElementBrokerageMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("BrokerageMaster");
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlElementMaster);
            OpenMasterDetailsForm("CurrencyMaster");
        }

        private void accrdianElementCurrencyMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("CurrencyMaster");
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlElementMaster);
            OpenMasterDetailsForm("KapanMaster");
        }

        private void accrdianElementKapanMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("KapanMaster");
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlElementMaster);
            OpenMasterDetailsForm("LedgerMaster");
        }

        private void accrdianElementPartyMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("LedgerMaster");
        }

        private void barSubItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YearCompanySelection();
        }

        private void barSubItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YearCompanySelection();
        }

        private void barbtnYear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YearCompanySelection();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlTransaction);
            OpenPurchaseForm();
        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlUtility);
            OpenOptionsPage();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlElementMaster);
            OpenMasterDetailsForm("UserMaster");
            
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem23_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
                //barManager1.ForceInitialize();
                //page.SelectedTabPage = PageRequested;
                //page.ActiveTab();
                //page.BringToFront();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "Purchase";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;

            //OpenMasterDetailsForm("Purchase");
        }

        private void barButtonItem24_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
                //barManager1.ForceInitialize();
                //page.SelectedTabPage = PageRequested;
                //page.ActiveTab();
                //page.BringToFront();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "Sales";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlTransaction);
            OpenPaymentPage();
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            BoilSendPage();
        }

        private void accrdianElementUserMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("UserMaster");
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlTransaction);
            OpenSaleForm();
        }

        private void accordionControlPurchase_Click(object sender, EventArgs e)
        {
            OpenPurchaseForm();
        }

        private void accordionControlElement17_Click(object sender, EventArgs e)
        {
            OpenSaleForm();
        }

        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            BoilReceivePage();
        }

        private void accordionControlPayment_Click(object sender, EventArgs e)
        {
            OpenPaymentPage();
        }

        private void accordionControlReceipt_Click(object sender, EventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlTransaction);
            OpenReceiptPage();
        }

        private void accordionControlContra_Click(object sender, EventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlTransaction);
            OpenContraPage();
        }

        private void accordionControlKapanMapping_Click(object sender, EventArgs e)
        {
            OpenKapanMappingPage();
        }

        private void accordionControlAssortSend_Click(object sender, EventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            OpenAssortSendPage();
        }

        private void accordionControlAssortReceive_Click(object sender, EventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            OpenAssortReceivePage();
        }

        private void accordionControlBoilSend_Click(object sender, EventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            BoilSendPage();
        }

        private void accordionControlBoilReceive_Click(object sender, EventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            BoilReceivePage();
        }

        private void accordionControlCharniSend_Click(object sender, EventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            CharniSendPage();
        }

        private void accordionControlCharniReceive_Click(object sender, EventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            CharniReceivePage();
        }

        private void accordionControlGalaSend_Click(object sender, EventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            GalaSendPage();
        }

        private void accordionControGalaReceive_Click(object sender, EventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            GalaReceivePage();
        }

        private void accordionControlNumberSend_Click(object sender, EventArgs e)
        {
            NumberSendPage();
            accordionControl1.ExpandElement(accordionControlProcess);
        }

        private void accordionControlNumberReceive_Click(object sender, EventArgs e)
        {
            NumberReceivePage();
        }

        private void accordionControlExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accordionControlTransfer_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlCalculator_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlOptions_Click(object sender, EventArgs e)
        {
            OpenOptionsPage();
        }

        private void barButtonItem37_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            CharniSendPage();
        }

        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            CharniReceivePage();
        }

        private void barButtonItem39_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            GalaSendPage();
        }

        private void barButtonItem40_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            GalaReceivePage();
        }

        private void barButtonItem41_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            NumberSendPage();
        }

        private void barButtonItem42_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NumberReceivePage();
            accordionControl1.ExpandElement(accordionControlProcess);
        }


        #endregion

        private void OpenMasterDetailsForm(string PageRequested)
        {
            panelControl1.SendToBack();
            FrmMasterDetails page = Application.OpenForms["frmMasterDetails"] as FrmMasterDetails;
            if (page != null)
            {
                page.Close();
                //barManager1.ForceInitialize();
                //page.SelectedTabPage = PageRequested;
                //page.ActiveTab();
                //page.BringToFront();
            }

            FrmMasterDetails frmMasterDetails = new FrmMasterDetails();
            frmMasterDetails.SelectedTabPage = PageRequested;
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void OpenTransactionDetailsForm(string PageRequested)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["FrmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
                //barManager1.ForceInitialize();
                //page.SelectedTabPage = PageRequested;
                //page.ActiveTab();
                //page.BringToFront();
            }

            FrmTransactionDetails frmTransactionDetails = new FrmTransactionDetails();
            frmTransactionDetails.SelectedTabPage = PageRequested;
            frmTransactionDetails.MdiParent = this;
            frmTransactionDetails.Show();
            frmTransactionDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }
        
        private void YearCompanySelection()
        {
            this.Enabled = false;
            FrmCompanyYearSelection frmCompanyYearSelection = new FrmCompanyYearSelection();
            frmCompanyYearSelection.BringToFront();
            if (frmCompanyYearSelection.ShowDialog() == DialogResult.OK)
            {
                this.Enabled = true;
                barBtnLoginCompany.Caption = Common.LoginCompanyName;
                barBtnLoginBranch.Caption = Common.LoginBranchName;
                barBtnLoginFinancialYear.Caption = Common.LoginFinancialYearName;
            }
        }

        private void OpenPurchaseForm()
        {
            Transaction.FrmPurchaseEntry page = Application.OpenForms["FrmPurchaseEntry"] as Transaction.FrmPurchaseEntry;
            if (page != null)
            {
                page.Close();
            }

            Transaction.FrmPurchaseEntry frmPurchaseEntry = new Transaction.FrmPurchaseEntry();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;

            frmPurchaseEntry.StartPosition = FormStartPosition.Manual;

            frmPurchaseEntry.Location = new Point((w - frmPurchaseEntry.Width - 200)/3, (Height - frmPurchaseEntry.Height) / 2);
            frmPurchaseEntry.ShowDialog();
        }

        private void OpenSaleForm()
        {
            Transaction.FrmSalesEntry page = Application.OpenForms["FrmSalesEntry"] as Transaction.FrmSalesEntry;
            if (page != null)
            {
                page.Close();
            }

            Transaction.FrmSalesEntry frmSalesEntry = new Transaction.FrmSalesEntry();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmSalesEntry.StartPosition = FormStartPosition.Manual;

            frmSalesEntry.Location = new Point((w - frmSalesEntry.Width - 200) / 3, (Height - frmSalesEntry.Height) / 2);

            frmSalesEntry.ShowDialog();
        }
        
        private static void OpenOptionsPage()
        {
            FrmOptions page = Application.OpenForms["FrmOptions"] as FrmOptions;
            if (page != null)
            {
                page.Close();
            }

            FrmOptions frmOptions = new FrmOptions();
            frmOptions.ShowDialog();
        }
        
        private void BoilSendPage()
        {
            Process.FrmBoilSend page = Application.OpenForms["FrmBoilSend"] as Process.FrmBoilSend;
            if (page != null)
            {
                page.Close();
            }

            Process.FrmBoilSend frmBoilSend = new Process.FrmBoilSend();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmBoilSend.StartPosition = FormStartPosition.Manual;

            frmBoilSend.Location = new Point((w - frmBoilSend.Width - 200) / 3, (Height - frmBoilSend.Height) / 2);

            frmBoilSend.ShowDialog();
        }
        
        private void BoilReceivePage()
        {
            Process.FrmBoilReceive page = Application.OpenForms["FrmBoilReceive"] as Process.FrmBoilReceive;
            if (page != null)
            {
                page.Close();
            }

            Process.FrmBoilReceive frmBoilReceive = new Process.FrmBoilReceive();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmBoilReceive.StartPosition = FormStartPosition.Manual;

            frmBoilReceive.Location = new Point((w - frmBoilReceive.Width - 200) / 3, (Height - frmBoilReceive.Height) / 2);

            frmBoilReceive.ShowDialog();
        }
        
        private void CharniSendPage()
        {
            Process.FrmCharniSend page = Application.OpenForms["FrmCharniSend"] as Process.FrmCharniSend;
            if (page != null)
            {
                page.Close();
            }

            Process.FrmCharniSend frmCharniSend = new Process.FrmCharniSend();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmCharniSend.StartPosition = FormStartPosition.Manual;

            frmCharniSend.Location = new Point((w - frmCharniSend.Width - 200) / 3, (Height - frmCharniSend.Height) / 2);

            frmCharniSend.ShowDialog();
        }

        private void CharniReceivePage()
        {
            Process.FrmCharniReceive page = Application.OpenForms["FrmCharniReceive"] as Process.FrmCharniReceive;
            if (page != null)
            {
                page.Close();
            }

            Process.FrmCharniReceive frmCharniReceive = new Process.FrmCharniReceive();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmCharniReceive.StartPosition = FormStartPosition.Manual;

            frmCharniReceive.Location = new Point((w - frmCharniReceive.Width - 200) / 3, (Height - frmCharniReceive.Height) / 2);

            frmCharniReceive.ShowDialog();
        }

        private void GalaSendPage()
        {
            Process.FrmGalaSend page = Application.OpenForms["FrmGalaSend"] as Process.FrmGalaSend;
            if (page != null)
            {
                page.Close();
            }

            Process.FrmGalaSend frmGalaSend = new Process.FrmGalaSend();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmGalaSend.StartPosition = FormStartPosition.Manual;

            frmGalaSend.Location = new Point((w - frmGalaSend.Width - 200) / 3, (Height - frmGalaSend.Height) / 2);

            frmGalaSend.ShowDialog();
        }

        private void GalaReceivePage()
        {
            Process.FrmGalaReceive page = Application.OpenForms["FrmGalaReceive"] as Process.FrmGalaReceive;
            if (page != null)
            {
                page.Close();
            }

            Process.FrmGalaReceive frmGalaReceive = new Process.FrmGalaReceive();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmGalaReceive.StartPosition = FormStartPosition.Manual;

            frmGalaReceive.Location = new Point((w - frmGalaReceive.Width - 200) / 3, (Height - frmGalaReceive.Height) / 2);

            frmGalaReceive.ShowDialog();
        }

        private void NumberSendPage()
        {
            Process.FrmNumberSend page = Application.OpenForms["FrmNumberSend"] as Process.FrmNumberSend;
            if (page != null)
            {
                page.Close();
            }

            Process.FrmNumberSend frmNumberSend = new Process.FrmNumberSend();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmNumberSend.StartPosition = FormStartPosition.Manual;

            frmNumberSend.Location = new Point((w - frmNumberSend.Width - 200) / 3, (Height - frmNumberSend.Height) / 2);

            frmNumberSend.ShowDialog();
        }

        
        private void NumberReceivePage()
        {
            Process.FrmNumberReceive page = Application.OpenForms["FrmNumberReceive"] as Process.FrmNumberReceive;
            if (page != null)
            {
                page.Close();
            }

            Process.FrmNumberReceive frmNumberReceive = new Process.FrmNumberReceive();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmNumberReceive.StartPosition = FormStartPosition.Manual;

            frmNumberReceive.Location = new Point((w - frmNumberReceive.Width - 200) / 3, (Height - frmNumberReceive.Height) / 2);

            frmNumberReceive.ShowDialog();
        }

        
        private void OpenPaymentPage()
        {
            Transaction.FrmPaymentEntry page = Application.OpenForms["FrmPaymentEntry"] as Transaction.FrmPaymentEntry;
            if (page != null)
            {
                page.Close();
            }

            Transaction.FrmPaymentEntry frmPaymentEntry = new Transaction.FrmPaymentEntry("Payment");

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmPaymentEntry.StartPosition = FormStartPosition.Manual;

            frmPaymentEntry.Location = new Point((w - frmPaymentEntry.Width - 200) / 3, (Height - frmPaymentEntry.Height) / 2);

            frmPaymentEntry.ShowDialog();
        }

        private void OpenReceiptPage()
        {
            Transaction.FrmPaymentEntry page = Application.OpenForms["FrmPaymentEntry"] as Transaction.FrmPaymentEntry;
            if (page != null)
            {
                page.Close();
            }

            Transaction.FrmPaymentEntry frmPaymentEntry = new Transaction.FrmPaymentEntry("Receipt");

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmPaymentEntry.StartPosition = FormStartPosition.Manual;

            frmPaymentEntry.Location = new Point((w - frmPaymentEntry.Width - 200) / 3, (Height - frmPaymentEntry.Height) / 2);

            frmPaymentEntry.ShowDialog();
        }

        private void OpenContraPage()
        {
            Transaction.FrmPaymentEntry page = Application.OpenForms["FrmPaymentEntry"] as Transaction.FrmPaymentEntry;
            if (page != null)
            {
                page.Close();
            }

            Transaction.FrmPaymentEntry frmPaymentEntry = new Transaction.FrmPaymentEntry("Contra");

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmPaymentEntry.StartPosition = FormStartPosition.Manual;

            frmPaymentEntry.Location = new Point((w - frmPaymentEntry.Width - 200) / 3, (Height - frmPaymentEntry.Height) / 2);

            frmPaymentEntry.ShowDialog();
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenReceiptPage();
        }

        

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenContraPage();
        }

        private void OpenRejectionPage(int RejectionType)
        {
            Process.FrmRejectionSendReceive page = Application.OpenForms["FrmRejectionSendReceive"] as Process.FrmRejectionSendReceive;
            if (page != null)
            {
                page.Close();
            }

            Process.FrmRejectionSendReceive frmRejectionSendReceive = new Process.FrmRejectionSendReceive(RejectionType);

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmRejectionSendReceive.StartPosition = FormStartPosition.Manual;

            frmRejectionSendReceive.Location = new Point((w - frmRejectionSendReceive.Width - 200) / 3, (Height - frmRejectionSendReceive.Height) / 2);

            frmRejectionSendReceive.ShowDialog();
        }

        private void barButtonItem21_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            OpenKapanMappingPage();
        }

        private void OpenKapanMappingPage()
        {
            Process.FrmKapanMap page = Application.OpenForms["FrmKapanMap"] as Process.FrmKapanMap;
            if (page != null)
            {
                page.Close();
            }

            Process.FrmKapanMap frmKapanMap = new Process.FrmKapanMap();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmKapanMap.StartPosition = FormStartPosition.Manual;

            frmKapanMap.Location = new Point((w - frmKapanMap.Width - 200) / 3, (Height - frmKapanMap.Height) / 2);

            frmKapanMap.ShowDialog();
        }

        private void barButtonItem34_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            OpenAssortSendPage();
        }

        private void OpenAssortSendPage()
        {
            Process.FrmAssortProcessSend page = Application.OpenForms["FrmAssortProcessSend"] as Process.FrmAssortProcessSend;
            if (page != null)
            {
                page.Close();
            }

            Process.FrmAssortProcessSend frmAssortProcessSend = new Process.FrmAssortProcessSend();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmAssortProcessSend.StartPosition = FormStartPosition.Manual;

            frmAssortProcessSend.Location = new Point((w - frmAssortProcessSend.Width - 200) / 3, (Height - frmAssortProcessSend.Height) / 2);

            frmAssortProcessSend.ShowDialog();
        }

        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            OpenAssortReceivePage();
        }

        private void OpenAssortReceivePage()
        {
            Process.FrmAssortProcessReceive page = Application.OpenForms["FrmAssortProcessReceive"] as Process.FrmAssortProcessReceive;
            if (page != null)
            {
                page.Close();
            }

            Process.FrmAssortProcessReceive frmAssortProcessReceive = new Process.FrmAssortProcessReceive();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmAssortProcessReceive.StartPosition = FormStartPosition.Manual;

            frmAssortProcessReceive.Location = new Point((w - frmAssortProcessReceive.Width - 200) / 3, (Height - frmAssortProcessReceive.Height) / 2);

            frmAssortProcessReceive.ShowDialog();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            Process.FrmTransferEntry page = Application.OpenForms["FrmTransferEntry"] as Process.FrmTransferEntry;
            if (page != null)
            {
                page.Close();
            }

            Process.FrmTransferEntry frmTransferEntry = new Process.FrmTransferEntry();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmTransferEntry.StartPosition = FormStartPosition.Manual;

            frmTransferEntry.Location = new Point((w - frmTransferEntry.Width - 100) / 3, (Height - frmTransferEntry.Height) / 2);

            frmTransferEntry.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem44_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
                //barManager1.ForceInitialize();
                //page.SelectedTabPage = PageRequested;
                //page.ActiveTab();
                //page.BringToFront();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "Payment";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;

        }

        private void barButtonItem46_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
                //barManager1.ForceInitialize();
                //page.SelectedTabPage = PageRequested;
                //page.ActiveTab();
                //page.BringToFront();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "Contra";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem45_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
                //barManager1.ForceInitialize();
                //page.SelectedTabPage = PageRequested;
                //page.ActiveTab();
                //page.BringToFront();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "Receipt";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlTransaction);
            Transaction.FrmExpenseEntry page = Application.OpenForms["FrmExpenseEntry"] as Transaction.FrmExpenseEntry;
            if (page != null)
            {
                page.Close();
            }

            Transaction.FrmExpenseEntry frmExpenseEntry= new Transaction.FrmExpenseEntry();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmExpenseEntry.StartPosition = FormStartPosition.Manual;

            frmExpenseEntry.Location = new Point((w - frmExpenseEntry.Width - 200) / 3, (Height - frmExpenseEntry.Height) / 2);

            frmExpenseEntry.ShowDialog();
        }

        private void barButtonItem47_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
                //barManager1.ForceInitialize();
                //page.SelectedTabPage = PageRequested;
                //page.ActiveTab();
                //page.BringToFront();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "Expense";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem50_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem51_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void OpenLoanForm()
        {
            accordionControl1.ExpandElement(accordionControlUtility);
            Utility.FrmLoanEntry page = Application.OpenForms["FrmLoanEntry"] as Utility.FrmLoanEntry;
            if (page != null)
            {
                page.Close();
            }

            Utility.FrmLoanEntry frmLoanEntry = new Utility.FrmLoanEntry();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmLoanEntry.StartPosition = FormStartPosition.Manual;

            frmLoanEntry.Location = new Point((w - frmLoanEntry.Width - 200) / 3, (Height - frmLoanEntry.Height) / 2);

            frmLoanEntry.ShowDialog();
        }

        private void OpenSalaryForm()
        {
            accordionControl1.ExpandElement(accordionControlTransaction);
            Transaction.FrmSalaryEntry page = Application.OpenForms["FrmSalaryEntry"] as Transaction.FrmSalaryEntry;
            if (page != null)
            {
                page.Close();
            }

            Transaction.FrmSalaryEntry frmSalaryEntry = new Transaction.FrmSalaryEntry();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmSalaryEntry.StartPosition = FormStartPosition.Manual;

            frmSalaryEntry.Location = new Point((w - frmSalaryEntry.Width - 200) / 3, (Height - frmSalaryEntry.Height) / 2);

            frmSalaryEntry.ShowDialog();
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            OpenLoanForm();
        }

        private void barButtonItem49_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenLoanForm();
        }

        private void barButtonItem52_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
                //barManager1.ForceInitialize();
                //page.SelectedTabPage = PageRequested;
                //page.ActiveTab();
                //page.BringToFront();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "Loan";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem48_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenSalaryForm();
        }

        private void barButtonItem53_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
                //barManager1.ForceInitialize();
                //page.SelectedTabPage = PageRequested;
                //page.ActiveTab();
                //page.BringToFront();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "Mixed";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem55_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
                //barManager1.ForceInitialize();
                //page.SelectedTabPage = PageRequested;
                //page.ActiveTab();
                //page.BringToFront();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "SalesSlipPrint";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem56_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmApprovalMaster page = new frmApprovalMaster();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;

            page.StartPosition = FormStartPosition.Manual;

            page.Location = new Point((w - page.Width - 200) / 3, (Height - page.Height) / 2);
            page.ShowDialog();
        }

        private void barButtonItem57_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
                //barManager1.ForceInitialize();
                //page.SelectedTabPage = PageRequested;
                //page.ActiveTab();
                //page.BringToFront();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "PurchaseSlipPrint";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem7_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            Transaction.FrmSlipTransfer page = Application.OpenForms["FrmSlipTransfer"] as Transaction.FrmSlipTransfer;
            if (page != null)
            {
                page.Close();
            }

            Transaction.FrmSlipTransfer frmSlipTransfer = new Transaction.FrmSlipTransfer();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmSlipTransfer.StartPosition = FormStartPosition.Manual;

            frmSlipTransfer.Location = new Point((w - frmSlipTransfer.Width - 200) / 3, (Height - frmSlipTransfer.Height) / 2);

            frmSlipTransfer.ShowDialog();
        }

        private void barButtonItem56_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenRejectionPage(2);
        }

        private void barButtonItem58_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenRejectionPage(1);
        }

        private void barButtonItem59_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenJangadPage(2);
        }

        private void OpenJangadPage(int JangadType)
        {
            Process.FrmJangadSend page = Application.OpenForms["FrmJangadSend"] as Process.FrmJangadSend;
            if (page != null)
            {
                page.Close();
            }

            Process.FrmJangadSend frmJangadSend = new Process.FrmJangadSend(JangadType);

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmJangadSend.StartPosition = FormStartPosition.Manual;

            frmJangadSend.Location = new Point((w - frmJangadSend.Width - 200) / 3, (Height - frmJangadSend.Height) / 2);

            frmJangadSend.ShowDialog();
        }

        private void barButtonItem60_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenJangadPage(1);
        }

        private void barButtonItem61_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.FrmPriceMaster page = Application.OpenForms["FrmPriceMaster"] as Process.FrmPriceMaster;
            if (page != null)
            {
                page.Close();
            }

            Process.FrmPriceMaster frmPriceMaster = new Process.FrmPriceMaster();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmPriceMaster.StartPosition = FormStartPosition.Manual;

            frmPriceMaster.Location = new Point((w - frmPriceMaster.Width - 200) / 3, (Height - frmPriceMaster.Height) / 2);

            frmPriceMaster.ShowDialog();
        }

        private void barButtonItem62_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            Utility.FrmOpeningStock page = Application.OpenForms["FrmOpeningStock"] as Utility.FrmOpeningStock;
            if (page != null)
            {
                page.Close();
            }

            Utility.FrmOpeningStock frmOpeningStock = new Utility.FrmOpeningStock();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmOpeningStock.StartPosition = FormStartPosition.Manual;

            frmOpeningStock.Location = new Point((w - frmOpeningStock.Width - 200) / 3, (Height - frmOpeningStock.Height) / 2);

            frmOpeningStock.ShowDialog();
        }

        private void barButtonKapanDetails_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmProcessDetails page = Application.OpenForms["FrmProcessDetails"] as FrmProcessDetails;
            if (page != null)
            {
                page.Close();
                //barManager1.ForceInitialize();
                //page.SelectedTabPage = PageRequested;
                //page.ActiveTab();
                //page.BringToFront();
            }

            FrmProcessDetails frmMasterDetails = new FrmProcessDetails();
            frmMasterDetails.SelectedTabPage = "Kapan";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonAssortSend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmProcessDetails page = Application.OpenForms["FrmProcessDetails"] as FrmProcessDetails;
            if (page != null)
            {
                page.Close();
                //barManager1.ForceInitialize();
                //page.SelectedTabPage = PageRequested;
                //page.ActiveTab();
                //page.BringToFront();
            }

            FrmProcessDetails frmMasterDetails = new FrmProcessDetails();
            frmMasterDetails.SelectedTabPage = "AssortSend";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonIAssortReceive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmProcessDetails page = Application.OpenForms["FrmProcessDetails"] as FrmProcessDetails;
            if (page != null)
            {
                page.Close();
                //barManager1.ForceInitialize();
                //page.SelectedTabPage = PageRequested;
                //page.ActiveTab();
                //page.BringToFront();
            }

            FrmProcessDetails frmMasterDetails = new FrmProcessDetails();
            frmMasterDetails.SelectedTabPage = "AssortReceive";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonBoilSend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmProcessDetails page = Application.OpenForms["FrmProcessDetails"] as FrmProcessDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmProcessDetails frmMasterDetails = new FrmProcessDetails();
            frmMasterDetails.SelectedTabPage = "BoilSend";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonBoilReceive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmProcessDetails page = Application.OpenForms["FrmProcessDetails"] as FrmProcessDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmProcessDetails frmMasterDetails = new FrmProcessDetails();
            frmMasterDetails.SelectedTabPage = "BoilReceive";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem64_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmProcessDetails page = Application.OpenForms["FrmProcessDetails"] as FrmProcessDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmProcessDetails frmMasterDetails = new FrmProcessDetails();
            frmMasterDetails.SelectedTabPage = "CharniSend";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem65_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmProcessDetails page = Application.OpenForms["FrmProcessDetails"] as FrmProcessDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmProcessDetails frmMasterDetails = new FrmProcessDetails();
            frmMasterDetails.SelectedTabPage = "CharniReceive";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem66_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmProcessDetails page = Application.OpenForms["FrmProcessDetails"] as FrmProcessDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmProcessDetails frmMasterDetails = new FrmProcessDetails();
            frmMasterDetails.SelectedTabPage = "GalaSend";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem67_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmProcessDetails page = Application.OpenForms["FrmProcessDetails"] as FrmProcessDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmProcessDetails frmMasterDetails = new FrmProcessDetails();
            frmMasterDetails.SelectedTabPage = "GalaReceive";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem68_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmProcessDetails page = Application.OpenForms["FrmProcessDetails"] as FrmProcessDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmProcessDetails frmMasterDetails = new FrmProcessDetails();
            frmMasterDetails.SelectedTabPage = "NumberSend";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem69_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmProcessDetails page = Application.OpenForms["FrmProcessDetails"] as FrmProcessDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmProcessDetails frmMasterDetails = new FrmProcessDetails();
            frmMasterDetails.SelectedTabPage = "NumberReceive";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem71_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "JangadSend";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem72_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "JangadReceive";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem73_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmProcessDetails page = Application.OpenForms["FrmProcessDetails"] as FrmProcessDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmProcessDetails frmMasterDetails = new FrmProcessDetails();
            frmMasterDetails.SelectedTabPage = "StockReport";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem73_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmProcessDetails page = Application.OpenForms["FrmProcessDetails"] as FrmProcessDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmProcessDetails frmMasterDetails = new FrmProcessDetails();
            frmMasterDetails.SelectedTabPage = "OpeningStockReport";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem74_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "PFReport";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem75_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "LedgerReport";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem76_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "WeeklyPurchaseReport";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem77_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "Payable";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem78_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "Receivable";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem79_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "BalanceSheet";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem80_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "ProfitLoss";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem81_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            Reports.FrmKapanLagadReport page = Application.OpenForms["FrmKapanLagadReport"] as Reports.FrmKapanLagadReport;
            if (page != null)
            {
                page.Close();
            }

            Reports.FrmKapanLagadReport frmKapanLagadReport = new Reports.FrmKapanLagadReport();
            frmKapanLagadReport.MdiParent = this;
            frmKapanLagadReport.Show();
            frmKapanLagadReport.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonItem82_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "CashBank";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonSalaryReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "SalaryReport";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonRejectionInReceive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "RejectionIn";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonRejectionOutSend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            FrmTransactionDetails page = Application.OpenForms["frmTransactionDetails"] as FrmTransactionDetails;
            if (page != null)
            {
                page.Close();
            }

            FrmTransactionDetails frmMasterDetails = new FrmTransactionDetails();
            frmMasterDetails.SelectedTabPage = "RejectionOut";
            frmMasterDetails.MdiParent = this;
            frmMasterDetails.Show();
            frmMasterDetails.BringToFront();

            accordionControlElementMaster.Expanded = true;
        }

        private void barButtonPriceMasterMobile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.FrmPriceMasterMobiles page = Application.OpenForms["FrmPriceMasterMobiles"] as Process.FrmPriceMasterMobiles;
            if (page != null)
            {
                page.Close();
            }

            Process.FrmPriceMasterMobiles frmPriceMasterMobile = new Process.FrmPriceMasterMobiles();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmPriceMasterMobile.StartPosition = FormStartPosition.Manual;

            frmPriceMasterMobile.Location = new Point((w - frmPriceMasterMobile.Width - 200) / 3, (Height - frmPriceMasterMobile.Height) / 2);

            frmPriceMasterMobile.ShowDialog();
        }

        private void barButtonGSTBillPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accordionControl1.ExpandElement(accordionControlProcess);
            Utility.FrmGSTBillEntry page = Application.OpenForms["FrmGSTBillEntry"] as Utility.FrmGSTBillEntry;
            if (page != null)
            {
                page.Close();
            }

            Utility.FrmGSTBillEntry frmGSTBillEntry = new Utility.FrmGSTBillEntry();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmGSTBillEntry.StartPosition = FormStartPosition.Manual;

            frmGSTBillEntry.Location = new Point((w - frmGSTBillEntry.Width - 200) / 3, (Height - frmGSTBillEntry.Height) / 2);

            frmGSTBillEntry.ShowDialog();
        }
    }
}
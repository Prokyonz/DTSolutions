using DevExpress.XtraEditors;
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
        public FrmMain()
        {
            InitializeComponent();
        }

        private void accordionControlElement15_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("CompanyMaster");
        }

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

        private void frmMain_Load(object sender, EventArgs e)
        {
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
            if(frmCompanyYearSelection.ShowDialog()==DialogResult.OK)
            {
                this.Enabled = true;
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barBtnShape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("ShapeMaster");
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("BranchMaster");
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("PurityMaster");
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("SizeMaster");
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
            OpenMasterDetailsForm("GalaMaster");
        }

        private void accrdianElementGalaMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("GalaMaster");
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("NumberMaster");
        }

        private void accrdianElementNumberMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("NumberMaster");
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
            OpenMasterDetailsForm("BrokerageMaster");
        }

        private void accrdianElementBrokerageMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("BrokerageMaster");
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("CurrencyMaster");
        }

        private void accrdianElementCurrencyMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("CurrencyMaster");
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("KapanMaster");
        }

        private void accrdianElementKapanMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("KapanMaster");
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("PartyMaster");
        }

        private void accrdianElementPartyMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("PartyMaster");
        }

        private void barSubItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YearCompanySelection();
        }

        private void YearCompanySelection()
        {
            this.Enabled = false;
            FrmCompanyYearSelection frmCompanyYearSelection = new FrmCompanyYearSelection();
            frmCompanyYearSelection.BringToFront();
            if (frmCompanyYearSelection.ShowDialog() == DialogResult.OK)
            {
                this.Enabled = true;
            }
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
            OpenPurchaseForm();
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

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmOptions page = Application.OpenForms["FrmOptions"] as FrmOptions;
            if (page != null)
            {
                page.Close();
            }

            FrmOptions frmOptions = new FrmOptions();
            frmOptions.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMasterDetailsForm("UserMaster");
        }

        private void accrdianElementUserMaster_Click(object sender, EventArgs e)
        {
            OpenMasterDetailsForm("UserMaster");
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transaction.FrmPaymentEntry page = Application.OpenForms["FrmPaymentEntry"] as Transaction.FrmPaymentEntry;
            if (page != null)
            {
                page.Close();
            }

            Transaction.FrmPaymentEntry frmPaymentEntry = new Transaction.FrmPaymentEntry();

            Screen screen = Screen.FromControl(this);

            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            int w = screen.Bounds.Width;
            int h = screen.Bounds.Height;


            frmPaymentEntry.StartPosition = FormStartPosition.Manual;

            frmPaymentEntry.Location = new Point((w - frmPaymentEntry.Width - 200) / 3, (Height - frmPaymentEntry.Height) / 2);

            frmPaymentEntry.ShowDialog();
        }
    }
}
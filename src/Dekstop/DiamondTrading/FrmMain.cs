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
            
        }

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem37_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem39_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem40_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem41_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem42_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            OpenMasterDetailsForm("Sales");
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem21_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
    }
}
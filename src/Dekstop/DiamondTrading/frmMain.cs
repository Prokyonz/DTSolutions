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
            panelControl1.SendToBack();
            FrmMasterDetails page = Application.OpenForms["frmMasterDetails"] as FrmMasterDetails;
            if (page != null)
            {
                page.BringToFront();
            }
            else
            {
                FrmMasterDetails frmmasterdetails = new FrmMasterDetails();
                frmmasterdetails.MdiParent = this;
                frmmasterdetails.Show();
                frmmasterdetails.BringToFront();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            FrmCompanyYearSelection frmCompanyYearSelection = new FrmCompanyYearSelection();
            if(frmCompanyYearSelection.ShowDialog()==DialogResult.OK)
            {

            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
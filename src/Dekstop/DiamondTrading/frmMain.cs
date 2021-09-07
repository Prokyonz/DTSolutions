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
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void accordionControlElement15_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.SendToBack();
            frmMasterDetails page = Application.OpenForms["frmMasterDetails"] as frmMasterDetails;
            if (page != null)
            {
                page.BringToFront();
            }
            else
            {
                frmMasterDetails frmmasterdetails = new frmMasterDetails();
                frmmasterdetails.MdiParent = this;
                frmmasterdetails.Show();
                frmmasterdetails.BringToFront();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmCompanyYearSelection frmCompanyYearSelection = new frmCompanyYearSelection();
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
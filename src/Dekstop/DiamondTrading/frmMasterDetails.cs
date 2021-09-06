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
    public partial class frmMasterDetails : DevExpress.XtraEditors.XtraForm
    {
        public frmMasterDetails()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmCompanyMaster frmcompanymaster = new Master.frmCompanyMaster();
            frmcompanymaster.ShowDialog();
        }
    }
}
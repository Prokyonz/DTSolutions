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

namespace DiamondTrading.Transaction
{
    public partial class FrmApproveReject : DevExpress.XtraEditors.XtraForm
    {
        private int _ApproveReject = 1;
        public string Comment
        {
            get
            {
                return txtComment.Text;
            }
        }
        public FrmApproveReject(int ApproveReject)
        {
            InitializeComponent();
            _ApproveReject = ApproveReject;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApproveReject_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FrmApproveReject_Load(object sender, EventArgs e)
        {
            if (_ApproveReject == 1)
            {
                btnApproveReject.Text = "&Approve";
                btnApproveReject.Appearance.BackColor = Color.FromArgb(30, 144, 255);
                this.Text = "Approve";
            }
            else
            {
                btnApproveReject.Text = "&Reject";
                btnApproveReject.Appearance.BackColor = Color.FromArgb(217, 83, 79);
                this.Text = "Reject";
            }
        }
    }
}
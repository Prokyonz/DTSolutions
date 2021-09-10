using DevExpress.XtraGrid.Views.Grid;
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
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private readonly LessWeightMasterRepository _lessWeightRepository;
        List<LessWeightMaster> finalData;
        public Form1()
        {
            InitializeComponent();
            _lessWeightRepository = new LessWeightMasterRepository();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            finalData = await _lessWeightRepository.GetLessWeightMasters();
            
            gridControl1.DataSource = finalData;
        }

        private void gridView1_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            GridView grdiView = sender as GridView;
            LessWeightMaster lessWeightMaster = grdiView.GetRow(e.RowHandle) as LessWeightMaster;
            if(lessWeightMaster != null)
            {
                e.IsEmpty = finalData.Where(w => w.Id == lessWeightMaster.Id).Count() > 0 ? false : true;
            }
        }

        private void gridView1_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            GridView grdiView = sender as GridView;
            LessWeightMaster lessWeightMaster = grdiView.GetRow(e.RowHandle) as LessWeightMaster;
            if (lessWeightMaster != null)
            {
                e.ChildList = finalData.Where(w => w.Id == lessWeightMaster.Id).FirstOrDefault().LessWeightDetails;
            }
        }

        private void gridView1_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void gridView1_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "childGrid";
        }
    }
}

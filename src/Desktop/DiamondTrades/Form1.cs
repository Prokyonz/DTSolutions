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

namespace DiamondTrades
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_ClickAsync(object sender, EventArgs e)
        {                        
            Data();            
        }

        public async void Data()
        {
            CompanyMasterRepository companyMasterRepository = new CompanyMasterRepository();
            var companyMasters = await companyMasterRepository.GetAllCompanyAsync();
            int i = companyMasters.Count();
            Console.WriteLine(i);            
            dataGridView1.DataSource = companyMasters;            
        }
    }
}

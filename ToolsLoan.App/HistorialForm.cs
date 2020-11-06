using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Loan.Shared;

namespace ToolsLoan.App
{
    public partial class HistorialForm : Form
    {
        private readonly List<HerramientaHistoryModel>  _herramientaHistories;
      
        public HistorialForm(List<HerramientaHistoryModel> herramientaHistoryModels)
        {
            _herramientaHistories = herramientaHistoryModels;
            InitializeComponent();
        }

        private async void HistorialForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _herramientaHistories;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Loan.DataAcces.Services;
using Tools.Loan.Domain;

namespace ToolsLoan.App
{
    public partial class PrestamosRegistradosForm : Form
    {
        readonly HerramientaService _herramientaService = new HerramientaService();
        public PrestamosRegistradosForm()
        {
            InitializeComponent();
        }

        private async void PrestamosRegistradosForm_Load(object sender, EventArgs e)
        {

            await LoadData();

        }
       async  Task  LoadData()
        {
            dataGridView2.DataSource = await _herramientaService.HistorialDeHerramientaPrestadasAsync();
        }
    }
}

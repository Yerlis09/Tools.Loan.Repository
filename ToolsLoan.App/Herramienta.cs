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

namespace ToolsLoan.App
{
    public partial class Herramienta : Form
    {
        readonly HerramientaService _herramientaService = new HerramientaService();
        public Herramienta()
        {
            InitializeComponent();
        }

        private async  void Herramienta_Load(object sender, EventArgs e)
        {
            await LoadData();
        }
        private async Task LoadData()
        {
            dataGridView2.DataSource =await  _herramientaService.GetHerramientaTableAsync();
        }
        // mira si pudes arglar esto 
        private async void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            var dt = (DataGridView)sender;
            if(dt.SelectedRows.Count > 0){
               var value = Convert.ToInt32(dt.SelectedRows[0].Cells["Id"].Value);
                var historial = await _herramientaService.GetHerramientaHistoryAsync(value);
                if (historial.Count > 0) {
                    new HistorialForm(historial).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No hay historial en este articulo");
                }
            }
        }
    }
}

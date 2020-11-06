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
using Tools.Loan.Shared;

namespace ToolsLoan.App
{
    public partial class HerramientaMetaDateForm : Form
    {
        readonly HerramientaService _herramientaService = new HerramientaService();
        public HerramientaMetaDateForm()
        {
            InitializeComponent();
        }

        private async  void Herramienta_Load(object sender, EventArgs e)
        {
            await LoadData();
        }
        public async Task LoadData()
        {
            dataGridView2.DataSource =await  _herramientaService.GetHerramientaTableAsync();
            CategoriacomboBox.Items.AddRange((await _herramientaService.GetAllCategoriesAsync()).ToArray());
        }
        // mira si pudes arglar esto 
        private async void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var dt = (DataGridView)sender;
            if (dt.SelectedRows.Count > 0)
            {
                var value = Convert.ToInt32(dt.SelectedRows[0].Cells["Id"].Value);
                var historial = await _herramientaService.GetHerramientaHistoryAsync(value);
              
                  
                    groupBox1.Controls.Clear();

                    groupBox1.Controls.Add(new PanelHermaienta(this.dataGridView2,value, _herramientaService, historial));
               
            }
         
            
        }

        private async void btnguardar_Click(object sender, EventArgs e)
        {
            btnguardar.Enabled = false; 

           await _herramientaService.CrearHerramientasAsync(new CrearHerrramintaModel {
                   Categoria = (string)CategoriacomboBox.SelectedItem,
                   Marca = marcaTxtBox.Text,
                   Nombre = herramientaTxt.Text, 
                   Serial = serialTxt.Text,
                   Stock = (int)stock_numericUpDown.Value,
           });
            await LoadData();
            btnguardar.Enabled = true;

        }
    }
}

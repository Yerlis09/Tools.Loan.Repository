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

        private async void Herramienta_Load(object sender, EventArgs e)
        {
            await LoadData();
        }
        public async Task LoadData()
        {
            dataGridView2.DataSource = await _herramientaService.GetHerramientaTableAsync();
            CategoriacomboBox.Items.AddRange((await _herramientaService.GetAllCategoriesAsync()).ToArray());
        }
        private  void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnguardar_Click(object sender, EventArgs e)
        {
            btnguardar.Enabled = false;

            await _herramientaService.CrearHerramientasAsync(new CrearHerrramintaModel
            {
                Categoria = (string)CategoriacomboBox.SelectedItem,
                Marca = marcaTxtBox.Text,
                Nombre = herramientaTxt.Text,
                Serial = serialTxt.Text,
                Stock = (int)stock_numericUpDown.Value,
            });
            await LoadData();
            btnguardar.Enabled = true;

        }

        private async void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // aqui ya esta 
            var txt = ((TextBox)sender).Text;
            dataGridView2.DataSource = await _herramientaService.BuscarEnHerramientaTableAsync(txt);
        }

        private async void btnactua_Click(object sender, EventArgs e)
        {
            btnactua.Enabled = false;
            var dt = dataGridView2;
            if (dt.SelectedRows.Count > 0)
            {
                var value = Convert.ToInt32(dt.SelectedRows[0].Cells["Id"].Value);
                //var historial = await _herramientaService.GetHerramientaHistoryAsync(value);
                new HerramientasForm(value).ShowDialog();
                await LoadData();
            }
            else
            {
                MessageBox.Show("Tiene que selcionar una herramienta");

            }
            btnactua.Enabled = true;
        }

        private async void btnHistorial_Click(object sender, EventArgs e)
        {
            btnHistorial.Enabled = false;
            var dt = dataGridView2;
            if (dt.SelectedRows.Count > 0)
            {
                var value = Convert.ToInt32(dt.SelectedRows[0].Cells["Id"].Value);
                var historial = await _herramientaService.GetHerramientaHistoryAsync(value);
                new HistorialForm(historial).ShowDialog();
                await LoadData();
            }
            else
            {
                MessageBox.Show("Tiene que selcionar una herramienta");

            }
            btnHistorial.Enabled = true;
        }

        private async void btneli_Click(object sender, EventArgs e)
        {
            btneli.Enabled = false;

            var dt = dataGridView2;
            if (dt.SelectedRows.Count > 0)
            {
                var value = Convert.ToInt32(dt.SelectedRows[0].Cells["Id"].Value);
                DialogResult dialogResult = MessageBox.Show("Herramienta ID :" + value, "Estas seguro de querer borrar ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    await _herramientaService.BorrarHerramientaAsync(value);
                    await LoadData();
                }
               
            }
            else
            {
                MessageBox.Show("Tiene que selcionar una herramienta");

            }

            btneli.Enabled = true;

        }
    }
}

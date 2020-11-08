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
using Tools.Loan.Shared;

namespace ToolsLoan.App
{
    public partial class RegistrarClienteForm : Form
    {
        readonly ClienteService _clienteService = new ClienteService();
        public RegistrarClienteForm()
        {
            InitializeComponent();
          
        }

        private async void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                btnguardar.Enabled = false;
                await _clienteService.CrearClienteAsync(new CrearClienteModel
                {

                     Identificacion = Convert.ToInt32(textBox1.Text),
                     Nombre= this.texNombreC.Text,
                     Apellido = this.texApellido.Text,
                     Cargo = this.texCargo.Text,

                });
                MessageBox.Show("Creado!");
                await LoadData();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            btnguardar.Enabled = true;
        }

        private async void RegistrarClienteForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        public async Task LoadData()
        {
            var result = await _clienteService.GetAllClientAsync();
            dataGridView1.DataSource = result;
        }
    }
    
}

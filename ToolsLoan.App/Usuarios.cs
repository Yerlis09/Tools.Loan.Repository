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
    public partial class Usuarios : Form
    {
        protected UsuarioService _UsuarioService = new UsuarioService();
        public Usuarios()
        {
            _UsuarioService = new UsuarioService();
            InitializeComponent();
        }

        private async void Usuarios_Load(object sender, EventArgs e)
        {
            await LoadData();

        }
        public async Task LoadData()
        {
            var result = await _UsuarioService.GetAllUserAsync();
            dataGridView2.DataSource = result;
            cmbrol.Items.AddRange((await _UsuarioService.GetAllRolesAsync()).ToArray());
        }

        private async void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
              
                btnguardar.Enabled = false;
                await _UsuarioService.CreateUser(new UserModel
                {
                    Nombre = this.txtnombre.Text,
                    PassWord = this.txtcontra.Text,
                    Role = (string)this.cmbrol.SelectedItem,
                    UserName = this.txtuser.Text

                });
                MessageBox.Show("Creado!");
                await LoadData();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
           
            btnguardar.Enabled = true;
        }

        private  void txtBuscar_TextChanged(object sender, EventArgs e) {



        }

        private async void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
           
            var txt = ((TextBox)sender).Text;
            dataGridView2.DataSource = await _UsuarioService.BuscarEnUsuarioTableAsync(txt);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btneli_Click(object sender, EventArgs e)
        {
            btneli.Enabled = false;

            var dt = dataGridView2;
            if (dt.SelectedRows.Count > 0)
            {
                var value = Convert.ToInt32(dt.SelectedRows[0].Cells["Id"].Value);
                DialogResult dialogResult = MessageBox.Show("Usuario ID :" + value, "Estas seguro de querer borrar ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    await _UsuarioService.BorrarUsuarioAsync(value);
                    await LoadData();
                }

            }
            else
            {
                MessageBox.Show("Tiene que selcionar una herramienta");

            }

            btneli.Enabled = true;
        }

        private  void btnactua_Click(object sender, EventArgs e)
        {
         
        }
    }
}

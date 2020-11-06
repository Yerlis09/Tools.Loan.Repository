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
        protected readonly UsuarioService _UsuarioService;
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
                // se me olvido algo cunado hagas codgio asyncronico tienes que hacer esto 
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

        private async void txtBuscar_TextChanged(object sender, EventArgs e) { 
        
            
            var input = ((TextBox)sender).Text.ToLower().Trim();
            if (input.Length > 0)
            {
                var result = (await _UsuarioService.GetUsersAsync(x => x.Id.ToString().Contains(input)
                || x.Nombre.Trim().ToLower().Contains(input)
                || x.Role.RoleName.Trim().ToLower().Contains(input)
                )).Select(x => new UserTableModel { Nombre = x.Nombre, Id = x.Id, Role = x.Role.RoleName, UserName = x.UserName }).ToList();
                dataGridView2.DataSource = result;
            }
            else
            {
                await LoadData();
            }
        }
    }
}

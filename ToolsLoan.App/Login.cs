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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async  void button1_Click(object sender, EventArgs e)
        {
            UsuarioService sr = new UsuarioService();
            var result = await sr.LoginAsync(textBox1.Text, textBox2.Text);
           
            if (result != null && result.Role == "Admin")
            {
                Program.User = result;
                AdministradorForm admin = new AdministradorForm();
                admin.Show();
                this.Hide();
              
            }
            else if(result != null && result.Role== "Encargado")
            {
                Program.User = result;
                EncargadoForm encar = new EncargadoForm();
                encar.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrecto, vuelva a ingresar sus datos");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}

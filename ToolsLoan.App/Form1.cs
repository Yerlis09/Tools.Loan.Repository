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
    public partial class Form1 : Form
    {
        public Form1()
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
            if(result == true)
            MessageBox.Show("logeado");
            else
                MessageBox.Show("buuu");
        }
    }
}

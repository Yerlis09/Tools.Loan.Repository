using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolsLoan.App
{
    public partial class EncargadoForm : Form
    {
        public EncargadoForm()
        {
            InitializeComponent();
        }

        private void contenerdor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnherra_Click(object sender, EventArgs e)
        {
            abrirformhijo(new HerramientaMetaDateForm());
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
        }

        private void abrirformhijo(object FormHijo)
        {
            if (this.contenerdor.Controls.Count > 0)
                this.contenerdor.Controls.RemoveAt(0);
            Form fh = FormHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.contenerdor.Controls.Add(fh);
            this.contenerdor.Tag = fh;
            fh.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirformhijo(new RegistrarClienteForm());
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            abrirformhijo(new GestionarPrestamoForm());
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Maximizar.Visible = false;
            Restaurar.Visible = true;
        }

        private void Restaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Restaurar.Visible = false;
            Maximizar.Visible = true;
        }
    }
}

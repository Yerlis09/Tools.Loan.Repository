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
    public partial class EntradaForm : Form
    {
        readonly ClienteService _clienteService = new ClienteService();
        private Cliente cliente;
        readonly HerramientaService _herramientaService = new HerramientaService();
        private List<HerramientasDisponiblesTableModel> HerramientasSelecionandas = new List<HerramientasDisponiblesTableModel>();
        private readonly GestionarPrestamoForm _Form;
        public EntradaForm(GestionarPrestamoForm form):this()
        {
            _Form = form;
           
        }

        public EntradaForm()
        {
           
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private  async void EntradaForm_Load(object sender, EventArgs e)
        {
           await LoadData();
        }
       async Task LoadData()
        {
            cmbnombre.Items.AddRange((await _clienteService.Indentificaciones()).ToArray());
            dataGridView1.DataSource = await _herramientaService.HerramientasDisponiblesAsync();
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            cliente = await _clienteService.LerrClientePorIndentificacion((string)cmbnombre.SelectedItem);
            texNombreC.Text = cliente?.Nombre;
            texApellido.Text = cliente?.Apellido;
          

        }
       
        private  void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            if(cliente == null)
            {
                MessageBox.Show("No has elegido a un cliente !");
                button3.Enabled = true;
                return;

            }
            var dt = dataGridView1;
         
            if (dt.SelectedRows.Count > 0 )
            {
                DataTable dt2 = new DataTable();
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                    dt2.Columns.Add(column.Name); //better to have cell type
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    dt2.Rows.Add();
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        dt2.Rows[i][j] = dataGridView1.SelectedRows[i].Cells[j].Value;
                      
                    }
                }
                if (RentardataGridView != null)
                {
                    RentardataGridView.DataSource = dt2;
                }
            }
            else
            {
                MessageBox.Show("Tiene que selcionar una herramienta");

            }
            button3.Enabled = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (cliente == null)
            {
                MessageBox.Show("No has elegido a un cliente !");
                button1.Enabled = true;
                return;

            }
            var dt = RentardataGridView;
            var list = new List<int>();
            if (dt.Rows.Count > 0)
            {
                foreach(DataGridViewRow row in dt.Rows)
                {
                    var value = Convert.ToInt32(row.Cells["Id"].Value);
                    list.Add(value);
                }
                await _herramientaService.RentarHerramientasAsync(new RentarHerramientaModel
                {
                    ClienteId = cliente.Id,

                    Description = txtdes.Text,
                    FechaDeSalida = dateTimePicker1.Value,
                    Herramientas = list,
                    UsuarioId = Program.User.UserId
                   
                });
                MessageBox.Show("Rentado!");
                //aqui es el error ? 
                // si, pruebalo
                // si ya se cual es el error deja lo arrgelo

                if (_Form != null)
                {
                    _Form.dataGridView2.DataSource = await _herramientaService.HerramientaPrestadasAsync();
                }
                // hagasmos un hack por haora
                this.RentardataGridView.DataSource = null;
                this.RentardataGridView.Rows.Clear();
                await LoadData();
            }
            else
            {
                MessageBox.Show("Tiene que selcionar una herramienta");

            }
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void txtdes_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}

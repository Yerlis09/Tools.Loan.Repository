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
    public partial class GestionarPrestamoForm : Form
    {
        readonly HerramientaService _herramientaService = new HerramientaService();
        public GestionarPrestamoForm()
        {
            InitializeComponent();
        }

        private async void GestionarPrestamoForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }
      public   async Task LoadData()
        {
            dataGridView2.DataSource = await _herramientaService.HerramientaPrestadasAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new EntradaForm().ShowDialog();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            var dt = dataGridView2;
            var list = new List<DevolverHeramientaModel>();
            if (dt.SelectedRows.Count > 0)
            {
                try
                {
                    foreach (DataGridViewRow row in dt.SelectedRows)
                    {
                        var value = Convert.ToInt32(row.Cells["HerramientaId"].Value);
                        var PrestamoId = Convert.ToInt32(row.Cells["PrestamoId"].Value);

                        list.Add(new DevolverHeramientaModel
                        {
                            PrestamoId = PrestamoId,
                            HerramientaId = value
                        });
                    }
                    await _herramientaService.DevolverHerramientaAsync(list);

                    await LoadData();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("Tiene que selcionar una herramienta");

            }
            button2.Enabled = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Tools.Loan.DataAcces.Services;

namespace ToolsLoan.App
{
    public partial class HerramientasForm : Form
    {
        readonly HerramientaService _herramientaService = new HerramientaService();
        readonly int SelectId;
        public HerramientasForm(int id)
        {
            SelectId = id;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private async void btnguardar_Click(object sender, EventArgs e)
        {
            btnguardar.Enabled = false;
            await _herramientaService.ActualizarHerramientaAsync(new Tools.Loan.Shared.HerramientaModel
            {
                Descripción = txtdescription.Text,
                Puesto = txtubicacion.Text,
                Id = SelectId
            });
            DialogResult dialogResult = MessageBox.Show("Cambios guardados", "Deseas cerrar?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            btnguardar.Enabled = true ;
        }

        private async  void HerramientasForm_Load(object sender, EventArgs e)
        {
           var res=   await _herramientaService.GetHerramientaByIdAsync(SelectId);
            txtdescription.Text = res.Descripción;
            txtubicacion.Text = res.Puesto;
            label3.Text = string.Format("HerramientaId:{0}",res.Id);
        }
    }
}

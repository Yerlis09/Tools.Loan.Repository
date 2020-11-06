using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Tools.Loan.DataAcces.Services;
using Tools.Loan.Shared;

namespace ToolsLoan.App
{
    public class PanelHermaienta :Panel
    {

       
     

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Estatdo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btnHistorial;
        Button btnCrearHerramienta;

        private readonly HerramientaService _herramientaService;
        private readonly int ID;
        private readonly List<HerramientaHistoryModel> _herramientaHistoryModels;
        readonly DataGridView _dt;
        
        public PanelHermaienta( DataGridView dt,int id, HerramientaService herramientaService, List<HerramientaHistoryModel> herramientaHistoryModels)
        {
            
            ID = id;
            _herramientaHistoryModels = herramientaHistoryModels;
            _herramientaService = herramientaService;
            _dt = dt;
            btnHistorial = new Button();
            btnCrearHerramienta = new Button();
            Init();
        }
        private void Init()
        {
           
            this.label3 = new System.Windows.Forms.Label();
            this.Estatdo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.btnguardar = new System.Windows.Forms.Button();
        
       
            // 
            // PanelHerramienta
            // 
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Estatdo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdescripcion);
            this.Controls.Add(this.btnguardar);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 75);
            this.Name = "PanelHerramienta";
            this.Size = new System.Drawing.Size(332, 216);
            this.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "Estado";
            // 
            // txtEsstado
            // 
            this.Estatdo.Location = new System.Drawing.Point(126, 93);
            this.Estatdo.Name = "txtnombre";
            this.Estatdo.Size = new System.Drawing.Size(179, 20);
            this.Estatdo.TabIndex = 22;
           
           
            Estatdo.Enabled = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 25;
            this.label2.Text = "Descripcion";
            // 
            // txtuser
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(126, 36);
            this.txtUbicacion.Name = "txtuser";
            this.txtUbicacion.Size = new System.Drawing.Size(179, 20);
            this.txtUbicacion.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 24;
            this.label1.Text = "Ubicacion";
            
            // 
            // txtcontra
            // 
            this.txtdescripcion.Location = new System.Drawing.Point(126, 64);
            this.txtdescripcion.Name = "txtcontra";
            this.txtdescripcion.Size = new System.Drawing.Size(179, 20);
            this.txtdescripcion.TabIndex = 21;

            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(115)))), ((int)(((byte)(35)))));
            this.btnguardar.FlatAppearance.BorderSize = 0;
            this.btnguardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnguardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardar.Location = new System.Drawing.Point(43, 141);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(262, 40);
            this.btnguardar.TabIndex = 23;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += Btnguardar_Click;






            // 
            // btnguardar
            // 
            this.btnHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(115)))), ((int)(((byte)(35)))));
            this.btnHistorial.FlatAppearance.BorderSize = 0;
            this.btnHistorial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnHistorial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.Location = new System.Drawing.Point(43, 200);
      
            this.btnHistorial.Size = new System.Drawing.Size(262, 40);
            this.btnHistorial.TabIndex = 23;
            this.btnHistorial.Text = "Ver historial";
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Click += BtnHistorial_Click; ;
            this.Controls.Add(btnHistorial);



           


            this.btnCrearHerramienta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(115)))), ((int)(((byte)(35)))));
            this.btnCrearHerramienta.FlatAppearance.BorderSize = 0;
            this.btnCrearHerramienta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCrearHerramienta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCrearHerramienta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearHerramienta.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearHerramienta.Location = new System.Drawing.Point(43, 250);

            this.btnCrearHerramienta.Size = new System.Drawing.Size(262, 40);
            this.btnCrearHerramienta.TabIndex = 23;
            this.btnCrearHerramienta.Text = "Agregar Herramienta";
            this.btnCrearHerramienta.UseVisualStyleBackColor = false;
            this.btnCrearHerramienta.Click += BtnCrearHerramienta_Click;
            this.Controls.Add(btnCrearHerramienta);


        }

        private async  void BtnCrearHerramienta_Click(object sender, EventArgs e)
        {
           var frm = (HerramientaMetaDateForm) this.FindForm();
            frm.groupBox1.Controls.Clear();
            frm.groupBox1.Controls.Add(frm.stock_numericUpDown);
            frm.groupBox1.Controls.Add(frm.label5);
            frm.groupBox1.Controls.Add(frm.CategoriacomboBox);
            frm.groupBox1.Controls.Add(frm.label4);
            frm.groupBox1.Controls.Add(frm.label3);
            frm.groupBox1.Controls.Add(frm.label2);
            frm.groupBox1.Controls.Add(frm.label1);
            frm.groupBox1.Controls.Add(frm.btnguardar);
            frm.groupBox1.Controls.Add(frm.serialTxt);
            frm.groupBox1.Controls.Add(frm.marcaTxtBox);
            frm.groupBox1.Controls.Add(frm.herramientaTxt);
            await frm.LoadData();
        
        }

        protected override async void OnPaint(PaintEventArgs e)
        {
            var herramienta = await _herramientaService.GetHerramientaByIdAsync(ID);
            Estatdo.Items.AddRange(new string[] { (herramienta.Rentada != null) ? "Prestado" : "No Prestado" });
            Estatdo.SelectedIndex = 0;
            txtdescripcion.Text = herramienta.Descripción;
            txtUbicacion.Text = herramienta.Puesto;
        }
        private void BtnHistorial_Click(object sender, EventArgs e)
        {
            new HistorialForm(_herramientaHistoryModels).ShowDialog();
        
        }

        private async void Btnguardar_Click(object sender, EventArgs e)
        {
            this.btnguardar.Enabled = false;
            await _herramientaService.ActualizarHerramientaAsync(new HerramientaModel {Descripción = txtdescripcion.Text,Puesto = txtUbicacion.Text, Id = ID  });
            _dt.DataSource = await _herramientaService.GetHerramientaTableAsync();
            this.btnguardar.Enabled = true;
        }
    }
}


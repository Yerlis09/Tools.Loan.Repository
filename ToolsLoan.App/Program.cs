using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Loan.Domain;
using Tools.Loan.Shared;

namespace ToolsLoan.App
{
   
    static class Program
    {
        public static LoginSuccessModel User { get; set; }
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
               Application.Run(new RegistrarClienteForm());
               // Application.Run(new GestionarPrestamoForm());
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}

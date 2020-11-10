using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Loan.Shared
{
    public class HerramientasPrestadasTableModel
    {
        public string ClienteId { get; set; }
        public string Identificacion { get; set; }
  
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string RentaRetrasada { get; set; }
        public string Address { get; set; }
        public int HerramientaId { get; set; }
        public string HerramintasPorNombre { get; set; }
        public int TotalDeherrametasPrestadas { get; set; }
        public string UsuariosQueGestionaron { get; set; }
        public string FechaEntrada  { get; set; }
        public string FechaSalida { get; set; }
        public string PrestamoId { get; set; }



    }
}

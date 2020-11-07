using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Loan.Shared
{
    public class RentarHerramientaModel
    {
        public List<int> Herramientas { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public string  Description { get; set; }
        public DateTime FechaDeSalida { get; set; }
    }
}

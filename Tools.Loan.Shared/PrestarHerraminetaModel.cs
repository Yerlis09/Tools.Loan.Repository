using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Loan.Shared
{
   public class PrestarHerraminetaModel
    {
        public int HerramientaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Salida { get; set; }
    }
}

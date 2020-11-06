using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Tools.Loan.Shared
{
   public  class HerramientaHistoryModel
    {
        public int Id { get; set; }
        public string Descripción { get; set; }
        public string FechaEntrada { get; set; }
        public string FechaSalida { get; set; }
        public string HerramientaId { get; set; }
      
        public string UsuarioEncargado { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Serial { get; set; }

        public string  Cliente { get; set; }
        
    }
}

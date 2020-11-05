using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tools.Loan.Domain
{
    [Table(nameof(Prestamo))]
    public class Prestamo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Descripción { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public Herramienta Herramienta { get; set; }
        public int HerramientaId { get; set; }

        public Usuario  Usuario { get; set; }
        public int UsuarioId { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tools.Loan.Domain
{
    [Table(nameof(Cliente))]
    public class Cliente
    {
        public Cliente()
        {
            Prestamos = new HashSet<Prestamo>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Address { get; set; }
        [Required]
        public string Identificacion { get; set; }
        public ICollection<Prestamo> Prestamos { get; set; }

    }
}

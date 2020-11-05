using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tools.Loan.Domain
{
    [Table(nameof(Herramienta))]
    public class Herramienta
    {
        public Herramienta()
        {
            Prestamos = new HashSet<Prestamo>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Descripción { get; set; }
        public string Puesto { get; set; }
        public int HerramientaMetaDataID { get; set; }
        public HerramientaMetaData HerramientaMetaData { get; set; }
        public ICollection<Prestamo> Prestamos { get; set; }
        public DateTime? Rentada { get; set; }

    }
}

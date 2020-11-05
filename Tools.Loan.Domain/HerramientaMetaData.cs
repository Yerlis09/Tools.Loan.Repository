using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tools.Loan.Domain
{
    [Table(nameof(HerramientaMetaData))]
    public class HerramientaMetaData
    {
        public HerramientaMetaData()
        {
            Herramientas = new HashSet<Herramienta>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Serial { get; set; }

        public int? CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public ICollection<Herramienta> Herramientas { get; set; }
       
    }
}

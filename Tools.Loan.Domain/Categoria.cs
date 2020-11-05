using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tools.Loan.Domain
{
    [Table(nameof(Categoria))]
    public class Categoria
    {
        public Categoria()
        {
            HerramientaMetaDatas = new HashSet<HerramientaMetaData>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<HerramientaMetaData> HerramientaMetaDatas { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tools.Loan.Domain
{
    [Table(nameof(Role))]
    public class Role
    {
        public Role()
        {
            Usuarios = new HashSet<Usuario>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RoleName { get; set; }
       public ICollection<Usuario> Usuarios { get; set; }
    }
}

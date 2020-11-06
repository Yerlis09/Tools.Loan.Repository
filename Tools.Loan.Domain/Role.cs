using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [MaxLength(22)]
        [MinLength(1)]
        public string RoleName { get; set; }
       public ICollection<Usuario> Usuarios { get; set; }
    }
}

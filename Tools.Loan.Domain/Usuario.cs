using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tools.Loan.Domain
{
    [Table(nameof(Usuario))]
    public class Usuario
    {
        public Usuario()
        {
            Prestamos = new HashSet<Prestamo>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string  Nombre { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<Prestamo> Prestamos { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}

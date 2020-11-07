using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Loan.Domain;

namespace Tools.Loan.DataAcces.Services
{
    public class ClienteService
    {
       public async Task<List<string>> Indentificaciones()
        {
            using (AppContext con = new AppContext())
            {

                return await con.Set<Cliente>().Select(x => x.Identificacion).ToListAsync();
            }
        }

        public async Task<Cliente> LerrClientePorIndentificacio(string identityficacion)
        {
            using (AppContext con = new AppContext())
            {

                return await con.Set<Cliente>().Where(x => x.Identificacion.Equals(identityficacion)).FirstOrDefaultAsync();
            }
        }
    }
}

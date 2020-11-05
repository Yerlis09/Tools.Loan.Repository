using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tools.Loan.DataAcces.Repositories;
using Tools.Loan.Domain;

namespace Tools.Loan.DataAcces.Services
{
    public class UsuarioService
    {
        // valida el login pero metele mas logica para validar los strings que dentren 
        public async  Task<bool> LoginAsync(string UserName ,string Password)
        {
            // te dejo esta capa para otro dia IRepository<Usuario> repository =  new BaseRepository<Usuario>(new AppContext()
            using (var context = new AppContext())
            {
                return await context.Set<Usuario>().AnyAsync(x => x.UserName.ToLower().Equals(UserName.ToLower()) && x.Password == Password);
            }
        }
        public async Task<Usuario> GetUserByIdAsync(string id)
        {
            if (!int.TryParse(id, out var userId))
                return null;
            
            using (var context = new AppContext())
            {
                return await context.Set<Usuario>().FirstOrDefaultAsync(x => x.Id == userId);
            }
        }
        public async Task<Usuario> GetUserByUserNameAsync(string UserName)
        {
       
            using (var context = new AppContext())
            {
                return await context.Set<Usuario>().FirstOrDefaultAsync(x => x.UserName == UserName);
            }
        }

        public async Task<List<Usuario>> GetUsersAsync(Expression<Func<Usuario, bool>> expression)
        {

            using (var context = new AppContext())
            {
                return await context.Set<Usuario>().Where(expression).ToListAsync();
            }
        }
    }
}

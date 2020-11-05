using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tools.Loan.DataAcces.Repositories;
using Tools.Loan.Domain;
using Tools.Loan.Shared;

namespace Tools.Loan.DataAcces.Services
{
    public class UsuarioService
    {
        // valida el login pero metele mas logica para validar los strings que dentren 
        public async  Task<LoginSuccessModel> LoginAsync(string UserName ,string Password)
        {
            // te dejo esta capa para otro dia IRepository<Usuario> repository =  new BaseRepository<Usuario>(new AppContext()
            using (var context = new AppContext())
            {
                var result =await context.Set<Usuario>().Include(x=> x.Role)
                    .Where(x => x.UserName.ToLower().Equals(UserName.Trim().ToLower()) && x.Password.Equals(Password)).Select(x=> new LoginSuccessModel { UserName = x.UserName, Role = x.Role.RoleName, UserId = x.Id}).FirstOrDefaultAsync();
                return result;
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

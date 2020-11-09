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
        public async Task<LoginSuccessModel> LoginAsync(string UserName, string Password)
        {
            // te dejo esta capa para otro dia IRepository<Usuario> repository =  new BaseRepository<Usuario>(new AppContext()
            using (var context = new AppContext())
            {
                var result = await context.Set<Usuario>().Include(x => x.Role)
                    .Where(x => x.UserName.ToLower().Equals(UserName.Trim().ToLower()) && x.Password.Equals(Password)).Select(x => new LoginSuccessModel { UserName = x.UserName, Role = x.Role.RoleName, UserId = x.Id }).FirstOrDefaultAsync();
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
                return await context.Set<Usuario>().FirstOrDefaultAsync(x => x.UserName.Trim().ToLower().Equals(UserName.Trim().ToLower()));
            }
        }


        public async Task<List<UserTableModel>> GetAllUserAsync()
        {

            using (var context = new AppContext())
            {
                return await context.Set<Usuario>().Select(x => new UserTableModel { Id = x.Id, Nombre = x.Nombre, Role = x.Role.RoleName, UserName = x.UserName }).ToListAsync();
            }
        }


        public async Task<List<Usuario>> GetUsersAsync(Expression<Func<Usuario, bool>> expression)
        {

            using (var context = new AppContext())
            {
                return await context.Set<Usuario>().Include(x => x.Role).Where(expression).ToListAsync();
            }
        }

        public async Task<bool> DoesRollExistsAsync(string roleName)
        {

            using (var context = new AppContext())
            {
                return await context.Set<Role>().AnyAsync(x => x.RoleName.Trim().ToLower().Equals(roleName.ToLower().Trim()));
            }
        }


        public async Task<Role> GetRoleByNameAsync(string roleName)
        {

            using (var context = new AppContext())
            {
                return await context.Set<Role>().FirstOrDefaultAsync(x => x.RoleName.Trim().ToLower().Equals(roleName.ToLower().Trim()));
            }
        }

        public async Task<List<string>> GetAllRolesAsync()
        {

            using (var context = new AppContext())
            {
                return await context.Set<Role>().Select(x => x.RoleName).ToListAsync();

            }
        }


        public async Task CreateUser(UserModel model)
        {
            if (model.UserName.Trim().Length == 0)
            {
                throw new Exception("El nombre de usuario esta vacio");
            }
            else if (model.PassWord.Trim().Length == 0)
            {
                throw new Exception("la clave  del usuario esta vacioa");
            }
            else if (!(await DoesRollExistsAsync(model.Role)))
            {
                throw new Exception("El rol no existe");
            }
            var user = await GetUserByUserNameAsync(model.UserName);
            if (user != null)
            {
                throw new Exception("El usuario ya existe!");
            }
            var role = await GetRoleByNameAsync(model.Role);
            using (var context = new AppContext())
            {
                user = new Usuario
                {
                    Nombre = model.Nombre.Trim().ToLower(),
                    Password = model.PassWord,
                    RoleId = role.Id,
                    UserName = model.UserName.Trim().ToLower()
                };
                context.Add(user);
                context.SaveChanges();
            }
        }

        public async Task<List<UserTableModel>> buscarUsuario(string buscar)
        {

            using (var context = new AppContext())
            {
                return await context.Set<Usuario>().Select(x => new UserTableModel { Nombre = x.Nombre }).Where(x => x.Nombre.Trim().ToLower().Contains(buscar)).ToListAsync(); 
            }
         }
    }   
}


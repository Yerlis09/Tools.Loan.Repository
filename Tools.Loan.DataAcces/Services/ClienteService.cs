using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Loan.Domain;
using Tools.Loan.Shared;

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

        public async Task<Cliente> LerrClientePorIndentificacion(string identityficacion)
        {        
            using (AppContext con = new AppContext())
            {
                return await con.Set<Cliente>().Where(x => x.Identificacion.Equals(identityficacion)).FirstOrDefaultAsync();
            }
        }

        public async Task CrearClienteAsync(CrearClienteModel model)
        {

            var cliente = await LerrClientePorIndentificacion(model.Identificacion);
            if(cliente != null )
            {
                throw new Exception("Estenumero de cedula ya existe !");

            }
            if (model == null)
            {
                throw new Exception("esta vacio");
            }
            
            using (AppContext con = new AppContext())
            {
                var client = new Cliente
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Cargo = model.Cargo,
                    Identificacion = model.Identificacion


                };


                con.Set<Cliente>().Add(client);
                await con.SaveChangesAsync();

            }
        }
    
        public async Task<bool> ExisteCliente(string id ,string  identi)
        {
            if (!int.TryParse(id, out var clientId))
            {
                 throw new Exception("la cadena que enviaste no es un numero");
            }
            using (var context = new AppContext())
            {
                return await context.Set<Cliente>().AnyAsync(x => x.Id.Equals(clientId));
            }

        }

        public async Task<List<clientTableModel>> GetAllClientAsync()
        {

            using (var context = new AppContext())
            {
                return await context.Set<Cliente>().Select(x => new clientTableModel {Id= Convert.ToInt32(x.Id), Identificacion = Convert.ToInt32(x.Identificacion), Nombre = x.Nombre, Apellido = x.Apellido, Cargo = x.Cargo }).ToListAsync();
            }
        }

        public async Task BorrarClienteAsync(int id)
        {
            var cliente = await GetClienteByIdAsync(id);
            if (cliente == null)
            {
                throw new Exception("La Cliente no existe");
            }

            using (var con = new AppContext())
            {

                con.Remove(cliente);

                await con.SaveChangesAsync();
            }

        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            using (AppContext con = new AppContext())
            {

                return await con.Set<Cliente>().FirstOrDefaultAsync(cliente => cliente.Id.Equals(id));
            }
        }

    }
}


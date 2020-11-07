using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Loan.Domain;
using Tools.Loan.Shared;

namespace Tools.Loan.DataAcces.Services
{
    public class HerramientaService
    {
        public async Task CrearHerramientasAsync(CrearHerrramintaModel model)
        {
            if (model == null)
                throw new Exception("el modelo esta bacio");
            using (AppContext con = new AppContext())
            {
                var categoria = await con.Set<Categoria>().FirstOrDefaultAsync(x => x.Nombre.Trim().ToLower().Equals(model.Nombre.ToLower().Trim()));
                if (categoria is null)
                {
                    categoria = new Categoria
                    {
                        Nombre = model.Nombre.Trim().ToUpper(),
                    };
                    con.Set<Categoria>().Add(categoria);
                }

                var meta = new HerramientaMetaData
                {
                    Categoria = categoria,
                    CategoriaId = categoria.Id,
                    Marca = model.Marca,
                    Nombre = model.Nombre,
                    Serial = model.Serial,
                };
                for (int i = 0; i < model.Stock; i++)
                {
                    meta.Herramientas.Add(new Herramienta());
                }
                con.Set<HerramientaMetaData>().Add(meta);
                await con.SaveChangesAsync();

            }
        }

        public async Task<List<string>> GetAllCategoriesAsync()
        {
            using (AppContext con = new AppContext())
            {
                return await con.Set<Categoria>().Select(x => x.Nombre).ToListAsync();
            }
        }


        public async Task<Herramienta> GetHerramientaByIdAsync(int id)
        {
            using (AppContext con = new AppContext())
            {

                return await con.Set<Herramienta>().FirstOrDefaultAsync(herramienta => herramienta.Id.Equals(id));
            }
        }


        // aqui tienes un ejemeplo

        public async Task<List<HerramientTableModel>> GetHerramientaTableAsync()
        {
            using (AppContext con = new AppContext())
            {
                return await con.Set<Herramienta>().Include(x => x.Prestamos).Include(x => x.HerramientaMetaData).ThenInclude(x => x.Categoria).Select(x => new HerramientTableModel
                {
                    Categoria = (x.HerramientaMetaData.Categoria == null) ? "N/A" : x.HerramientaMetaData.Categoria.Nombre,
                    Descripción = x.Descripción,
                    FechaRentada = (x.Rentada == null) ? "N/A" : x.Rentada.Value.ToString(),
                    Rentada = (x.Rentada == null) ? "NO" : "SI",
                    Id = x.Id,
                    Marca = x.HerramientaMetaData.Marca,
                    Nombre = x.HerramientaMetaData.Nombre,
                    Puesto = x.Puesto,
                    Serial = x.HerramientaMetaData.Serial,
                    PrestamosEnTotal = x.Prestamos.Count.ToString()


                }).ToListAsync();
            }
        }

        public async Task<List<Tools.Loan.Shared.HerramientasDisponiblesTableModel>> HerramientasDisponiblesAsync()
        {
            using (AppContext con = new AppContext())
            {
                return await con.Set<Herramienta>().Where(x => x.Rentada == null).Include(x => x.HerramientaMetaData).ThenInclude(x => x.Categoria).Select(x => new Tools.Loan.Shared.HerramientasDisponiblesTableModel
                {
                    Categoria = (x.HerramientaMetaData.Categoria == null) ? "N/A" : x.HerramientaMetaData.Categoria.Nombre,
                    Descripción = x.Descripción,
                    Id = x.Id,
                    Marca = x.HerramientaMetaData.Marca,
                    Nombre = x.HerramientaMetaData.Nombre,
                    Puesto = x.Puesto,
                    Serial = x.HerramientaMetaData.Serial,



                }).ToListAsync();
            }
        }

        public async Task<List<HerramientaHistoryModel>> GetHerramientaHistoryAsync(int Id)
        {
            using (AppContext con = new AppContext())
            {
                return await con.Set<Prestamo>()
                    .Include(x => x.Usuario)
                    .Include(x => x.Cliente)
                    .Include(x => x.Herramienta)
                    .ThenInclude(x => x.HerramientaMetaData).Where(x => x.HerramientaId == Id)
                    .Select(x => new HerramientaHistoryModel
                    {
                        Id = x.HerramientaId,
                        Marca = x.Herramienta.HerramientaMetaData.Marca,
                        Nombre = x.Herramienta.HerramientaMetaData.Nombre,
                        Descripción = x.Descripción,
                        Serial = x.Herramienta.HerramientaMetaData.Serial,
                        UsuarioEncargado = x.Usuario.Nombre,
                        HerramientaId = x.HerramientaId.ToString(),
                        Cliente = x.Cliente.Nombre,
                        FechaEntrada = x.FechaEntrada.ToString(),
                        FechaSalida = x.FechaSalida.ToString()
                    }).ToListAsync();
            }
        }

        public async Task ActualizarHerramientaAsync(HerramientaModel model)
        {
            var herramienta = await GetHerramientaByIdAsync(model.Id);
            if (herramienta == null)
            {
                throw new Exception("La herrameinta no existe");
            }

            using (var con = new AppContext())
            {
                herramienta.Puesto = model.Puesto;
                herramienta.Descripción = model.Descripción;
                con.Update(herramienta);

                await con.SaveChangesAsync();
            }

        }

        public async Task BorrarHerramientaAsync(int id)
        {
            var herramienta = await GetHerramientaByIdAsync(id);
            if (herramienta == null)
            {
                throw new Exception("La herrameinta no existe");
            }

            using (var con = new AppContext())
            {

                con.Remove(herramienta);

                await con.SaveChangesAsync();
            }

        }


        public async Task DevolverHerramientaAsync(List<DevolverHeramientaModel> ids)
        {
            using (var T = await new AppContext().Database.BeginTransactionAsync())
            {
                using (var con = new AppContext())
                {
                    foreach (var i in ids)
                    {
                        var h = await GetHerramientaByIdAsync(i.HerramientaId);
                        if (h == null || h.Rentada == null)
                        {
                            throw new Exception(" esta herraminta no existe o no esta disponible id:" + h?.Id);
                        }
                        var p = await con.Set<Prestamo>().Where(x => x.Id.Equals(i.PrestamoId)).FirstOrDefaultAsync();
                        if (p == null || p.HerramientaDevultaFecha != null)
                        {
                            throw new Exception(" esta prestamo no existe o no esta disponible id:" + p?.Id);
                        }
                        h.Rentada = null;
                        p.HerramientaDevultaFecha = DateTime.Now;
                        con.Update(h);
                        con.Update(p);


                    }
                    try
                    {
                        await con.SaveChangesAsync();
                        T.Commit();
                    }
                    catch (Exception e)
                    {
                        T.Rollback();
                        throw e;
                    }
                }
            }

        }

        public async Task<List<HerramientasPrestadasTableModel>> HerramientaPrestadasAsync()
        {


            using (var con = new AppContext())
            {

                var query = con.Set<Prestamo>();
                var clientequery = con.Set<Cliente>().AsQueryable();
                var herramientasQuery = con.Set<Herramienta>().AsQueryable();
                var UsuarioQuery = con.Set<Usuario>().AsQueryable();
                var rs = (from q in query
                          join c in clientequery on q.ClienteId equals c.Id
                          join h in herramientasQuery on q.HerramientaId equals h.Id
                          join u in UsuarioQuery on q.UsuarioId equals u.Id
                          where h.Rentada != null
                          select
                          new HerramientasPrestadasTableModel
                          {
                              Address = c.Address,
                              Apellido = c.Apellido,
                              HerramientaId = h.Id,
                              HerramintasPorNombre = h.HerramientaMetaData.Nombre,
                              Identificacion = c.Identificacion,
                              Nombre = c.Nombre,
                              TotalDeherrametas = herramientasQuery.Where(x => x.Prestamos.Any(y => y.ClienteId == c.Id)).Count(),
                              UsuariosQueGestionaron = u.Nombre,
                              RentaRetrasada = (q.FechaSalida - DateTime.Now).TotalDays > -1 ? string.Format("Le quedan  {0} Dias para entregar", (int)(q.FechaSalida - DateTime.Now).TotalDays) : "La Entrega esta retrasada",
                              FechaEntrada = q.FechaEntrada.ToString(),
                              FechaSalida = q.FechaSalida.ToString(),
                              ClienteId = c.Id.ToString(),
                              PrestamoId = q.Id.ToString()

                          }
                                                  );

                return await rs.ToListAsync();

            }

        }




        public async Task RentarHerramientasAsync(RentarHerramientaModel model)
        {
            using (var T = await new AppContext().Database.BeginTransactionAsync())
            {
                using (var con = new AppContext())
                {
                    foreach (var i in model.Herramientas)
                    {
                        var h = await GetHerramientaByIdAsync(i);
                        if (h == null || h.Rentada != null)
                        {
                            throw new Exception(" esta herraminta no existe o no esta disponible id:" + h?.Id);
                        }
                        h.Rentada = DateTime.Now;
                        con.Set<Herramienta>().Update(h);
                        con.Set<Prestamo>().Add(
                        new Prestamo
                        {
                            HerramientaId = i,
                            ClienteId = model.ClienteId,
                            Descripción = model.Description,
                            FechaEntrada = DateTime.Now,
                            FechaSalida = model.FechaDeSalida,
                            UsuarioId = model.UsuarioId

                        });

                    }
                    try
                    {
                        await con.SaveChangesAsync();
                        T.Commit();
                    }
                    catch (Exception e)
                    {
                        T.Rollback();
                        throw e;
                    }
                }
            }

        }
    }
}

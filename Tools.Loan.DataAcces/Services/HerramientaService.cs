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


        // aqui tienes un ejemeplo

        public async Task<List<HerramientTableModel>> GetHerramientaTableAsync()
        {
            using (AppContext con = new AppContext())
            {
                return await con.Set<Herramienta>().Include(x=> x.Prestamos).Include(x=> x.HerramientaMetaData).ThenInclude(x=> x.Categoria).Select(x => new HerramientTableModel 
                {
                    Categoria = (x.HerramientaMetaData.Categoria== null)?"N/A": x.HerramientaMetaData.Categoria.Nombre,
                    Descripción = x.Descripción,
                    FechaRentada = (x.Rentada == null)?"N/A":x.Rentada.Value.ToString(),
                    Rentada = (x.Rentada == null) ? "NO":"SI",
                    Id = x.Id,
                    Marca = x.HerramientaMetaData.Marca,
                    Nombre =  x.HerramientaMetaData.Nombre,
                    Puesto = x.Puesto,
                    Serial = x.HerramientaMetaData.Serial,
                    PrestamosEnTotal = x.Prestamos.Count.ToString()

                    
                }).ToListAsync();
            }
         }


        public async Task<List<HerramientaHistoryModel>> GetHerramientaHistoryAsync(int Id)
        {
            using (AppContext con = new AppContext())
            {
                return await con.Set<Prestamo>()
                    .Include(x=> x.Usuario)
                    .Include(x=> x.Cliente)
                    .Include(x => x.Herramienta)
                    .ThenInclude(x => x.HerramientaMetaData).Where(x=> x.HerramientaId == Id)
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



        public async Task PrestarHerramientaAsync(CrearHerrramintaModel model)
        {
            throw new NotImplementedException();
        }
    }
}

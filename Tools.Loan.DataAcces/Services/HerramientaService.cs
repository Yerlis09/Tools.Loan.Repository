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
            using(AppContext con = new AppContext())
            {
                var categoria = await con.Set<Categoria>().FirstOrDefaultAsync(x => x.Nombre == model.Nombre);
                if(categoria is null)
                    throw new Exception("Categoria no encontrada");

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

            }
        }

        // aqui tienes un ejemeplo
        public async Task PrestarHerramientaAsync(CrearHerrramintaModel model)
        {
            if (model == null)
                throw new Exception("el modelo esta bacio");
            using (AppContext con = new AppContext())
            {
                var categoria = await con.Set<Categoria>().FirstOrDefaultAsync(x => x.Nombre == model.Nombre);
                if (categoria is null)
                    throw new Exception("Categoria no encontrada");

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

            }
        }
    }
}

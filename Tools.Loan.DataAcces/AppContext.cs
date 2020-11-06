using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tools.Loan.Domain;


namespace Tools.Loan.DataAcces
{
   public class AppContext:DbContext
    {
        public AppContext()
        {
            //this.Database.EnsureCreated();
            //this.Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.AppSettings.Get("con"));
           
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasKey(x => x.Id);
            modelBuilder.Entity<Role>().HasData(
           new Role
           {
               Id= 1,
               RoleName = "Admin",

           },
            new Role
            {
                Id = 2,
                RoleName = "Encargado",

            }

           );
            modelBuilder.Entity<Role>().HasIndex(x => x.RoleName).IsUnique();

            modelBuilder.Entity<Usuario>().HasKey(usuario => usuario.Id);
            // esto es para llenar la base que datos sin necidad de yo hacerlo manuelamente al crearla 
            modelBuilder.Entity<Usuario>().HasData(new Usuario { Id = 1, Nombre = "Admin", Password = "123", UserName = "Admin", RoleId = 1 });
           
            modelBuilder.Entity<Usuario>().HasOne(x => x.Role).WithMany(x=> x.Usuarios).HasForeignKey(x=> x.RoleId);
            modelBuilder.Entity<Usuario>().HasIndex(x => x.UserName).IsUnique();
            modelBuilder.Entity<Usuario>().Property(x => x.UserName).IsRequired();
            modelBuilder.Entity<Cliente>().HasKey(x => x.Id);
            modelBuilder.Entity<Cliente>().HasData(new Cliente
            {
                Address = "Solgat",
                Id = 1,
                Apellido = "wilimardo",
                Nombre = "Wili"

            }); ;

            modelBuilder.Entity<Herramienta>().HasKey(x => x.Id);
            modelBuilder.Entity<Herramienta>().HasOne(x => x.HerramientaMetaData).WithMany(x=> x.Herramientas).HasForeignKey(x=> x.HerramientaMetaDataID);
            modelBuilder.Entity<Herramienta>().HasData(new Herramienta { Id = 1, Descripción = "N/A", HerramientaMetaDataID = 1 },
                                  new Herramienta { Id = 2, Descripción = "N/A", HerramientaMetaDataID = 1 },
                                  new Herramienta { Id = 3, Descripción = "N/A", HerramientaMetaDataID = 1 },
                                  new Herramienta { Id = 4, Descripción = "N/A", HerramientaMetaDataID = 1 });
            modelBuilder.Entity<HerramientaMetaData>().HasKey(x => x.Id);
            modelBuilder.Entity<HerramientaMetaData>().HasMany(x => x.Herramientas).WithOne(x => x.HerramientaMetaData).HasForeignKey(x => x.HerramientaMetaDataID);
            modelBuilder.Entity<HerramientaMetaData>().HasOne(x => x.Categoria).WithMany(x => x.HerramientaMetaDatas).HasForeignKey(x => x.CategoriaId).IsRequired(false);
            modelBuilder.Entity<HerramientaMetaData>().HasData(new HerramientaMetaData
            { 
                 
                   
                          
                             Nombre ="Martillo",
                             Marca ="Cat",
                             Serial = "AFFFD234",
                              Id = 1,
                  
                         
                     
                    
            
            });



            modelBuilder.Entity<Categoria>().HasKey(x => x.Id);
            modelBuilder.Entity<Categoria>().HasMany(x => x.HerramientaMetaDatas).WithOne(x=> x.Categoria).HasForeignKey(x=> x.CategoriaId).IsRequired(false);
            modelBuilder.Entity<Categoria>().HasIndex(x => x.Nombre).IsUnique();
            modelBuilder.Entity<Prestamo>().HasKey(x => x.Id);
            modelBuilder.Entity<Prestamo>().HasData(new Prestamo { 
            Id = 1,
            ClienteId = 1,
            Descripción ="Presto un martillo ",
            FechaEntrada = DateTime.UtcNow,
                FechaSalida = DateTime.UtcNow.AddDays(3),
               HerramientaId = 1,
               UsuarioId = 1

            });
            modelBuilder.Entity<Prestamo>().HasOne(x => x.Usuario).WithMany(x => x.Prestamos).HasForeignKey(x => x.UsuarioId);
            modelBuilder.Entity<Prestamo>().HasOne(x => x.Cliente).WithMany(x => x.Prestamos).HasForeignKey(x => x.ClienteId);
            modelBuilder.Entity<Prestamo>().HasOne(x => x.Herramienta).WithMany(x => x.Prestamos).HasForeignKey(x => x.HerramientaId);

            base.OnModelCreating(modelBuilder);
        }
    }

}

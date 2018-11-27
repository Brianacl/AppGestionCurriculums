using AppGestionCurriculums.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppGestionCurriculums.Data
{
    public class DBContext : DbContext
    {
        private readonly string FicDataBasePath;

        public DBContext(string FicPaDataBasePath)
        {
            FicDataBasePath = FicPaDataBasePath;
            FicMetCrearBD();
        }

        private async void FicMetCrearBD()
        {
            try
            {
                //FIC: Se crea la base de datos en base el esquema
                await Database.EnsureCreatedAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - DbContext", e.Message.ToString(), "OK");
            }

        }//ESTE METODO CREA LA BASE DE DATOS

        protected async override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlite($"Filename={FicDataBasePath}");
                optionsBuilder.EnableSensitiveDataLogging();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - OnConfiguring", e.Message.ToString(), "OK");
            }
        }//CONFIGURACION DE LA CONEXION

        public DbSet<Eva_carrera_grado_estudios> eva_grado_estudios { get; set; }
        public DbSet<Eva_curriculo_idiomas> eva_curriculo_idiomas { get; set; }
        public DbSet<Eva_actividades_funciones> eva_actividades_funciones { get; set; }

        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Entity<Eva_carrera_grado_estudios>()
                       .HasKey(c => new { c.IdGradoEstudio });

                modelBuilder.Entity<Eva_curriculo_idiomas>()
                    .HasKey(c => new { c.IdIdioma });

                modelBuilder.Entity<Eva_actividades_funciones>()
                    .HasKey(c => new { c.IdFuncionAct });
            }
            catch(Exception e)
            {
                await new Page().DisplayAlert("ALERTA - OnModelCreting", e.Message.ToString(), "OK");
            }
        }
    }//Fin clase
}

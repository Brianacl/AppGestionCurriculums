using System;
using System.Collections.Generic;
using System.Text;
using AppGestionCurriculums.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace AppGestionCurriculums.Data
{
    public class FicDBContext : DbContext
    {
        private readonly string FicDataBasePath;

        public FicDBContext(string FicPaDataBasePath)
        {
            FicDataBasePath = FicPaDataBasePath;
            FicMetCrearDB();
        }

        private async void FicMetCrearDB()
        {
            try
            {
                await Database.EnsureCreatedAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("Alerta", "DBContext" + e.Message.ToString(), "ok");
            }
        }

        protected async override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlite($"Filename={FicDataBasePath}");
                optionsBuilder.EnableSensitiveDataLogging();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("Alerta", e.Message.ToString(), "ok");
            }
        }

        public DbSet<Eva_curriculo_referencias> eva_Curriculo_Referencias { get; set; }
        public DbSet<Eva_experiencia_laboral> eva_Experiencia_Laborals { get; set; }

        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Entity<Eva_curriculo_referencias>().HasKey(c => new { c.IdReferencia });

                modelBuilder.Entity<Eva_experiencia_laboral>().HasKey(c => new { c.IdExperiencia });
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("alerta", e.Message.ToString(), "ok");
            }
        }
        
    }
}

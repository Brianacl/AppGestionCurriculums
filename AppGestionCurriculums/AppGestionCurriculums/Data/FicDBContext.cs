﻿using AppGestionCurriculums.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
//using System.Web;
using Xamarin.Forms;

namespace AppGestionCurriculums.Data
{
    public class FicDBContext : DbContext
    {
        private readonly string FicDataBasePath;
        public Boolean alreadyDBcreated;

        public FicDBContext(string FicPaDataBasePath)
        {
            alreadyDBcreated = true;
            FicDataBasePath = FicPaDataBasePath;
            FicMetCrearDB();
            
        }

        private async void FicMetCrearDB()
        {
            try
            {
                //FIC: Se crea la base de datos en base el esquema
                await Database.EnsureCreatedAsync();
                alreadyDBcreated = false;           
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA FicDBContext", e.Message.ToString() + " 6", "OK");
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
                await new Page().DisplayAlert("ALERTA", e.Message.ToString() + " 3", "OK");
            }
        }//CONFIGURACION DE LA CONEXION
        
        public void AddDataPersonas(string idDom,string idTel,string idDir,string numCtrl,string nom,string apPat,string apMat,string rfc,string curp,string fnac,string sex,string freg,string fmod,string ureg,string umod,string act,string bor)
        {
            int numPersonas=0;
            using (SqliteConnection db =
                new SqliteConnection($"Filename={FicDataBasePath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "SELECT COUNT(*) FROM Rh_cat_personas;";
                numPersonas = Convert.ToInt32(insertCommand.ExecuteScalar());
                if (numPersonas <= 4)
                {
                    insertCommand.CommandText = "INSERT INTO Rh_cat_personas (IdDomicilio,IdTelefono,IdDirWeb,NumControl,Nombre,ApPaterno,ApMaterno, RFC,CURP,FechaNac,Sexo,FechaReg, FechaUltMod,UsuarioReg,UsuarioMod,Activo,Borrado) VALUES (@Entry1,@Entry2,@Entry3,@Entry4,@Entry5,@Entry6,@Entry7,@Entry8,@Entry9,@Entry10,@Entry11,@Entry12,@Entry13,@Entry14,@Entry15,@Entry16,@Entry17);";
                    insertCommand.Parameters.AddWithValue("@Entry1", idDom);
                    insertCommand.Parameters.AddWithValue("@Entry2", idTel);
                    insertCommand.Parameters.AddWithValue("@Entry3", idDir);
                    insertCommand.Parameters.AddWithValue("@Entry4", numCtrl);
                    insertCommand.Parameters.AddWithValue("@Entry5", nom);
                    insertCommand.Parameters.AddWithValue("@Entry6", apPat);
                    insertCommand.Parameters.AddWithValue("@Entry7", apMat);
                    insertCommand.Parameters.AddWithValue("@Entry8", rfc);
                    insertCommand.Parameters.AddWithValue("@Entry9", curp);
                    insertCommand.Parameters.AddWithValue("@Entry10", fnac);
                    insertCommand.Parameters.AddWithValue("@Entry11", sex);                   
                    insertCommand.Parameters.AddWithValue("@Entry12", freg);
                    insertCommand.Parameters.AddWithValue("@Entry13", fmod);
                    insertCommand.Parameters.AddWithValue("@Entry14", ureg);
                    insertCommand.Parameters.AddWithValue("@Entry15", umod);
                    insertCommand.Parameters.AddWithValue("@Entry16", act);
                    insertCommand.Parameters.AddWithValue("@Entry17", bor);
                    insertCommand.ExecuteReader();
                }                
                db.Close();
            }

        }

        public void AddDataCurriculo(string idPer, string freg, string fmod, string ureg, string umod, string act, string bor)
        {
            int numPersonas = 0;
            using (SqliteConnection db =
                new SqliteConnection($"Filename={FicDataBasePath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "SELECT COUNT(*) FROM Eva_curriculo_persona;";
                numPersonas = Convert.ToInt32(insertCommand.ExecuteScalar());
                if (numPersonas <= 4)
                {
                    insertCommand.CommandText = "INSERT INTO Eva_curriculo_persona (IdPersona, FechaReg, FechaUltMod,UsuarioReg,UsuarioMod,Activo,Borrado) VALUES (@Entry1,@Entry12,@Entry13,@Entry14,@Entry15,@Entry16,@Entry17);";
                    insertCommand.Parameters.AddWithValue("@Entry1", idPer);
                    insertCommand.Parameters.AddWithValue("@Entry12", freg);
                    insertCommand.Parameters.AddWithValue("@Entry13", fmod);
                    insertCommand.Parameters.AddWithValue("@Entry14", ureg);
                    insertCommand.Parameters.AddWithValue("@Entry15", umod);
                    insertCommand.Parameters.AddWithValue("@Entry16", act);
                    insertCommand.Parameters.AddWithValue("@Entry17", bor);
                    insertCommand.ExecuteReader();
                }
                db.Close();
            }

        }

        public void AddDataDomicilio(string idDom, string dom, string eCalle1, string eCalle2, string cp, string pais, string estado, string mun, string colonia, string freg, string fmod, string ureg, string umod, string act, string bor)
        {
            int numPersonas = 0;
            using (SqliteConnection db =
                new SqliteConnection($"Filename={FicDataBasePath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "SELECT COUNT(*) FROM Rh_cat_domicilios;";
                numPersonas = Convert.ToInt32(insertCommand.ExecuteScalar());
                if (numPersonas <= 4)
                {
                    insertCommand.CommandText = "INSERT INTO Rh_cat_domicilios (IdDomicilio,Domicilio,EntreCalle1,EntreCalle2,CodigoPostal,Pais,Estado, Municipio,Colonia,FechaReg, FechaUltMod,UsuarioReg,UsuarioMod,Activo,Borrado) VALUES (@Entry1,@Entry2,@Entry3,@Entry4,@Entry5,@Entry6,@Entry7,@Entry8,@Entry9,@Entry10,@Entry11,@Entry12,@Entry13,@Entry14,@Entry15);";
                    insertCommand.Parameters.AddWithValue("@Entry1", idDom);
                    insertCommand.Parameters.AddWithValue("@Entry2", dom);
                    insertCommand.Parameters.AddWithValue("@Entry3", eCalle1);
                    insertCommand.Parameters.AddWithValue("@Entry4", eCalle2);
                    insertCommand.Parameters.AddWithValue("@Entry5", cp);
                    insertCommand.Parameters.AddWithValue("@Entry6", pais);
                    insertCommand.Parameters.AddWithValue("@Entry7", estado);
                    insertCommand.Parameters.AddWithValue("@Entry8", mun);
                    insertCommand.Parameters.AddWithValue("@Entry9", colonia);
                    insertCommand.Parameters.AddWithValue("@Entry10", freg);
                    insertCommand.Parameters.AddWithValue("@Entry11", fmod);
                    insertCommand.Parameters.AddWithValue("@Entry12", ureg);
                    insertCommand.Parameters.AddWithValue("@Entry13", umod);
                    insertCommand.Parameters.AddWithValue("@Entry14", act);
                    insertCommand.Parameters.AddWithValue("@Entry15", bor);
                    insertCommand.ExecuteReader();
                }
                db.Close();
            }

        }

        public void AddDataTelefono(string idTel, string numTel, string freg, string fmod, string ureg, string umod, string act, string bor)
        {
            int numPersonas = 0;
            using (SqliteConnection db =
                new SqliteConnection($"Filename={FicDataBasePath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "SELECT COUNT(*) FROM Rh_cat_telefonos;";
                numPersonas = Convert.ToInt32(insertCommand.ExecuteScalar());
                if (numPersonas <= 4)
                {
                    insertCommand.CommandText = "INSERT INTO Rh_cat_telefonos (IdTelefono,NumTelefono,FechaReg, FechaUltMod,UsuarioReg,UsuarioMod,Activo,Borrado) VALUES (@Entry1,@Entry2,@Entry10,@Entry11,@Entry12,@Entry13,@Entry14,@Entry15);";
                    insertCommand.Parameters.AddWithValue("@Entry1", idTel);
                    insertCommand.Parameters.AddWithValue("@Entry2", numTel);
                    insertCommand.Parameters.AddWithValue("@Entry10", freg);
                    insertCommand.Parameters.AddWithValue("@Entry11", fmod);
                    insertCommand.Parameters.AddWithValue("@Entry12", ureg);
                    insertCommand.Parameters.AddWithValue("@Entry13", umod);
                    insertCommand.Parameters.AddWithValue("@Entry14", act);
                    insertCommand.Parameters.AddWithValue("@Entry15", bor);
                    insertCommand.ExecuteReader();
                }
                db.Close();
            }

        }

        public void AddDataDirWeb(string idDirWeb, string dirWeb, string freg, string fmod, string ureg, string umod, string act, string bor)
        {
            int numPersonas = 0;
            using (SqliteConnection db =
                new SqliteConnection($"Filename={FicDataBasePath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "SELECT COUNT(*) FROM Rh_cat_dir_web;";
                numPersonas = Convert.ToInt32(insertCommand.ExecuteScalar());
                if (numPersonas <= 4)
                {
                    insertCommand.CommandText = "INSERT INTO Rh_cat_dir_web (IdDirweb,DireccionWeb,FechaReg, FechaUltMod,UsuarioReg,UsuarioMod,Activo,Borrado) VALUES (@Entry1,@Entry2,@Entry10,@Entry11,@Entry12,@Entry13,@Entry14,@Entry15);";
                    insertCommand.Parameters.AddWithValue("@Entry1", idDirWeb);
                    insertCommand.Parameters.AddWithValue("@Entry2", dirWeb);
                    insertCommand.Parameters.AddWithValue("@Entry10", freg);
                    insertCommand.Parameters.AddWithValue("@Entry11", fmod);
                    insertCommand.Parameters.AddWithValue("@Entry12", ureg);
                    insertCommand.Parameters.AddWithValue("@Entry13", umod);
                    insertCommand.Parameters.AddWithValue("@Entry14", act);
                    insertCommand.Parameters.AddWithValue("@Entry15", bor);
                    insertCommand.ExecuteReader();
                }
                db.Close();
            }

        }
        public DbSet<Eva_curriculo_competencias> eva_curriculo_competencias { get; set; }
        public DbSet<Eva_curriculo_persona> eva_curriculo_persona { get; set; }
        public DbSet<Rh_cat_personas> rh_cat_personas { get; set; }
        public DbSet<Rh_cat_domicilios> rh_cat_domicilios { get; set; }
        public DbSet<Rh_cat_telefonos> rh_cat_telefonos { get; set; }
        public DbSet<Rh_cat_dir_web> rh_cat_dir_web { get; set; }

        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Entity<Eva_curriculo_competencias>().HasKey(pk => new { pk.IdCompetencia });
                modelBuilder.Entity<Eva_curriculo_persona>().HasKey(pk => new { pk.IdCurriculo });
                modelBuilder.Entity<Rh_cat_personas>().HasKey(pk => new { pk.IdPersona });
                modelBuilder.Entity<Rh_cat_telefonos>().HasKey(pk => new { pk.IdTelefono });
                modelBuilder.Entity<Rh_cat_domicilios>().HasKey(pk => new { pk.IdDomicilio });
                modelBuilder.Entity<Rh_cat_dir_web>().HasKey(pk => new { pk.IdDirWeb });
                /*
                modelBuilder.Entity<Eva_curriculo_competencias>().HasOne(f => eva_curriculo_persona).WithMany().
                    HasForeignKey(f => new { f.IdCurriculo });

                modelBuilder.Entity<Eva_curriculo_persona>().HasOne(f => rh_cat_personas).WithMany().
                    HasForeignKey(f => new { f.IdPersona });

                modelBuilder.Entity<Rh_cat_telefonos>().HasOne(f => rh_cat_personas).WithMany().
                     HasForeignKey(f => new { f.IdTelefono});

                modelBuilder.Entity<Rh_cat_domicilios>().HasOne(f => rh_cat_personas).WithMany().
                     HasForeignKey(f => new { f.IdDomicilio });

                modelBuilder.Entity<Rh_cat_dir_web>().HasOne(f => rh_cat_personas).WithMany().
                     HasForeignKey(f => new { f.IdDirWeb });*/
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString() + " 5", "OK");
            }

        }
    }
}

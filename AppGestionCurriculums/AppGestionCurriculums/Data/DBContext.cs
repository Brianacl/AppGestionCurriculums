using AppGestionCurriculums.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
//using System.Web;
using Xamarin.Forms;

namespace AppGestionCurriculums.Data
{
    public class DBContext : DbContext
    {
        private readonly string FicDataBasePath;
        public Boolean alreadyDBcreated;

        public DBContext(string FicPaDataBasePath)
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
        
        public void AddDataPersonas(int idDom, int idTel, int idDir,string numCtrl,string nom,string apPat,string apMat,string rfc,string curp,string fnac,string sex,string freg,string fmod,string ureg,string umod,string act,string bor)
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
        
        public void AddDataCurriculo(int idPer, string freg, string fmod, string ureg, string umod, string act, string bor)
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

        public void AddDataDomicilio(int idDom, string dom, string eCalle1, string eCalle2, string cp, string pais, string estado, string mun, string colonia, string freg, string fmod, string ureg, string umod, string act, string bor)
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

        public void AddDataTelefono(int idTel, string numTel, string freg, string fmod, string ureg, string umod, string act, string bor)
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

        public void AddDataDirWeb(int idDirWeb, string dirWeb, string freg, string fmod, string ureg, string umod, string act, string bor)
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

        public void AddDataGiroExperienciaLaboral(int IdTipoGeneral, int IdGeneral, string DesGeneral)
        {
            int numPersonas = 0;
            using (SqliteConnection db =
                new SqliteConnection($"Filename={FicDataBasePath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "SELECT COUNT(*) FROM Tipo_gen_giro_experienciaLaboral;";
                numPersonas = Convert.ToInt32(insertCommand.ExecuteScalar());
                if (numPersonas <= 4)
                {
                    insertCommand.CommandText = "INSERT INTO Tipo_gen_giro_experienciaLaboral (IdTipoGeneral,IdGeneral,DesGeneral)" +
                        " VALUES (@Entry1,@Entry2,@Entry3);";
                    insertCommand.Parameters.AddWithValue("@Entry1", IdTipoGeneral);
                    insertCommand.Parameters.AddWithValue("@Entry2", IdGeneral);
                    insertCommand.Parameters.AddWithValue("@Entry10", DesGeneral);
                   
                    insertCommand.ExecuteReader();
                }
                db.Close();
            }

        }

        public void AddDataGenParentezcoReferencias(int IdTipoGeneral, int IdGeneral, string DesGeneral)
        {
            int numPersonas = 0;
            using (SqliteConnection db =
                new SqliteConnection($"Filename={FicDataBasePath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "SELECT COUNT(*) FROM Tipo_gen_parentezco_referencias;";
                numPersonas = Convert.ToInt32(insertCommand.ExecuteScalar());
                if (numPersonas <= 4)
                {
                    insertCommand.CommandText = "INSERT INTO Tipo_gen_parentezco_referencias (IdTipoGeneral,IdGeneral,DesGeneral)" +
                        " VALUES (@Entry1,@Entry2,@Entry3);";
                    insertCommand.Parameters.AddWithValue("@Entry1", IdTipoGeneral);
                    insertCommand.Parameters.AddWithValue("@Entry2", IdGeneral);
                    insertCommand.Parameters.AddWithValue("@Entry10", DesGeneral);

                    insertCommand.ExecuteReader();
                }
                db.Close();
            }

        }


        //Betsy
        public DbSet<Eva_curriculo_competencias> eva_curriculo_competencias { get; set; }
        public DbSet<Eva_curriculo_persona> eva_curriculo_persona { get; set; }
        public DbSet<Rh_cat_personas> rh_cat_personas { get; set; }
        public DbSet<Rh_cat_domicilios> rh_cat_domicilios { get; set; }
        public DbSet<Rh_cat_telefonos> rh_cat_telefonos { get; set; }
        public DbSet<Rh_cat_dir_web> rh_cat_dir_web { get; set; }
        //Brian
        public DbSet<Eva_carrera_grado_estudios> eva_grado_estudios { get; set; }
        public DbSet<Eva_curriculo_idiomas> eva_curriculo_idiomas { get; set; }
        public DbSet<Eva_actividades_funciones> eva_actividades_funciones { get; set; }
        public DbSet<Eva_proyectos> eva_proyectos { get; set; }
        public DbSet<Tipo_gen_grado_estudio> tipo_gen_grado_estudio { get; set; }
        //jjesusmonroy
        public DbSet<Eva_curriculo_herramientas> eva_curriculo_herramientas { get; set; }
        public DbSet<Eva_curriculo_conocimientos> eva_curriculo_conocimientos { get; set; }
        //Alegria 
        public DbSet<Eva_experiencia_laboral> eva_experiencia_laboral { get; set; }
        public DbSet<Eva_curriculo_referencias> eva_curriculo_referencias { get; set; }
        public DbSet<Tipo_gen_giro_experienciaLaboral> tipo_Gen_Giro_ExperienciaLaboral { get; set; }
        public DbSet<Tipo_gen_parentezco_referencias> tipo_gen_parentezco_referencias { get;set; }

        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                //Primary keys
                //Betsy
                modelBuilder.Entity<Eva_curriculo_competencias>()
                    .HasKey(pk => new { pk.IdCompetencia });

                modelBuilder.Entity<Eva_curriculo_persona>()
                    .HasKey(pk => new { pk.IdCurriculo });

                modelBuilder.Entity<Rh_cat_personas>()
                    .HasKey(pk => new { pk.IdPersona });

                modelBuilder.Entity<Rh_cat_telefonos>()
                    .HasKey(pk => new { pk.IdTelefono });

                modelBuilder.Entity<Rh_cat_domicilios>()
                    .HasKey(pk => new { pk.IdDomicilio });

                modelBuilder.Entity<Rh_cat_dir_web>()
                    .HasKey(pk => new { pk.IdDirWeb });

                //Brian
                modelBuilder.Entity<Eva_carrera_grado_estudios>()
                      .HasKey(c => new { c.IdUltimoGrado });

                modelBuilder.Entity<Eva_curriculo_idiomas>()
                    .HasKey(c => new { c.IdIdioma });

                modelBuilder.Entity<Eva_actividades_funciones>()
                    .HasKey(c => new { c.IdFuncionAct });

                modelBuilder.Entity<Eva_proyectos>()
                    .HasKey(c => new { c.IdProyecto });

                modelBuilder.Entity<Tipo_gen_grado_estudio>()
                    .HasKey(c => new { c.IdTipoGeneral, c.IdGeneral });

                //peps
                modelBuilder.Entity<Eva_curriculo_herramientas>()
                    .HasKey(c => new { c.IdHerramienta });

                modelBuilder.Entity<Eva_curriculo_conocimientos>()
                    .HasKey(c => new { c.IdConocimiento });

                //Alegria
                modelBuilder.Entity<Eva_experiencia_laboral>()
                    .HasKey(c => new { c.IdExperiencia });

                modelBuilder.Entity<Eva_curriculo_referencias>()
                    .HasKey(c => new { c.IdReferencia });
                modelBuilder.Entity<Tipo_gen_giro_experienciaLaboral>()
                    .HasKey(c => new { c.IdTipoGeneral, c.IdGeneral });
                modelBuilder.Entity<Tipo_gen_parentezco_referencias>()
                    .HasKey(c => new { c.IdTipoGeneral, c.IdGeneral });
         

                //Foreign keys
                //Betsy
                modelBuilder.Entity<Eva_curriculo_competencias>()
                    .HasOne(f => f.eva_curriculo_persona)
                    .WithMany()
                    .HasForeignKey(f => new { f.IdCurriculo });

                modelBuilder.Entity<Eva_curriculo_persona>()
                    .HasOne(f => f.rh_cat_personas).WithMany()
                    .HasForeignKey(f => new { f.IdPersona });

                modelBuilder.Entity<Rh_cat_domicilios>()
                    .HasOne(p => p.rh_Cat_Personas)
                    .WithMany(b => b.Domicilios)
                    .HasForeignKey(p => p.IdPersona)
                    .HasConstraintName("FK_Persona_Domicilios");

                modelBuilder.Entity<Eva_curriculo_persona>()
                    .HasOne(p => p.rh_cat_personas)
                    .WithMany(b => b.Curriculos)
                    .HasForeignKey(p => p.IdCurriculo)
                    .HasConstraintName("FK_Persona_Curriculo");

                modelBuilder.Entity<Eva_curriculo_competencias>()
                    .HasOne(p => p.eva_curriculo_persona)
                    .WithMany(b => b.Competencias)
                    .HasForeignKey(p => p.IdCurriculo)
                    .HasConstraintName("FK_Curriculo_Competencias");

                //Brian
                modelBuilder.Entity<Eva_carrera_grado_estudios>()
                    .HasOne(p => p.Eva_Curriculo_Persona)
                    .WithMany(b => b.GradoEstudios)
                    .HasForeignKey(p => p.IdCurriculo)
                    .HasConstraintName("FK_Curriculo_GradoEstudios");

                modelBuilder.Entity<Eva_curriculo_idiomas>()
                    .HasOne(p => p.eva_Curriculo_Persona)
                    .WithMany(b => b.Idiomas)
                    .HasForeignKey(p => p.IdCurriculo)
                    .HasConstraintName("FK_Curriculo_Idiomas");

                modelBuilder.Entity<Eva_carrera_grado_estudios>()
                    .HasOne(p => p.tipoGenGradoEstudio)
                    .WithMany(b => b.gradosEstudio)
                    .HasForeignKey(p => new { p.IdGenGradoEstudio, p.IdGenTipo })
                    .HasConstraintName("FK_TipoGenGradoEstudio_GradoEstudio");

                //Alegria
                modelBuilder.Entity<Eva_experiencia_laboral>()
                    .HasOne(p => p.eva_Curriculo_Persona)
                    .WithMany(b => b.ExperienciaLaboral)
                    .HasForeignKey(p => p.IdCurriculo)
                    .HasConstraintName("FK_Curriculo_Experiencia");

                modelBuilder.Entity<Eva_curriculo_referencias>()
                    .HasOne(p => p.eva_curriculo_personas)
                    .WithMany(b => b.Referencias)
                    .HasForeignKey(p => p.IdCurriculo)
                    .HasConstraintName("FK_Curriculo_Referencias");

                modelBuilder.Entity<Eva_experiencia_laboral>()
                    .HasOne(p => p.tipoGenExperienciaLaboral)
                    .WithMany(b => b.experienciaLaboral)
                    .HasForeignKey(p => new { p.IdGenExperienciaLaboral, p.IdGenTipo })
                    .HasConstraintName("FK_TipoGenGiro_ExperienciaLaboral");

                modelBuilder.Entity<Eva_curriculo_referencias>()
                    .HasOne(p => p.tipoGenParentezco)
                    .WithMany(b => b.curriculoReferencias)
                    .HasForeignKey(p => new { p.IdGenParentezco, p.IdGenTipo })
                    .HasConstraintName("FK_tipo_gen_parentezco");

                //Cristobal
                modelBuilder.Entity<Eva_actividades_funciones>()
                    .HasOne(p => p.Experiencia)
                    .WithMany(b => b.Funciones)
                    .HasForeignKey(p => p.IdExperiencia)
                    .HasConstraintName("FK_Experiencia_Funciones");

                modelBuilder.Entity<Eva_proyectos>()
                    .HasOne(p => p.Experiencia)
                    .WithMany(b => b.Proyectos)
                    .HasForeignKey(p => p.IdExperiencia)
                    .HasConstraintName("FK_Experiencia_Proyectos");

                //Peps 
                modelBuilder.Entity<Eva_curriculo_conocimientos>()
                    .HasOne(p => p.Competencia)
                    .WithMany(b => b.Conocimientos)
                    .HasForeignKey(p => p.IdCompetencia)
                    .HasConstraintName("FK_Competencia_Conocimientos");

                modelBuilder.Entity<Eva_curriculo_herramientas>()
                    .HasOne(p => p.Conocimiento)
                    .WithMany(b => b.Herramientas)
                    .HasForeignKey(p => p.IdConocimiento)
                    .HasConstraintName("FK_Conocimiento_Herramientas");



            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString() + " 5", "OK");
            }

        }
    }
}

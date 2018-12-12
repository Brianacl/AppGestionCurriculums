using AppGestionCurriculums.Data;
using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.SQLite;
using AppGestionCurriculums.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppGestionCurriculums.Services
{
    public class FicSrvCurriculoPersonas : IFicSrvEvaCurriculoPersonas
    {
        private readonly DBContext LoDBContext;

        public FicSrvCurriculoPersonas()
        {
            LoDBContext = new DBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());

            //INSERT Eva_cat_tipo_competencias
            LoDBContext.AddDataCatTipoCompetencias("1", "Interpersonales", "Son necesarias para adaptarse a los ambientes laborales y para saber interartuar coordinadamentecon otros,como la comunicación,trabajo en equipo,liderazgo,manejo de conflitos,capacidad de adaptacion y proactividad.");
            LoDBContext.AddDataCatTipoCompetencias("2", "Intelectuales", "Comprende aquellos procesos de pensamiento que el estudiante debe usar con un fin determinado.");
            LoDBContext.AddDataCatTipoCompetencias("3", "Empresariales y de emprendimiento", "Desarrolla capacidad para crea, liderar y sostener unidades de negocio por cuenta propia.");
            LoDBContext.AddDataCatTipoCompetencias("4", "Organizacional", "Desarrolla la habilidad para aprender de las experiencias de los otros y para aplicar el pensamiento estrategico en diferentes situaciones de la empresa, como gestionar recursos e información.");
            LoDBContext.AddDataCatTipoCompetencias("5", "Personales", "Condición del individuo que le permite actuar en un espacio productivo desarrolla sus potencias.");
            LoDBContext.AddDataCatTipoCompetencias("6", "Tecnológica", "Permite a los jovenes identificar , transformar e innovar procedimientos, métodos y artefactos, y usar herramientas informaticas al alcance.");

            //INSERT Eva_cat_competencias
            LoDBContext.AddDataCatCompetencias("1", "1", "Comunicación", "");
            LoDBContext.AddDataCatCompetencias("2", "1", "Trabajo en equipo", "");
            LoDBContext.AddDataCatCompetencias("3", "1", "Liderazgo", "");
            LoDBContext.AddDataCatCompetencias("4", "1", "Manejo de conflictos", "");
            LoDBContext.AddDataCatCompetencias("5", "1", "Capacidad de adaptación", "");
            LoDBContext.AddDataCatCompetencias("6", "1", "Proactividad", "");
            LoDBContext.AddDataCatCompetencias("7", "2", "Toma de decisiones", "");
            LoDBContext.AddDataCatCompetencias("8", "2", "Creatividad", "");
            LoDBContext.AddDataCatCompetencias("9", "2", "Solución de problemas", "");
            LoDBContext.AddDataCatCompetencias("10", "2", "Atención", "");
            LoDBContext.AddDataCatCompetencias("11", "2", "Memoria", "");
            LoDBContext.AddDataCatCompetencias("12", "2", "Concentración", "");
            LoDBContext.AddDataCatCompetencias("13", "3", "Identificación de oportunidade para crear empresas o unidades de negocio", "");
            LoDBContext.AddDataCatCompetencias("14", "3", "Elaboración de planes para crear empresas o unidades de negocio", "");
            LoDBContext.AddDataCatCompetencias("15", "3", "Consecución de recursos", "");
            LoDBContext.AddDataCatCompetencias("16", "3", "Capacidad para asumir el riesgo", "");
            LoDBContext.AddDataCatCompetencias("17", "3", "Mercadeo y ventas", "");
            LoDBContext.AddDataCatCompetencias("18", "4", "Gestión de información", "");
            LoDBContext.AddDataCatCompetencias("19", "4", "Orientación al servicio", "");
            LoDBContext.AddDataCatCompetencias("20", "4", "Referencia competitiva", "");
            LoDBContext.AddDataCatCompetencias("21", "4", "Gestión y manejo de recursos", "");
            LoDBContext.AddDataCatCompetencias("22", "4", "Responsabilidad ambiental", "");
            LoDBContext.AddDataCatCompetencias("23", "5", "Orientación etica", "");
            LoDBContext.AddDataCatCompetencias("24", "5", "Dominio personal", "");
            LoDBContext.AddDataCatCompetencias("25", "5", "Inteligencia emocional", "");
            LoDBContext.AddDataCatCompetencias("26", "5", "Adaptación al cambio", "");
            LoDBContext.AddDataCatCompetencias("27", "6", "Identificar, transformar, innovar procedimientos", "");
            LoDBContext.AddDataCatCompetencias("28", "6", "Usar herramientas informaticas", "");
            LoDBContext.AddDataCatCompetencias("29", "6", "Crear, adaptar, aprobar, manejar, transferir tecnologias", "");
            LoDBContext.AddDataCatCompetencias("30", "6", "Elaborar modelos tecnológicos", "");
            LoDBContext.AddDataCatCompetencias("31", "6", "Soporte tecnico de equipos de computo", "");
            LoDBContext.AddDataCatCompetencias("32", "6", "Desarrollo de software", "");
            LoDBContext.AddDataCatCompetencias("33", "6", "Tecnologías emergentes", "");
            LoDBContext.AddDataCatCompetencias("34", "6", "Técnicas de calidad de software", "");
            LoDBContext.AddDataCatCompetencias("35", "6", "Técnicas de arquitectura de software", "");
            LoDBContext.AddDataCatCompetencias("36", "6", "Tratamiento de la información (bases de datos, análisis de información para generar valor)", "");
            LoDBContext.AddDataCatCompetencias("37", "6", "Redes y comunicaciones", "");
            LoDBContext.AddDataCatCompetencias("38", "6", "Seguridad e integridad de la información", "");
            LoDBContext.AddDataCatCompetencias("39", "6", "Bases sobre lógica de programación", "");
        }//Fin del constructor

        public async Task<IEnumerable<Eva_curriculo_persona>> FicMetGetCurriculo(Rh_cat_personas persona)
        {
            return await (from curriculo in LoDBContext.eva_curriculo_persona
                          where curriculo.IdPersona == persona.IdPersona
                          select curriculo
                          ).AsNoTracking().ToListAsync();
        }

        public async Task FicMetInsertNewCurriculo(Eva_curriculo_persona FicInsertCurriculo)
        {
            try
            {
                var FicSourceCurriculoExist = await (
                       from curriculo in LoDBContext.eva_curriculo_persona
                       where curriculo.IdCurriculo == FicInsertCurriculo.IdCurriculo
                       select curriculo
                        ).FirstOrDefaultAsync();

                if (FicSourceCurriculoExist == null)
                {

                    FicInsertCurriculo.FechaReg = DateTime.Now;
                    FicInsertCurriculo.FechaUltMod = DateTime.Now;
                    FicInsertCurriculo.UsuarioReg = "Beth";
                    FicInsertCurriculo.UsuarioMod = "Beth";
                    FicInsertCurriculo.Activo = "S";
                    FicInsertCurriculo.Borrado = "N";

                    await LoDBContext.AddAsync(FicInsertCurriculo);

                }
                else
                {
                    FicInsertCurriculo.IdCurriculo = FicSourceCurriculoExist.IdCurriculo;
                    FicInsertCurriculo.FechaUltMod = DateTime.Now;
                    LoDBContext.Entry(FicSourceCurriculoExist).State = EntityState.Detached;
                    LoDBContext.Update(FicInsertCurriculo);
                }

                await LoDBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - SRVINSERT", e.Message.ToString(), "OK");
            }
        }//Insertar nuevo

        public async Task FicMetDeleteCurriculo(Eva_curriculo_persona deleteCurriculo)
        {
            using (IDbContextTransaction transaction = LoDBContext.Database.BeginTransaction())
            {
                try
                {
                    if (await ExistCurriculo(deleteCurriculo))
                    {
                        await new Page().DisplayAlert("ALERTA", "No se encontró el registro", "OK");
                        return;
                    }//BUSCAR SI YA SE INSERTO UN REGISTRO

                    LoDBContext.Entry(deleteCurriculo).State = EntityState.Detached;
                    LoDBContext.Remove(deleteCurriculo);
                    await LoDBContext.SaveChangesAsync();

                    transaction.Commit(); //CONFIRMA/GUARDA
                    return;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    await new Page().DisplayAlert("ALERTA - SRVDELETE", ex.Message.ToString(), "OK");
                }
            }//ENTRA EN CONTEXTO DE TRANSACIONES
        }//Fin delete

        private async Task<bool> ExistCurriculo(Eva_curriculo_persona existCurriculo)
        {
            return await (from curriculo in LoDBContext.eva_curriculo_persona
                          where curriculo.IdCurriculo == existCurriculo.IdCurriculo
                          select curriculo).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }//BUSCA SI EXISTE UN REGISTRO
    }
}

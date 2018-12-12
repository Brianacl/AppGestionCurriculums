using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppGestionCurriculums.Data;
using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.SQLite;
using AppGestionCurriculums.Models;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppGestionCurriculums.Services
{
    public class FicSrvGradoEstudios : IFicSrvGradoEstudios
    {
        private readonly DBContext LoDBContext;

        public FicSrvGradoEstudios()
        {
            LoDBContext = new DBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//Fin del constructor

        public async Task<IEnumerable<Eva_carrera_grado_estudios>> FicMetGetListGradoEstudios(Eva_curriculo_persona curriculo)
        {
            return await (from gradoEstudios in LoDBContext.eva_grado_estudios
                          where gradoEstudios.IdCurriculo == curriculo.IdCurriculo
                          select gradoEstudios).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Tipo_gen_grado_estudio>> FicMetGetListTipoGradoEstudio()
        {
            return await (from tipoGradoEstudios in LoDBContext.tipo_gen_grado_estudio
                          select tipoGradoEstudios).AsNoTracking().ToListAsync();
        }

        public async Task FicMetInsertNewGradoEstudios(Eva_carrera_grado_estudios FicInsertGradoEstudios)
        {
            try
            {
                var FicSourceGradoEstudioExist = await (
                       from gradoEstudios in LoDBContext.eva_grado_estudios
                       where gradoEstudios.IdGradoEstudio == FicInsertGradoEstudios.IdGradoEstudio
                       select gradoEstudios
                        ).FirstOrDefaultAsync();

                if (FicSourceGradoEstudioExist == null)
                {
                    var idUltimoGrado = ultimoGrado();
                    FicInsertGradoEstudios.IdUltimoGrado = (short)++idUltimoGrado;
                    FicInsertGradoEstudios.FechaReg = DateTime.Now;
                    FicInsertGradoEstudios.FechaUltMod = DateTime.Now;
                    FicInsertGradoEstudios.UsuarioReg = "Brian Casas";
                    FicInsertGradoEstudios.UsuarioMod = "Brian Casas";
                    FicInsertGradoEstudios.Activo = 'S';
                    FicInsertGradoEstudios.Borrado = 'N';

                    await LoDBContext.AddAsync(FicInsertGradoEstudios);

                }
                else
                {
                    FicInsertGradoEstudios.IdGradoEstudio = FicSourceGradoEstudioExist.IdGradoEstudio;
                    FicInsertGradoEstudios.FechaUltMod = DateTime.Now;
                    LoDBContext.Entry(FicSourceGradoEstudioExist).State = EntityState.Detached;
                    LoDBContext.Update(FicInsertGradoEstudios);
                }

                await LoDBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - SrvInsert", e.Message.ToString(), "OK");
            }
        }//Insertar nuevo

        public async Task FicMetDeleteGradoEstudios(Eva_carrera_grado_estudios deleteGradoEstudio)
        {
            using (IDbContextTransaction transaction = LoDBContext.Database.BeginTransaction())
            {
                try
                {
                    if (await ExistIdioma(deleteGradoEstudio))
                    {
                        await new Page().DisplayAlert("ALERTA", "No se encontró el registro", "OK");
                        return;
                    }//BUSCAR SI YA SE INSERTO UN REGISTRO

                    LoDBContext.Entry(deleteGradoEstudio).State = EntityState.Detached;
                    LoDBContext.Remove(deleteGradoEstudio);
                    await LoDBContext.SaveChangesAsync();

                    transaction.Commit(); //CONFIRMA/GUARDA
                    return;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    await new Page().DisplayAlert("ALERTA - SrvDelete", ex.Message.ToString(), "OK");
                }
            }//ENTRA EN CONTEXTO DE TRANSACIONES
        }//Fin delete

        private async Task<bool> ExistIdioma(Eva_carrera_grado_estudios existGradoEstudio)
        {
            return await (from gradoEstudios in LoDBContext.eva_grado_estudios
                          where gradoEstudios.IdGradoEstudio == existGradoEstudio.IdGradoEstudio
                          select gradoEstudios).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }//BUSCA SI EXISTE UN REGISTRO

        private int ultimoGrado()
        {
            if (LoDBContext.eva_grado_estudios.Count() == 0)
            {
                return 0;
            }

            return LoDBContext.eva_grado_estudios.Max(gradoEstudio => gradoEstudio.IdUltimoGrado);
        }

    }//Fin clase
}

using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCurriculums.Interfaces
{
    public interface IFicSrvRhCatPersonas
    {
        Task<IEnumerable<Rh_cat_personas>> FicMetGetListPersonas();
        Task FicMetInsertNewPersona(Rh_cat_personas FicPaPersona);
        Task FicMetDeletePersona(Rh_cat_personas FicPaPersona);
        
    }
}

using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCurriculums.Interfaces.CurriculumsPersonas
{
    public interface IFicSrvCurriculumsPersonas
    {
        Task<IEnumerable<Rh_cat_personas>> FicMetGetListCurriculumsPersonas();
    }
}

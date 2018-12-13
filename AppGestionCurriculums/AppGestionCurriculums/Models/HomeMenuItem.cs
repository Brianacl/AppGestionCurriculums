using System;
using System.Collections.Generic;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Personas,
        CurriculumsPersonas,
        Competencias,
        ListaIdiomas,
        GradoEstudios,
        Funciones,
        Proyectos
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}

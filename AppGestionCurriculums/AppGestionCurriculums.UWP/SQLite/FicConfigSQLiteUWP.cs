using AppGestionCurriculums.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
//using System.Runtime.CompilerServices;
using AppGestionCurriculums.UWP.SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(FicConfigSQLiteUWP))]
namespace AppGestionCurriculums.UWP.SQLite
{
    public class FicConfigSQLiteUWP : IFicConfigSQLite
    {
        public string FicGetDataBasePath()
        {
            //Debug.WriteLine(Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.FicDataBaseName));
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.FicDataBaseName);
        }
    }
}

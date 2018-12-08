using AppGestionCurriculums.Interfaces.SQLite;
<<<<<<< HEAD
=======
using AppGestionCurriculums.UWP.SQLite;
>>>>>>> 6c59bf6951881b0a28c62606b3ed3af9a4f959d8
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
<<<<<<< HEAD
//using System.Runtime.CompilerServices;
using AppGestionCurriculums.UWP.SQLite;
=======
>>>>>>> 6c59bf6951881b0a28c62606b3ed3af9a4f959d8
using Xamarin.Forms;

[assembly: Dependency(typeof(FicConfigSQLiteUWP))]
namespace AppGestionCurriculums.UWP.SQLite
{
    public class FicConfigSQLiteUWP : IFicConfigSQLite
    {
        public string FicGetDataBasePath()
        {
<<<<<<< HEAD
            //Debug.WriteLine(Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.FicDataBaseName));
=======
            Debug.WriteLine(Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.FicDataBaseName));
>>>>>>> 6c59bf6951881b0a28c62606b3ed3af9a4f959d8
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.FicDataBaseName);
        }
    }
}

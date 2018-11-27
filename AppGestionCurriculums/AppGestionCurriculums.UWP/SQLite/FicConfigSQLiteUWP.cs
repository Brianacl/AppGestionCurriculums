using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using AppGestionCurriculums.Interfaces.SQLite;
using AppGestionCurriculums.UWP.SQLite;
using Xamarin.Forms;
using System.Diagnostics;
using System.IO;

[assembly: Dependency(typeof(FicConfigSQLiteUWP))]

namespace AppGestionCurriculums.UWP.SQLite
{
    public class FicConfigSQLiteUWP : IConfigSqlite
    {
        public string FicGetDataBasePath()
        {
            Debug.WriteLine(Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.FicDataBaseName));
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.FicDataBaseName);
        }
    }
}

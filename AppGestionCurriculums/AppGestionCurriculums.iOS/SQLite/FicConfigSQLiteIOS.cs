using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using AppGestionCurriculums.iOS.SQLite;
using System.IO;
using AppGestionCurriculums.Interfaces.SQLite;

namespace AppGestionCurriculums.iOS.SQLite
{
    public class FicConfigSQLiteIOS : IFicConfigSQLite
    {
        public string FicGetDataBasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, AppSettings.FicDataBaseName);
        }
    }
}
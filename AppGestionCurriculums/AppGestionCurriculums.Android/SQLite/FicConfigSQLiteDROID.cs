using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using System.Text;
using AppGestionCurriculums.Interfaces.SQLite;
=======
using System.IO;
using System.Text;
>>>>>>> 6c59bf6951881b0a28c62606b3ed3af9a4f959d8

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppGestionCurriculums.Droid.SQLite;
using Xamarin.Forms;
<<<<<<< HEAD
using System.IO;
=======
using AppGestionCurriculums.Interfaces.SQLite;
>>>>>>> 6c59bf6951881b0a28c62606b3ed3af9a4f959d8

[assembly: Dependency(typeof(FicConfigSQLiteDROID))]
namespace AppGestionCurriculums.Droid.SQLite
{
    public class FicConfigSQLiteDROID : IFicConfigSQLite
    {
        public string FicGetDataBasePath()
        {
            var PathFile = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
            var DirectorioDB = PathFile.Path + "/Curriculums/";
            string PathDB = Path.Combine(DirectorioDB, AppSettings.FicDataBaseName);
            return PathDB;
        }
    }//Fin clase
}
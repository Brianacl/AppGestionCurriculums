﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppGestionCurriculums.Droid.SQLite;
using Xamarin.Forms;
using AppGestionCurriculums.Interfaces.SQLite;

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
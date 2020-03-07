using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SR.Bertoni.Test.Depency;
using Xamarin.Forms;

[assembly: Dependency(typeof(SR.Bertoni.Test.Droid.Services.FileHelper))]
namespace SR.Bertoni.Test.Droid.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetDatabasePath()
        {
            var appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var directoryname = Path.Combine(appData, SR.Bertoni.Test.Repository.Database.DATA_FOLDER);

            if (!Directory.Exists(directoryname))
            {
                Directory.CreateDirectory(directoryname);
            }
            return directoryname;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using SR.Bertoni.Test.Depency;
using Xamarin.Forms;

[assembly: Dependency(typeof(SR.Bertoni.Test.iOS.Services.FileHelper))]
namespace SR.Bertoni.Test.iOS.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetDatabasePath()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var directoryname = Path.Combine(appData, Repository.Database.DATABASE_NAME);

            if (!Directory.Exists(directoryname))
            {
                Directory.CreateDirectory(directoryname);
            }
            return directoryname;
        }
    }
}
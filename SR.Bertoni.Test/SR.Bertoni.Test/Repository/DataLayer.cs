using System;
using System.Collections.Generic;
using System.Text;

namespace SR.Bertoni.Test.Repository
{
    public class DataLayer
    {
        public static DataLayer Instance { get; } = new DataLayer();

        public Database Database;

        public void SetDataBasePlatform()
        {
            if (Database == null)
            {
                Database = new Database();
                Database.Open();
            }
        }
    }
}

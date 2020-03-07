using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.Bertoni.Test.Repository
{
    public class TableModel
    {
        public TableModel() { }
        [PrimaryKey]
        public string Id { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Updated { get; set; } = DateTime.UtcNow;
    }
}
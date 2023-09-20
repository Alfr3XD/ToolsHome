using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ToolsHome.Models
{
    public class Tarea
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public string State { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ToolsHome.Models
{
    public class Gasto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string State { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ToolsHome.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public string State { get; set; }

    }
}

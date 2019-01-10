using System;
using System.Collections.Generic;
using System.Text;

namespace OrchestreAcademy.Domän
{
    class Event
    {
        public int EventId { get; set; }
        public string StadNamn { get; set; }
        public DateTime Datum { get; set; } 
        public string Namn { get; set; }
        public string Instrumet { get; set; }
        public string Stycke { get; set; }


    }
}

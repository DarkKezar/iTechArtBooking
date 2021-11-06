using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Hotel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }

        //TO ADD:
        //Some info fields 
    }
}

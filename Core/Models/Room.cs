using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Room
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Hotel HotelId { get; set; }
        public uint Cost { get; set; }

        //To ADD
        //Field with photo src
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Room
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public Hotel Hotel { get; set; }
        public Double Cost { get; set; } 

        //To ADD
        //Field with photo src
    }
}

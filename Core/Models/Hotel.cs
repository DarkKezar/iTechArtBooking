using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Hotel
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
        public string Info { get; set; }
        public string PhotoUrl { get; set; }
    }
}

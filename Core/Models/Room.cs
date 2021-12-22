using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public List<string> PhotosUrl { get; set; }
    }
}

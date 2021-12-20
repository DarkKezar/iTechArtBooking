using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Booking
    {
        [Key]
        public long Id { get; set; }
        public Room Room { get; set; }
        public User User { get; set; }
        public DateTime SatrtDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

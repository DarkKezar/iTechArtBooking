using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Booked
    {
        public long Id { get; set; }
        public Room RoomId { get; set; }
        public User UserId { get; set; }
        public DateTime Date { get; set; }
        public SByte Period { get; set; }
    }
}

using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Repositories
{
    public class RoomRepository
    {

        public static bool Add(int hotelId, string name, uint cost)
        {
            using (var db = new BookingContext())
            {
                var Hotel = db.Hotels.Where(h => h.Id == hotelId).Include(r => r.Rooms).First();
                if (Hotel == null) return false;

                var Room = new Room() { Name = name, Hotel = Hotel, Cost = cost };
                Hotel.Rooms.Add(Room);
               // db.Rooms.Add(Room);
                db.SaveChanges();
            }
            return true;
        }
        public static Room GetById(int id)
        {
            using(var db = new BookingContext())
            {
                var Room = db.Rooms.Where(r => r.Id == id).ToList();
                if (Room.Count() == 0) return null; //Not Found;
                else return Room[0];
            }
        }
    }
}

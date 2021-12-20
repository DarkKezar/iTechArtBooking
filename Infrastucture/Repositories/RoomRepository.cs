using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Infrastucture.Repositories
{
    public class RoomRepository
    {

        public async Task<HttpStatusCodeResult> Add(int hotelId, string name, uint cost)
        {
            using (var db = new BookingContext())
            {
                var Hotel = await db.Hotels.Where(h => h.Id == hotelId).Include(r => r.Rooms).FirstAsync();
                if (Hotel == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Not found"); ;

                Hotel.Rooms.Add(new Room() { Name = name, Hotel = Hotel, Cost = cost });
               // db.Rooms.Add(Room);
                db.SaveChanges();
            }
            return new HttpStatusCodeResult(HttpStatusCode.Accepted, "Ok"); ;
        }
        public async Task<Room> Get(int id)
        {
            using(var db = new BookingContext())
            {
                var Room = await db.Rooms.Where(r => r.Id == id).ToListAsync();
                if (Room.Count() == 0) return null; //Not Found;
                else return Room[0];
            }
        }
    }
}

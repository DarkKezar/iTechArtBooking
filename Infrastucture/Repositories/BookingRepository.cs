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
    public class BookingRepository
    {
        public async Task<HttpStatusCodeResult> Add(int roomId, int userId, DateTime date, Byte period)
        {
            /*         using(var db = new BookingContext())
                     {
                         var User = db.Users.Where(b => b.Id == userId).ToList();
                         var Room = db.Rooms.Where(b => b.Id == roomId).ToList();

                         if (User.Count() == 0 || Room.Count() == 0) return false;
                         var AlreadyBooking = db.Booking
                                                 .Where(b => b.StartDate >= date 
                                                          && b.StartDate <= date.AddDays(period))
                                                 .ToList();
                         if (AlreadyBooking.Count() != 0) return false;
                         var Booking = new Booking 
                         { 
                             Room = Room[0], 
                             User = User[0], 
                             SatrtDate = date, 
                             EndDate = period 
                         };

                         db.Booking.Add(Booking);
                         db.SaveChanges();
                     }
                     return true;*/
            return new HttpStatusCodeResult(HttpStatusCode.Accepted, "ok");
        }
        public async Task<HttpStatusCodeResult> Delete(int id)
        {
            using(var db = new BookingContext())
            {
                var Booking = await db.Booking.Where(b => b.Id == id).ToListAsync();
                if (Booking.Count() == 0) return new HttpStatusCodeResult(HttpStatusCode.NotFound, "404");

                db.Booking.Remove(Booking[0]);
                db.SaveChanges();
            }
            return new HttpStatusCodeResult(HttpStatusCode.Accepted, "ok");
        }
        public async Task<List<Booking>> Get(int userId)
        {
            using(var db = new BookingContext())
            {
                //var Booking = await db.Booking.Where(b => b.User.Id == userId).ToListAsync();

                return await db.Booking.Where(b => b.User.Id == userId).ToListAsync();
            }
        }
    }
}

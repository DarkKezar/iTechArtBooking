using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Repositories
{
    public class BookedRepository
    {
        public static bool Add(int roomId, int userId, DateTime date, SByte period)
        {
            using(var db = new BookingContext())
            {
                var User = db.Users.First(b => b.Id == userId);
                var Room = db.Rooms.First(b => b.Id == roomId);

                if (User == null || Room == null) return false;
                var AlreadyBooked = db.Booked
                                        .Where(b => b.Date >= date 
                                                 && b.Date <= date.AddDays(period))
                                        .ToList();
                if (AlreadyBooked.Count() != 0) return false;
                var Booked = new Booked { Room = Room, User = User, Date = date, Period = period };

                db.Booked.Add(Booked);
                db.SaveChanges();
            }
            return true;
        }
        public static bool Delete(int id)
        {
            using(var db = new BookingContext())
            {
                var Booked = db.Booked.Where(b => b.Id == id).ToList();
                if (Booked.Count() == 0) return false;

                db.Booked.Remove(Booked[0]);
                db.SaveChanges();
            }
            return true;
        }
        public static List<Booked> GetAll(int userId)
        {
            using(var db = new BookingContext())
            {
                var Booked = db.Booked.Where(b => b.User.Id == userId).ToList();

                return Booked;
            }
        }
    }
}

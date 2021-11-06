using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Repositories
{
    public class HotelRepository
    {
        public static bool Add(string name)
        {
            if (name.Count() == 0) return false;
            using (var db = new BookingContext())
            {
                var Hotel = new Hotel() { Name = name };
                db.Hotels.Add(Hotel);

                db.SaveChanges();
            }
            return true;
        }
        public static bool DeleteById(int id)
        {
            using (var db = new BookingContext())
            {
                var Hotel = db.Hotels.Where(h => h.Id == id).ToList();
                if (Hotel.Count() == 0) return false;
                db.Hotels.Remove(Hotel[0]);
                db.SaveChanges();
            }

            return true;
        }
        public static Hotel GetById(int id)
        {
            using (var db = new BookingContext())
            {
                var Hotel = db.Hotels
                                    .Where(b => b.Id == id)
                                    .Include(b => b.Rooms)
                                    .AsNoTracking()
                                    .ToList();
                if (Hotel.Count() == 0) return null; //code 404
                else return Hotel[0];
            }
        }
        public static List<Hotel> GetAll(int count, int from)
        {

            //Rewrite
            if(count == 0)
            {
                using (var db = new BookingContext())
                {
                    var Hotels = db.Hotels.Where(b => b.Id >= 1).AsNoTracking().ToList();
                    return Hotels;
                }
            }
            if (count < 1 || from < 1) return new List<Hotel>(); //Error
            using (var db = new BookingContext())
            {
                var Hotels = db.Hotels.Where(b => b.Id >= from).Take(count).AsNoTracking().ToList();
                return Hotels;
            }
        }
    }
}

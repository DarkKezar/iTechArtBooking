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
    public class HotelRepository
    {
        public async Task<HttpStatusCodeResult> Add(string name)
        {
            if (name.Count() == 0) return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Not found"); 
            using (var db = new BookingContext())
            {
                //var Hotel = new Hotel() { Name = name };
                _ = await db.Hotels.AddAsync(new Hotel() { Name = name });

                db.SaveChanges();
            }
            return new HttpStatusCodeResult(HttpStatusCode.Accepted, "ok"); 
        }
        public async Task<HttpStatusCodeResult> Delete(int id)
        {
            using (var db = new BookingContext())
            {
                var Hotel = await db.Hotels.Where(h => h.Id == id).ToListAsync();
                if (Hotel.Count() == 0) return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Not found");
                db.Hotels.Remove(Hotel[0]);
                db.SaveChanges();
            }

            return new HttpStatusCodeResult(HttpStatusCode.Accepted, "Hotel was deleted");
        }
        public async Task<Hotel> Get(int id)
        {
            using (var db = new BookingContext())
            {
                var Hotel = await db.Hotels
                                    .Where(b => b.Id == id)
                                    .Include(b => b.Rooms)
                                    .AsNoTracking()
                                    .ToListAsync();
                if (Hotel.Count() == 0) return null; //code 404
                else return  Hotel[0];
            }
        }

        public async Task<List<Hotel>> Get(int count, int from)
        {

            if(count == 0)
            {
                using (var db = new BookingContext())
                {
                    var Hotels = db.Hotels.Where(b => b.Id >= 1).AsNoTracking().ToListAsync();
                    return await Hotels;
                }
            }
            if (count < 1 || from < 1)
            {
                return new List<Hotel>();
            }

            using (var db = new BookingContext())
            {
                var Hotels = db.Hotels.Where(b => b.Id >= from).Take(count).AsNoTracking().ToListAsync();
                return await Hotels;
            }
        }
    }
}

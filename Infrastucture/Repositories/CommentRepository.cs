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
    public class CommentRepository
    {

        public async Task<HttpStatusCodeResult> Add(int hotelId, int userId, string comment, byte mark)
        {
            using(var db = new BookingContext())
            {
                var User = await db.Users.Where(u => u.Id == userId).ToListAsync();
                var Hotel = await db.Hotels.Where(h => h.Id == hotelId).ToListAsync();

                if (User.Count() == 0 || Hotel.Count() == 0) return new HttpStatusCodeResult(HttpStatusCode.Accepted, "ok"); 

                db.Comments.Add(new Comment
                {
                    User = User[0],
                    Hotel = Hotel[0],
                    CommentText = comment,
                    Mark = mark
                });
                db.SaveChanges();
            }
            return new HttpStatusCodeResult(HttpStatusCode.Accepted, "ok"); 
        }

        public async Task<List<Comment>> Get(int hotelId)
        {
            using(var db = new BookingContext())
            {
                var Comments = await db.Comments.Where(c => c.Hotel.Id == hotelId).ToListAsync();
                return Comments;
            }
        }

    }
}

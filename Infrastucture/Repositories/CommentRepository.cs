using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Repositories
{
    public class CommentRepository
    {

        public static bool Add(int hotelId, int userId, string comment, sbyte mark)
        {
            using(var db = new BookingContext())
            {
                var User = db.Users.Where(u => u.Id == userId).ToList();
                var Hotel = db.Hotels.Where(h => h.Id == hotelId).ToList();

                if (User.Count() == 0 || Hotel.Count() == 0) return false;
                if (mark < 1 || mark > 5) return false;
                var Comment = new Comment
                {
                    User = User[0],
                    Hotel = Hotel[0],
                    CommentText = comment,
                    Mark = mark
                };

                db.Comments.Add(Comment);
                db.SaveChanges();
            }
            return true;
        }

        public static List<Comment> GetAll(int hotelId)
        {
            using(var db = new BookingContext())
            {
                var Comments = db.Comments.Where(c => c.Hotel.Id == hotelId).ToList();
                return Comments;
            }
        }

    }
}

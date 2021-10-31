using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Repositories.Fake
{
    public class FakeCommentRepository
    {
        public static List<Comment> Get(int HotelId)
        {
            var Ans = new List<Comment>();

            for (int i = 0; i < 5; i++)
            {
                var temp = new Comment();
                temp.Id = 0;
                temp.HotelId = FakeHotelRepository.Get(0, HotelId)[0];
                temp.UserId = new User();
                temp.CommentText = "Text..." + i;
                temp.Mark = 5;

                Ans.Add(temp);
            }

            return Ans;
        }
    }
}

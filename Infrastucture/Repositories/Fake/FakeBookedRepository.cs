using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Repositories.Fake
{
    public class FakeBookedRepository
    {
        public static List<Booked> Get(int RoomId)
        {
            Random rnd = new Random();
            var Ans = new List<Booked>();

            for(int i=0; i<rnd.Next(3, 10); i++)
            {
                var temp = new Booked();
                temp.Id = i + 1;
                temp.RoomId = new Room();
                    temp.RoomId.Id = RoomId;
                    temp.RoomId.Name = "Room_" + RoomId;
                temp.UserId = new User();
                    temp.UserId.Id = rnd.Next(1, 10000);
                    temp.UserId.Name = "UserName_" + temp.UserId.Id;
                temp.Date = new DateTime();
                temp.Period = Convert.ToSByte(rnd.Next(1, 50));

                Ans.Add(temp);
            }

            return Ans;
        }
    }
}

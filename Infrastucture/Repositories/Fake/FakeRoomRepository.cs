using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Repositories.Fake
{
    public class FakeRoomRepository
    {
        public static List<Room> Get(int HotelId = -1)
        {
            Random rnd = new Random();

            var Hotels = new List<Hotel>();
            if (HotelId == -1) Hotels = FakeHotelRepository.Get(rnd.Next(5, 10), rnd.Next(3, 7));
            else Hotels = FakeHotelRepository.Get(0, rnd.Next(3, 7));

            var Ans = new List<Room>();

            int j = 1;
            foreach(Hotel H in Hotels)
            {
                for(int i = 0; i < rnd.Next(2, 5); i++)
                {
                    var temp = new Room();
                    temp.Id = j;
                    temp.Name = H.Name + " Room_" + i;
                    temp.HotelId = H;
                    temp.Cost = 0;

                    j++;
                    Ans.Add(temp);
                }
            }

            return Ans;
        }
    }
}

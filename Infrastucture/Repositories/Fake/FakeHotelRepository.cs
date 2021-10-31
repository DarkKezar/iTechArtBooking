using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Repositories.Fake
{
    public class FakeHotelRepository
    {
        public static List<Hotel> Get(int Count = -1, int From = 0)
        {
            if (Count == -1) Count = 100; //Return All;
            var ans = new List<Hotel>();
            for(int i = From; i <= From + Count; i++)
            {
                var temp = new Hotel();
                temp.Id = i;
                temp.Name = "Hotel_" + i;
                ans.Add(temp);
            }
            return ans;
        }
    }
}

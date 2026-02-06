using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATripster.Entities
{
    public class HotelService
    {

        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        public int ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}

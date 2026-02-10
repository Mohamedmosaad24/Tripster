using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTripster.ViewModels
{
    public class RoomListVM
    {
        public int Id { get; set; }
        public string RoomType { get; set; } = default!;
        public int Capacity { get; set; }
        public decimal Price { get; set; }
    }
}

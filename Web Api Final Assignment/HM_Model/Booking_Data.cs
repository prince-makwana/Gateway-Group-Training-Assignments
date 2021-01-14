using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_Model
{
    public class Booking_Data
    {
        public int bookingId { get; set; }
        public int hotelId { get; set; }
        public int roomId { get; set; }
        public string statusOfBooking { get; set; }
        public string bookingDate { get; set; }
        public Nullable<int> isActive { get; set; }
    }
}

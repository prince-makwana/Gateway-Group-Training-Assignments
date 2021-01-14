using HM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_BAL.Interface
{
    public interface IHotelManager
    {
        Hotel_Data GetHotel();
        Hotel_Data GetHotel(int id);
        List<Hotel_Data> GetAllHotels();
        String createHotel(Hotel_Data model);
        String createRoom(Room_Data model);
        String bookRoom(Booking_Data model);
        String checkBooking(Booking_Data model);
        IQueryable getRoomsByParameters(Hotel_Data model);
        String deleteBooking(int id);
        String UpdateBookingDate(Booking_Data model);
        String UpdateBookingStatus(Booking_Data model);
    }
}

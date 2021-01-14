using HM_BAL.Interface;
using HM_DAL.Repository;
using HM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_BAL
{
    public class HotelManager : IHotelManager
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public string bookRoom(Booking_Data model)
        {
            return _hotelRepository.bookRoom(model);
        }

        public string checkBooking(Booking_Data model)
        {
            return _hotelRepository.checkBooking(model);
        }

        public string createHotel(Hotel_Data model)
        {
            return _hotelRepository.createHotel(model);
        }

        public string createRoom(Room_Data model)
        {
            return _hotelRepository.createRoom(model);
        }

        public string deleteBooking(int id)
        {
            return _hotelRepository.deleteBooking(id);
        }

        public List<Hotel_Data> GetAllHotels()
        {
            var data = _hotelRepository.GetAllHotels();
            return data;
        }

        public Hotel_Data GetHotel()
        {
            var hotel = _hotelRepository.GetHotel();
            return hotel;
        }

        public Hotel_Data GetHotel(int id)
        {
            var hotel = _hotelRepository.GetHotel(id);
            return hotel;
        }

        public IQueryable getRoomsByParameters(Hotel_Data model)
        {
            return _hotelRepository.getRoomsByParameters(model);
        }

        public string UpdateBookingDate(Booking_Data model)
        {
            return _hotelRepository.UpdateBookingDate(model);
        }

        public string UpdateBookingStatus(Booking_Data model)
        {
            return _hotelRepository.UpdateBookingStatus(model);
        }
    }
}

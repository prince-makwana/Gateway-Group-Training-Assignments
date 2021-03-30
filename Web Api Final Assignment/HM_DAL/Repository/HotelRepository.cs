using HM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HM_DAL.Repository 
{
    public class HotelRepository : IHotelRepository
    {
        private readonly Database.HotelManagementSystemEntities _dbContext;

        public HotelRepository()
        {
            _dbContext = new Database.HotelManagementSystemEntities();
        }

        public string bookRoom(Booking_Data model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Booking_Data, Database.Booking>());
            try
            {
                if(model != null)
                {
                    var mapper = config.CreateMapper();
                    var entity = _dbContext.Rooms.Find(model.roomId);
                    Database.Booking booking = mapper.Map<Database.Booking>(model);
                    booking.isActive = 0;
                    booking.statusOfBooking = "Booked";
                    
                    entity.isActive = 1;

                    _dbContext.Bookings.Add(booking);
                    _dbContext.SaveChanges();
                    return "Booked Successfully!";
                }
                return "Model is Null!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string checkBooking(Booking_Data model)
        {
            var roomsEntity = _dbContext.Rooms.ToList();

            if(roomsEntity != null)
            {
                foreach (var item in roomsEntity)
                {
                    var book_avail = _dbContext.Bookings.Where(x => x.roomId == item.rid & x.bookingDate == model.bookingDate);

                    if (book_avail.Count() != 0)
                    {
                        return "Not Available!";
                    }
                    else
                        return "Available!";
                }
            }
            return "Rooms are not found in Hotel. Please Enter Correct Parameters or contact to administrator!";
        }

        public string createHotel(Hotel_Data model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Hotel_Data, Database.Hotel>());
            try
            {
                if(model != null)
                {
                    var mapper = config.CreateMapper();
                    Database.Hotel entity = mapper.Map<Database.Hotel>(model);
                    _dbContext.Hotels.Add(entity);
                    _dbContext.SaveChanges();
                    return "Hotel Added Successfully!";
                }
                return "Model is Null!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string createRoom(Room_Data model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Room_Data, Database.Room>());
            try
            {
                if(model != null)
                {
                    var mapper = config.CreateMapper();
                    Database.Room entity = mapper.Map<Database.Room>(model);
                    _dbContext.Rooms.Add(entity);
                    _dbContext.SaveChanges();
                    return "Room Added Successfully!";
                }
                return "Model is Null!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string deleteBooking(int id)
        {
            var entity = _dbContext.Bookings.Find(id);
            var entity2 = _dbContext.Rooms.Find(entity.roomId);

            if(entity != null)
            {
                entity2.isActive = 0;
                _dbContext.Bookings.Remove(entity);
                _dbContext.SaveChanges();

                return "Booking Deleted Successfully!";
            }
            return "No Data Found!";
        }

        public List<Hotel_Data> GetAllHotels()
        {
            List<Hotel_Data> hotelList = new List<Hotel_Data>();

            var data = _dbContext.Hotels.OrderBy(x => x.hotelName).ToList();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.Hotel, Hotel_Data>());
            var mapper = config.CreateMapper();
            if (data != null)
            {
                foreach (var item in data)
                {
                    Hotel_Data hotel = mapper.Map<Hotel_Data>(item);
                    hotelList.Add(hotel);
                }
            }
            return hotelList;
        }

        public Hotel_Data GetHotel()
        {
            Hotel_Data hotel = new Hotel_Data
            {
                hid = 2,
                hotelName = "Honest",
                address = "Bhuj"
            };
            return hotel;
        }

        public Hotel_Data GetHotel(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.Hotel, Hotel_Data>());
            var mapper = config.CreateMapper();

            var entity = _dbContext.Hotels.Find(id);

            if(entity != null)
            {
                Hotel_Data hotel = mapper.Map<Hotel_Data>(entity);
                return hotel;
            }
            return null;
        }

        public IQueryable getRoomsByParameters(Hotel_Data model)
        {
            var hotelData = from h in _dbContext.Hotels
                            join r in _dbContext.Rooms on h.hid equals r.hotelId
                            where h.city == model.city || h.pincode == model.pincode
                            orderby r.price
                            select new{
                                h.hid,
                                r.rid,
                                r.roomName,
                                h.hotelName,
                                r.category,
                                r.price,
                                h.pincode,
                                h.city,
                            };

            return hotelData;
        }

        public string UpdateBookingDate(Booking_Data model)
        {
            var entity = _dbContext.Bookings.Find(model.bookingId);
            if(entity != null)
            {
                entity.bookingDate = model.bookingDate;
                _dbContext.SaveChanges();
                return "Booking Date Updated Successfully!";
            }
            return "Something went wrong. Pleas try after sometime.";
        }

        public string UpdateBookingStatus(Booking_Data model)
        {
            var entity = _dbContext.Bookings.Find(model.bookingId);

            if(entity != null)
            {
                entity.statusOfBooking = model.statusOfBooking;
                _dbContext.SaveChanges();
                return "Booking Status Updated Successfully!";
            }

            return "Something went wrong. Please try after sometime.";
        }
    }
}

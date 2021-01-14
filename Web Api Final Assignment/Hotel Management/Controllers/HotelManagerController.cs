using HM_BAL.Interface;
using HM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hotel_Management.Controllers
{
    [AuthenticationFilter]
    public class HotelManagerController : ApiController
    {
        private readonly IHotelManager _hotelManager;

        public HotelManagerController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        // GET: api/HotelManager
        public IHttpActionResult GetHotels()
        {
            var hotel = _hotelManager.GetAllHotels();
            if(hotel.Count == 0)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        // GET: api/HotelManager/5
        public HttpResponseMessage GetHotelById(int id)
        {
            var hotel = _hotelManager.GetHotel(id);
            return Request.CreateResponse<Hotel_Data>(HttpStatusCode.OK, hotel);
        }

        // POST: api/HotelManager
        
        public string createHotel([FromBody]Hotel_Data model)
        {
            return _hotelManager.createHotel(model);
        }

        public string createRoom([FromBody] Room_Data model)
        {
            return _hotelManager.createRoom(model);
        }

        [HttpPost]
        public string BookRoom([FromBody] Booking_Data model)
        {
            return _hotelManager.bookRoom(model);
        }

        // PUT: api/HotelManager/5
        [HttpPut]
        public String UpdateBookingDate([FromBody]Booking_Data model)
        {
            return _hotelManager.UpdateBookingDate(model);
        }

        [HttpPut]
        public String UpdateBookingStatus([FromBody] Booking_Data model)
        {
            return _hotelManager.UpdateBookingStatus(model);
        }

        // DELETE: api/HotelManager/5
        [HttpDelete]
        public String DeleteBooking(int id)
        {
            return _hotelManager.deleteBooking(id);
        }

        [HttpPost]
        public IHttpActionResult checkAvailability([FromBody]Booking_Data model)
        {
            var booking = _hotelManager.checkBooking(model);
            return Ok(booking);
        }

        [HttpPost]
        public IQueryable getRoomsByParameters([FromBody]Hotel_Data model)
        {
            var data = _hotelManager.getRoomsByParameters(model);
            return data;
        }
    }
}

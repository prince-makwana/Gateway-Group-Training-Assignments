//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel_Management.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int bookingId { get; set; }
        public int hotelId { get; set; }
        public int roomId { get; set; }
        public string statusOfBooking { get; set; }
        public string bookingDate { get; set; }
        public Nullable<int> isActive { get; set; }
    }
}

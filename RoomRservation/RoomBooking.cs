using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRservation
{


    class RoomBooking
    {
        public String roomType { get; set; }
        public String roomNumber { get; set; }
        public DateTime checkInDate { get; set; }
        public DateTime checkOutDate { get; set; }
        public String RoomName { get; set; }


        public RoomBooking(String roomType, String roomNumber,DateTime checkin,DateTime checkout)
        {
            this.roomType = roomType;
            this.roomNumber = roomNumber;
            this.checkInDate = checkin;
            this.checkOutDate = checkout;
            this.RoomName = this.roomType + this.roomNumber;
        }

    }
}

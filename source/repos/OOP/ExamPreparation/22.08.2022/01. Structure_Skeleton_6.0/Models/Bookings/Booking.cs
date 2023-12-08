using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int duration;
        private int adults;
        private int children;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
        }

        public IRoom Room { get; private set; }

        public int ResidenceDuration
        {
            get { return duration; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
                duration = value;
            }
        }


        public int AdultsCount
        {
            get { return adults; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                adults = value;
            }
        }

        public int ChildrenCount
        {
            get { return children; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                children = value;
            }
        }

        public int BookingNumber { get; private set; }

        public string BookingSummary()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {Room.GetType().Name}");
            sb.Append($"Adults: {AdultsCount} ");
            sb.AppendLine($"Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: {(ResidenceDuration * Room.PricePerNight):f2} $");

            return sb.ToString().TrimEnd();
        }
    }
}

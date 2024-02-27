using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Dinner.Entities
{
    public sealed class DinnerReservation : Entity<DinnerReservationId>
    {
        private DinnerReservation(DinnerReservationId id, ReservationStatus reservationStatus, int guestCount, GuestId guestId, BillId billId) : base(id)
        {
            ReservationStatus = reservationStatus;
            GuestCount = guestCount;
            GuestId = guestId;
            BillId = billId;
        }

        private DinnerReservation()
        {

        }


        public int GuestCount { get; private set; }
        public ReservationStatus ReservationStatus { get; private set; }
        public GuestId GuestId { get; private set; }
        public BillId BillId { get; private set; }

        public DateTime ArrivalDateTime { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

    }
}

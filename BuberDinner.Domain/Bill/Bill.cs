using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Bill
{
    public sealed class Bill : AggregateRoot<BillId, Guid>
    {
        private Bill(BillId id, DinnerId dinnerId, GuestId guestId, HostId hostId, Price price, DateTime createdDateTime, DateTime updateDateTime) : base(id)
        {
            DinnerId = dinnerId;
            GuestId = guestId;
            HostId = hostId;
            Price = price;
            CreatedDateTime = createdDateTime;
            UpdateDateTime = updateDateTime;
        }
        private Bill()
        {

        }
        public static Bill Create(DinnerId dinnerId, GuestId guestId, HostId hostId, Price price, DateTime createdDateTime, DateTime updateDateTime)
        {
            return new(BillId.CreateUnique(), dinnerId, guestId, hostId, price, createdDateTime, updateDateTime);
        }

        public DinnerId DinnerId { get; private set; }

        public GuestId GuestId { get; private set; }

        public HostId HostId { get; private set; }

        public Price Price { get; private set; }

        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdateDateTime { get; private set; }

    }
}

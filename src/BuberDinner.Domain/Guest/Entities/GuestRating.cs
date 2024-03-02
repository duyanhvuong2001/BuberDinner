using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;


namespace BuberDinner.Domain.Guest.Entities
{
    public sealed class GuestRating : Entity<GuestRatingId>
    {
        private GuestRating(GuestRatingId id, HostId hostId, DinnerId dinnerId, Rating rating, DateTime createdDateTime, DateTime updatedDateTime) : base(id)
        {
            HostId = hostId;
            DinnerId = dinnerId;
            Rating = rating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        private GuestRating()
        {

        }

        public HostId HostId { get; private set; }
        public DinnerId DinnerId { get; private set; }
        public Rating Rating { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

    }
}

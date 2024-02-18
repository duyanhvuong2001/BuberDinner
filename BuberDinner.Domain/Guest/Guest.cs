using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.Entities;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Guest
{
    public sealed class Guest : AggregateRoot<GuestId>
    {
        private readonly List<DinnerId> _upcomingDinnerIds = new();
        private readonly List<DinnerId> _pastDinnerIds = new();
        private readonly List<DinnerId> _pendingDinnerIds = new();
        private readonly List<BillId> _billIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        private readonly List<GuestRating> _ratings = new();
        private Guest(GuestId id, DateTime createdDateTime, DateTime updatedDateTime, UserId userId, string firstName, string lastName, ProfileImage profileImage, AverageRating averageRating) : base(id)
        {
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
        }

        public static Guest Create(DateTime createdDateTime, DateTime updatedDateTime, UserId userId, string firstName, string lastName, ProfileImage profileImage, AverageRating averageRating)
        {
            return new(GuestId.CreateUnique(), createdDateTime, updatedDateTime, userId, firstName, lastName, profileImage, averageRating);
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public ProfileImage ProfileImage { get; private set; }

        public AverageRating AverageRating { get; private set; }
        public IReadOnlyList<GuestRating> Ratings => _ratings.AsReadOnly();

        public UserId UserId { get; private set; }

        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
        public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    }
}

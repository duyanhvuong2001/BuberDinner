using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Dinner
{
    public sealed class Dinner : AggregateRoot<DinnerId, Guid>
    {
        private readonly List<DinnerReservation> _reservations = new();
        private Dinner(DinnerId id, string name, string description, DateTime startDateTime, DateTime startedDateTime, DateTime endDateTime, DateTime endedDateTime, DateTime createdDateTime, DateTime updatedDateTime, bool isPublic, int maxGuests, DinnerStatus status, Price price, HostId hostId, MenuId menuId, string imageURL, DinnerLocation location) : base(id)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            StartedDateTime = startedDateTime;
            EndedDateTime = endedDateTime;
            EndDateTime = endDateTime;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Status = status;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageURL = imageURL;
            Location = location;
        }

        public static Dinner Create(string name, string description, DateTime startDateTime, DateTime startedDateTime, DateTime endedDateTime, DateTime endDateTime, DateTime createdDateTime, DateTime updatedDateTime, bool isPublic, int maxGuests, DinnerStatus status, Price price, HostId hostId, MenuId menuId, string imageURL, DinnerLocation location)
        {
            return new(DinnerId.CreateUnique(), name, description, startDateTime, startedDateTime, endDateTime, endedDateTime, createdDateTime, updatedDateTime, isPublic, maxGuests, status, price, hostId, menuId, imageURL, location);
        }

        private Dinner()
        {

        }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public DateTime StartDateTime { get; private set; }
        public DateTime StartedDateTime { get; private set; }
        public DateTime EndedDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }


        public bool IsPublic { get; private set; }
        public int MaxGuests { get; private set; }
        public DinnerStatus Status { get; private set; }
        public Price Price { get; private set; }

        public HostId HostId { get; private set; }
        public MenuId MenuId { get; private set; }
        public string ImageURL { get; private set; }

        public DinnerLocation Location { get; private set; }

        public IReadOnlyList<DinnerReservation> Reservations => _reservations.AsReadOnly();

    }
}

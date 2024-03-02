﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.Events;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId, Guid>
    {
        private readonly List<MenuSection> _sections;
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();

        private Menu()
        {

        }
        private Menu(MenuId menuId, string name, string description, AverageRating averageRating, HostId hostId, DateTime createdDateTime, DateTime updatedDateTime, List<MenuSection> sections) : base(menuId)
        {
            Name = name;
            Description = description;
            AverageRating = averageRating;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
            _sections = sections;
        }

        public static Menu Create(string name, string description, HostId hostId, List<MenuSection> sections)
        {
            var menu = new Menu(MenuId.CreateUnique(), name, description, AverageRating.CreateNew(), hostId, DateTime.Now, DateTime.Now, sections);

            menu.AddDomainEvent(new MenuCreated(menu));

            return menu;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public AverageRating AverageRating { get; private set; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

        public HostId HostId { get; private set; }

        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
    }
}

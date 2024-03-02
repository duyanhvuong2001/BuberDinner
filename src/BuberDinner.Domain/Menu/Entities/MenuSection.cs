using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items;

        private MenuSection()
        {

        }
        private MenuSection(MenuSectionId id, string name, string description, List<MenuItem> items) : base(id)
        {
            Name = name;
            Description = description;
            _items = items;
        }

        public string Name { get; }

        public string Description { get; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        public static MenuSection Create(string name, string description, List<MenuItem> items)
        {
            return new(MenuSectionId.CreateUnique(), name, description, items);
        }
    }
}

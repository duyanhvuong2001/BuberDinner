


namespace BuberDinner.Contracts.Menu
{
    public record CreateMenuRequest(
        string Name, string Description, List<CreateMenuSection> Sections);

    public record CreateMenuSection(
        string Name,
        string Description,
        List<CreateMenuItem> Items
        );
    public record CreateMenuItem(
        string Name,
        string Description
        );
}

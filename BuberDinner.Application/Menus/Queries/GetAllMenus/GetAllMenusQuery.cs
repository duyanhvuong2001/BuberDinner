using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Queries.GetAllMenus
{
    public record GetAllMenusQuery() : IRequest<ErrorOr<List<Menu>>>;
}

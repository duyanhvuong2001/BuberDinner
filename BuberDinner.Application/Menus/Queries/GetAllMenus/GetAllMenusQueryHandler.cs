using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Queries.GetAllMenus
{
    public class GetAllMenusQueryHandler : IRequestHandler<GetAllMenusQuery, ErrorOr<List<Menu>>>
    {
        private readonly IMenuRepository _menuRepository;

        public GetAllMenusQueryHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<List<Menu>>> Handle(GetAllMenusQuery request, CancellationToken cancellationToken)
        {
            return await _menuRepository.GetAllMenus();
        }
    }
}

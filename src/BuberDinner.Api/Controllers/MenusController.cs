using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.Menus.Queries.GetAllMenus;
using BuberDinner.Contracts.Menu;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("/api/hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public MenusController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _sender = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenus()
        {
            var getAllMenusResult = await _sender.Send(new GetAllMenusQuery());

            return getAllMenusResult.Match(
                menus => Ok(_mapper.Map<List<MenuResponse>>(menus)),
                errors => Problem(errors)
                );
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
        {
            var command = _mapper.Map<CreateMenuCommand>((request, hostId));

            var createMenuResult = await _sender.Send(command);

            return createMenuResult.Match(
                menu => Ok(_mapper.Map<MenuResponse>(menu)),
                errors => Problem(errors)
                );
        }


    }
}

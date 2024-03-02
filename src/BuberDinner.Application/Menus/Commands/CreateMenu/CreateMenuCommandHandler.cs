using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            //Create Menu

            var menu = Menu.Create(
                name: request.Name,
                description: request.Description,
                hostId: HostId.Create(Guid.Parse(request.HostId)),
                sections: request.Sections.ConvertAll(section => MenuSection.Create(
                    name: section.Name,
                    description: section.Description,
                    items: section.Items.ConvertAll(item => MenuItem.Create(
                        name: item.Name,
                        description: item.Description
                        ))
                    ))
                );

            //Add to repository
            _menuRepository.Add(menu);

            //Save changes to db
            await _unitOfWork.SaveChangesAsync();
            //Return Menu
            return menu!;
        }
    }
}

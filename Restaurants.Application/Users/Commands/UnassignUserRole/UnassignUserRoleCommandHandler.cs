using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Users.Commands.AssignUserRole;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Users.Commands.UnassignUserRole
{
    public class UnassignUserRoleCommandHandler(ILogger<UnassignUserRoleCommandHandler> logger, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<UnassignUserRoleCommand>
    {
        public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("unassigning user role: {@Request}", request);
            //featch the user by email user manager
            var user = await userManager.FindByEmailAsync(request.UserEmail);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserEmail);
            }
            var role = await roleManager.FindByNameAsync(request.Role) ?? throw new NotFoundException(nameof(IdentityRole), request.Role);

            await userManager.RemoveFromRoleAsync(user, role.Name!);
        }
    }
}

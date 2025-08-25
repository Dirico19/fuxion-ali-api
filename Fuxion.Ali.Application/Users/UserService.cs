using Fuxion.Ali.Application.Users.Get;
using Fuxion.Ali.Application.Users.List;
using Fuxion.Ali.Application.Users.Update;
using Fuxion.Ali.Contracts.Common;
using Fuxion.Ali.Contracts.Common.Dtos;
using Fuxion.Ali.Contracts.Users.Create;
using Fuxion.Ali.Contracts.Users.Get;
using Fuxion.Ali.Contracts.Users.List;
using Fuxion.Ali.Contracts.Users.Update;
using Fuxion.Ali.Domain.Interfaces;

namespace Fuxion.Ali.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Result<ListUsersResponse>> ListUsersAsync(ListUsersRequest request, CancellationToken cancellationToken = default)
        {
            var users = await _unitOfWork.Users.GetAllFilteredAsync(request.Search, cancellationToken);

            if (!users.Any())
            {
                return ListUsersResult.NoUsersFound();
            }

            var userDtos = users.Select(u => new UserDto
            {
                UserId = u.Id,
                UserName = u.Name,
                RoleId = u.UserRoles.Select(ur => ur.Role.Id).FirstOrDefault(),
                Role = u.UserRoles.Select(ur => ur.Role.Description).FirstOrDefault(),
                FirstName = u.Contacts.FirstOrDefault()?.FirstName,
                LastName = u.Contacts.FirstOrDefault()?.LastName,
                Email = u.Contacts.FirstOrDefault()?.Email,
                Phone = u.Contacts.FirstOrDefault()?.Phone,
            }).ToList();

            var response = new ListUsersResponse(userDtos);

            return ListUsersResult.UsersFound(response);
        }

        public async Task<Result<GetUserResponse>> GetUserAsync(GetUserRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _unitOfWork.Users.FindWithDetailsByIdAsync(request.Id, cancellationToken);

            if (user == null)
            {
                return GetUserResult.UserNotFound();
            }

            var userDto = new UserDto
            {
                UserId = user.Id,
                UserName = user.Name,
                RoleId = user.UserRoles.Select(ur => ur.Role.Id).FirstOrDefault(),
                FirstName = user.Contacts.FirstOrDefault()?.FirstName,
                LastName = user.Contacts.FirstOrDefault()?.LastName,
                Email = user.Contacts.FirstOrDefault()?.Email,
                Phone = user.Contacts.FirstOrDefault()?.Phone,
            };

            var response = new GetUserResponse(userDto);

            return GetUserResult.UserFound(response);
        }

        public async Task<Result<UpdateUserResponse>> UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _unitOfWork.Users.FindWithDetailsByIdAsync(request.UserId, cancellationToken);

            if (user == null)
            {
                return UpdateUserResult.UserNotFound();
            }

            user.Name = request.UserName;
            user.UserRoles.Clear();
            user.UserRoles.Add(new()
            {
                UserId = user.Id,
                RoleId = request.RoleId
            });
            var contact = user.Contacts.FirstOrDefault();

            if (contact == null)
            {
                return UpdateUserResult.UserContactNotFound();
            }

            contact.FirstName = request.FirstName;
            contact.LastName = request.LastName;
            contact.Email = request.Email;
            contact.Phone = request.Phone;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return UpdateUserResult.UserUpdated();
        }

        public Task<Result<CreateUserResponse>> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

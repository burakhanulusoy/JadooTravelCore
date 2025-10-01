using JadooTravelCore.Dtos.UserDto;
using JadooTravelCore.Entities;

namespace JadooTravelCore.Services.UserServices
{
    public interface IUserService
    {

        Task<List<ResultUserDto>> GetAllUserAsync();
        Task<GetByIdUserDto> GetByIdUserAsync(string id);
        Task UpdateUserAsync(UpdateUserDto updateUserDto);
        Task CreateUserAsync(CreateUserDto createUserDto);
        Task DeleteUserAsync(string id);
        Task<User> GetByUserName(string name,string password);

    }
}

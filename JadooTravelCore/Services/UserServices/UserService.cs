using AutoMapper;
using JadooTravelCore.Dtos.UserDto;
using JadooTravelCore.Entities;
using JadooTravelCore.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace JadooTravelCore.Services.UserServices
{
    public class UserService : IUserService
    {

        private readonly IMongoCollection<User> _userColection;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _userColection = database.GetCollection<User>(_databaseSettings.UserCollectionName);
            _mapper = mapper;
        }

        public async Task CreateUserAsync(CreateUserDto createUserDto)
        {

            var user=_mapper.Map<User>(createUserDto);
            await _userColection.InsertOneAsync(user);

        }

        public async Task DeleteUserAsync(string id)
        {
            await _userColection.DeleteOneAsync(x => x.UserId == id);
        }

        public async Task<List<ResultUserDto>> GetAllUserAsync()
        {

            var user = await _userColection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultUserDto>>(user);


        }

        public async Task<GetByIdUserDto> GetByIdUserAsync(string id)
        {
            var value=await _userColection.Find(x=>x.UserId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdUserDto>(value);

        }

        public async Task UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var user=_mapper.Map<User>(updateUserDto);
            await _userColection.FindOneAndReplaceAsync(x => x.UserId == updateUserDto.UserId, user);
        }




        public async Task<User> GetByUserName(string name,string password)
        {

            return await _userColection.Find(x=>x.UserName==name && x.UserPassword==password).FirstOrDefaultAsync();

        }






    }
}

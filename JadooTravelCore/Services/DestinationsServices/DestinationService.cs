using AutoMapper;
using JadooTravelCore.Dtos.DestinationDtos;
using JadooTravelCore.Entities;
using JadooTravelCore.Settings;
using MongoDB.Driver;

namespace JadooTravelCore.Services.DestinationsServices
{
    public class DestinationService : IDestinationService
    {

        private readonly IMongoCollection<Destination> _destianationCollection;
        private readonly IMapper _mapper;

        public DestinationService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {

            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _destianationCollection = database.GetCollection<Destination>(_databaseSettings.DestinationCollectionName);
            _mapper = mapper;
        }

        public async Task CreateDestinationAsync(CreateDestinationDto createDestinationDto)
        {

            var value = _mapper.Map<Destination>(createDestinationDto);
            await _destianationCollection.InsertOneAsync(value);
        
    
        }

        public async Task DeleteDestinationAsync(string id)
        {
        
        await _destianationCollection.DeleteOneAsync(x=>x.DestinationId == id);
        
        }

        public async Task<List<ResultDestinationDto>> GetAllDestinationAsync()
        {
            var value= await _destianationCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultDestinationDto>>(value);



        }

        public async Task<GetDestinationByIdDto> GetDestinationByIdAsync(string id)
        {
            var value=await _destianationCollection.Find(x=>x.DestinationId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetDestinationByIdDto>(value);


        }

        public async Task UpdateDestinationAsync(UpdateDestinationDto updateDestinationDto)
        {
        
            var value= _mapper.Map<Destination>(updateDestinationDto);
            await _destianationCollection.FindOneAndReplaceAsync(x=>x.DestinationId==updateDestinationDto.DestinationId, value);


        }
    }
}

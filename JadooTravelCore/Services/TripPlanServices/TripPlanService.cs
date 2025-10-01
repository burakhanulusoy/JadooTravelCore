using AutoMapper;
using JadooTravelCore.Dtos.TripPlanDtos;
using JadooTravelCore.Entities;
using JadooTravelCore.Settings;
using MongoDB.Driver;

namespace JadooTravelCore.Services.TripPlanServices
{
    public class TripPlanService : ITripPlanService
    {

        private readonly IMongoCollection<TripPlan> _trpPlanCollection;
        private readonly IMapper _mapper;

        public TripPlanService(IMapper mapper,IDatabaseSettings databaseSettings)
        {

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _trpPlanCollection = database.GetCollection<TripPlan>(databaseSettings.TripPlanCollectionName);
            _mapper = mapper;
        }

        public async Task CreateTripPlanAsync(CreateTripPlanDto createTripPlanDto)
        {
             var value=_mapper.Map<TripPlan>(createTripPlanDto);
             await _trpPlanCollection.InsertOneAsync(value);
        }

        public async Task DeleteTripPlanAsync(string id)
        {
            await _trpPlanCollection.DeleteOneAsync(x=>x.TripPlanId == id);

        }


        public async Task<List<ResultTripPlanDto>> GetAllTripPlansAsync()
        {
            var value=await _trpPlanCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultTripPlanDto>>(value);
        }

        public async Task<GetTripPlanByIdDto> GetTripPlanByIdAsync(string id)
        {
            var value=await _trpPlanCollection.Find(x=>x.TripPlanId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetTripPlanByIdDto>(value);
        }

        public async Task UpdateTripPlanAsync(UpdateTripPlanDto updateTripPlanDto)
        {

            var value=_mapper.Map<TripPlan>(updateTripPlanDto);
            await _trpPlanCollection.FindOneAndReplaceAsync(x=>x.TripPlanId==updateTripPlanDto.TripPlanId, value);




        }
    }
}

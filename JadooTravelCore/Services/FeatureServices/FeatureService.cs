using AutoMapper;
using JadooTravelCore.Dtos.FeatureDtos;
using JadooTravelCore.Entities;
using JadooTravelCore.Settings;
using MongoDB.Driver;

namespace JadooTravelCore.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {


        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper,IDatabaseSettings databaseSettings)
        {

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database=client.GetDatabase(databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(databaseSettings.FeatureCollectionName);



            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {

            var value = _mapper.Map<Feature>(createFeatureDto);
            await _featureCollection.InsertOneAsync(value);


        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureId == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var value = await _featureCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(value);



        }

        public async Task<GetFeatureByIdDto> GetFeatureByIdAsync(string id)
        {
            var value = await _featureCollection.Find(x => x.FeatureId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetFeatureByIdDto>(value);


        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
           
            var value=_mapper.Map<Feature>(updateFeatureDto);
            await _featureCollection.FindOneAndReplaceAsync(x=>x.FeatureId==updateFeatureDto.FeatureId, value);



        }
    }
}

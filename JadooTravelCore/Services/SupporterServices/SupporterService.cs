using AutoMapper;
using JadooTravelCore.Dtos.SupporterDtos;
using JadooTravelCore.Entities;
using JadooTravelCore.Settings;
using MongoDB.Driver;

namespace JadooTravelCore.Services.SupporterServices
{
    public class SupporterService : ISupporterService
    {
        private readonly IMongoCollection<Supporter> _supporterCollection;
        private readonly IMapper _mapper;

        public SupporterService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database=client.GetDatabase(_databaseSettings.DatabaseName);
            _supporterCollection=database.GetCollection<Supporter>(_databaseSettings.SupporterCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSuppoerterAsync(CreateSupporterDto createSupporterDto)
        {
            var values=_mapper.Map<Supporter>(createSupporterDto);
            await _supporterCollection.InsertOneAsync(values);
        }

        public async Task DeleteSuppoerterAsync(string id)
        {
            
            await _supporterCollection.DeleteOneAsync(x=>x.SupporterId == id);
        }

        public async Task<List<ResultSupporterDto>> GetAllSupporterAsync()
        {
           
            var values=await _supporterCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultSupporterDto>>(values);

        }

        public async Task<GetByIdSupporterDto> GetByIdSupporterAsync(string id)
        {
            var values=await _supporterCollection.Find(x=>x.SupporterId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSupporterDto>(values);
        }

        public async Task UpdateSuppoerterAsync(UpdateSupporterDto updateSupporterDto)
        {

            var value = _mapper.Map<Supporter>(updateSupporterDto);
            await _supporterCollection.FindOneAndReplaceAsync(x=>x.SupporterId==updateSupporterDto.SupporterId, value);

        }
    
    
  
    
    }
}

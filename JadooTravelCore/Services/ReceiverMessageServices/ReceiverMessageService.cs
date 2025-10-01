


using AutoMapper;
using JadooTravelCore.Dtos.ReceiverMessageDtos;
using JadooTravelCore.Entities;
using JadooTravelCore.Settings;
using MongoDB.Driver;

namespace JadooTravelCore.Services.ReceiverMessageServices
{
    public class ReceiverMessageService : IReceiverMessageService
    {

        private readonly IMongoCollection<ReceiverMessage> _receiverMessageCollection;
        private readonly IMapper _mapper;

        public ReceiverMessageService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _receiverMessageCollection = database.GetCollection<ReceiverMessage>(_databaseSettings.ReceiverMessageCollectionName);



            _mapper = mapper;
        }

        public async Task CreateReceiverMessageAsync(CreateReceiverMessageDto createReceiverMessageDto)
        {
            var value=_mapper.Map<ReceiverMessage>(createReceiverMessageDto);
            await _receiverMessageCollection.InsertOneAsync(value);
        }

        public async Task DeleteReceiverMessageAsync(string id)
        {
            await _receiverMessageCollection.DeleteOneAsync(x=>x.ReceiverMessageId==id);
        }

        public async Task<List<ResultReceiverMessageDto>> GetAllReceiverMessageAsync()
        {
            
            var user = await _receiverMessageCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultReceiverMessageDto>>(user);

            
            
            
        }

        public async Task<GetByIdReceiverMessageDto> GetByIdReceiverMessageAsync(string id)
        {
          
            var value=await _receiverMessageCollection.Find(x=>x.ReceiverMessageId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdReceiverMessageDto>(value);

        }

        public async Task UpdateReceiverMessageAsync(UpdateReceiverMessageDto updateReceiverMessageDto)
        {
            
            var value=_mapper.Map<ReceiverMessage>(updateReceiverMessageDto);
            await _receiverMessageCollection.FindOneAndReplaceAsync(x=>x.ReceiverMessageId==updateReceiverMessageDto.ReceiverMessageId, value);



        }
        
    }
}

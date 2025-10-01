using AutoMapper;
using JadooTravelCore.Dtos.TestimonialDtos;
using JadooTravelCore.Entities;
using JadooTravelCore.Settings;
using MongoDB.Driver;

namespace JadooTravelCore.Services.TestimonialServices
{
    public class TestimonailService : ITesimonialService
    {

        private readonly IMongoCollection<Testimonial> _testimonailCollection;
        private readonly IMapper _mapper;

        public TestimonailService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database=client.GetDatabase(_databaseSettings.DatabaseName);
            _testimonailCollection=database.GetCollection<Testimonial>(_databaseSettings.TestimonialCollectionName);
            _mapper = mapper;
        }

        public async Task CreateTestimonialAsync(CreateTetimonialDto createTetimonialDto)
        {

            var user = _mapper.Map<Testimonial>(createTetimonialDto);
            await _testimonailCollection.InsertOneAsync(user);

        }

        public async Task DeleteTestimonialAsync(string id)
        {
          
            await _testimonailCollection.DeleteOneAsync(x=>x.TestimonialId==id);

        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            var user=await _testimonailCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(user);




        }

        public async Task<GetByIdTestimonial> GetByIdTestimonialAsync(string id)
        {
          
            var user=await _testimonailCollection.Find(x=>x.TestimonialId== id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdTestimonial>(user);


        }

        public async Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            
            var user=_mapper.Map<Testimonial>(updateTestimonialDto);
            await _testimonailCollection.FindOneAndReplaceAsync(x => x.TestimonialId == updateTestimonialDto.TestimonialId, user);





        }
    }
}

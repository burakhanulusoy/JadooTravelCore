using AutoMapper;
using JadooTravelCore.Dtos.CategoryDtos;
using JadooTravelCore.Entities;
using JadooTravelCore.Settings;
using MongoDB.Driver;

namespace JadooTravelCore.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {

        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper ,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database=client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);


            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
           await _categoryCollection.DeleteOneAsync(x=>x.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {

            var values=await _categoryCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);

        }

        public async Task<GetCategoryByIdDto> GetCategoryByIdAsync(string id)
        {
           var value=await _categoryCollection.Find(x=>x.CategoryId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetCategoryByIdDto>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x=>x.CategoryId==updateCategoryDto.CategoryId, value);
         

        }
    }
}

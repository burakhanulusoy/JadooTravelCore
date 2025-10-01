using JadooTravelCore.Dtos.FeatureDtos;

namespace JadooTravelCore.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task DeleteFeatureAsync(string id);
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task<GetFeatureByIdDto> GetFeatureByIdAsync(string id);




    }
}

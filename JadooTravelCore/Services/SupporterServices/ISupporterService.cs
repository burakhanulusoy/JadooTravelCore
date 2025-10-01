using JadooTravelCore.Dtos.SupporterDtos;

namespace JadooTravelCore.Services.SupporterServices
{
    public interface ISupporterService
    {
        Task<List<ResultSupporterDto>> GetAllSupporterAsync();
        Task<GetByIdSupporterDto> GetByIdSupporterAsync(string id);
        Task DeleteSuppoerterAsync(string id);
        Task UpdateSuppoerterAsync(UpdateSupporterDto updateSupporterDto);
        Task CreateSuppoerterAsync(CreateSupporterDto createSupporterDto);
    }
}

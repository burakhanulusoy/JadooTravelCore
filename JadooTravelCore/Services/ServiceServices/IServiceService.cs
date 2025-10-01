using JadooTravelCore.Dtos.ServiceDtos;

namespace JadooTravelCore.Services.ServiceServices
{
    public interface IServiceService
    {

        Task<List<ResultServiceDto>> GetAllServicesAsync();
        Task<GetByIdServiceDto> GetByIdServiceAsync(string id);
        Task DeleteServiceAsync(string id);
        Task UpdateServiceAsync(UpdateServiceDto updateServiceDto);
        Task CreateServiceAsync(CreateServiceDto createServiceDto);







    }
}

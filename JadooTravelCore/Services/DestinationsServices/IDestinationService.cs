using JadooTravelCore.Dtos.DestinationDtos;

namespace JadooTravelCore.Services.DestinationsServices
{
    public interface IDestinationService
    {

        Task<List<ResultDestinationDto>> GetAllDestinationAsync();
        Task UpdateDestinationAsync(UpdateDestinationDto updateDestinationDto);
        Task<GetDestinationByIdDto> GetDestinationByIdAsync(string id);
        Task DeleteDestinationAsync(string id);
        Task CreateDestinationAsync(CreateDestinationDto createDestinationDto);


    }
}

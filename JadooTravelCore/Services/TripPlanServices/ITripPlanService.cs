using JadooTravelCore.Dtos.TripPlanDtos;

namespace JadooTravelCore.Services.TripPlanServices
{
    public interface ITripPlanService
    {
        Task<List<ResultTripPlanDto>> GetAllTripPlansAsync();
        Task<GetTripPlanByIdDto> GetTripPlanByIdAsync(string id);
        Task UpdateTripPlanAsync(UpdateTripPlanDto updateTripPlanDto);
        Task CreateTripPlanAsync(CreateTripPlanDto createTripPlanDto);
        Task DeleteTripPlanAsync(string id);

    }
}

using JadooTravelCore.Dtos.TestimonialDtos;

namespace JadooTravelCore.Services.TestimonialServices
{
    public interface ITesimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        Task<GetByIdTestimonial> GetByIdTestimonialAsync(string id);
        Task CreateTestimonialAsync(CreateTetimonialDto createTetimonialDto);
        Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);
        Task DeleteTestimonialAsync(string id);
    }
}

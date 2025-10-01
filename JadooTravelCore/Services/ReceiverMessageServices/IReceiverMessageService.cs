using JadooTravelCore.Dtos.ReceiverMessageDtos;

namespace JadooTravelCore.Services.ReceiverMessageServices
{
    public interface IReceiverMessageService
    {


        Task<List<ResultReceiverMessageDto>> GetAllReceiverMessageAsync();
        Task<GetByIdReceiverMessageDto> GetByIdReceiverMessageAsync(string id);
        Task UpdateReceiverMessageAsync(UpdateReceiverMessageDto updateReceiverMessageDto);
        Task DeleteReceiverMessageAsync(string id);
        Task CreateReceiverMessageAsync(CreateReceiverMessageDto createReceiverMessageDto);



    }
}

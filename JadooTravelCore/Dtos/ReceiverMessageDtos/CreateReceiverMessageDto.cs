namespace JadooTravelCore.Dtos.ReceiverMessageDtos
{
    public class CreateReceiverMessageDto
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string NameSurname { get; set; }
        public DateTime ReceiverDate { get; set; }
        public bool Status { get; set; }

    }
}

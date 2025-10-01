namespace JadooTravelCore.Dtos.DestinationDtos
{
    public class CreateDestinationDto
    {

       
        public string City { get; set; }
        public bool Status { get; set; }

        public string Country { get; set; }
        public string ShortDescription { get; set; }
        public string accomodationPlace { get; set; }
        public string DepatureDate { get; set; }
        public string DepatureCar { get; set; }
        public string DepaturPlace { get; set; }
        public string ReturnDate { get; set; }
        public string ReturnPlace { get; set; }
        public string Route { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public string DayNight { get; set; }
        public int Capacity { get; set; }
        public string LongDescription { get; set; }
        public string Services { get; set; }
        public string Phone { get; set; }
        public string Instagram { get; set; }
        public string WhoAreWe { get; set; }
    }
}

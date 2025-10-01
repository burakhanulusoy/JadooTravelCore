using AutoMapper;
using JadooTravelCore.Dtos.CategoryDtos;
using JadooTravelCore.Dtos.DestinationDtos;
using JadooTravelCore.Dtos.FeatureDtos;
using JadooTravelCore.Dtos.ReceiverMessageDtos;
using JadooTravelCore.Dtos.ServiceDtos;
using JadooTravelCore.Dtos.SupporterDtos;
using JadooTravelCore.Dtos.TestimonialDtos;
using JadooTravelCore.Dtos.UserDto;
using JadooTravelCore.Entities;

namespace JadooTravelCore.Mapping
{
    public class GeneralMapping:Profile
    {

        public GeneralMapping()
        {
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,GetCategoryByIdDto>().ReverseMap();

            CreateMap<User,GetByIdUserDto>().ReverseMap();
            CreateMap<User,ResultUserDto>().ReverseMap();
            CreateMap<User,CreateUserDto>().ReverseMap();
            CreateMap<User,UpdateUserDto>().ReverseMap();



            CreateMap<ReceiverMessage, UpdateReceiverMessageDto>().ReverseMap();
            CreateMap<ReceiverMessage, CreateReceiverMessageDto>().ReverseMap();
            CreateMap<ReceiverMessage, GetByIdReceiverMessageDto>().ReverseMap();
            CreateMap<ReceiverMessage, ResultReceiverMessageDto>().ReverseMap();
            CreateMap<UpdateReceiverMessageDto, GetByIdReceiverMessageDto>().ReverseMap();


            CreateMap<Destination,UpdateDestinationDto>().ReverseMap();
            CreateMap<Destination,CreateDestinationDto>().ReverseMap();
            CreateMap<Destination,ResultDestinationDto>().ReverseMap();
            CreateMap<Destination,GetDestinationByIdDto>().ReverseMap();


            CreateMap<Testimonial,ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial,UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial,CreateTetimonialDto>().ReverseMap();
            CreateMap<Testimonial,GetByIdTestimonial>().ReverseMap();


            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetFeatureByIdDto>().ReverseMap();

            CreateMap<Service,ResultServiceDto>().ReverseMap();
            CreateMap<Service,GetByIdServiceDto>().ReverseMap();
            CreateMap<Service,CreateServiceDto>().ReverseMap();
            CreateMap<Service,UpdateServiceDto>().ReverseMap();

            CreateMap<Supporter,ResultSupporterDto>().ReverseMap();
            CreateMap<Supporter,GetByIdSupporterDto>().ReverseMap();
            CreateMap<Supporter,CreateSupporterDto>().ReverseMap();
            CreateMap<Supporter,UpdateSupporterDto>().ReverseMap();



        }


    }
}

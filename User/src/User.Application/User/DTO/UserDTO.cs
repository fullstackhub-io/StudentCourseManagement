namespace User.Application.User.DTO
{
    using AutoMapper;
    using System;
    using global::User.Application.Common.Mappings;
    public class UserDTO : IMapFrom<Domain.Entities.User>
    {
        public int UserID { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.User, UserDTO>()
                 .ForMember(d => d.Salutation, opt => opt.MapFrom(s => s.Gender.ToUpper() == "M" ? "Hi Sir!" : "Hi Ma'am!"))
                 .ForMember(d => d.Age, opt => opt.MapFrom(s => DateTime.Today.Year - s.DOB.Year))
                 ;
            profile.CreateMap<UserDTO, Domain.Entities.User>();
        }
    }
}

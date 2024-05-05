using AutoMapper;
using System.ComponentModel.DataAnnotations;
using UE03_Eventmanagement_Backend._01_DB_Models;

namespace KT_CE_Api.DTOs.V1
{
    public class DTOs
    {
        //Room
        // GET DTO
        public class GetRoomDto
        {
            public string Name { get; set; }
            public string Location { get; set; }
            public string Floor { get; set; }
        }

        // PUT DTO
        public class UpdateRoomDto
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Location { get; set; }
            [Required]
            public string Floor { get; set; }
        }

        // POST DTO
        public class CreateRoomDto
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Location { get; set; }
            [Required]
            public string Floor { get; set; }
        }

        public class RoomProfile : Profile
        {
            public RoomProfile()
            {
                CreateMap<Room, GetRoomDto>().ReverseMap();
                CreateMap<UpdateRoomDto, Room>().ReverseMap();
                CreateMap<CreateRoomDto, Room>().ReverseMap();
            }
        }

        //LVA
        // GET DTO
        public class GetLVADto
        {
            public string Name { get; set; }
            public string Leader { get; set; }
            public string Type { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string Rhythm { get; set; }
        }

        // PUT DTO
        public class UpdateLVADto
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Leader { get; set; }
            [Required]
            public string Type { get; set; }
            [Required]
            public DateTime StartTime { get; set; }
            [Required]
            public DateTime EndTime { get; set; }
            [Required]
            public string Rhythm { get; set; }
        }

        // POST DTO
        public class CreateLVADto
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Leader { get; set; }
            [Required]
            public string Type { get; set; }
            [Required]
            public DateTime StartTime { get; set; }
            [Required]
            public DateTime EndTime { get; set; }
            [Required]
            public string Rhythm { get; set; }
        }

        public class LVAProfile : Profile
        {
            public LVAProfile()
            {
                CreateMap<LVA, GetLVADto>().ReverseMap();
                CreateMap<UpdateLVADto, LVA>().ReverseMap();
                CreateMap<CreateLVADto, LVA>().ReverseMap();
            }
        }

        //Booking
        // GET DTO
        public class GetBookingDto
        {
            public int RoomNr { get; set; }
            public string RoomName { get; set; }
            public string RoomLocation { get; set; }
            public DateTime Date { get; set; }
            public string From { get; set; }
            public string To { get; set; }
            public string Rhytm { get; set; }
            public string Type { get; set; }
            public int LVANr { get; set; }
            public string LVAName { get; set; }
            public string LVALeaderName { get; set; }
        }

        // PUT DTO
        public class UpdateBookingDto
        {
            [Required]
            public int Id { get; set; }
            [Required]
            public DateTime Date { get; set; }
            [Required]
            public int RoomId { get; set; }
            [Required]
            public int LvaId { get; set; }
        }

        // POST DTO
        public class CreateBookingDto
        {
            [Required]
            public DateTime Date { get; set; }
            [Required]
            public int RoomId { get; set; }
            [Required]
            public int LvaId { get; set; }
        }

        public class BookingProfile : Profile
        {
            public BookingProfile()
            {
                CreateMap<Booking, GetBookingDto>()
                    .ForMember(dest => dest.RoomNr, opt => opt.MapFrom(src => src.Room.Id))
                    .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.Room.Name))
                    .ForMember(dest => dest.RoomLocation, opt => opt.MapFrom(src => src.Room.Location))
                    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                    .ForMember(dest => dest.From, opt => opt.MapFrom(src => src.LVA.StartTime.ToString("HH:mm")))
                    .ForMember(dest => dest.To, opt => opt.MapFrom(src => src.LVA.EndTime.ToString("HH:mm")))
                    .ForMember(dest => dest.Rhytm, opt => opt.MapFrom(src => src.LVA.Rhythm))
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.LVA.Type))
                    .ForMember(dest => dest.LVANr, opt => opt.MapFrom(src => src.LVA.Id))
                    .ForMember(dest => dest.LVAName, opt => opt.MapFrom(src => src.LVA.Name))
                    .ForMember(dest => dest.LVALeaderName, opt => opt.MapFrom(src => src.LVA.Leader));
                CreateMap<UpdateBookingDto, Booking>().ReverseMap();
                CreateMap<CreateBookingDto, Booking>().ReverseMap();
            }
        }

    }
}

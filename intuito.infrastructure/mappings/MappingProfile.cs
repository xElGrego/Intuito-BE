using AutoMapper;
using intuito.domain.DTOs;
using intuito.domain.entities;

namespace intuito.infrastructure.mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDto, CustomerEntity>();
            CreateMap<MovieDto, MovieEntity>();
            CreateMap<RoomDto, RoomEntity>();
            CreateMap<SeatDto, SeatEntity>();
            CreateMap<BillboardDto, BillboardEntity>();
            CreateMap<BillboardEntity, BillboardDto>();
            CreateMap<BookingDto, BookingEntity>();
        }
    }
}
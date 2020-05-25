using System;
using AutoMapper;
using ecoupon.DTO;
using ecoupon.models;

namespace ecoupon.mapper
{
    public class EcouponProfile : Profile
    {
        public EcouponProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}

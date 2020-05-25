using System;
using AutoMapper;
using ecoupon.DTO;
using ecoupon.models;

namespace ecoupon.mapper
{
    public class EcouponMapperConfiguration
    {
        public static IMapper Configure()
        {
             var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new EcouponProfile());
                });
            IMapper mapper = mappingConfig.CreateMapper();
            return mapper;
        }
    }
}

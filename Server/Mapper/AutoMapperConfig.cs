using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MFA.Server.Domain;
using MFA.Shared.DTOs;

namespace MFA.Server.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<RefreshToken, RefreshTokenDto>();
            });
            
            configuration.AssertConfigurationIsValid();

            return configuration.CreateMapper();
        }
    }
}
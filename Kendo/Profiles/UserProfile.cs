using AutoMapper;
using Kendo.dtos;
using Kendo.Models;
using System.Collections.Generic;

namespace Kendo.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserWriteDto, User>();
            CreateMap<UserStatisticWriteDto, User>();
            CreateMap<BattleStatisticWriteDto, BattleStatistic>();
            CreateMap< BattleStatistic, BattleStatisticWriteDto>();

            CreateMap<User, UserWriteDto>();
            CreateMap<UserWriteDto, User>();
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Business
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Dtos.GiftInput, Data.Gift>();
            CreateMap<Data.Gift, Dtos.Gift>();

            CreateMap<Dtos.UserInput, Data.User>();
            CreateMap<Data.User, Dtos.User>();
        }
    }
}

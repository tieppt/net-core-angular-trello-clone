using AutoMapper;
using Trollo.API.Data.Entities;
using Trollo.Common.ViewModels;

namespace Trollo.API.Profiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<Card, CardVm>().ReverseMap();
            CreateMap<Card, CardInformation>().ReverseMap();
        }
    }
}
using AutoMapper;
using Trollo.Common.ViewModels;
using TrolloAPI.Data.Entities;

namespace TrolloAPI.Profiles
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
using System.Linq;
using AutoMapper;
using Trollo.Common.ViewModels;
using TrolloAPI.Data.Entities;

namespace TrolloAPI.Profiles
{
    public class BoardProfile : Profile
    {
        public BoardProfile()
        {
            CreateMap<Board, BoardVm>().ReverseMap();
            CreateMap<Board, BoardInformation>()
                .ForMember(d => d.ListCardIds, exp => exp.MapFrom(s => s.ListCards.Select(lc => lc.Id)))
                .ReverseMap();
        }
    }
}
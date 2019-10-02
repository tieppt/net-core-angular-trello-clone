using System;
using System.Collections.Generic;

namespace Trollo.Common.ViewModels
{
    public class ListCardVm : BaseVm
    {
        public ListCardVm()
        {
            Cards = new List<CardInformation>();
        }

        public string Title { get; set; }
        public int Order { get; set; }
        public Guid BoardId { get; set; }
        public BoardInformation Board { get; set; }
        public List<CardInformation> Cards { get; set; }
    }
}
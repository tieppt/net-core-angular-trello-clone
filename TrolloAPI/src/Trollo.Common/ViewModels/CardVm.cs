using System;

namespace Trollo.Common.ViewModels
{
    public class CardVm : BaseVm
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public Guid ListCardId { get; set; }
        public ListCardInformation ListCard { get; set; }
    }
}
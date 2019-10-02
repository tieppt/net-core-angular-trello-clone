using System;
using System.Collections.Generic;

namespace Trollo.Common.ViewModels
{
    public class ListCardInformation : BaseVm
    {
        public string Title { get; set; }
        public int Order { get; set; }
        public Guid BoardId { get; set; }
        public List<Guid> CardIds { get; set; }

        public ListCardInformation()
        {
            CardIds = new List<Guid>();
        }
    }
}
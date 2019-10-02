using System;
using System.Collections.Generic;

namespace Trollo.Common.ViewModels
{
    public class BoardInformation : BaseVm
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public string Scope { get; set; }
        public Guid UserId { get; set; }
        public List<Guid> ListCardIds { get; set; }

        public BoardInformation()
        {
            ListCardIds = new List<Guid>();
        }
    }
}
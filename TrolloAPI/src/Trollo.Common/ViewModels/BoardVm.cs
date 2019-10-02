using System;
using System.Collections.Generic;

namespace Trollo.Common.ViewModels
{
    public class BoardVm : BaseVm
    {
        public BoardVm()
        {
            ListCards = new List<ListCardVm>();
        }

        public string Title { get; set; }
        public string Status { get; set; }
        public string Scope { get; set; }
        public Guid UserId { get; set; }
        public List<ListCardVm> ListCards { get; set; }
    }
}
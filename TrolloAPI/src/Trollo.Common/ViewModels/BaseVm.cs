using System;

namespace Trollo.Common.ViewModels
{
    public class BaseVm
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
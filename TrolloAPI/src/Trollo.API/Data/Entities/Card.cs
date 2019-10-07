using System;

namespace Trollo.API.Data.Entities
{
    public class Card : BaseEntity
    {
        internal Card()
        {
        }

        public Card(string title, string description = "", int order = 0)
        {
            Title = title;
            Description = description;
            Order = order;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public Guid ListCardId { get; set; }
        public virtual ListCard ListCard { get; set; }
    }
}
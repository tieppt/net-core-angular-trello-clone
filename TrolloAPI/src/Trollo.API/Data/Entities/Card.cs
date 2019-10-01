using System;
using System.ComponentModel.DataAnnotations;

namespace TrolloAPI.Data.Entities
{
    public class Card : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public Guid ListCardId { get; set; }
        public virtual ListCard ListCard { get; set; }
        internal Card()
        {
        }

        public Card(string title, string description = "", int order = 0)
        {
            Title = title;
            Description = description;
            Order = order;
        }
    }
}
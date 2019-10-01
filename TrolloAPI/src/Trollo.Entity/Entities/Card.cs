using System;
using System.ComponentModel.DataAnnotations;

namespace Trollo.Entity.Entities
{
    public class Card : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public Guid ListCardId { get; set; }
        public ListCard ListCard { get; set; }
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
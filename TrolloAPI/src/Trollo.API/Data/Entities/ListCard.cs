using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrolloAPI.Data.Entities
{
    public class ListCard : BaseEntity
    {
        public string Title { get; set; }
        public int Order { get; set; }
        public Guid BoardId { get; set; }
        public virtual Board Board { get; set; }
        public virtual ICollection<Card> Cards { get; set; }

        internal ListCard()
        {
        }

        public ListCard(string title, int order = 0)
        {
            Title = title;
            Order = order;
            Cards = new HashSet<Card>();
        }
    }
}
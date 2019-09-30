using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trollo.Common.Entities
{
    public class ListCard : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        public int Order { get; set; }
        public Guid BoardId { get; set; }
        public Board Board { get; set; }
        public List<Card> Cards { get; set; }

        internal ListCard()
        {
        }

        public ListCard(string title, int order = 0)
        {
            Title = title;
            Order = order;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrolloAPI.Data.Entities
{
    public class Board : BaseEntity
    {
        public string Title { get; set; }
        public string Status { get; set; } // draft or published
        public string Scope { get; set; } // private or public
        public Guid UserId { get; set; }
//        public AppUser User { get; set; }
        public virtual ICollection<ListCard> ListCards { get; set; }

        internal Board()
        {
        }

        public Board(string title, string status, string scope)
        {
            Title = title;
            Status = status;
            Scope = scope;
            CreatedAt = DateTime.UtcNow;
            ModifiedAt = DateTime.UtcNow;
            ListCards = new HashSet<ListCard>();
        }
    }
}
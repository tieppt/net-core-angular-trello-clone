using System;
using System.Collections.Generic;

namespace Trollo.API.Data.Entities
{
    public class Board : BaseEntity
    {
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

        public string Title { get; set; }
        public string Status { get; set; } // draft or published
        public string Scope { get; set; } // private or public

        public Guid UserId { get; set; }

//        public AppUser User { get; set; }
        public virtual ICollection<ListCard> ListCards { get; set; }
    }
}
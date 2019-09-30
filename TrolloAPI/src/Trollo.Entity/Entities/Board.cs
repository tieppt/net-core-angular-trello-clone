using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Trollo.Identity.Identity;

namespace Trollo.Entity.Entities
{
    public class Board : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        [MaxLength(16)]
        public string Status { get; set; } // draft or published
        [Required]
        [MaxLength(16)]
        public string Scope { get; set; } // private or public
        
        public Guid UserId { get; set; }
//        public AppUser User { get; set; }
        
        public List<ListCard> ListCards { get; set; }

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
        }
    }
}
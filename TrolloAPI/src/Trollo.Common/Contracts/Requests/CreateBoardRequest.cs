using System.ComponentModel.DataAnnotations;

namespace Trollo.Common.Contracts.Requests
{
    public class CreateBoardRequest
    {
        [Required]
        [StringLength(255, ErrorMessage = "TITLE_MIN_LENGTH", MinimumLength = 6)]
        public string Title { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuessingGame.Models
{
    public class GameViewModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Too short")]
        [MaxLength(20, ErrorMessage = "Too long")]
        [Display(Name = "Player Name")]
        public string PlayerName { get; set; }

        [Required(ErrorMessage = "Guess is required.")]
        [Range(1, 10, ErrorMessage = "Guess must be between 1 and 10")]
        public int Guess { get; set; }

        public override string ToString() => $"{PlayerName} ({Guess})";
    }
}

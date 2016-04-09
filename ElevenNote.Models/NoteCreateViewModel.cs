using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteCreateViewModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least two characters")]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        [MaxLength(8000)]
        public string Content { get; set; }

        public override string ToString() => $"[New] {Title}";
    }
}

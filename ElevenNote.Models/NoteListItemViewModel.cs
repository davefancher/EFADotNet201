using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteListItemViewModel
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public bool IsStarred { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString() => $"[{NoteId}] {Title}";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;

namespace ElevenNote.Web.Controllers.WebApi
{
    [Authorize]
    [RoutePrefix("api/Notes")]
    public class NotesController : ApiController
    {
        private readonly Lazy<NoteService> _svc;

        public NotesController()
        {
            _svc =
                new Lazy<NoteService>(
                    () =>
                    {
                        var userId = Guid.Parse(User.Identity.GetUserId());
                        return new NoteService(userId);
                    });
        }

        [Route]
        public IEnumerable<NoteListItemViewModel> Get()
        {
            return _svc.Value.GetNotes();
        }

        [Route]
        public bool Post(NoteCreateViewModel vm)
        {
            return _svc.Value.CreateNote(vm);
        }

        [Route("{id}")]
        public NoteDetailViewModel Get(int id)
        {
            return _svc.Value.GetNoteById(id);
        }

        [Route("{id}")]
        public bool Put(int id, NoteEditViewModel vm)
        {
            return _svc.Value.UpdateNote(vm);
        }

        [Route("{id}")]
        public bool Delete(int id)
        {
            return _svc.Value.DeleteNote(id);
        }

        private bool SetStarState(int noteId, bool state)
        {
            var detail =
                _svc
                    .Value
                    .GetNoteById(noteId);

            var note =
                new NoteEditViewModel
                {
                    NoteId = detail.NoteId,
                    Title = detail.Title,
                    Content = detail.Content,
                    IsStarred = state
                };

            return _svc.Value.UpdateNote(note);
        }

        [Route("{id}/Star")]
        [HttpPost]
        public bool ToggleStarOn(int id)
        {
            return SetStarState(id, true);
        }

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id)
        {
            return SetStarState(id, false);
        }
    }
}

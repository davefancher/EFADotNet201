using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;

namespace ElevenNote.Web.Controllers
{
    [Authorize]
    public class NotesController : Controller
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

        public ActionResult Index()
        {
            var notes = _svc.Value.GetNotes();

            return View(notes);
        }

        public ActionResult Create()
        {
            var vm = new NoteCreateViewModel();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(NoteCreateViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            if(!_svc.Value.CreateNote(vm))
            {
                ModelState.AddModelError("", "Unable to create note");
                return View(vm);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var note = _svc.Value.GetNoteById(id);

            return View(note);
        }

        public ActionResult Edit(int id)
        {
            var detail = _svc.Value.GetNoteById(id);
            var note =
                new NoteEditViewModel
                {
                    NoteId = detail.NoteId,
                    Title = detail.Title,
                    Content = detail.Content,
                    IsStarred = detail.IsStarred
                };

            return View(note);
        }

        [HttpPost]
        public ActionResult Edit(NoteEditViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            if(!_svc.Value.UpdateNote(vm))
            {
                ModelState.AddModelError("", "Unable to update note");
                return View(vm);
            }

            return RedirectToAction("Index");
        }
    }
}

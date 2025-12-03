using Microsoft.AspNetCore.Mvc;
using NotesApp.Models;
using NotesApp.Repositories;

namespace NotesApp.Controllers
{
    public class NotesController : Controller
    {
        private readonly INoteRepository _repo;
        public NotesController(INoteRepository repository)
        {
            _repo = repository;
        }

        public async Task<IActionResult> Index()
        {
            var notes = await _repo.GetAllAsync();
            return View(notes);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Note note)
        {
            if (!ModelState.IsValid) return View(note);
            await _repo.AddAsync(note);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var note = await _repo.GetAsync(id);
            if (note == null) return NotFound();
            return View(note);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Note note)
        {
            if (!ModelState.IsValid) return View(note);
            note.UpdatedAt = DateTime.UtcNow;
            await _repo.UpdateAsync(note);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var note = await _repo.GetAsync(id);
            if (note == null) return NotFound();
            return View(note);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
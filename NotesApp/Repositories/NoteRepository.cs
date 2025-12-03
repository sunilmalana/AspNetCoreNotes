
using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Models;

namespace NotesApp.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _db;
        public NoteRepository(AppDbContext db) { _db = db; }

        public async Task AddAsync(Note note)
        {
            _db.Notes.Add(note);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var note = await _db.Notes.FindAsync(id);
            if (note != null)
            {
                _db.Remove(note);
                await _db.SaveChangesAsync();
            }
        }

        public Task<List<Note>> GetAllAsync() =>
            _db.Notes.OrderByDescending(x => x.CreatedAt).ToListAsync();

        public Task<Note?> GetAsync(int id) =>
            _db.Notes.FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(Note note)
        {
            _db.Notes.Update(note);
            await _db.SaveChangesAsync();
        }
    }
}
using NotesApp.Models;

namespace NotesApp.Repositories
{
    public interface INoteRepository
    {
        Task<List<Note>> GetAllAsync();
        Task<Note?> GetAsync(int id);
        Task AddAsync(Note note);
        Task UpdateAsync(Note note);
        Task DeleteAsync(int id);
    }
}
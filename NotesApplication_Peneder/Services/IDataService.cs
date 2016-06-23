using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotesExercise03_Peneder.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Note>> GetAllNotes();

        Task SaveNote(Note note);

        Task AddNote(Note note);

        Task DeleteNote(Note note);
    }
}
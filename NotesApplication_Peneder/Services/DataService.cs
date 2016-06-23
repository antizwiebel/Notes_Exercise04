using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotesExercise03_Peneder.Services
{
    public class DataService : IDataService
    {

        private readonly List<Note> allNotes;

        public DataService()
        {
            allNotes= new List<Note>();
        }

        public async Task<IEnumerable<Note>> GetAllNotes()
        {
            return allNotes;
        }

        public Task AddNote(Note note)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteNote(Note note)
        {
            allNotes.Remove(note);
        }

        public async Task SaveNote(Note note)
        {
            allNotes.Add(note);
        }
    }
}
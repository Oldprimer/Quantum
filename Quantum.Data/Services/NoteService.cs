using Quantum.Data.Interfaces;
using Quantum.Data.Model;

namespace Quantum.Data.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> noteRepo;
        
        
        public NoteService(IRepository<Note> noteRepo)
        {
            this.noteRepo = noteRepo;
        }

        public IEnumerable<Note> GetAll()
        {
            return noteRepo.GetAll();
        }

        public Note? Find(Guid id)
        {
            return noteRepo.Find(id);
        }

        public void Update(Note note)
        {
            noteRepo.Update(note);
            noteRepo.Save();
        }

        public void Add(string header, string content)
        {
            noteRepo.Add(
                new Note
                {
                    Note_Id = Guid.NewGuid(),
                    Header = header,
                    Content = content,
                    Created = DateTime.Now
                });
            noteRepo.Save();
        }

        public IEnumerable<Note> Filter(string filter)
        {
            return noteRepo.Where(note => note.Header.Contains(filter) || note.Content.Contains(filter));
        }
    }
}

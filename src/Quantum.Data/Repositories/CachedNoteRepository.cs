using Quantum.Data.Interfaces;
using Quantum.Data.Model;
using System.Linq.Expressions;

namespace Quantum.Data.Repositories
{
    public class CachedNoteRepository : IRepository<Note>
    {
        private readonly NoteRepository NoteRepository;
        private IEnumerable<Note> Notes;

        public CachedNoteRepository(NoteRepository noteRepository)
        {
            NoteRepository = noteRepository;
        }


        public void Add(Note item)
        {
            Notes = null;
            NoteRepository.Add(item);
        }

        public Note? Find(Guid id)
        {
            return NoteRepository.Find(id);
        }

        public IEnumerable<Note> GetAll()
        {
            if (Notes != null)
                return Notes;
            Notes = NoteRepository.GetAll();
            return Notes;

        }

        public void Save()
        {
            NoteRepository.Save();
        }

        public void Update(Note item)
        {
            Notes = null;
            NoteRepository.Update(item);
        }

        public IEnumerable<Note> Where(Expression<Func<Note, bool>> expresion)
        {
            return NoteRepository.Where(expresion);
        }
    }
}

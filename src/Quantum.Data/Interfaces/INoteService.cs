using Quantum.Data.Model;

namespace Quantum.Data.Interfaces
{
    public interface INoteService
    {
        IEnumerable<Note> GetAll();
        IEnumerable<Note> Filter(string filter);
        Note? Find(Guid id);
        void Update(Note note);
        void Add(string header, string content);

    }
}
using System.Linq.Expressions;

namespace Quantum.Tests.Mock
{
    public class NoteRepositoryMock : IRepository<Note>
    {
        private readonly List<Note> notes = new List<Note>
        {
                new Note
                {
                    Note_Id = Guid.NewGuid(),
                    Header = "Note 1 Header",
                    Content = "Note 1 Content",
                    Created = DateTime.Now.AddDays(-5)
                },
                new Note
                {
                    Note_Id = Guid.NewGuid(),
                    Header = "Note 2 Header",
                    Content = "Note 2 Content",
                    Created = DateTime.Now.AddDays(-4)
                },
                new Note
                {
                    Note_Id = Guid.NewGuid(),
                    Header = "Note 3 Header",
                    Content = "Note 3 Content",
                    Created = DateTime.Now.AddDays(-3)
                },
                new Note
                {
                    Note_Id = Guid.NewGuid(),
                    Header = "Note 4 Header",
                    Content = "Note 4 Content",
                    Created = DateTime.Now.AddDays(-2)
                },
        };

        public void Add(Note item)
        {
            notes.Add(item);
        }

        public Note? Find(Guid id)
        {
            return notes.SingleOrDefault(x => x.Note_Id == id);
        }

        public IEnumerable<Note> GetAll()
        {
            return notes;
        }

        public void Save()
        {
        }

        public void Update(Note item)
        {
            notes.ForEach(note =>
            {
                if (note.Note_Id == item.Note_Id)
                {

                    note.Header = item.Header;
                    note.Content = item.Content;
                    note.Created = item.Created;
                }
            });
        }

        public IEnumerable<Note> Where(Expression<Func<Note, bool>> expresion)
        {
            return notes.Where(expresion.Compile());
        }
    }
}

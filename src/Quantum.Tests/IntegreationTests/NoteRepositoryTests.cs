using Quantum.Data.Context;
using Quantum.Data.Repositories;

namespace Quantum.Tests.IntegreationTests
{
    [TestFixture]
    public class NoteRepositoryTests
    {
        private readonly PostgreSqlContext context;
        private readonly IRepository<Note> noteRepository;
        public NoteRepositoryTests()
        {
            context = new PostgreSqlContextFactory().CreateDbContext(Array.Empty<string>());
            noteRepository = new NoteRepository(context);
        }

        [Test]
        public void Add_NewNote_ShouldAddNoteToDb()
        {
            Note note = new Note()
            {
                Note_Id = Guid.NewGuid(),
                Header = "qwerty",
                Content = "12345",
                Created = DateTime.Now,
            }; 

            noteRepository.Add(note);
            Note result = noteRepository.Find(note.Note_Id);

            Assert.That(note, Is.EqualTo(result));

        }
        [Test]
        public void Add_NullNote_ShouldThrowArgumentNullException()
        {

            Assert.Catch<ArgumentNullException>(() =>
            {
                noteRepository.Add(null!);
            });
        }
    }
}

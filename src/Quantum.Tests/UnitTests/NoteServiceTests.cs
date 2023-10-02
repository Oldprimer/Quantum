using Quantum.Data.Services;
using Quantum.Tests.Mock;

namespace Quantum.Tests.UnitTests
{
    [TestFixture]
    public class NoteServiceTests
    {
        private readonly INoteService noteService;
        public NoteServiceTests()
        {
            noteService = new NoteService(new NoteRepositoryMock());
        }

        [Test]
        public void Add_HeaderAndContext_ShouldAddNewNote()
        {
            var random = new Random();
            string header = random.Next().ToString();
            string content = random.Next().ToString();


            noteService.Add(header, content);

            Assert.True(noteService.GetAll().Any(x => x.Header == header && x.Content == content));
        }
        [Test]
        public void Add_NULLS_ShouldAddNewNote()
        {
            noteService.Add(null, null);

            Assert.True(noteService.GetAll().Any(x => 
            string.IsNullOrWhiteSpace(x.Header) && string.IsNullOrWhiteSpace(x.Content)));
        }
        public void Filter_NoteFilter_ShouldReturnNotes()
        {
            var filter = "Note";
            var result = noteService.Filter(filter);

            Assert.IsTrue(result.All(note => note.Header.Contains(filter) || note.Content.Contains(filter)));
        }
    }
}

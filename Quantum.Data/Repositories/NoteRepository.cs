using Quantum.Data.Context;
using Quantum.Data.Interfaces;
using Quantum.Data.Model;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
namespace Quantum.Data.Repositories
{
    public class NoteRepository : IRepository<Note>
    {
        private readonly PostgreSqlContext postgreSqlContext;
        public NoteRepository(PostgreSqlContext postgreSqlContext)
        {
            this.postgreSqlContext = postgreSqlContext;
        }

        public IEnumerable<Note> GetAll()
        {
            return postgreSqlContext.Notes.OrderBy(note => note.Created);
        }
        public IEnumerable<Note> Where(Expression<Func<Note, bool>> where)
        {
            return postgreSqlContext.Notes.Where(where);
        }
        public Note? Find(Guid id)
        {
            return postgreSqlContext.Notes.Find(id);
        }
        public void Add(Note note)
        {
            postgreSqlContext.Notes.Add(note);
        }
        public void Update(Note note)
        {
            postgreSqlContext.Notes.Update(note);
        }

        public void Save()
        {
            postgreSqlContext.SaveChanges();
        }
    }
}

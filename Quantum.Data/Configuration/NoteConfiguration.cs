using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quantum.Data.Model;

namespace Quantum.Data.Configuration
{
    internal class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(note => note.Note_Id).HasName("note_pkey");

            builder.Property(note => note.Note_Id).HasColumnName("note_id");
            builder.Property(note => note.Header).HasColumnName("header");
            builder.Property(note => note.Content).HasColumnName("content");
            builder.Property(note => note.Created).HasColumnName("created").HasColumnType("timestamp without time zone");

            builder.ToTable("Notes");
            builder.HasData(new[] { new Note
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
                },});
        }
    }
}

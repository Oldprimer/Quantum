namespace Quantum.Data.Model
{
    public class Note
    {
        public Guid Note_Id { get; set; }
        public string? Header { get; set; }
        public string? Content { get; set; }
        public DateTime? Created { get; set; }
    }
}

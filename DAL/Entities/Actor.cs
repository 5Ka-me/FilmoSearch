namespace DAL.Entities
{
    public class Actor : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public ICollection<ActorFilm>? Films { get; set; }
    }
}

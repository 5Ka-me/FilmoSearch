namespace DAL.Entities
{
    public class Film : BaseEntity
    {
        public string Title { get; set; } = null!;

        public ICollection<ActorFilm>? Actors { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}

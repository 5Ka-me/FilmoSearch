namespace DAL.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public ICollection<ActorFilm>? Actors { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}

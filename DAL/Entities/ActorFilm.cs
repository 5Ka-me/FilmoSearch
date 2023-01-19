namespace DAL.Entities
{
    public class ActorFilm
    {
        public int ActorId { get; set; }
        public int FilmId { get; set; }

        public Actor Actor { get; set; } = null!;
        public Film Film { get; set; } = null!;
    }
}

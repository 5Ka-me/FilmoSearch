namespace DAL.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Stars { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}

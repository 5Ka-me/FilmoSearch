namespace DAL.Entities
{
    public class Review : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Stars { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; } = null!;
    }
}

namespace BiblioContext.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName {  get; set; }
        public string AuthorLastName { get; set; }
        public string Ganre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsAvailable { get; set; }

    }
}


namespace LibraryApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
    }
}

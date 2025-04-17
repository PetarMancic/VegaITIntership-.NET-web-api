namespace Bookstore.Domain.Entities;
public class Author : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Country { get; set; }
    public List<Book> Books { get; set; }
}

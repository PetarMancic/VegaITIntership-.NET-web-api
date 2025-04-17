using Bookstore.Domain.Entities;
public class Book : BaseEntity
{
    public string Title { get; set; }
    public float Price { get; set; }
    public Author Author { get; set; }
}


namespace Bookstore.Domain.Exceptions;
public class BookNotFoundException: Exception
{
    public BookNotFoundException(int bookId) : base( $"Book with {bookId} is not found!") {}
    public BookNotFoundException(int bookId , Exception ex) :base( $"Book with {bookId} is not found!", ex) {}
}
   


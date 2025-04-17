namespace Bookstore.Domain.Exceptions;
public class AuthorNotFoundExcpetion :Exception
{
    public AuthorNotFoundExcpetion(int authorId): base($"Author with {authorId} is not found!") {}
    public AuthorNotFoundExcpetion(int authorId, Exception ex): base($"Author with {authorId} is not found!",ex){}
}

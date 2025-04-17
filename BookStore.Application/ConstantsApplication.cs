namespace BookStore.Application;

public static class ConstantsApplication
{
    public static class AuthorExceptionMessages 
    {        
        public static string AuthorUpdated = "Author successfully updated!";
        public static string AuthorSoftDeleted = "Author successfully softly deleted!";
        public static string AuthorHardDeleted = "Author successfully hard deleted!";

    }

    public static class BookExceptionMessages
    {
        public static string BookUpdated = "Book successfully updated!";
        public static string BookSoftDeleted = "Book successfully softly deleted!";
        public static string BookHardDeleted = "Book successfully hard deleted!";
    }
}

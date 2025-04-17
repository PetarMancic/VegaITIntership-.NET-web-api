using Bookstore.Domain.DTO.Author;
using Bookstore.Domain.DTO.AuthorDtos;
using Bookstore.Domain.Entities;
using Bookstore.MappingExtensions.BookMapingExtension;


namespace Bookstore.MappingExtensions.AuthorMappingExtensions;
public static class AuthorMappingExtensions
{

    /// <summary>
    /// It converts object type <see cref="AddAuthorDTO"/> in object type <see cref="Author"/>
    /// </summary>
    /// <param name="dto"> The <see cref="AddAuthorDTO"/>  object to convert </param>
    /// <returns>A new <see cref="Author"/> entity with properties mapped from the DTO 
/// and an empty book collection. </returns>
    public static Author ToDomainEntity(this AddAuthorDTO dto )
    {
        return new Author
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Country = dto.Country,
            Books = [],
        };
    }
            
            
    /// <summary>
    ///  Converts an <see cref="Author"/> entity to a <see cref="NewAuthorDTO"/> without including the books collection.
    /// </summary>
    /// <param name="author">The <see cref="Author"/> entity to convert.</param>
    /// <returns> Returns a new  author object but without list of books. </returns>
    public  static NewAuthorDTO ToNewAuthorDTO( this Author author)
    {
        return new NewAuthorDTO(
            author.Id,
            author.Name,
            author.Surname,
            author.Country
        );
    }
            


    /// <summary>
    ///Converts <see cref="Author"/> entity to a <see cref="GetAuthorDTO"/> including the books collection.
    /// </summary>
    /// <param name="author"></param>
    /// <returns>Returns a new author object including list of books.</returns>
    public static GetAuthorDTO ToGetAuthorDTO(this Author  author)
    {
       return new GetAuthorDTO(
            author.Id,
            author.Name,
            author.Surname,
            author.Country,
            author.CreatedAt,
            author.UpdatedAt,
            author.DeletedAt,
            author.Books.Select(book => book.ToBookDto()).ToList()
        );
    }
    public static void ApplyUpdate(this Author author, string newName, string newSurname, string newCountry)
    {
        author.Name= newName;
        author.Surname=newSurname;
        author.Country=newCountry;
        
    }
}
        

        
    


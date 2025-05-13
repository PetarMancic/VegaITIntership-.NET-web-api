using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStore.Domain.Entities;

public class User : IdentityUser
{
    public int  Id{ get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;

}

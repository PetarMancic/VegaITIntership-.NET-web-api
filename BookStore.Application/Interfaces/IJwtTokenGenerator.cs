using BookStore.Domain.Entities;

namespace BookStore.Application.Interfaces;
public interface IJwtTokenGenerator
{
    public string GenerateToken( User user);
}

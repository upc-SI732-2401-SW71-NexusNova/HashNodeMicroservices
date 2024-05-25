using HashNode.API.AccessIdentityManagement.Domain.Repositories;
using HashNode.API.Shared.Infrastructure.Persistence.Data;
using HashNode.API.Shared.Infrastructure.Persistence.Repositories;
using HashNode.API.UserManagement.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace HashNode.API.AccessIdentityManagement.infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User> FindUserByIdAsync(string id)
    {
        return await _context.Users.FindAsync(id);
    }
    
    public async Task<User> FindUserByEmailAsync(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(e => e.Email == email);
    }

    public async Task<IEnumerable<User>> ListAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task CreateUserAsync(User newUser)
    {
        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User updateUser)
    {
        _context.Users.Update(updateUser);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User deleteUser)
    {
        _context.Users.Remove(deleteUser);
        await _context.SaveChangesAsync();
    }

    public bool UserExists(string userId)
    {
        return _context.Users.Any(e => e.Id == userId);
    }
}
using Domain.Entities;
using Application.User.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.User;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<UserEntity> GetAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<UserEntity> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<UserEntity> CreateAsync(UserEntity user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<UserEntity> UpdateAsync(UserEntity user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}

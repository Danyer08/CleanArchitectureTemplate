using Domain.Entities;
using Application.User.Interfaces;

namespace Application.User.Commands;

public class RegisterCommand(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserEntity> ExecuteAsync(string name, string email, string password)
    {
        var user = new UserEntity
        {
            Name = name,
            Email = email,
            Password = password
        };
        return await _userRepository.CreateAsync(user);
    }
}
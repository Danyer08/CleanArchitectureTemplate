using Domain.Entities;
using Application.User.Interfaces;

namespace Application.User.Commands;

public class LoginCommand(IUserRepository userRepository) {
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserEntity> ExecuteAsync(string email, string password) {
        var user = await _userRepository.GetByEmailAsync(email) ?? throw new Exception("User not found");

        // if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
        // {
        //     throw new Exception("Invalid password");
        // }


        return user;
    }
}
using Domain.Entities;
using Application.Common;

namespace Application.User.Interfaces;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    Task<UserEntity> GetByEmailAsync(string email);
}

using e_Kart.Core.Entities;

namespace e_Kart.Core.RepositoryContracts
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> AddUser(ApplicationUser? user);
        Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
    }
}

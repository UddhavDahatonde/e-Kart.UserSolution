using Dapper;
using e_Kart.Core.Entities;
using e_Kart.Core.RepositoryContracts;
using e_Kart.Infrastructure.ApplicationDbContext;

namespace e_Kart.Infrastructure.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly DbContext _dbContext;
        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser? user)
        {
            user.UserID = Guid.NewGuid();
            var parameters = new
            {
                UserID = user.UserID,
                Email = user.Email,
                PersonName = user.PersonName,
                Gender = user.Gender,
                Password = user.Password
            };
            string query = "insert into public.\"Users\"(\"UserID\",\"Email\",\"PersonName\",\"Gender\",\"Password\")" +
                "Values(@UserID,@Email,@PersonName,@Gender,@Password)";
            int rowAffected = await _dbContext.DbConnection.ExecuteAsync(query, parameters);

            if (rowAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
            var parameters = new { Email = email, Password = password };

            return await _dbContext.DbConnection.QuerySingleOrDefaultAsync<ApplicationUser>(query, parameters);

        }
    }

}

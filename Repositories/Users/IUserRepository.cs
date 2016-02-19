using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<List<User>> GetAll(int divisionId);

        void Add(User user);
        Task<User> Get(int userId);
        void Delete(int userId);
        void Update(User user);
    }
}

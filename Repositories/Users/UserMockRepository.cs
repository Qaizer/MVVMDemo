using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Users
{
    class UserMockRepository : IUserRepository
    {
        public void Add(User user)
        {
            return;
        }

        public void Delete(int userId)
        {
            return;
        }

        public Task<User> Get(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            return;
        }
    }
}

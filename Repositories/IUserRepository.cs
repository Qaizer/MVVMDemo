using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRepository
    {
        IList<User> GetAll();

        void Add(User user);
        User Get(int userId);
        void Delete(int userId);
        void Update(int userId);
    }
}

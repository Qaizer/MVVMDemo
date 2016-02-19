using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Users
{
    public class UserRepository : IUserRepository
    {

        public async void Add(User user)
        {
            using (var context = new MVVMDemoDBEntities())
            {
                context.Users.Add(new User { FirstName = user.FirstName, LastName = user.LastName });
                await context.SaveChangesAsync();
            }
        }

        public async void Delete(int userId)
        {
            using (var context = new MVVMDemoDBEntities())
            {
                context.Users.Remove(await context.Users.FirstOrDefaultAsync(x => x.UserId == userId));
                await context.SaveChangesAsync();
            }
        }

        public async Task<User> Get(int userId)
        {
            using (var context = new MVVMDemoDBEntities())
            {
                return await context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            }
        }

        public async Task<List<User>> GetAll()
        {
            using (var context = new MVVMDemoDBEntities())
            {
                return await context.Users.ToListAsync();
            }
        }

        public async void Update(User user)
        {
            using (var context = new MVVMDemoDBEntities())
            {
                User userToUpdate = await context.Users.FirstOrDefaultAsync(x => x.UserId == user.UserId);
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.Division = user.Division;
                await context.SaveChangesAsync();
            }
        }
    }
}

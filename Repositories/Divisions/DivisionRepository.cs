using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Divisions
{
    public class DivisionRepository : IDivisionRepository
    {
        public async void Add(string name)
        {
            using (var context = new MVVMDemoDBEntities())
            {
                if(!context.Divisions.Any(x => x.Name == name))
                {
                    context.Divisions.Add(new Division { Name = name });
                    await context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("En avdelning med det namnet finns redan");
                }
            }
        }

        public async void Delete(int divisionId)
        {
            using(var context = new MVVMDemoDBEntities())
            {
                context.Divisions.Remove(await context.Divisions.FirstOrDefaultAsync(x => x.DivisionId == divisionId));
                await context.SaveChangesAsync();
            }
        }

        public async Task<Division> Get(int divisionId)
        {
            using (var context = new MVVMDemoDBEntities())
            {
                return await context.Divisions.FirstOrDefaultAsync(x => x.DivisionId == divisionId);
            }
        }

        public async Task<List<Division>> GetAll()
        {
            using (var context = new MVVMDemoDBEntities())
            {
                //await Task.Delay(2000);
                return await context.Divisions.ToListAsync();
            }
        }

        public void Update(int divisionId)
        {
            throw new NotImplementedException();
        }

        public async void Update(Division division)
        {
            using(var context = new MVVMDemoDBEntities())
            {
                var divisionToUpdate = await context.Divisions.FirstOrDefaultAsync(x => x.DivisionId == division.DivisionId);
                divisionToUpdate.Name = division.Name;
                await context.SaveChangesAsync();
            }
        }
    }
}
using System;
using System.Collections.Generic;
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
                context.Divisions.Remove(context.Divisions.FirstOrDefault(x => x.DivisionId == divisionId));
                await context.SaveChangesAsync();
            }
        }

        public Division Get(int divisionId)
        {
            throw new NotImplementedException();
        }

        public List<Division> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(int divisionId)
        {
            throw new NotImplementedException();
        }
    }
}
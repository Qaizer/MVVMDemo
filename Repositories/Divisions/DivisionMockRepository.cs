using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Divisions
{
    public class DivisionMockRepository : IDivisionRepository
    {
        public void Add(string name)
        {
            return;
        }

        public void Delete(int divisionId)
        {
            return;
        }

        public Division Get(int divisionId)
        {
            return new Division { DivisionId = 666, Name = "Skärselden" };
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

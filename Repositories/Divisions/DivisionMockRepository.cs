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

        public Task<Division> Get(int divisionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Division>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(int divisionId)
        {
            return;
        }
    }
}

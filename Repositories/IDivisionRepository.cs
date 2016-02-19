using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IDivisionRepository
    { 
        IList<Division> GetAll();

        void Add(Division division);
        Division Get(int divisionId);
        void Delete(int divisionId);
        void Update(int divisionId);
    }
}

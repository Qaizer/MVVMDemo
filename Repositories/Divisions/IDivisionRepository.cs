using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Divisions
{
    public interface IDivisionRepository
    { 
        List<Division> GetAll();

        void Add(string name);
        Division Get(int divisionId);
        void Delete(int divisionId);
        void Update(int divisionId);
    }
}

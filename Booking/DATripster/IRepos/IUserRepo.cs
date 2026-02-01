using DATripster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTripster.IRepos
{
    public interface IUserRepo : IRepo<User>
    {
        User? GetById(int id);
        User? GetByEmail(string email);
        User? GetByName(string name);
    }
}

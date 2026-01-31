using BLTripster.ViewModels;
using DATripster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTripster.IServices
{
    public interface IUserService
    {
       
        IEnumerable<User> GetAllUsers();
        User? GetUserById(int id);
        User? GetUserByEmail(string email);
        User? GetUserByName(string name);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}

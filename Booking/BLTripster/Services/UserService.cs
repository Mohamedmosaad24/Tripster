using BLTripster.IServices;
using DALTripster.IRepos;
using DATripster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTripster.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo userRepo;

        public UserService(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return userRepo.GetAll();
        }

        public User? GetUserById(int id)
        {
            return userRepo.GetById(id);
        }

        public User? GetUserByName(string name)
        {
            return userRepo.GetByName(name);
        }

        public User? GetUserByEmail(string email)
        {
            return userRepo.GetByEmail(email);
        }

        public void AddUser(User user)
        {
            userRepo.Add(user);
            userRepo.Save();
        }
        public void UpdateUser(User user)
        {
            userRepo.Update(user);
            userRepo.Save();
        }
        public void DeleteUser(int id)
        {
            userRepo.Delete(id);
            userRepo.Save();
        }


    }
}

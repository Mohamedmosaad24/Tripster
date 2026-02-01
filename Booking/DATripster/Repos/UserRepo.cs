using DALTripster.IRepos;
using DATripster.Data;
using DATripster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTripster.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly TripsterDB _context;
        public UserRepo(TripsterDB context)
        {
            _context = context;
        }
        public void Add(User entity)
        {
            _context.Users.Add(entity);
        }
        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null) _context.Users.Remove(user);

        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetByEmail(string email)
        {
           return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User? GetById(int id)
        {
           return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User? GetByName(string name)
        {
            return _context.Users.FirstOrDefault(u => u.Name == name);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
        }
    }
}

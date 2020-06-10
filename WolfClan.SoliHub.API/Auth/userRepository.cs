using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfClan.SoliHub.Abstracts.Contracts.Base;
using WolfClan.SoliHub.Messages.Base;

namespace WolfClan.SoliHub.API.Auth
{
    public class userRepository : IUserRepository<User>
    {

        User_dbContext db;
        public userRepository(User_dbContext _db)
        {
            db = _db;
        }

        public void Add(User entity)
        {
            db.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id, User entity)
        {
            throw new NotImplementedException();
        }

        public User Find(int id)
        {
          return  db.Users.SingleOrDefault(x => x.Id == id);
        }

        public User FindWithEmail(string mail)
        {
            return db.Users.SingleOrDefault(x => x.Email == mail);
        }

        public IList<User> List()
        {
            return db.Users.ToList();
        }
    }
}


using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DalUser
    {
        ChatAppContext chatAppContext = new ChatAppContext();
        public void Add(User user)
        {
            chatAppContext.Add(user);
            chatAppContext.SaveChanges();
        }
        public void Delete(User user)
        {
            chatAppContext.Remove(user);
            chatAppContext.SaveChanges();
        }
        public void Update(User user)
        {
            chatAppContext.Update(user);
            chatAppContext.SaveChanges();
        }
        public List<User> GetUsers()
        {
            return chatAppContext.Set<User>().ToList();
        }
        public User? GetByID(int id)
        {
            return chatAppContext.Set<User>().Find(id);
        }
        public User? GetByUsername(string userName)
        {
            return chatAppContext.Set<User>().Find(userName);
        }

    }
}

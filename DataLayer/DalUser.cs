using Common.DTOs;
using DataLayer.Abstract;
using DataLayer.Abstract.Repository;
using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DalUser : EfDalBase<User,ChatAppContext>,IUserDal
    {
        ChatAppContext chatAppContext = new ChatAppContext();


        public User? GetByUsername(string userName)
        {
            return chatAppContext.Users.FirstOrDefault(x=>x.Username == userName);
        }

        public bool isValidUserName(string userName)
        {
            return chatAppContext.Users.Any(x=>x.Username == userName);
        }

        public bool isValidUserEmail(string email)
        {
            return chatAppContext.Users.Any(x => x.Email == email);
        }

        public List<User> GetListAll(bool isActive)
        {
            return (List<User>)chatAppContext.Users.Where(x => x.IsActive == isActive).ToList();
        }
    }
}

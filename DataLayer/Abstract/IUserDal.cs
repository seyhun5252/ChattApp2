using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstract
{
    internal interface IUserDal
    {
        public User GetByUsername(string userName);
        public bool isValidUserName(string userName);
        public bool isValidUserEmail(string email);

    }
}

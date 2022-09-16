using DataLayer.Abstract;
using DataLayer.Abstract.Repository;
using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DalFriend : EfDalBase<Friend, ChatAppContext>, IFrinedDal
    {
        ChatAppContext chatAppContext = new ChatAppContext();

        public List<Friend> GetPasFriend(Expression<Func<Friend, bool>> filter)
        {
            return chatAppContext.Friends.Where(filter).ToList();
        }
    }
}

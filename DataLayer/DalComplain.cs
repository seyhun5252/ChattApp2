using DataLayer.Abstract;
using DataLayer.Abstract.Repository;
using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DalComplain: EfDalBase<Complain, ChatAppContext>  , IComplainDal
    {
        ChatAppContext chatAppContext = new ChatAppContext();


        public List<Complain> GetComplainByUserId(int userId)
        {
            return chatAppContext.Set<Complain>().Where(x => x.ComplainantUserId == userId).ToList();
        }

        public object GetListAll(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}

using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstract
{
    public interface IFrinedDal
    {
        public List<Friend> GetPasFriend(Expression<Func<Friend, bool>> filter);

    }
}

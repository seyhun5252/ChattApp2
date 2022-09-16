using DataLayer.Abstract.Repository;
using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstract
{
    public interface IComplainDal
    {
        List<Complain> GetComplainByUserId(int userId);
    }
}

using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Abstract.Repository;
using DataLayer.Abstract;

namespace DataLayer
{
    public class DalGroup : EfDalBase<Group,ChatAppContext>,IGroupDal
    {


    }
}

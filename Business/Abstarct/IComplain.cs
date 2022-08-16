using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IComplain
    {
        void Add(Complain complain);
        void Delete(Complain complain);
        void Update(Complain complain);

        List<Complain> GetAll();
        Complain GetById(int id);

    }
}

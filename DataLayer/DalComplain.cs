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
    public class DalComplain
    {
        ChatAppContext chatAppContext = new ChatAppContext();

        public void Add(Complain complain)
        {
            chatAppContext.Add(complain);
            chatAppContext.SaveChanges();
        }
        public void Delete(Complain complain)
        {
            chatAppContext.Remove(complain);
            chatAppContext.SaveChanges();
        }

        public void Update(Complain complain)
        {
            chatAppContext.Update(complain);
            chatAppContext.SaveChanges();
        }

        public List<Complain> GetListAll()
        {
            return chatAppContext.Set<Complain>().ToList();
        }

        public Complain? GetById(int id)
        {

         return chatAppContext.Set<Complain>().Find(id);
        }

        public List<Complain> GetComplainByUserID2(int id)
        {
            return chatAppContext.Set<Complain>().Where(x => x.ComplainantUserId == id).ToList();
        }

    }
}

using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DalFriend
    {
        ChatAppContext chatAppContext = new ChatAppContext();

        public void Add(Friend friend)
        {
            chatAppContext.Add(friend);
            chatAppContext.SaveChanges();
        }
        public void Delete(Friend friend)
        {
            chatAppContext.Remove(friend);
            chatAppContext.SaveChanges();
        }

        public void Update(Friend friend)
        {
            chatAppContext.Update(friend);
            chatAppContext.SaveChanges();
        }

        public List<Friend> GetList(int userID)
        {
            return chatAppContext.Set<Friend>().Where(x=>x.RequestedUserId == userID).ToList();
        }
    }
}

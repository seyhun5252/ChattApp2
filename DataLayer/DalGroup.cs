using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Group
    {
        ChatAppContext chatAppContext = new ChatAppContext();

        public void Add(Group group)
        {
            chatAppContext.Add(group);
            chatAppContext.SaveChanges();
        }
        public void Update(Group group)
        {
            chatAppContext.Update(group);
            chatAppContext.SaveChanges();
        }
        public void Delete(Group group)
        {
            chatAppContext.Remove(group);
            chatAppContext.SaveChanges();
        }
        public Group GetList(int groupId)
        {
            return chatAppContext.Set<Group>().Find(groupId);
        }
    }
}

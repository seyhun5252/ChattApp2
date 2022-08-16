using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DalGroupMember
    {
        ChatAppContext chatAppContext = new ChatAppContext();

        public void Add(GroupMember groupMember)
        {
            chatAppContext.Add(groupMember);
            chatAppContext.SaveChanges();
        }
        public void Update(GroupMember groupMember)
        {
            chatAppContext.Update(groupMember);
            chatAppContext.SaveChanges();
        }
        public void Delete(GroupMember groupMember)
        {
            chatAppContext.Remove(groupMember);
            chatAppContext.SaveChanges();
        }
        public List<GroupMember> GetAll(int groupID) 
        {
            return chatAppContext.Set<GroupMember>().Where(x => x.GroupId == groupID).ToList();
        }
    }
}

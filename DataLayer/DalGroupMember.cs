using DataLayer.Abstract;
using DataLayer.Abstract.Repository;
using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DalGroupMember : EfDalBase<GroupMember, ChatAppContext>, IGroupMemberDal
    {
        ChatAppContext chatAppContext = new ChatAppContext();

        public GroupMember? groupMemberGet(int groupId)
        {
            return chatAppContext.Set<GroupMember>().SingleOrDefault(x=>x.GroupId == groupId);

        }

        public GroupMember groupMemberUserAdmin(int GroupId , int? userId , int? addUserId)
        {
            if (userId == null)
            {
                return chatAppContext.Set<GroupMember>().FirstOrDefault(x=>x.GroupId == GroupId
                && x.AddedUserId == addUserId);

            }
            return chatAppContext.Set<GroupMember>().FirstOrDefault(x => x.GroupId == GroupId
                && x.UserId == addUserId);

        }
    }
}

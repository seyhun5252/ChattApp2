using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstract
{
    public interface IGroupMemberDal
    {
        public GroupMember groupMemberGet(int groupMemberId);
        public GroupMember groupMemberUserAdmin(int GroupId, int? userId, int? addUserId);



    }
}

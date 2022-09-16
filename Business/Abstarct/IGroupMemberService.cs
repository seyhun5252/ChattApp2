using Common.DTOs;
using Common.Result;
using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IGroupMemberService 
    {
        BCResponse Add(GroupMemberDto groupMemberDto);
        BCResponse Delete(int  groupMemberId);
        BCResponse Update(GroupMemberDto GroupMemberDto);
        BCResponse GetAll(int groupId);
    }
}

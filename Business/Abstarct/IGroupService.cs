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
    public interface IGroupService : IBaseService<Group>
    {

        BCResponse Add(GroupDto groupDto);
        BCResponse Delete(int groupId);
        BCResponse Update(GroupDto group);
        BCResponse GetList(int groupId);
    }
}

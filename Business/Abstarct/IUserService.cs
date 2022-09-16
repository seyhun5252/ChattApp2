using Common.DTOs;
using Common.Result;
using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IUserService : IBaseService<User>
    {
        BCResponse Add(UserDto userDto);
        BCResponse Delete(int userId);
        BCResponse Update(UserDto userDto);
        BCResponse GetUsers(bool isActive);
        BCResponse GetByID(int userId);
        BCResponse GetByUsername(string userName);
    }
}

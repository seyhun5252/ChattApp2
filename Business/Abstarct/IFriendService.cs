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
    public interface IFriendService 
    {
        BCResponse Add(FriendDto friendDto);
        BCResponse Delete(int FriendId);
        BCResponse Update(FriendDto friendDto);
        BCResponse GetList(int userId);

    }
}

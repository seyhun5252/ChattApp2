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
    public interface IMessageService 
    {
        BCResponse SendMessage(MessageDto messageDto);
        BCResponse Delete(int messageId);

        BCResponse GetGroupMessage(int senderId, int groupId);
        BCResponse GetPrivateMessage(int senderId, int receiverID);
    }
}

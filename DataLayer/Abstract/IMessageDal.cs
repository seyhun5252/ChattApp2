using DataLayer.Abstract.Repository;
using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstract
{
    public interface IMessageDal 
    {
        public List<Message> GetGroupMessage(int senderId, int groupId);
        public List<Message> GetPrivateMessage(int senderId, int receiverID);
    }
}

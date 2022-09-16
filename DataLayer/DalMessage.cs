using DataLayer.Abstract;
using DataLayer.Abstract.Repository;
using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{

    public class DalMessage : EfDalBase<Message, ChatAppContext> , IGroupDal
    {
        ChatAppContext chatAppContext = new ChatAppContext();

        public List<Message> GetGroupMessage(int senderId, int groupId)
        {
            return chatAppContext.Set<Message>().Where(x => x.GroupId == groupId && x.SenderId == senderId).ToList();

        }
        public List<Message> GetPrivateMessage(int senderId, int receiverID)
        {
            return chatAppContext.Set<Message>().Where(x => x.ReceiverId == receiverID && x.SenderId == senderId).ToList();

        }
    }
}

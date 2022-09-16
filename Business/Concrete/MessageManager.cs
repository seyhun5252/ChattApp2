using Business.Abstarct;
using Common.DTOs;
using Common.Result;
using DataLayer;
using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        DalMessage _dalMessage;
        DateTime dateTime = DateTime.Now;
        public MessageManager(DalMessage dalMessage)
        {
            _dalMessage = dalMessage;
        }

        public BCResponse Delete(int messageId)
        {
            var getByMessagById = _dalMessage.GetById(x => x.MessageId == messageId);

            if (getByMessagById != null)
            {
                //var getByMessageMyOwn = _dalMessage.GetById(x => x.SenderId
                //== getByMessagById.SenderId);

                //if (getByMessageMyOwn != null)
                //{

                    int delete = _dalMessage.Delete(getByMessagById);
                    return new BCResponse() { value = delete };
                //}
                //return new BCResponse() { Errors = "Kendi mesajını değilse silemezsiniz" };
            }
            else
            {
                return new BCResponse() { Errors = "Böyle bir mesaj yoktur" };

            }
        }

        public BCResponse GetGroupMessage(int senderId, int groupId)
        {
            var getGroupMessage = _dalMessage.GetById(x => x.SenderId == senderId && x.GroupId == groupId);
            if (getGroupMessage != null)
            {
                return new BCResponse() { value = getGroupMessage };

            }
            else
            {
                return new BCResponse() { Errors = "Kullanıc grupta değildir" };
            }

        }

        public BCResponse GetPrivateMessage(int senderId, int receiverID)
        {
            var getPrivateMessage = _dalMessage.GetById(x => x.SenderId == senderId && x.ReceiverId == receiverID);

            if (getPrivateMessage != null)
            {
                return new BCResponse() { value = getPrivateMessage };

            }
            else
            {
                return new BCResponse() { Errors = "Arkdaş değiller" };
            }

        }

        public BCResponse SendMessage(MessageDto messageDto)
        {
            
            
            
            if ((messageDto.GroupId != null || messageDto.ReceiverId == null)
                && messageDto.GroupId == null || messageDto.ReceiverId != null)
            {
                Message message = new Message();

                message.SenderId = messageDto.SenderId;
                message.ReceiverId = messageDto.ReceiverId;
                message.GroupId = messageDto.GroupId;
                message.MessageContent = messageDto.MessageContent;

                message.SendDate = dateTime;
                message.ReadDate = messageDto.ReadDate;


                int add = _dalMessage.Add(message);
                return new BCResponse() { value = add };
            }

            return new BCResponse() { Errors = "Böyle bir mesaj gönderilemedi" };
        }
    }
}

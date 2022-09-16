using Business.Abstarct;
using Business.Validation.FluentValidation;
using Common.DTOs;
using Common.Result;
using DataLayer;
using DataLayer.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FriendManager : IFriendService
    {
        DalFriend _dalFriend;

        public FriendManager(DalFriend dalFriend)
        {
            _dalFriend = dalFriend;
        }

        DateTime dateTime = DateTime.Now;

        public BCResponse Add(FriendDto friendDto)
        {


            if (friendDto != null)
            {
                var getisFriend = _dalFriend.GetById(x => x.RequestedUserId == friendDto.RequestedUserId
                                                    && x.RequesterUserId == friendDto.RequesterUserId);
                if (friendDto.RequesterUserId != friendDto.RequestedUserId)
                {
                    if (getisFriend != null)
                    {
                        return new BCResponse() { Errors = "Bu kullancılar arkadaş istekleri gönde" +
                            "rilmiş" };

                    }
                    else
                    {
                        Friend friend = new Friend();
                        friend.RequesterUserId = friendDto.RequesterUserId;
                        friend.RequestedUserId = friendDto.RequestedUserId;
                        friend.FriendStatusId = friendDto.FriendStatusId;
                        friend.RequestedDate = dateTime;

                        int add = _dalFriend.Add(friend);

                        return new BCResponse() { value = add };
                    }
                }
                else
                {
                    return new BCResponse() { Errors = "Kendi kendinize istek atamazsınız" };

                }

            }
            else
            {
                return new BCResponse() { Errors = "girdiğiniz değerler boş olamaz" };

            }
        }

        public BCResponse Delete(int FriendId)
        {
            var values = _dalFriend.GetById(x => x.FriendId == FriendId);


            if (values?.FriendStatusId == 2)
            {
                int delete = _dalFriend.Delete(values);
                return new BCResponse() { value = delete };
            }
            else
            {
                return new BCResponse() { Errors = "Kullanıclar arkadaş değiller" };
            }

        }

        public BCResponse GetList(int friendId)
        {
            var getListFriendAll = _dalFriend.GetListAll(x => x.FriendId == friendId);

            if (getListFriendAll.Count > 0)
            {
                return new BCResponse() { value = getListFriendAll };
            }
            else
            {
                return new BCResponse() { Errors = "Bulunumadı" };
            }


        }

        public BCResponse Update(FriendDto friendDto)
        {
            int update;

            if (friendDto != null)
            {
                var getisFriend = _dalFriend.GetById(x => x.RequestedUserId == friendDto.RequestedUserId
                                                                    && x.RequesterUserId == friendDto.RequesterUserId);
                if (getisFriend!.FriendStatusId == 2)
                {
                    return new BCResponse() { Errors = "İstek onaylandı durumunda olduğu için tekrar istek atılamaz ve" +
                        "güncellenemez" };

                }
                else if(getisFriend!.FriendStatusId == 1)
                {

                    if (getisFriend != null)
                    {
                        getisFriend.FriendStatusId = friendDto.FriendStatusId;
                        getisFriend.RequestedUserId = friendDto.RequestedUserId;
                        getisFriend.RequesterUserId = friendDto.RequesterUserId;


                        update = _dalFriend.Update(getisFriend);
                        return new BCResponse() { value = update };
                    }
                    else
                    {
                        return new BCResponse() { Errors = "Bulunamadı" };
                    }
                }
                else
                {
                    return new BCResponse() { Errors = "Bulunamadı" };

                }

            }
            else
            {
                return new BCResponse() { Errors = "Boş deerler girmeyiniz" };

            }




        }
    }
}

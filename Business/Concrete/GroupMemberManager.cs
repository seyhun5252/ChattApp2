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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GroupMemberManager : IGroupMemberService
    {
        DalGroupMember _groupMember;

        public GroupMemberManager(DalGroupMember groupMember)
        {
            _groupMember = groupMember;
        }

        DateTime dateTime = DateTime.Now;
        public BCResponse Add(GroupMemberDto groupMemberDto)
        {

            if (groupMemberDto != null)
            {
                var getByUserGroup = _groupMember.GetById(x => x.GroupId
                == groupMemberDto.GroupId && x.UserId == groupMemberDto.UserId);

                if (getByUserGroup == null)
                {
                    var getUserAdmin = _groupMember.groupMemberUserAdmin(GroupId: groupMemberDto.GroupId,
                       addUserId: groupMemberDto.AddedUserId, userId: null);


                    var getByAdmin = _groupMember.groupMemberUserAdmin(GroupId: groupMemberDto.GroupId,
                       addUserId: groupMemberDto.AddedUserId, userId: groupMemberDto.UserId);
                    if (getByAdmin == null && getUserAdmin == null)
                    {
                        return new BCResponse() { Errors = "Ekleyen kullanıcı admin değil " };

                    }

                    if (getByAdmin != null)
                    {
                        if (getByAdmin.IsAdmin == true)
                        {
                            GroupMember groupMember = new GroupMember();
                            groupMember.GroupId = groupMemberDto.GroupId;
                            groupMember.UserId = groupMemberDto.UserId;
                            groupMember.AddedUserId = groupMemberDto.AddedUserId;
                            groupMember.AddedDate = dateTime;
                            groupMember.IsAdmin = groupMemberDto.IsAdmin;

                            int add = _groupMember.Add(groupMember);
                            return new BCResponse() { value = add };
                        }
                    }
                    else
                    {
                        if (getUserAdmin != null)
                        {
                            if (getByAdmin!.IsAdmin == true)
                            {
                                GroupMember groupMember = new GroupMember();
                                groupMember.GroupId = groupMemberDto.GroupId;
                                groupMember.UserId = groupMemberDto.UserId;
                                groupMember.AddedUserId = groupMemberDto.AddedUserId;
                                groupMember.AddedDate = dateTime;
                                groupMember.IsAdmin = groupMemberDto.IsAdmin;

                                int add = _groupMember.Add(groupMember);
                                return new BCResponse() { value = add };
                            }
                            else
                            {
                                return new BCResponse() { Errors = "Ekleyen kullancı admin değildir" };

                            }
                        }
                    }

                }
                return new BCResponse() { Errors = "Kullanıcı zaten grupta " };
            }
            else
            {
                return new BCResponse() { Errors = "Boş değerler girilmez" };

            }

        }

        public BCResponse Delete(int groupMemberId)
        {
            var values = _groupMember.GetById(x => x.GroupMemberId == groupMemberId);
            if (values != null)
            {
                int delete = _groupMember.Delete(values);
                return new BCResponse() { value = delete };
            }
            return new BCResponse() { Errors = "Kullanıcı böyle bir grupta yok" };
        }

        public BCResponse GetAll(int groupId)
        {
            var GetAllGroupId = _groupMember.GetListAll(x => x.GroupId == groupId);
            if (groupId != null)
            {
                if (GetAllGroupId != null)
                {
                    return new BCResponse() { value = GetAllGroupId };
                }
            }
            return new BCResponse() { Errors = "Kullacnı grupta değil" };
        }

        public BCResponse Update(GroupMemberDto groupMemberDto)
        {


            if (groupMemberDto != null)
            {
                var getByIdUpdate = _groupMember.GetById(x => x.GroupMemberId
                        == groupMemberDto.GroupMemberId);

                if (getByIdUpdate == null)
                {
                    if (getByIdUpdate != null)
                    {
                        getByIdUpdate.GroupId = groupMemberDto.GroupId;
                        getByIdUpdate.UserId = groupMemberDto.UserId;
                        getByIdUpdate.AddedUserId = getByIdUpdate.AddedUserId;
                        getByIdUpdate.AddedDate = getByIdUpdate.AddedDate;
                        getByIdUpdate.IsAdmin = groupMemberDto.IsAdmin;


                        int update = _groupMember.Update(getByIdUpdate);
                        return new BCResponse() { value = update };
                    }
                    else
                    {
                        return new BCResponse()
                        {
                            Errors = "Grup yönetici değilsiniz o yüzde" +
                            "değişilik yapamazsınız"
                        };

                    }
                    return new BCResponse() { Errors = "Böyle bir group yok" };
                }
            }

            return new BCResponse() { Errors = "Güncelenemedi" };
        }
    }
}

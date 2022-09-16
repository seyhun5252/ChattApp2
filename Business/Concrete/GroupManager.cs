using Business.Abstarct;
using Common.DTOs;
using Common.Result;
using DataLayer;
using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GroupManager : IGroupService
    {
        DalGroup _dalGroup;
        DalGroupMember _dalGroupMember;

        public GroupManager(DalGroup dalGroup, DalGroupMember dalGroupMember)
        {
            _dalGroup = dalGroup;
            _dalGroupMember = dalGroupMember;
        }
        DateTime dateTime = DateTime.Now;


        public BCResponse Add(GroupDto groupDto)
        {


            int add;
            if (groupDto != null)
            {
                Group group = new Group();
                group.Name = groupDto.Name;
                group.Description = groupDto.Description;
                group.GroupProfilePhoto = groupDto.GroupProfilePhoto;
                group.CreaterUserId = groupDto.CreaterUserId;
                group.CreateDate = dateTime;

                add = _dalGroup.Add(group);
                return new BCResponse { value = add };
            }

            return new BCResponse { Errors = "Eklenemedi" };
        }

        public BCResponse Delete(int groupId)
        {
            var getGroup = _dalGroup.GetById(x => x.GroupId == groupId);
            int delete;
            if (groupId != null)
            {
                if (getGroup != null)
                {
                    delete = _dalGroup.Delete(getGroup);
                    return new BCResponse { value = delete };
                }
                else
                {
                    return new BCResponse { Errors = "Böyle bir group yok" };


                }


            }
            else
            {
                return new BCResponse { Errors = "Böyle bir Id yok" };

            }
            return new BCResponse { Errors = "Group silinemedi" };
        }

        public BCResponse? GetList(int groupId)
        {
            var values = _dalGroup.GetById(x => x.GroupId == groupId);
            if (groupId != null)
            {
                if (values != null)
                {
                    return new BCResponse { value = values };
                }
            }
            return new BCResponse { Errors = "Böyle bir grup yok" };

        }

        public BCResponse Update(GroupDto groupDto)
        {


            int update;
            if (groupDto != null)
            {
                var getGroupUpdate = _dalGroup.GetById(x => x.GroupId
                == groupDto.GroupId);

                var user = _dalGroupMember.groupMemberGet(groupDto.GroupId);
                
               
                if (getGroupUpdate != null && user.IsAdmin == true) 
                {

                    getGroupUpdate.Name = groupDto.Name;
                    getGroupUpdate.Description = groupDto.Description;
                    getGroupUpdate.GroupProfilePhoto = groupDto.GroupProfilePhoto;
                    getGroupUpdate.CreaterUserId = groupDto.CreaterUserId;


                    update = _dalGroup.Update(getGroupUpdate);
                    return new BCResponse() { value = update };
                }
                else
                {
                    return new BCResponse { Errors = "Group bulunamadı veya " +
                        "kullanıcı admin dei" };
                }

            }
            return new BCResponse { Errors = "Güncellenemedi" };
        }
    }
}

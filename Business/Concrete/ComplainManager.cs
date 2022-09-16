using Business.Abstarct;
using DataLayer.Entity;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Common.Result;
using Common.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Business.Validation.FluentValidation;
using FluentValidation;

namespace Business.Concrete
{
    public class ComplainManager : IComplainService
    {

        DalComplain _dalComplain;
        DalMessage _dalMessage;
        public ComplainManager(DalComplain dalComplain, DalMessage dalMessage)
        {
            _dalComplain = dalComplain;
            _dalMessage = dalMessage;
        }
        DateTime dateTime = DateTime.Now;
        public BCResponse Add(ComplainDto complainDto)
        {



            int add;

            if (complainDto != null)
            {
                var isAnyMessage = _dalMessage.GetById(x => x.MessageId
                    == complainDto.MessageReferenceId);

                if (isAnyMessage != null)
                {

                    if (complainDto.ComplainStatusId != null)
                    {
                        Complain complain = new Complain();
                        complain.ComplainantUserId = complainDto.ComplainantUserId;
                        complain.ComplainedOfUserId = complainDto.ComplainedOfUserId;
                        complain.ComplainStatusId = complainDto.ComplainStatusId;
                        complain.ComplainDate = dateTime;
                        complain.MessageReferenceId = complainDto.MessageReferenceId;


                        add = _dalComplain.Add(complain);
                        return new BCResponse() { value = add };
                    }
                    else
                    {
                        return new BCResponse()
                        {
                            Errors = "Şikayet edilme nedeni girilmesi" +
                            "gereklidir"
                        };
                    }

                }
                else
                {
                    return new BCResponse()
                    {
                        Errors = "Daha önce mesajlaşmadığınız için " +
                        "kullancı şikayet edilemez"
                    };
                }



            }
            else
            {
                return new BCResponse() { Errors = "Böyle birisi yok" };
            }
        }

        public BCResponse Delete(int complainId)
        {
            var getComplainById = _dalComplain.GetById(x => x.ComplainId == complainId);

            if (getComplainById != null)
            {
                int delete = _dalComplain.Delete(getComplainById);
                return new BCResponse { value = delete };
            }

            return new BCResponse { Errors = "Böyle bir şikyet yok" };

        }


        public BCResponse GetAll(Expression<Func<Complain, bool>> filter)
        {

            var getListAll = _dalComplain.GetListAll(filter);
            return new BCResponse { value = getListAll };


        }

        public BCResponse? GetById(int id)
        {
            var getById = _dalComplain.GetById(x => x.ComplainId == id);
            if (getById != null)
            {
                return new BCResponse { value = getById };
            }

            return new BCResponse { Errors = "Böyle bir şikayet yok" };
        }

        public BCResponse GetComplainByUserId(int userId)
        {

            if (userId != null)
            {
                var complianUserById = _dalComplain.GetComplainByUserId(userId);

                if (complianUserById != null)
                {
                    return new BCResponse() { value = complianUserById };
                }
            }
            return new BCResponse() { Errors = "Böyle bir şikayet bulunamadı" };
        }

        public BCResponse Update(ComplainDto complainDto)
        {

            if (complainDto.ComplainStatusId != null)
            {
                var getByIdUpdate = _dalComplain.GetById(x => x.ComplainId == complainDto.ComplainId);

                if (complainDto != null)
                {
                    if (getByIdUpdate != null)
                    {
                        getByIdUpdate.ComplainantUserId = complainDto.ComplainantUserId;
                        getByIdUpdate.ComplainedOfUserId = complainDto.ComplainedOfUserId;
                        getByIdUpdate.ComplainStatusId = complainDto.ComplainStatusId;
                        getByIdUpdate.MessageReferenceId = complainDto.MessageReferenceId;



                        int update = _dalComplain.Update(getByIdUpdate);
                        return new BCResponse() { value = update };
                    }

                }

                return new BCResponse { Errors = "Güncellenemedi" };
            }
            else
            {
                return new BCResponse
                {
                    Errors = "Şikayet nedeni boş olduğu için güncelle" +
                    "nemedi."
                };
            }

        }
    }
}

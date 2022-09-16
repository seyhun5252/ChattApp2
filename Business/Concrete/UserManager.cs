using Business.Abstarct;
using Business.Validation.FluentValidation;
using Common.CrossCuttingConcers.Validation;
using Common.DTOs;
using Common.Result;
using DataLayer;
using DataLayer.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        DalUser _dalUser;
        DateTime dateTime = DateTime.Now;


        public UserManager(DalUser dalUser)
        {
            _dalUser = dalUser;
        }

        public BCResponse Add(UserDto userDto)
        {

            if (userDto != null)
            {
                int add;
                var isUserName = _dalUser.isValidUserName(userDto.Username);

                var isEmail = _dalUser.isValidUserEmail(userDto.Email);

                if (isUserName == false && isEmail == false)
                {
                    User user = new User();
                    user.Username = userDto.Username;
                    user.Email = userDto.Email;
                    user.Surname = userDto.Surname;
                    user.Name = userDto.Name;
                    user.Password = userDto.Password;
                    user.ProfilePhoto = userDto.ProfilePhoto;
                    user.CreateDate = dateTime;
                    user.IsActive = userDto.IsActive;
                    user.IsAdmin = userDto.IsAdmin;


                    var context = new ValidationContext<User>(user);
                    UserValidator userValidator = new UserValidator();
                    var validateRule = userValidator.Validate(context);

                    if (!validateRule.IsValid)
                    {
                        String errors = validateRule.Errors[0].ToString();
                        return new BCResponse() { Errors = errors };

                    }


                    add = _dalUser.Add(user);
                    return new BCResponse() { value = add };


                }

                return new BCResponse()
                {
                    Errors = "Kullancı adı veya email" +
                    "var olduğu için tekrar kayıt eklenemez"
                };
            }
            else
            {
                return new BCResponse() { Errors = "Değerleriniz boş olamaz" };

            }
        }

        public BCResponse Delete(int userId)
        {
            var getId = _dalUser.GetById(x => x.UserId == userId);
            int delete;
            if (getId != null)
            {
                if (getId != null)
                {


                    delete = _dalUser.Delete(getId);
                    return new BCResponse() { value = delete };
                }
                else
                {
                    return new BCResponse() { Errors = "Kullanıcı bulunamadı" };

                }

            }
            else
            {
                return new BCResponse() { Errors = "Boş değerler girmeyiniz" };
            }

        }


        public BCResponse? GetByID(int userId)
        {
            var value = _dalUser.GetById(x => x.UserId == userId);

            if (value != null)
            {
                return new BCResponse() { value = value };
            }

            return new BCResponse() { Errors = "Kullnaıcı bulunamadı" };
        }

        public BCResponse? GetByUsername(string userName)
        {
            var values = _dalUser.GetByUsername(userName);
            if (userName != null)
            {
                if (values != null)
                {
                    return new BCResponse() { value = values };
                }
                else
                {
                    return new BCResponse() { Errors = "Kullanıcı Bulunamadı" };

                }
            }
            else
            {
                return new BCResponse() { Errors = "Boş değerler girmeyiniz" };

            }

        }

        public BCResponse GetUsers(bool isActive)
        {

            var user = _dalUser.GetListAll(isActive);
            if (user != null)
            {
                return new BCResponse() { value = user };

            }
            else
            {
                return new BCResponse() { Errors = "böyle bir kullanıc adı bulunmaktadır" };

            }
        }

        public BCResponse Update(UserDto userDto)
        {
            var getByIdUpdate = _dalUser.GetById(x => x.UserId == userDto.UserId);
            var isAnyUserName = _dalUser.GetById(x => x.Username == userDto.Username);


            if (userDto != null)
            {
                if (getByIdUpdate != null)
                {
                    if (isAnyUserName == null)
                    {
                        getByIdUpdate.Username = userDto.Username;
                        getByIdUpdate.Email = userDto.Email;
                        getByIdUpdate.Surname = userDto.Surname;
                        getByIdUpdate.Name = userDto.Name;
                        getByIdUpdate.Password = userDto.Password;
                        getByIdUpdate.ProfilePhoto = userDto.ProfilePhoto;
                        getByIdUpdate.CreateDate = dateTime;
                        getByIdUpdate.IsActive = userDto.IsActive;
                        getByIdUpdate.IsAdmin = userDto.IsAdmin;


                        int update = _dalUser.Update(getByIdUpdate);
                        return new BCResponse() { value = update };
                    }
                    else
                    {
                        return new BCResponse() { Errors = "böyle bir kullanıc adı bulunmaktadır" };

                    }

                }
                else
                {
                    return new BCResponse() { Errors = "Kullanıcı Bulunamadı" };
                }
            }
            else
            {
                return new BCResponse() { Errors = "Boş Kullanıcı girilmiştir" };
            }
        }
    }
}



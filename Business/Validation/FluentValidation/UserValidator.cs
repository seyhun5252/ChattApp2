using DataLayer.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Username).MaximumLength(50).WithMessage("Kullanıc adınız maximum 50 karakter olmalıdır.");
            RuleFor(u => u.Username).MinimumLength(2).WithMessage("kullanıcı adınız en 2 karakter olmalıdır.");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Şifrenizi boş geçemezsiniz.");
            RuleFor(u => u.Password).MinimumLength(2).WithMessage("Şifreniz minimum 2 karakteruzunluğunda olmaldır.");
           
            RuleFor(p => p.Password).Matches(@"[A-Z]+").WithMessage("Şifrenizde en az 1 büyük harf olmalıdır .");
            RuleFor(p => p.Password).Matches(@"[a-z]+").WithMessage("Şİfrenizde en az 1 küçük harf olmalıdır.");
            RuleFor(p => p.Password).Matches(@"[0-9]+").WithMessage("Şifrenizde en az 1 tane rakam olmalıdır.");
            RuleFor(p => p.Password).Matches(@"[\!\?\*\.]*$").WithMessage("Şiferenizde en az bir tane özel karakter olmaldır.");

            RuleFor(e => e.Email).NotEmpty().WithMessage("Email Alanı boş olamaz.");
            RuleFor(n => n.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            RuleFor(s => s.Surname).NotEmpty().WithMessage("Soyadı alanı boş geçilemez");
            


        }
    }
}

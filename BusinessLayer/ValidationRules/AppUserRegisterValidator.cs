using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTOs>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrarı boş geçilemez");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Şifreler uyuşmuyor");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Email boş geçilemez");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Geçerli bir email adresi giriniz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır");
        }
    }
}

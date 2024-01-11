using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class FirstAboutValidator : AbstractValidator<FirstAbout>
    {
        public FirstAboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmı boş olamaz!");
            RuleFor(x => x.FirstImage).NotEmpty().WithMessage("Lütfen görsel seçiniz!");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Lütfen en az 50 karakter girin!");
            RuleFor(x => x.Description).MaximumLength(1500).WithMessage("Lütfen açıklamayı kısaltın!");
        }
    }
}

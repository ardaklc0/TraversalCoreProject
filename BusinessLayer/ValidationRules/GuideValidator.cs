using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Rehber ismi boş olamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Resim boş olamaz");
            RuleFor(x => x.Name).MinimumLength(10).WithMessage("İsim en az 10 karakter olmalıdır");
        }
    }
}

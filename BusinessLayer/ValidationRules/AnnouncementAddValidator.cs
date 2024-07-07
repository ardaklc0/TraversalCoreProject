using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementAddValidator : AbstractValidator<AnnouncementAddDTOs>
    {
        public AnnouncementAddValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik alanı boş geçilemez.");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Başlık alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Content).MinimumLength(3).WithMessage("İçerik alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Başlık alanı en fazla 100 karakter olmalıdır.");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("İçerik alanı en fazla 500 karakter olmalıdır.");
        }
    }
}

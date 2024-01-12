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
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty!");
            RuleFor(x => x.FirstImage).NotEmpty().WithMessage("Please choose an image!");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Please enter at least 50 character!");
            RuleFor(x => x.Description).MaximumLength(1500).WithMessage("Please enter at most 1500 character!");
        }
    }
}

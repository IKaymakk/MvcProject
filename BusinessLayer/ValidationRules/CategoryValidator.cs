using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Bırakılamaz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklaması Boş Bırakılamaz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori Adı Minimum 3 Karakter Olmalıdır");
            RuleFor(x => x.CategoryName).MaximumLength(30).WithMessage("Kategori Adı Maksimum 30 Karakter Olmalıdır");
            RuleFor(x => x.CategoryDescription).MinimumLength(15).WithMessage("Kategori Açıklaması Minimum 15 Karakter Olmalıdır");
            RuleFor(x => x.CategoryDescription).MaximumLength(75).WithMessage("Kategori Açıklaması Maksimum 75 Karakter Olmalıdır");

        }
    }
}

using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Bir Mail Adresi Giriniz");
            RuleFor(x => x.UserMail).MinimumLength(7).WithMessage("En Az 7 Karakter Giriniz");
            RuleFor(x => x.UserMail).MaximumLength(100).WithMessage("En Fazla 100 Karakter Giriniz");
            RuleFor(x => x.Username).MaximumLength(100).WithMessage("En Fazla 100 Karakter Giriniz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı Boş Bırakılamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Bırakılamaz");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("En Fazla 100 Karakter Giriniz");
            RuleFor(x => x.Message).MaximumLength(500).WithMessage("En Fazla 500 Karakter Giriniz");
            RuleFor(x => x.Message).MaximumLength(500).WithMessage("En Fazla 500 Karakter Giriniz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Boş Bırakılamaz");
        }
    }
}

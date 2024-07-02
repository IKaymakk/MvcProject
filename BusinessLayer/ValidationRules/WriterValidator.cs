using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Bırakılamaz");
            RuleFor(x => x.WriterName).MaximumLength(70).WithMessage("Yazar Adı Maksimum 70 Karakterden Oluşabilir");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar Adı Minimum 3 Karakter Olabilir");

            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Bırakılamaz");
            RuleFor(x => x.WriterSurname).MaximumLength(70).WithMessage("Yazar Soyadı Maksimum 70 Karakterden Oluşabilir");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Yazar Soyadı Minimum 3 Karakter Olabilir");

            RuleFor(x => x.WriterAbout).MinimumLength(30).WithMessage("Yazar Hakkında Kısmı İçin En Az 30 Karakter Giriniz");
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("Yazar Hakkında Kısmı İçin En Fazla 100 Karakter Giriniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar Hakkında Kısmı Boş Bırakılamaz");

            RuleFor(x => x.WriterTel).MaximumLength(20).WithMessage("Yazar Telefonu Maksimum 20 Karakter Olmalıdır");
            RuleFor(x => x.WriterTel).MinimumLength(10).WithMessage("Yazar Telefonu Minimum 10 Karakter Olmalıdır");
            RuleFor(x => x.WriterTel).NotEmpty().WithMessage("Yazar Telefon Numara Kısmı Boş Bırakılamaz");

            RuleFor(x => x.WriterMail).MinimumLength(10).WithMessage("Yazar Maili Minimum 10 Karakter Olmalıdır");
            RuleFor(x => x.WriterMail).MaximumLength(200).WithMessage("Yazar Maili Maksimum 200 Karakter Olmalıdır");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar Mail Kısmı Boş Bırakılamaz");

            RuleFor(x => x.WriterImage).MaximumLength(300).WithMessage("Yazar Resmi Dosya Yolu Maksimum 300 Karakter Olmalıdır");
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Yazar Resmi Dosya Yolu Boş Bırakılamaz");
        }
    }
}

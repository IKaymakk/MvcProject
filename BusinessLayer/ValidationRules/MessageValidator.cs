using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresi Boş Bırakılamaz");
            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Konu Boş Bırakılamaz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj Boş Bırakılamaz");
            RuleFor(x => x.MessageSubject).MinimumLength(3).WithMessage("Konu Minimum 3 Karakter Olmalıdır");
            RuleFor(x => x.MessageSubject).MaximumLength(50).WithMessage("Konu Maksimum 50Karakter Olmalıdır");
        }
    }
}

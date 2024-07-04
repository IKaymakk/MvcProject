using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetList();
        List<Message> GetListSendBox();
        void MessageAdd(Message Message);
        Message GetMessage(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message meMessage);
        int GetMessageCount();
    }
}

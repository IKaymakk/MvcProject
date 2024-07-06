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
        List<Message> GetList(string p);
        List<Message> GetListSendBox(string p);
        void MessageAdd(Message Message);
        Message GetMessage(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message meMessage);
        int GetMessageCount();
    }
}

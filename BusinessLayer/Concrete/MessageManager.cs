﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            _messagedal = messagedal;
        }

        public List<Message> GetList(string p)
        {
            return _messagedal.List(x => x.ReceiverMail == p).OrderByDescending(x => x.MessageDate).ToList(); ;
        }

        public List<Message> GetListSendBox(string p)
        {
            return _messagedal.List(x => x.SenderMail == p).OrderByDescending(x => x.MessageDate).ToList();
        }

        public Message GetMessage(int id)
        {
            return _messagedal.Get(x => x.MessageID == id);
        }

        public int GetMessageCount()
        {
            return _messagedal.Count(x => x.ReceiverMail == "admin@gmail.com");
        }

        public void MessageAdd(Message message)
        {
            _messagedal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message meMessage)
        {
            throw new NotImplementedException();
        }
    }
}

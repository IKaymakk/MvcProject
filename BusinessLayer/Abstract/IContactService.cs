using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        List<Contact> GetLTrashist();
        void ContactAdd(Contact contact);
        Contact GetContact(int id);
        void ContactDelete(Contact contact);
        void ContactUpdate(Contact contact);
        int GetContactCount();
        void ContactStatu(int id);
    }
}

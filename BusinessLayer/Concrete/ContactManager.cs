using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactdal;

        public ContactManager(IContactDal contactdal)
        {
            _contactdal = contactdal;
        }

        public void ContactAdd(Contact contact)
        {
            _contactdal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _contactdal.Delete(contact);
        }

        public void ContactStatu(int id)
        {
            Contact c = _contactdal.Get(x => x.ContactID == id);
            if (c.ContactMessageStatu == false)
            {
                c.ContactMessageStatu = true;
                _contactdal.Update(c);
            }
            else
            {
                c.ContactMessageStatu = false;
                _contactdal.Update(c);
            }
        }


        public void ContactUpdate(Contact contact)
        {
            _contactdal.Update(contact);
        }

        public Contact GetContact(int id)
        {
            return _contactdal.Get(x => x.ContactID == id);
        }

        public int GetContactCount()
        {
            return _contactdal.Count(x=>x.ContactMessageStatu==true);
        }
        public int GetTrashBoxCount()
        {
            return _contactdal.Count(x => x.ContactMessageStatu == false);
        }
      

        public List<Contact> GetList()
        {
            return _contactdal.List().Where(x => x.ContactMessageStatu == true).OrderByDescending(x => x.Date).ToList();
        }

        public List<Contact> GetLTrashist()
        {
            return _contactdal.List().Where(x => x.ContactMessageStatu == false).OrderByDescending(x => x.Date).ToList();
        }

    }
}

using BusinessLayer.Abstract;
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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingdal;
        public HeadingManager(IHeadingDal headingdal)
        {
            _headingdal = headingdal;
        }

        public Heading GetById(int id)
        {
            return _headingdal.Get(x => x.HeadingID == id);
        }

        public List<Heading> Getlist()
        {
            return _headingdal.List();
        }

        public void HeadingAdd(Heading heading)
        {
            _headingdal.Insert(heading);
        }


        public int HeadingCount()
        {
            return _headingdal.Count();
        }

        public void HeadingChangeStatus(int id)
        {
            Heading c = _headingdal.Get(x => x.HeadingID == id);
            if (c.HeadingStatus == true)
            {
                c.HeadingStatus = false;
                _headingdal.Update(c);

            }
            else
            {
                c.HeadingStatus = true;
                _headingdal.Update(c);
            }
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingdal.Update(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            throw new NotImplementedException();
        }

        public List<Heading> GetlistByWriter(int id)
        {
            return _headingdal.List(x => x.WriterID == id);
        }

        public List<Heading> SearchingList(string p)
        {
            return _headingdal.List(x => x.HeadingName.Contains(p));
        }
    }
}

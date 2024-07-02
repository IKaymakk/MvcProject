using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void HeadingDelete(Heading heading)
        {
            _headingdal.Delete(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingdal.Update(heading);
        }
    }
}

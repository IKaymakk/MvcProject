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
    public class AboutManager : IAboutService
    {
        IAboutDal _iaboutdal;

        public AboutManager(IAboutDal iaboutdal)
        {
            _iaboutdal = iaboutdal;
        }

        public void AboutAdd(About about)
        {
            _iaboutdal.Insert(about);
        }

        public void AboutDelete(About about)
        {
            _iaboutdal.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            _iaboutdal.Update(about);
        }

        public About GetById(int id)
        {
            return _iaboutdal.Get(x => x.AboutID == id);
        }

        public List<About> Getlist()
        {
            return _iaboutdal.List();
        }
    }
}

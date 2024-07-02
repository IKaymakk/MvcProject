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
    public class IContentManager : IContentService
    {
        IContentDal _contentdal;

        public IContentManager(IContentDal contentdal)
        {
            _contentdal = contentdal;
        }

        public void ContentAdd(Content content)
        {
            _contentdal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            _contentdal.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentdal.Update(content);
        }

        public Content GetById(int id)
        {
            return _contentdal.Get(x => x.ContentID == id);
        }

        public List<Content> Getlist()
        {
            return _contentdal.List();
        }

        public List<Content> GetlistByHeadingID(int id)
        {
            return _contentdal.List(x => x.HeadingID == id);
        }
    }
}

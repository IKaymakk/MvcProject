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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerdal;

        public WriterManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }

        public Writer GetById(int id)
        {
            return _writerdal.Get(x => x.WriterID == id);
        }

        public int GetCount()
        {
            return _writerdal.Count();
        }

        public List<Writer> GetList()
        {
            return _writerdal.List();
        }

        public void WriterAdd(Writer writer)
        {
            _writerdal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerdal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerdal.Update(writer);
        }
        public void WriterStatus(int id)
        {
            Writer w = _writerdal.Get(x => x.WriterID == id);
            if (w.WriterStatus == false)
            {
                w.WriterStatus = true;
                _writerdal.Update(w);
            }
            else
            {
                w.WriterStatus = false;
                _writerdal.Update(w);
            }
        }
    }
}

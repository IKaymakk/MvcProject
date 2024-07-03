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
    public class CommentManager : ICommentService
    {
        ICommentDal _icommentdal;

        public CommentManager(ICommentDal icommentdal)
        {
            _icommentdal = icommentdal;
        }

        public void CommentDelete(Comment comment)
        {
            _icommentdal.Delete(comment);
        }

        public List<Comment> CommentListByHeadingID(int id)
        {
            return _icommentdal.List(x => x.HeadingID == id);
        }
    }
}

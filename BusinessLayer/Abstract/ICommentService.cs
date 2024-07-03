using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    internal interface ICommentService
    {
        List<Comment> CommentListByHeadingID(int id);
        void CommentDelete(Comment comment);
    }
}

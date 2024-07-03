using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        [StringLength(50)]
        public string CommentUserName { get; set; }
        [StringLength(250)]
        public string CommentText { get; set; }
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }
    }
}

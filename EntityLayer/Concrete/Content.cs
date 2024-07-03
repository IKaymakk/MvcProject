using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        [StringLength(5000)]
        public string ContentValue { get; set; }
        [StringLength(5000)]
        public string ContentValue2 { get; set; }
        [StringLength(5000)]
        public string ContentValue3 { get; set; }
        public DateTime ContentDate { get; set; }
        [StringLength(300)]
        public string ContentImg1 { get; set; }
        [StringLength(300)]
        public string ContentImg2 { get; set; }
        [StringLength(300)]
        public string ContentImg3 { get; set; }
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }
        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }


    }
}

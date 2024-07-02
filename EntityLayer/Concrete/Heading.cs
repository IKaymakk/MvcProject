﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }
        [StringLength(100)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }
        [StringLength(300)]
        public string HeadingImg { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }

        [StringLength(70)]
        public string WriterName { get; set; }

        [StringLength(70)]
        public string WriterSurname { get; set; }

        [StringLength(300)]
        public string WriterImage { get; set; }

        [StringLength(200)]
        public string WriterMail { get; set; }

        [StringLength(200)]
        public string WriterPassword { get; set; }
        [StringLength(100)]
        public string WriterAbout { get; set; }
        [StringLength(20)]
        public string WriterTel { get; set; }
        public bool WriterStatus { get; set; }

        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Content { get; set; }

    }
}

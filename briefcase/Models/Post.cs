using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace briefcase.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime? RowCreated { get; set; }

        public DateTime? LastModified { get; set; }


        public virtual Category Category { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public int? CategoryId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public List<Category> Categories { get; set; }
        public virtual Category Category { get; set; }
    }
}
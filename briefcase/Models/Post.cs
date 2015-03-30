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
        public int? PartOfCategoryId { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}
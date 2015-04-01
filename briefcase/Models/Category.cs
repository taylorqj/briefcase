using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace briefcase.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? RowCreated { get; set; }
        public DateTime? RowModified { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
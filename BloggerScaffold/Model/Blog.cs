using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggerScaffold.Model
{
    public partial class Blog
    {
        public int BlogId { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public int BlogPost { get; set; }

        [ForeignKey("BlogPost")]
        [InverseProperty("Blog")]
        public virtual Post BlogPostNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggerScaffold.Model
{
    public partial class BloggerUser
    {
        public BloggerUser()
        {
            Post = new HashSet<Post>();
        }

        public int UserId { get; set; }
        [Required]
        [StringLength(255)]
        public string Username { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [InverseProperty("Author")]
        public virtual ICollection<Post> Post { get; set; }
    }
}

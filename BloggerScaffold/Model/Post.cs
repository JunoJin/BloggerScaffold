using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggerScaffold.Model
{
    public partial class Post
    {
        public Post()
        {
            Blog = new HashSet<Blog>();
            InverseParent = new HashSet<Post>();
        }

        public int PostId { get; set; }
        public int AuthorId { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string PostContent { get; set; }
        public int LikeCount { get; set; }
        public int? ParentId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("AuthorId")]
        [InverseProperty("Post")]
        public virtual BloggerUser Author { get; set; }
        [ForeignKey("ParentId")]
        [InverseProperty("InverseParent")]
        public virtual Post Parent { get; set; }
        [InverseProperty("BlogPostNavigation")]
        public virtual ICollection<Blog> Blog { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<Post> InverseParent { get; set; }
    }
}

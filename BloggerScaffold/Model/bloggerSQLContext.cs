using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BloggerScaffold.Model
{
    public partial class bloggerSQLContext : DbContext
    {
        public bloggerSQLContext()
        {
        }

        public bloggerSQLContext(DbContextOptions<bloggerSQLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<BloggerUser> BloggerUser { get; set; }
        public virtual DbSet<Post> Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:blogger-msa2019p2.database.windows.net,1433;Initial Catalog=blogger-SQL;Persist Security Info=False;User ID=JunoJin;Password=yeNC5500;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.BlogPostNavigation)
                    .WithMany(p => p.Blog)
                    .HasForeignKey(d => d.BlogPost)
                    .HasConstraintName("BlogPost");
            });

            modelBuilder.Entity<BloggerUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__BloggerU__1788CC4C74BC0373");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Username).IsUnicode(false);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("AuthorId");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("ParentId");
            });
        }
    }
}

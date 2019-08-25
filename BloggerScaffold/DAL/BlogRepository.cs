using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BloggerScaffold.Model;

namespace BloggerScaffold.DAL
{
    public class BlogRepository : IBlogRepository, IDisposable
    {
        private bloggerSQLContext context;

        public BlogRepository(bloggerSQLContext context)
        {
            this.context = context;
        }

        public IEnumerable<Blog> GetBlogs()
        {
            return context.Blog.ToList();
        }

        public Blog GetBlogByID(int id)
        {
            return context.Blog.Find(id);
        }

        public void InsertBlog(Blog blog)
        {
            context.Blog.Add(blog);
        }

        public void DeleteBlog(int blogId)
        {
            Blog blog = context.Blog.Find(blogId);
            context.Blog.Remove(blog);
        }

        public void UpdateBlog(Blog blog)
        {
            context.Entry(blog).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloggerScaffold.Model;

namespace BloggerScaffold.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggerUsersController : ControllerBase
    {
        private readonly bloggerSQLContext _context;

        public BloggerUsersController(bloggerSQLContext context)
        {
            _context = context;
        }

        // GET: api/BloggerUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BloggerUser>>> GetBloggerUser()
        {
            return await _context.BloggerUser.ToListAsync();
        }

        // GET: api/BloggerUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BloggerUser>> GetBloggerUser(int id)
        {
            var bloggerUser = await _context.BloggerUser.FindAsync(id);

            if (bloggerUser == null)
            {
                return NotFound();
            }

            return bloggerUser;
        }

        // PUT: api/BloggerUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBloggerUser(int id, BloggerUser bloggerUser)
        {
            if (id != bloggerUser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(bloggerUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloggerUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BloggerUsers
        [HttpPost]
        public async Task<ActionResult<BloggerUser>> PostBloggerUser(BloggerUser bloggerUser)
        {
            _context.BloggerUser.Add(bloggerUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBloggerUser", new { id = bloggerUser.UserId }, bloggerUser);
        }

        // DELETE: api/BloggerUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BloggerUser>> DeleteBloggerUser(int id)
        {
            var bloggerUser = await _context.BloggerUser.FindAsync(id);
            if (bloggerUser == null)
            {
                return NotFound();
            }

            _context.BloggerUser.Remove(bloggerUser);
            await _context.SaveChangesAsync();

            return bloggerUser;
        }

        private bool BloggerUserExists(int id)
        {
            return _context.BloggerUser.Any(e => e.UserId == id);
        }
    }
}

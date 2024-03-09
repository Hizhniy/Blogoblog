using Blogoblog.DAL.DB;
using Blogoblog.DAL.Models;

namespace Blogoblog.DAL.Repositories
{
    public class CommentRepository : Repository<Comment>
    {
        public CommentRepository(BlogoblogContext db) : base(db)
        {
        }
    }
}

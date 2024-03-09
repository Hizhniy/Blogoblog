using Blogoblog.DAL.DB;
using Blogoblog.DAL.Models;


namespace Blogoblog.DAL.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(BlogoblogContext db) : base(db)
        {
        }
    }
}

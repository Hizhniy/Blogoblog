using Blogoblog.DAL.DB;
using Blogoblog.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace Blogoblog.DAL.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(BlogoblogContext db) : base(db)
        {
        }
        //public IEnumerable<Tag> GetAllTagsInArticle()
        //{
        //    return Set.Include(x => x.Articles);
        //}
    }
}

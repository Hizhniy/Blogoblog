using Blogoblog.DAL.DB;
using Blogoblog.DAL.Models;

namespace Blogoblog.DAL.Repositories
{
    public class ArticleRepository : Repository<Article>
    {
        public ArticleRepository(BlogoblogContext db) : base(db)
        {
        }

        public IEnumerable<Article> GetArticlesByAuthorId(int user_Id)
        {
            var articles = Set.AsEnumerable().Where(x => x.User_Id == user_Id);
            return articles.ToList();
        }
    }
}

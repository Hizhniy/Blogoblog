using Blogoblog.DAL.DB;
using Blogoblog.DAL.Models;


namespace Blogoblog.DAL.Repositories
{
    public class RoleRepository : Repository<Role>
    {
        public RoleRepository(BlogoblogContext db) : base(db)
        {
        }
    }
}

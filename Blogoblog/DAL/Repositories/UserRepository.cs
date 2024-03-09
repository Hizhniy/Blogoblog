using Blogoblog.DAL.DB;
using Blogoblog.DAL.Models;

namespace Blogoblog.DAL.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(BlogoblogContext db) : base(db)
        {
        }

        public new async Task Add(User user)
        {
            user.Roles.Add(new Role { Id = 1, Role_Name = "Пользователь" });
            Set.Add(user);
            await _db.SaveChangesAsync();
        }
    }
}

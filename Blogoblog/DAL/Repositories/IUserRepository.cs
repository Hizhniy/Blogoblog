using Blogoblog.DAL.Models;

namespace Blogoblog.DAL.Repositories
{
    public interface IUserRepository<T> : IRepository<T> where T : class
    {
        User GetByLogin(string login);
    }
}
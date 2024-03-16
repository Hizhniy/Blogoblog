namespace Blogoblog.DAL.Models
{
    public class UserViewModel
    {
        public User? User { get; set; }
        public virtual IList<string>? Roles { get; set; }
    }
}

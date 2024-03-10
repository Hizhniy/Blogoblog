using Blogoblog.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogoblog.DAL.DB
{
    public class BlogoblogContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public BlogoblogContext(DbContextOptions<BlogoblogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Article>().ToTable("Articles");
            builder.Entity<Tag>().ToTable("Tags");
            builder.Entity<Comment>().ToTable("Comments");

            //builder.Entity<Comment>()
            //    .HasOne(a => a.User)
            //    .WithMany(b => b.Comments)
            //    .HasForeignKey(c => c.User_Id)
            //    .HasPrincipalKey(d => d.Id)
            //    .IsRequired(false);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        ////    //optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");
        ////    //optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-891I20FV\SQLEXPRESS;Database=BLOGOBLOG;Trusted_Connection=True;Trust Server Certificate=True;");
        ////    //optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=BLOGOBLOG;Trusted_Connection=True;Trust Server Certificate=True;");
        //    optionsBuilder.UseSqlite(@"Data Source=BLOGOBLOG.db");
        //}
    }
}

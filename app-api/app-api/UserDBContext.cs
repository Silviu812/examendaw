using Microsoft.EntityFrameworkCore;

namespace app_api
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; } = null!;

    }
}

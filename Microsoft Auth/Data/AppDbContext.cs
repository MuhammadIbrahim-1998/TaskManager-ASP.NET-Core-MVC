using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft_Auth.Models;

namespace Microsoft_Auth.Data
{
   
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

       
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}

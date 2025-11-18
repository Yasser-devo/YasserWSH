using Microsoft.EntityFrameworkCore;
using YasserWorkShop.Models;

namespace YasserWorkShop.Data
{
    public class WSHDBContext:DbContext
    {
       public WSHDBContext(DbContextOptions<WSHDBContext> op):base(op)
        {

        }
        
        public DbSet<Employer> employers { get; set; }
    }
}

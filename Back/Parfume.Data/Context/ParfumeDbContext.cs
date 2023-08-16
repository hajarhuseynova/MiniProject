using Microsoft.EntityFrameworkCore;

namespace Parfume.App.Context
{
    public class ParfumeDbContext:DbContext
    {
      
        public ParfumeDbContext(DbContextOptions<ParfumeDbContext> options) : base(options)
        {

        }

    }
}

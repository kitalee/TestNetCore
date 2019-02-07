using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestCore.Models
{
    public class TestCoreContext : DbContext
    {
        public TestCoreContext (DbContextOptions<TestCoreContext> options)
            : base(options)
        {
        }

        public DbSet<TestCore.Models.Movie> Movie { get; set; }
    }
}

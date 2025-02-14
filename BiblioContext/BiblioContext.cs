using BiblioContext.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioContext
{
    public class BiblioContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = default!;
        public DbSet<Borrowing> Borrowing { get; set; } = default!;
        public DbSet<Ganre> Ganre { get; set; } = default!;

        public BiblioContext(DbContextOptions<BiblioContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }
    }
}

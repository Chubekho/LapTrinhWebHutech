using Buoi5.Models;
using Microsoft.EntityFrameworkCore;


namespace Buoi5.Models
{
    public class Buoi5DbContext : DbContext
    {
        public Buoi5DbContext(DbContextOptions<Buoi5DbContext> options) : base(options)
        {

        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Grade> Grade { get; set; }
    }
}

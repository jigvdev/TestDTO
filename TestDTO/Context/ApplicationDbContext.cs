using Microsoft.EntityFrameworkCore;
using TestDTO.Entities;

namespace TestDTO.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Autor> Autores { get; set; }
    }
}

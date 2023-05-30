using Microsoft.EntityFrameworkCore;
using MvcCubosEc2.Models;

namespace MvcCubosEc2.Data
{
    public class CubosContext:DbContext
    {

        public CubosContext(DbContextOptions<CubosContext> options)
            : base(options) { }

        public DbSet<Cubo> Cubos { get; set; }
    }
}

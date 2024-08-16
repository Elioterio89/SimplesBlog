using BlogDatum.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BlogDatum.Data
{
    public class BlogDatumContext : DbContext
    {
        public BlogDatumContext(DbContextOptions<BlogDatumContext> options): base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
    }
}

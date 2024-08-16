using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace BlogDatum.Data
{
    public class DesignTimeDbContextFactory
    {
        public class BlogDatumContextFactory : IDesignTimeDbContextFactory<BlogDatumContext>
        {
            public BlogDatumContext CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var optionsBuilder = new DbContextOptionsBuilder<BlogDatumContext>();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DatumConnection"));

                return new BlogDatumContext(optionsBuilder.Options);
            }
        }
    }
}

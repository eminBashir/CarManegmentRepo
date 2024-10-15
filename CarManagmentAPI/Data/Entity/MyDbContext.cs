using Microsoft.EntityFrameworkCore;

namespace CarManagmentAPI.Data.Entity
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<SpecialModel> SpecialModels { get; set; }

    }
}


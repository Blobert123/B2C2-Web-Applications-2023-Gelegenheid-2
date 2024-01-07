using B2C2_Web_Applications_2023_Gelegenheid_2.Models;
using Microsoft.EntityFrameworkCore;

namespace B2C2_Web_Applications_2023_Gelegenheid_2.Data
{
    public class CollectionDBContext : DbContext
    {
        public CollectionDBContext(DbContextOptions<CollectionDBContext> options) : base(options)
        {
            
        }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<CollectionItem> CollectionItems { get; set; }

        public DbSet<CollectionName> CollectionNames { get; set; }

        public DbSet<User> Users { get; set; }

    }
}

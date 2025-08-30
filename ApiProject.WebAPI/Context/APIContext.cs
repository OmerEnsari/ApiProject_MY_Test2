using Microsoft.EntityFrameworkCore;

namespace ApiProject.WebAPI.Context
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        public DbSet<Entities.Category> Categories { get; set; }
        public DbSet<Entities.Product> Products { get; set; }
        public DbSet<Entities.Feature> Features { get; set; }
        public DbSet<Entities.Reservation> Reservations { get; set; }
        public DbSet<Entities.Galery> Galeries { get; set; }
        public DbSet<Entities.Contact> Contacts { get; set; }
        public DbSet<Entities.ContactMessage> ContactMessages { get; set; }
        public DbSet<Entities.Testimonial> Testimonials { get; set; }
        public DbSet<Entities.Service> Services { get; set; }
        public DbSet<Entities.Chef> Chefs { get; set; }
    }
}

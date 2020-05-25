using Microsoft.EntityFrameworkCore;
using ecoupon.models;

namespace ecoupon.data
{
    public class EcouponContext : DbContext
    {
        public EcouponContext(DbContextOptions<EcouponContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
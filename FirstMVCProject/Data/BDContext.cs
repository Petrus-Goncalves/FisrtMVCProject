using FirstMVCProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCProject.Data
{
    public class BDContext : DbContext
    {
        public BDContext(DbContextOptions<BDContext> options) : base(options)
        {

        }

        public DbSet<ContactModel> Contacts { get; set; }
    }
}
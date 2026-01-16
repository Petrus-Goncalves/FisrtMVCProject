using FirstMVCProject.Models;
using FirstMVCProject.Models.User;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCProject.Data
{
    public class BDContext : DbContext
    {
        public BDContext(DbContextOptions<BDContext> options) : base(options)
        {

        }

        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
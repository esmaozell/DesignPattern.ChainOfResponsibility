using Microsoft.EntityFrameworkCore;

namespace DesignPattern.ChainOfResponsibility.DataAcsessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=Esma;initial " +
                "catalog=DesignPattern1;integrated security=true;"); 
        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}

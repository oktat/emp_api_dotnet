using Microsoft.EntityFrameworkCore;
 
class DataService : DbContext {
    string str = "Server=localhost; User ID=sargabt; Password=titok; Database=sargabt";
 
    public DbSet<Employee> Employees { get; set; }
 
    protected override void OnConfiguring(DbContextOptionsBuilder ob)
    {
        ob.UseMySql(str, ServerVersion.AutoDetect(str));
    } 
}

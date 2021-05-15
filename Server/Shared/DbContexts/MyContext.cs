using Microsoft.EntityFrameworkCore;
using Shared;

public class MyContext : DbContext
{
    public DbSet<UserData> UserDatas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite(@"Data Source='../DbFile/MyDb.db'");
}
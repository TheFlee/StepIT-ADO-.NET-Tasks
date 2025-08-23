using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3;

class UserContext : DbContext
{
    private readonly string connectionString;

    public DbSet<User> Users { get; set; }

    public UserContext(string connString)
    {
        connectionString = connString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyBlazorVault.Data;

public class MyVaultDbContext : IdentityDbContext
{
    public MyVaultDbContext(DbContextOptions<MyVaultDbContext> options)
        : base(options)
    {
    }

    public DbSet<Secret> Secrets => Set<Secret>();
}

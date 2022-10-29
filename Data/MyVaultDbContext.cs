using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MyBlazorVault.Data;

public class MyVaultDbContext : IdentityDbContext
{
    public MyVaultDbContext(DbContextOptions<MyVaultDbContext> options)
        : base(options)
    {
    }

    public DbSet<Secret> Secrets => Set<Secret>();
}

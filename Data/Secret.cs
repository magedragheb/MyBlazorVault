using Microsoft.AspNetCore.Identity;
namespace MyBlazorVault.Data;
public class Secret
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public string UserName { get; set; } = "";
    public string EncryptedPassword { get; set; } = "";
    public bool? Favorite { get; set; }
    public string? Notes { get; set; }
    public IdentityUser? User { get; set; }

}
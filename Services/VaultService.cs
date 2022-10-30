using MyBlazorVault.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MyBlazorVault.Services;

public class VaultService
{
    private readonly MyVaultDbContext _db;
    private readonly AuthenticationStateProvider _provider;

    public VaultService(MyVaultDbContext context, AuthenticationStateProvider provider)
    {
        _db = context;
        _provider = provider;
    }

    public async Task<string?> GetUserId()
    {
        var user = (await _provider.GetAuthenticationStateAsync()).User;
        var userId = user.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;

        return userId;
    }

    public async Task<Secret> GetSecretById(int id)
    {
        var secret = await _db.Secrets.FindAsync(id);
        if (secret == null)
            throw new NotImplementedException();
        return secret;
    }

    public async Task<List<Secret>> GetUserSecrets()
    {
        var userId = GetUserId().Result;
        if (userId == null)
            throw new NotImplementedException();
        var secrets = await _db.Secrets.Where(s => s.User!.Id == userId)
                                                .ToListAsync();
        if (secrets == null)
            throw new NotImplementedException();
        return secrets;
    }

    public async Task<Secret> AddSecret(Secret secret)
    {
        if (secret == null)
            throw new NotImplementedException();
        var userId = GetUserId().Result;
        if (userId == null)
            throw new NotImplementedException();
        secret.User = await _db.Users.FindAsync(userId);
        await _db.Secrets.AddAsync(secret);
        await _db.SaveChangesAsync();
        return secret;
    }

    public async Task EditSecret(int Id, Secret secret)
    {
        var toEdit = await _db.Secrets.FindAsync(Id);
        if (toEdit == null)
            throw new NotImplementedException();

        toEdit.Title = secret.Title;
        toEdit.UserName = secret.UserName;
        toEdit.EncryptedPassword = secret.EncryptedPassword;
        toEdit.Favorite = secret.Favorite;
        toEdit.Notes = secret.Notes;

        await _db.SaveChangesAsync();
    }

    public async Task DeleteSecret(int Id)
    {
        var secret = await _db.Secrets.FindAsync(Id);
        if (secret == null)
            throw new NotImplementedException();
        _db.Secrets.Remove(secret);
        await _db.SaveChangesAsync();
    }
}

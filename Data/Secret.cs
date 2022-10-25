namespace MyBlazorVault.Data;
public class Secret
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public string UserName {get; set;} = "";
    public string HashedPassword {get; set;} = "";
    public bool? Favorite {get; set;}
    public string? Notes {get;set;}


}
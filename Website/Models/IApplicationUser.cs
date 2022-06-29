namespace Inventory.Website.Models
{

    public interface IApplicationUser
    {
        bool IsSignedIn { get; }
        int Agency { get; }
        int UserID { get; }
    }
}

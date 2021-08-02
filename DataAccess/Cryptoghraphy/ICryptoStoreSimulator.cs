namespace DataAccess.Cryptoghraphy
{
    //This is a rather awkward implementation of a service that can save encrypted values to a separate store
    //This is NOT a pattern to be copied, rather it is a stop-gap to make creating other samples elsewhere possible
    public interface ICryptoStoreSimulator
    {
        bool SaveUserName(string userId, string userName);
        string GetUserName(string userId);
        bool SaveUserEmail(string userId, string userEmail);
        string GetUserEmail(string userId);
        bool SavePhoneNumber(string userId, string phoneNumber);
        string GetPhoneNumber(string userId);
        bool SaveNormalizedUserName(string userId, string userName);
        string GetNormalizedUserName(string userId);
        bool SaveNormalizedUserEmail(string userId, string userEmail);
        string GetNormalizedUserEmail(string userId);
    }
}

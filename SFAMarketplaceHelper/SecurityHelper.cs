using BCrypt.Net;

namespace SFAMarketplaceWEB.Helpers
{
    public class SecurityHelper
    {
        public static string GeneratePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, workFactor: 13);
        }

        public static bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
        }

        public static string GetDBConnectionString()
        {
            // Update the connection string to match your SFAMarketplaceWEB database
            string connString = "Server=(localdb)\\MSSQLLOCALDB;Database=SFAMarketplace;Trusted_Connection=true;";
            return connString;
        }
    }
}

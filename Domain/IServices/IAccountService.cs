using Data;

namespace Domain.IServices
{
    public interface IAccountService
    {
        /// <summary>
        /// Validate user account
        /// </summary>
        /// <param name="username">Account username</param>
        /// <param name="password">Account password</param>
        string ValidateAccount(string username, string password);

        /// <summary>
        /// Get user id by generated token
        /// </summary>
        /// <param name="token">Account token</param>
        string GetUserIdByToken(string token);

        /// <summary>
        /// Check if user token is generated
        /// </summary>
        /// <param name="token">Account token</param>
        bool IsTokenAvailable(string token);
    }
}

namespace Business
{
    public interface IUserBll
    {
        /// <summary>
        /// Used for password encryption
        /// </summary>
        /// <param name="text">The raw password input.</param>
        /// <returns>64 character SHA256 Hash.</returns>
        string HashPassword(string text);
    }
}

using System;

namespace Business
{
    public class UserBll
    {
        /// <summary>
        /// Used for password encryption
        /// </summary>
        /// <param name="text">The raw password input.</param>
        /// <returns>64 character SHA256 Hash.</returns>
        public string HashPassword(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }
    }
}
using System;
using System.Security.Cryptography;
using System.Text;

namespace MisProject.Core.Security;

public static class PasswordHelper
{
    /// <summary>
    /// Hash password using MD5
    /// </summary>
    /// <param name="password">Password you want to hash</param>
    /// <exception cref="ArgumentException">Password null exception</exception>
    /// <returns>Hashed password with a salt</returns>
    public static string HashPasswordMd5(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Password can not be empty", nameof(password));

        var provider = MD5.Create();
#if DEBUG
        var salt = "MySalt";
#else
        var salt = Environment.GetEnvironmentVariable("MD5_SALT");
        if (string.IsNullOrEmpty(salt))
            throw new ArgumentException("MD5_SALT Environment Variable is null!", nameof(salt));
#endif

        var passwordBytes = Encoding.ASCII.GetBytes(salt + password);
        var hashedBytes = provider.ComputeHash(passwordBytes);
        provider.Dispose();

        var sb = new StringBuilder();
        foreach (var byt in hashedBytes)
        {
            sb.Append(byt.ToString("X2"));
        }
        return sb.ToString();
    }
}
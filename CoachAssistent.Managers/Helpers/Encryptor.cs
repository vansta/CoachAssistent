using CoachAssistent.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachAssistent.Managers
{
    internal static class Encryptor
    {
        internal static void EncryptPassword(this Credential credential, string password)
        {
            credential.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        internal static bool VerifyPassword(this Credential credential, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, credential.PasswordHash);
        }
    }
}

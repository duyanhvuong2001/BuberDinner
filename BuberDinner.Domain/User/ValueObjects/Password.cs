using BuberDinner.Domain.Common.Models;
using System.Security.Cryptography;

namespace BuberDinner.Domain.User.ValueObjects
{
    public sealed class Password : ValueObject
    {
        public string HashedPassword { get; private set; }
        private Password(string hashedPassword)
        {
            HashedPassword = hashedPassword;
        }

        private Password()
        {

        }

        public static Password Create(string plainPassword)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);

            return new(hashedPassword);
        }

        public bool VerifyPassword(string plainPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, HashedPassword);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return HashedPassword;
        }
    }
}

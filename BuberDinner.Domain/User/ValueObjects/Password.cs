using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.User.ValueObjects
{
    public sealed class Password : ValueObject
    {
        public string HashedPassword { get; private set; }

        private Password(string plainPassword)
        {

        }

        public static Password Create(string plainPassword)
        {
            return new(plainPassword);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return HashedPassword;
        }
    }
}

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.User
{
    public sealed class User : AggregateRoot<UserId, Guid>
    {
        private User(UserId id, string firstName, string lastName, string email, DateTime createdDateTime, DateTime updatedDateTime, Password password) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
            Password = password;
        }

        private User()
        {

        }

        public static User Create(string firstName, string lastName, string email, DateTime createdDateTime, DateTime updatedDateTime, string plainPassword)
        {
            return new(UserId.CreateUnique(), firstName, lastName, email, createdDateTime, updatedDateTime, Password.Create(plainPassword));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

        public Password Password { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }



    }
}

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Guest.ValueObjects
{
    public sealed class GuestId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private GuestId(Guid value)
        {
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static GuestId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}

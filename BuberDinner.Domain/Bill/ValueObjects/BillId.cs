using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Bill.ValueObjects
{
    public class BillId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private BillId(Guid value)
        {
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static BillId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static BillId Create(Guid id)
        {
            return new(id);
        }
    }
}

using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Dinner.ValueObjects
{
    public sealed class DinnerReservationId : ValueObject
    {
        public Guid Value { get; }

        private DinnerReservationId(Guid value)
        {
            Value = value;
        }



        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static DinnerReservationId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static DinnerReservationId Create(Guid id)
        {
            return new(id);
        }
    }
}

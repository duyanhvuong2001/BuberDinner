using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public sealed class Rating : ValueObject
    {
        public double Value { get; }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        private Rating(double value)
        {
            Value = value;
        }

        public static Rating CreateNew(double rating = 0)
        {
            return new(rating);
        }
    }
}

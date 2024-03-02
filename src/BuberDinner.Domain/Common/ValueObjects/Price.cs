using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public sealed class Price : ValueObject
    {
        public double Amount { get; }
        public string Currency { get; set; }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }

        private Price(double amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        private Price()
        {

        }
        public static Price CreateNew(double amount, string currency)
        {
            return new(amount, currency);
        }
    }
}

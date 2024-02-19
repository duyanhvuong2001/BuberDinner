﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Bill.ValueObjects
{
    public class BillId : ValueObject
    {
        public Guid Value { get; }

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
    }
}
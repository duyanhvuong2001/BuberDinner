using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Dinner.ValueObjects
{
    public sealed class DinnerLocation : ValueObject
    {
        public string Name { get; init; }
        public string Address { get; init; }
        public float Latitude { get; init; }
        public float Longitude { get; init; }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Address;
            yield return Latitude;
            yield return Longitude;
        }

        private DinnerLocation(string name, string address, float latitude, float longitude)
        {
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        public static DinnerLocation Create(string name, string address, float latitude, float longitude)
        {
            return new(name, address, latitude, longitude);
        }
    }
}

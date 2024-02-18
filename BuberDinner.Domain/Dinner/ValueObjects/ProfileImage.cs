using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Dinner.ValueObjects
{
    public sealed class ProfileImage : ValueObject
    {
        public string ImageURL { get; private set; }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return ImageURL;
        }

        public static ProfileImage CreateNew(string imageURL)
        {
            return new(imageURL);
        }
        private ProfileImage(string imageUrl)
        {
            ImageURL = imageUrl;
        }
    }
}

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects
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

        private ProfileImage()
        {

        }
    }
}

using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.MenuReview.ValueObjects
{
    public sealed class Comment : ValueObject
    {
        public string Text { get; }

        private Comment(string text)
        {
            Text = text;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Text;
        }

        public static Comment CreateUnique(string text)
        {
            return new(text);
        }
    }
}

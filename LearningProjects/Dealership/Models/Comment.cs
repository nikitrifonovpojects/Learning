using System.Text;
using Dealership.Common;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        private string content;

        public Comment(string content)
        {
            this.Content = content;
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, Constants.MinCommentLength, Constants.MaxCommentLength, string.Format(Constants.StringMustBeBetweenMinAndMax, "Content", Constants.MinCommentLength, Constants.MaxCommentLength));
                this.content = value;
            }
        }

        public string Author { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(string.Format("    {0}", this.Content));
            builder.Append(string.Format("      User: {0}", this.Author));

            return builder.ToString();
        }
    }
}

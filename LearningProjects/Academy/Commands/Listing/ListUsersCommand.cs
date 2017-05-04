using System;
using System.Collections.Generic;
using System.Text;
using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Models.Common;

namespace Academy.Commands.Listing
{
    public class ListUsersCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public ListUsersCommand(IAcademyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }
        public string Execute(IList<string> parameters)
        {
            var builder = new StringBuilder();

            if (this.engine.Trainers.Count == 0 && this.engine.Students.Count == 0)
            {
                throw new ArgumentException(Constants.NoListedUsersErrorMessage);
            }
            if (this.engine.Trainers.Count != 0)
            {
                if (this.engine.Students.Count == 0)
                {
                    builder.Append(this.ListItemsInCollection(this.engine.Trainers));
                }
                else
                {
                    builder.AppendLine(this.ListItemsInCollection(this.engine.Trainers));
                }
            }
            if (this.engine.Students.Count != 0)
            {
                builder.Append(this.ListItemsInCollection(this.engine.Students));
            }

            return builder.ToString();
        }

        private string ListItemsInCollection<T>(IList<T> collection)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < collection.Count; i++)
            {
                var current = collection[i];
                if (i == collection.Count - 1)
                {
                    builder.Append(current.ToString());
                }
                else
                {
                    builder.AppendLine(current.ToString());
                }
            }

            return builder.ToString();
        }
    }
}

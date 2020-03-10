using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Domain.Common
{
    public class Notification
    {
        private readonly IList<Error> _errors = new List<Error>();
        public bool HasErrors { get { return _errors.Count != 0; } }

        public IEnumerable<Error> Errors
        {
            get { return _errors; }
        }

        public class Error
        {
            public string Message { get; private set; }

            public Error(string message)
            {
                Message = message;
            }
        }

        public void AddError(Error error)
        {
            _errors.Add(error);
        }

        public bool IncludesError(Error error)
        {
            return _errors.Contains(error);
        }
    }
}

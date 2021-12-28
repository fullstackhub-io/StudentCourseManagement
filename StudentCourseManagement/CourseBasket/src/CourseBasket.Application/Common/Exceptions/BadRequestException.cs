using System;
using System.Collections.Generic;

namespace CourseBasket.Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
          : base()
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}

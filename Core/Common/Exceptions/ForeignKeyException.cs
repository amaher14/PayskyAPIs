using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Exceptions;
public class ForeignKeyException : Exception
{
    public ForeignKeyException() : base()
    {

    }

    public ForeignKeyException(params string[] failure) : base("One or more validation failures have occurred.")
    {
        this.Failures = failure;
    }
    public ForeignKeyException(string failure) : base("One or more validation failures have occurred.")
    {

        this.Failures = new string[1] { failure };
    }

    public string[] Failures { get; }
}


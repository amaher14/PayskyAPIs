using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Exceptions;
public class FileStoreException : Exception
{
    public FileStoreException(string message)
        : base(message)
    {
    }
    public FileStoreException(string message, Exception innerException)
       : base(message, innerException)
    {
    }
}

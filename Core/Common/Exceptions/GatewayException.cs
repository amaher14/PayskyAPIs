using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.Common.Exceptions;
public class GatewayException : Exception
{
    public string Request { get; private set; }
    public string Response { get;private set; }

    public GatewayException( string request, string response) : base(response)
    {
        Response = response;
        Request = request;
    }

}


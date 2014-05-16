using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dasher
{
    /// <summary>
    /// Percent-encoding, also known as URL encoding, is a mechanism for encoding information in a 
    /// Uniform Resource Identifier (URI) under certain circumstances. Although it is known as URL 
    /// encoding it is, in fact, used more generally within the main Uniform Resource Identifier 
    /// (URI) set, which includes both Uniform Resource Locator (URL) and Uniform Resource Name 
    /// (URN). As such, it is also used in the preparation of data of the 
    /// application/x-www-form-urlencoded media type, as is often used in the submission of HTML 
    /// form data in HTTP requests.
    /// </summary>
    public class URL : IAlgorithm
    {
        public byte[] Encode(byte[] data)
        {
            return Encoding.UTF8.GetBytes(WebUtility.UrlEncode(Encoding.UTF8.GetString(data)));
        }

        public byte[] Decode(byte[] data)
        {
            return Encoding.UTF8.GetBytes(WebUtility.UrlDecode(Encoding.UTF8.GetString(data)));
        }

        public override string ToString()
        {
            return "URL";
        }
    }
}

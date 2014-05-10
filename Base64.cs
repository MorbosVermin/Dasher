using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dasher
{
    /// <summary>
    /// Base64 is a group of similar binary-to-text encoding schemes that 
    /// represent binary data in an ASCII string format by translating it 
    /// into a radix-64 representation. The term Base64 originates from a 
    /// specific MIME content transfer encoding.
    /// 
    /// Base64 is only an integrity cipher and cannot be relied upon solely 
    /// for any security. However, it can be used to encode output of other
    /// ciphers to incease the security and/or ensure that the contents 
    /// were not modified during transit.
    /// </summary>
    public class Base64
    {
        /// <summary>
        /// Base64 IEncoder Implementation 
        /// </summary>
        public class Encoder : IEncoder
        {
            public bool InsertLineBreaks { get; set; }

            public Encoder() 
            {
                InsertLineBreaks = false;
            }

            public byte[] Encode(byte[] data)
            {
                return Encoding.UTF8.GetBytes(Convert.ToBase64String(data, ((InsertLineBreaks) ? Base64FormattingOptions.InsertLineBreaks : Base64FormattingOptions.None)));
            }
        }

        /// <summary>
        /// Base64 IDecoder Implementation
        /// </summary>
        public class Decoder : IDecoder
        {
            public byte[] Decode(byte[] data)
            {
                return Convert.FromBase64String(Encoding.UTF8.GetString(data));
            }
        }
    }
}

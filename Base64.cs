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
    /// ciphers to increase the security and/or ensure that the contents 
    /// were not modified during transit.
    /// 
    /// For example, using Base64 or XOR ciphers alone would not provide 
    /// much security. However, together they can be quite strong against
    /// attacks depending on the key length used in the XOR cipher. A
    /// normal encryption scheme would be to first XOR the data and then
    /// use Base64 to send the data. Then, to decrypt, the actions would 
    /// first be to decode the Base64 and then use a shared key to use XOR
    /// and deobfuscate the data again.
    /// 
    /// When using Base64, in some situations it may be necessary to add 
    /// line breaks at every 76-80 characters. This is mostly for formatting, 
    /// but some mediums will require this (i.e. SMTP is a good example).
    /// </summary>
    public class Base64 : IAlgorithm
    {
        /// <summary>
        /// Whether or not to apply line-breaks at every 76 characters as defined
        /// by the Convert.ToBase64String method.
        /// </summary>
        public bool InsertLineBreaks { get; set; }

        public byte[] Encode(byte[] input)
        {
            return Encoding.UTF8.GetBytes(Convert.ToBase64String(input, ((InsertLineBreaks) ? Base64FormattingOptions.InsertLineBreaks : Base64FormattingOptions.None)));
        }

        public byte[] Decode(byte[] input)
        {
            return Convert.FromBase64String(Encoding.UTF8.GetString(input));
        }

        public override string ToString()
        {
            return "Base64";
        }
    }
}

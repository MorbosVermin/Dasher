using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dasher
{
    /// <summary>
    /// With XOR cipher, a string of text can be encrypted by applying the bitwise XOR operator to every 
    /// character using a given key. To decrypt the output, merely reapplying the XOR function with the 
    /// key will remove the cipher.
    /// </summary>
    public class XOR
    {
        public class Encoder : IEncoder, IDecoder
        {
            public string Key { get; set; }

            public Encoder(string key)
            {
                Key = key;
            }

            /* TODO
             * I originally wrote this code in Java a couple of years ago to 
             * crack WebSphere password files which use this simple XOR operation
             * with a known key. However, it seems that C# does not like the 
             * negative values, looking instead for positive integers (32bit) only.
             */
            //public Encoder() : this(Encoding.UTF8.GetString(new byte[] { -99, -89, -39, -128, 5, -72, -119, -100 })) { }

            public byte[] Encode(byte[] data)
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(Key);
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = (byte)((data[i] ^ keyBytes[i % keyBytes.Length]) & 0xff);
                }

                return data;
            }

            public byte[] Decode(byte[] data)
            {
                return Encode(data);
            }
        }
    }
}

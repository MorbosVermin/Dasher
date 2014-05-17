using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dasher
{
    /// <summary>
    /// ROT-13  is a simple letter substitution cipher that replaces a letter 
    /// with the letter 13 letters after it in the alphabet. ROT13 is an example 
    /// of the 'Caesar cipher', developed in ancient Rome. 
    /// </summary>
    public class Rot13 : IAlgorithm
    {
        /// <summary>
        /// In the basic Latin alphabet, ROT13 is its own inverse; that is, to 
        /// undo ROT13, the same algorithm is applied, so the same action can 
        /// be used for encoding and decoding. For this reason, the Encoder class, 
        /// which implements IEncoder and IDecoder, does provide a convienent 
        /// Decode method but simply calls Encode.
        /// </summary>
        public byte[] Encode(byte[] data)
        {
            string value = Encoding.UTF8.GetString(data);
            char[] chars = value.ToCharArray();
            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < chars.Length; i++)
            {
                int number = (int)chars[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }

                buffer.Append((char)number);
            }

            return Encoding.UTF8.GetBytes(buffer.ToString());
        }

        public byte[] Decode(byte[] data)
        {
            return Encode(data);
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", "ROT-13", getDescription());
        }

        public string getDescription()
        {
            return "A simple character rotation algorithm.";
        }

    }
}

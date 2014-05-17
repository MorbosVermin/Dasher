using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dasher
{
    /// <summary>
    /// In mathematics and computing, hexadecimal (also base 16, or hex) is a positional numeral system 
    /// with a radix, or base, of 16. It uses sixteen distinct symbols, most often the symbols 0–9 to 
    /// represent values zero to nine, and A, B, C, D, E, F (or alternatively a–f) to represent values 
    /// ten to fifteen.
    /// </summary>
    public class Hex : IAlgorithm
    {
        public byte[] Encode(byte[] data)
        {
            string value = Encoding.UTF8.GetString(data);
            StringBuilder buffer = new StringBuilder();
            foreach (char l in value.ToCharArray())
            {
                int v = Convert.ToInt32(l);
                buffer.Append(String.Format("{0:X}", v));
            }

            return Encoding.UTF8.GetBytes(buffer.ToString());
        }

        public byte[] Decode(byte[] data)
        {
            string value = Encoding.UTF8.GetString(data);
            string[] values = value.Split(' ');
            StringBuilder buffer = new StringBuilder();
            foreach (string v in values)
            {
                int val = Convert.ToInt32(v, 16);
                buffer.Append(Char.ConvertFromUtf32(val));
            }

            return Encoding.UTF8.GetBytes(buffer.ToString());
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", "Hex (or base 16)", getDescription());
        }


        public string getDescription()
        {
            return "Algorithm where 0-9 represent 0-9 and A-F are 10-15.";
        }

    }
}

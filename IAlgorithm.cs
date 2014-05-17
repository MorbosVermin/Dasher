using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dasher
{
    public interface IAlgorithm
    {
        /// <summary>
        /// Encodes the given byte[] and returns the encoded byte[].
        /// </summary>
        /// <param name="input">byte[] data to encode.</param>
        /// <returns>byte[] encoded data.</returns>
        byte[] Encode(byte[] input);

        /// <summary>
        /// Decodes the given encoded byte[] and returns the decoded byte[].
        /// </summary>
        /// <param name="input">Encoded byte[] to decode.</param>
        /// <returns>Decoded byte[]</returns>
        byte[] Decode(byte[] input);

        /// <summary>
        /// Returns a simple description of this IAlgorithm implementation.
        /// </summary>
        /// <returns>Description</returns>
        string getDescription();
    }
}

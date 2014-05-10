using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dasher
{
    /// <summary>
    /// Decoders implement this interface.
    /// </summary>
    public interface IDecoder
    {
        byte[] Decode(byte[] data);
    }
}

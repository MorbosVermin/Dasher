using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dasher
{
    /// <summary>
    /// Encoders implement this interface.
    /// </summary>
    public interface IEncoder
    {
        byte[] Encode(byte[] data);
    }
}

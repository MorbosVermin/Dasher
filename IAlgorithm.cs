using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dasher
{
    public interface IAlgorithm
    {
        byte[] Encode(byte[] input);
        byte[] Decode(byte[] input);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICache
    {
        Task WriteAsync(string @string);
        Task<string> ReadAsync();
        Task WriteAsync(byte[] bytes);
        Task<byte[]> ReadBytesAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FileDataProvider : ICache
    {
        public string Path { get; }

        public FileDataProvider(string path)
        {
            Path = path;
        }

        public async Task<string> ReadAsync()
        {
            return await File.ReadAllTextAsync(Path);
            /*
            //wykorzystanie using powoduje automatyczne wywołanie funkcji Dispose
            using var filestream = new FileStream(Path, FileMode.Open);
            using var streamReader = new StreamReader(filestream);

            var result = await streamReader.ReadToEndAsync();

            return result;
            */
        }

        public async Task WriteAsync(string @string)
        {
            await File.WriteAllTextAsync(Path, @string);


            /*
            var filestream = new FileStream(Path, FileMode.Create); 

            //var bytes = Encoding.ASCII.GetBytes(@string);
            //filestream.WriteAsync(bytes, 0, bytes.Length);
            var streamWriter = new StreamWriter(filestream);
            await streamWriter.WriteAsync(@string);
            await streamWriter.FlushAsync();

            await streamWriter.DisposeAsync();
            await filestream.DisposeAsync();
            //return Task.CompletedTask;
            */
        }

        public Task WriteAsync(byte[] bytes)
        {
            return File.WriteAllBytesAsync(Path, bytes);
        }

        public Task<byte[]> ReadBytesAsync()
        {
            return File.ReadAllBytesAsync(Path);
        }
    }
}

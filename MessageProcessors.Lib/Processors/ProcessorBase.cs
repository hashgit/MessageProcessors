using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProcessors.Lib.Processors
{
    public abstract class ProcessorBase
    {
        protected async void WriteToFile(string text, string filePath)
        {
            await WriteTextAsync(text, filePath);
        }

        private async Task WriteTextAsync(string text, string filePath)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }
    }
}

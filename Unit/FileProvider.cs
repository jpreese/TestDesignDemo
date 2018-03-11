using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Unit
{
    public class FileProvider : IFileProvider
    {
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}

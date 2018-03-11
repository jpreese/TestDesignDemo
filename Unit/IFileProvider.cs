using System;
using System.Collections.Generic;
using System.Text;

namespace Unit
{
    public interface IFileProvider
    {
        string ReadAllText(string path);
    }
}

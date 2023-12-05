using Handball.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Handball.IO
{
    public class TextWriter : IWriter
    {
        private string path = "../../../output.txt";

        public TextWriter()
        {
               File.Delete(path);
        }
        public void Write(string text )
        {
            using (StreamWriter writer = new StreamWriter(path,true))
            {
                writer.Write(text);
            };
        }

        public void WriteLine(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true
                ))
            {
                writer.WriteLine(message);
            };
        }
    }
}

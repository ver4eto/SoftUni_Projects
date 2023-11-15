using LogForYou.Core.Exceptions;
using LogForYou.Core.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogForYou.Core.IO
{
    public class LogFile : ILogFile
    {
        private const string DefaultExtension = "txt";
        private static readonly string DefaultName = $"Log_{DateTime.Now:yyyy-MM-dd-HH-mm-ss}";
        private static readonly string DefaultPath = $"{Directory.GetCurrentDirectory()}";

        private string _name;
        private string _extension;
        private string _path;


        public LogFile()
        {
            Name = DefaultName;
            Extension = DefaultExtension;
            Path = DefaultPath;
        }
        public LogFile(string name, string extension, string path)
            :this()
        {
            Name = name;
            Extension = extension;
            Path = path;
        }

        public string Name
        {
            get => _name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFileNameException();
                }
                _name = value;
            }
        }

        public string Extension 
        {
            get => _extension;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFileExtensionException();
                }
                _extension = value;
            }
        }

        public string Path 
        {
            get => _path;
            set
            {
                if (!Directory.Exists(value))
                {
                    throw new InvalidPathException(nameof(value));
                }
                _path = value;
            }
        }

        public string FullPath => System.IO.Path.GetFullPath($"{Path}/{Name}.{Extension}");

        public int Size => File.ReadAllText(Path).Length;
    }
}

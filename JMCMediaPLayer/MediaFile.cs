using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMCMediaPLayer
{
    public class MediaFile
    {
        //properties
        public string FileName { get; set; }
        public string Path { get; set; }

        //constructors
        public MediaFile() { }

        public MediaFile(string fileName, string path)
        {
            this.FileName = fileName;
            this.Path = path;
        }
    }
}

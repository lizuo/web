using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CSVFileDAL : IDisposable
    {
        public string FilePath;
        protected FileStream fileStream;
        protected StreamReader strReader;

        public virtual void WriteToDatabase()
        {
        }

        public CSVFileDAL(string path)
        {
            FilePath = path;
            fileStream = File.OpenRead(FilePath);
            strReader = new StreamReader(fileStream, Encoding.UTF8);
        }

        public void Dispose()
        {
            strReader.Close();
            fileStream.Close();
        }
    }
}

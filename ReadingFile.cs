using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingTextFileToDatabase
{
    public class ReadingFile()
    {
        public static List<string> ReadFile(string path)
        {
                List<string> lines = File.ReadAllLines(path).ToList();
                return lines;
        }
    }
}

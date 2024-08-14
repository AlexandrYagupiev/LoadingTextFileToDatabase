using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Xml.Linq;

namespace LoadingTextFileToDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите путь к файлу с раширениме csv:");
            List<string> list = ReadingFile.ReadFile(Console.ReadLine());
            Console.WriteLine(WorkingWithDatabase.WriteTheDatabase(list));
            Console.WriteLine(WorkingWithDatabase.NumberOfMentions());
        }
    }
}

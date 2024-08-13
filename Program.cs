using System.IO;

namespace LoadingTextFileToDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Укажите путь к файлу формата csv");
                string path = Console.ReadLine();
                using (StreamReader sr = new StreamReader(path))
                {
                    string text = sr.ReadToEnd().Replace(Environment.NewLine, " ");
                    string[] split = text.Split(';');
                    foreach (string line in split)
                    {
                        Console.WriteLine(line);
                    }
                }
                Console.ReadKey();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

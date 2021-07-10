using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace ConsoleZipStream
{
    class Program
    {
        static void Main(string[] args)
        {

            FileTextWriter();


            string zipPath = "archive.zip";
            var file = new FileStream("text.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

            using (ZipArchive zipFile = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                var entry = zipFile.CreateEntry("text.txt", CompressionLevel.Optimal);

                using (var dataStream = entry.Open())
                {
                    file.CopyTo(dataStream);
                }
            }
        }

        public static void FileTextWriter()
        {
            FileStream file;
            StreamWriter streamWrite;
            TextWriter textWriter = Console.Out;

            try
            {
                file = new FileStream("text.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                streamWrite = new StreamWriter(file);
            }
            catch (Exception e)
            {
                Console.WriteLine("Не могу открыть text.txt.");
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Нажмите Escape (Esc) чтобы выйти из программы.");
            Console.Write("Введите текст: ");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                var input = Console.ReadLine();

                Console.SetOut(streamWrite);
                Console.WriteLine(input);
                Console.SetOut(textWriter);
            }

            streamWrite.Close();
            file.Close();

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}

using System;
using System.IO;

namespace Lesson
{
    class Program
    {
        static void DirectoryOverview(string path, int level)
        {
            var directories = Directory.GetDirectories(path);

            for (int i = 0; i < directories.Length; i++)

            {
                var directory = directories[i];
                var directoryInfo = new DirectoryInfo(directory);
                Console.WriteLine($"{directory}\n attributes: {directoryInfo.Attributes} Creation time: {directoryInfo.CreationTime} Last update: {directoryInfo.LastWriteTime}");
                DirectoryOverview(directory, level - 1);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите уровень: ");
                int level = int.Parse(Console.ReadLine());
                DirectoryOverview(@"../../../", level);
               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

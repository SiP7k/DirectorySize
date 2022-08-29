using System;
using System.IO;

namespace DirectorySize
{
    class DirectorySize
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users/cavva/Desktop/sss";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            Console.WriteLine(GetSize(dirInfo));
        }
        public static long GetSize(DirectoryInfo dirInfo)
        {
            long size = 0;

            try
            {
                if (dirInfo.Exists)
                {
                    var files = dirInfo.GetFiles();
                    var directories = dirInfo.GetDirectories();

                    foreach (var file in files)
                    {
                        size += file.Length;
                    }
                    foreach (var directory in directories)
                    {
                        size += GetSize(directory);
                    }
                }
                else
                {
                    Console.WriteLine("Папки по данному пути не найдено, проверьте правильность ввода");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return size;
        }
    }
}


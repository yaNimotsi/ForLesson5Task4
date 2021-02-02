using System;
using System.IO;
using System.Text.Json;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathFolder = @"D:\Текущие документы\Дыбрын земля площадок";

            string[] AllSubFolders = GetAllFolder(pathFolder);

            PrintFolderAndFiles(AllSubFolders);
        }

        static string[] GetAllFolder(string startFolderPath)
        {
            return Directory.GetDirectories(startFolderPath, "*", SearchOption.AllDirectories);
        }

        static string[] GetFilesInFolder(string folderPath)
        {
            string[] pathsToFiles = Directory.GetFiles(folderPath);

            string[] nameFiles = new string[pathsToFiles.Length];
            for (int i = 0; i< pathsToFiles.Length; i++)
            {
                nameFiles[i] = Path.GetFileName(pathsToFiles[i]);
            }

            return nameFiles;
        }

        static void PrintFolderAndFiles(string[] AllFolders)
        {
            for(int i = 0; i < AllFolders.Length; i++)
            {
                if (AllFolders[i] == null) continue;
                else
                {
                    Console.WriteLine($"Текущая папка {AllFolders[i]}");
                    string[] filesInFolder = GetFilesInFolder(AllFolders[i]);

                    if (filesInFolder.Length > 0)
                    {
                        Console.WriteLine("Файлы в указанной папке:");
                        Console.WriteLine();
                        foreach (string str in filesInFolder) Console.WriteLine(str);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("В указанной папке нет файлов!");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}

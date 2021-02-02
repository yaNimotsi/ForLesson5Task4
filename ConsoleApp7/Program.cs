using System;
using System.IO;
using System.Text;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathFolder = @"D:\Текущие документы\Дыбрын земля площадок";
            string fileToWriteText = @"D:\Текущие документы\Файл для примера.txt";

            string[] AllSubFolders = GetAllFolder(pathFolder);

            PrintFolderAndFiles(AllSubFolders, fileToWriteText);
        }

        static string[] GetAllFolder(string startFolderPath)
        {
            return Directory.GetDirectories(startFolderPath, "*", SearchOption.AllDirectories);
        }

        static string[] GetFilesInFolder(string folderPath)
        {
            string[] pathsToFiles = Directory.GetFiles(folderPath);

            string[] nameFiles = new string[pathsToFiles.Length];
            for (int i = 0; i < pathsToFiles.Length; i++)
            {
                nameFiles[i] = Path.GetFileName(pathsToFiles[i]);
            }

            return nameFiles;
        }

        static void PrintFolderAndFiles(string[] AllFolders, string fileToWritePath)
        {
            for (int i = 0; i < AllFolders.Length; i++)
            {
                if (AllFolders[i] == null) continue;
                else
                {
                    string[] filesInFolder = GetFilesInFolder(AllFolders[i]);

                    File.AppendAllText(fileToWritePath, $"Текущая папка {AllFolders[i]}", Encoding.UTF8);

                    if (filesInFolder.Length > 0)
                    {
                        File.AppendAllText(fileToWritePath, "Файлы в указанной папке: \n", Encoding.UTF8); ;

                        foreach (string str in filesInFolder)
                        {
                            File.AppendAllText(fileToWritePath, $"{str} \n", Encoding.UTF8); ;
                        }

                        Console.WriteLine();
                    }
                    else
                    {
                        File.AppendAllText(fileToWritePath, "В указанной папке нет файлов! \n", Encoding.UTF8);
                    }
                }
            }
        }
    }
}

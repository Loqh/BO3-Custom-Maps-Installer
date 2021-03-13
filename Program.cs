using System;
using System.IO;
using System.IO.Compression;

namespace BO3_Custom_Maps_Installer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                // Config
                Console.WriteLine("Entering config mode");
                DisplayExitMessage();
            }
            else
            {
                // Install map with args[0]
                CreateNecessaryFolders();
                
                WorkshopFile currentWorkshopFile = new WorkshopFile(args[0]);
                Console.WriteLine("Extracting " + currentWorkshopFile.RealArchiveName);
                
                ExtractWorkshopArchive(currentWorkshopFile);

                DisplayExitMessage();
            }
        }

        private static void DisplayExitMessage()
        {
            Console.WriteLine("Press any key to exit the application.");
            Console.ReadKey();
        }

        private static void CreateNecessaryFolders()
        {
            // usermaps in root
        }

        private static void ExtractWorkshopArchive(WorkshopFile currentWorkshopFile)
        {
            string usermapsPath = "/home/guillaume/Downloads/";
            string newMapPath = usermapsPath + currentWorkshopFile.ArchiveName;
            ZipFile.ExtractToDirectory(currentWorkshopFile.ArchivePath, newMapPath);
            
            var mapFiles = Directory.GetFiles(newMapPath);
            var mapFolders = Directory.GetDirectories(newMapPath);

            string zoneFolderPath = newMapPath + "/zone";
                                    Directory.CreateDirectory(zoneFolderPath);
            
            
            foreach (var VARIABLE in mapFiles)
            {
                Console.WriteLine(VARIABLE);
                File.Move(VARIABLE, zoneFolderPath + "/" + VARIABLE.Substring(VARIABLE.LastIndexOf(Path.DirectorySeparatorChar) + 1));
            }

            Console.WriteLine("end files");

            foreach (var VARIABLE in mapFolders)
            {
                Console.WriteLine(VARIABLE);
                Directory.Move(VARIABLE, zoneFolderPath + "/" + VARIABLE.Substring(VARIABLE.LastIndexOf(Path.DirectorySeparatorChar) + 1));
            }
            
            Directory.Move(newMapPath, usermapsPath + "zm_town");

            Console.WriteLine("end of app");
        }
    }
}
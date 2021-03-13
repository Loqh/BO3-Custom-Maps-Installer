using System.IO;

namespace BO3_Custom_Maps_Installer
{
    public class WorkshopFile
    {
        private string archivePath;
        private string archiveName;
        private string realArchiveName;

        public WorkshopFile(string archivePath)
        {
            this.archivePath = archivePath;
            realArchiveName = archivePath.Substring(archivePath.LastIndexOf(Path.DirectorySeparatorChar) + 1);
            archiveName = realArchiveName.Substring(0, realArchiveName.IndexOf("."));
        }

        public string ArchivePath => archivePath;

        public string ArchiveName => archiveName;

        public string RealArchiveName => realArchiveName;
    }
}
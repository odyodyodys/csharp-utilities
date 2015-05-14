using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Utilities.IO
{
    public static class FileFolderUtils
    {
        public static void CopyFolderRecursively(string SourcePath, string DestinationPath)
        {
            // ensure destination folder exists
            Directory.CreateDirectory(DestinationPath);

            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
            }
        }

        public static void EmptyFolder(string path)
        {
            System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(path);

            foreach (FileInfo file in downloadedMessageInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}

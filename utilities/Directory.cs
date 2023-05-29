using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteDocsAutomationProject.utilities
{
    public enum Directory
    {
        UploadFilesPath
    }

    public class DirectoryPaths
    {
        public static string GetPath(Directory folder)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string binDebugNetPath = "\\bin\\Debug\\net6.0";
            string folderPath = folder switch
            {
                Directory.UploadFilesPath => baseDirectory.Replace(binDebugNetPath, "") + "uploadFiles\\",
                _ => throw new ArgumentException("Invalid folder name")
            };
            return folderPath;
        }

    }

}

using System.IO;
using System.Configuration;

namespace UEDataSortBackup
{
    class DeleteEmpty//goal: delete empty folders in my sort source.
    {
        public void deleteEmptyDir()
        {
            string sortPath = ConfigurationManager.AppSettings.Get("sortPath");//pull sortPath from config

            foreach (var directory in Directory.GetDirectories(sortPath))//delete empty directories in sortPath
            {
                if (Directory.GetFiles(directory).Length == 0 &&
                    Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                }
            }
        }
    }
}
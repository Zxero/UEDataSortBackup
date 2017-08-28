using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Specialized;

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
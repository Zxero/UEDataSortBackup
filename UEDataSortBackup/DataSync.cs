using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Files;
using System.Configuration;

namespace UEDataSortBackup
{
    class DataSync
    {
        public static void Sync(string[] args)
        {
            string RelicaRootPath = ConfigurationManager.AppSettings.Get("sortPath");//Load sortPath from config

            try
            {
                //set options variable. Refer to MSDN on each of these do
                FileSyncOptions options = FileSyncOptions.ExplicitDetectChanges |
                    FileSyncOptions.RecycleDeletedFiles | FileSyncOptions.RecyclePreviousFileOnUpdates |
                    FileSyncOptions.RecycleConflictLoserFiles;

                //set FileSyncFilters. This tell the sync to ignore all .WFM files
                FileSyncScopeFilter filter = new FileSyncScopeFilter();
                filter.FileNameExcludes.Add("*.wfm");


            }
            catch (Exception e)
            {
                Debug.WriteLine("\nException from File Sync Provider:\n" + e.ToString());
            }
        }
    }
}
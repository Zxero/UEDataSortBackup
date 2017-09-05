using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Files;
using System.Configuration;

namespace UEDataSortBackup
{
    class DataSync
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main(string[] args)
        {
            string replica1RootPath = ConfigurationManager.AppSettings.Get("sortPath");//Load sortPath from config
            string replica2RootPath = ConfigurationManager.AppSettings.Get("syncPath");//Load syncPath from config

            try
            {
                //set options variable. Refer to MSDN on each of these do
                FileSyncOptions options = FileSyncOptions.ExplicitDetectChanges |
                    FileSyncOptions.RecycleDeletedFiles | FileSyncOptions.RecyclePreviousFileOnUpdates |
                    FileSyncOptions.RecycleConflictLoserFiles;

                //set FileSyncFilters. This tell the sync to ignore all .WFM files
                FileSyncScopeFilter filter = new FileSyncScopeFilter();
                filter.FileNameExcludes.Add("*.wfm");

                // Explicitly detect changes on both replicas before syncyhronization occurs.
                // This avoids two change detection passes for the bidirectional synchronization 
                // that we will perform.
                DetectChangesOnFileSystemReplica(
                    replica1RootPath, filter, options);
                DetectChangesOnFileSystemReplica(
                    replica2RootPath, filter, options);

                // Synchronize the replicas in a single direction. Replica 1 is
                // the source. The third parameter(the filter value) is null because the filter is specified in DetectChangesOnFileSystemReplica().
                SyncFileSystemReplicasOneWay(replica1RootPath, replica2RootPath, null, options);
            }
            catch (Exception e)
            {
                log.Info("\nException from File Sync Provider:\n" + e.ToString());
            }
            Console.ReadLine();
        }

        public static void DetectChangesOnFileSystemReplica(
        string replicaRootPath,
        FileSyncScopeFilter filter, FileSyncOptions options)
        {
            FileSyncProvider provider = null;

            try
            {
                provider = new FileSyncProvider(replicaRootPath, filter, options);
                provider.DetectChanges();
            }
            finally
            {
                if (provider != null)
                    provider.Dispose();
            }
        }

        public static void SyncFileSystemReplicasOneWay(
        string sourceReplicaRootPath, string destinationReplicaRootPath,
        FileSyncScopeFilter filter, FileSyncOptions options)
        {
            FileSyncProvider sourceProvider = null;
            FileSyncProvider destinationProvider = null;

            try
            {
                // Instantiate source and destination providers, with a null filter (the filter
                // was specified in DetectChangesOnFileSystemReplica()), and options for both.
                sourceProvider = new FileSyncProvider(
                    sourceReplicaRootPath, filter, options);
                destinationProvider = new FileSyncProvider(
                    destinationReplicaRootPath, filter, options);

                // Register event handlers so that we can write information
                // to the console.
                destinationProvider.AppliedChange +=
                    new EventHandler<AppliedChangeEventArgs>(OnAppliedChange);
                destinationProvider.SkippedChange +=
                    new EventHandler<SkippedChangeEventArgs>(OnSkippedChange);

                // Use SyncCallbacks for conflicting items.
                SyncCallbacks destinationCallbacks = destinationProvider.DestinationCallbacks;
                destinationCallbacks.ItemConflicting += new EventHandler<ItemConflictingEventArgs>(OnItemConflicting);
                destinationCallbacks.ItemConstraint += new EventHandler<ItemConstraintEventArgs>(OnItemConstraint);

                SyncOrchestrator agent = new SyncOrchestrator();
                agent.LocalProvider = sourceProvider;
                agent.RemoteProvider = destinationProvider;
                agent.Direction = SyncDirectionOrder.Upload; // Upload changes from the source to the destination.

                Console.WriteLine("Synchronizing changes to replica: " +
                    destinationProvider.RootDirectoryPath);
                agent.Synchronize();
            }
            finally
            {
                // Release resources.
                if (sourceProvider != null) sourceProvider.Dispose();
                if (destinationProvider != null) destinationProvider.Dispose();
            }
        }
        // Provide information about files that were affected by the synchronization session.
        public static void OnAppliedChange(object sender, AppliedChangeEventArgs args)
        {
            switch (args.ChangeType)
            {
                case ChangeType.Create:
                    log.Info("-- Applied CREATE for file " + args.NewFilePath);
                    break;
                case ChangeType.Delete:
                    log.Info("-- Applied DELETE for file " + args.OldFilePath);
                    break;
                case ChangeType.Update:
                    log.Info("-- Applied OVERWRITE for file " + args.OldFilePath);
                    break;
                case ChangeType.Rename:
                    log.Info("-- Applied RENAME for file " + args.OldFilePath +
                                      " as " + args.NewFilePath);
                    break;
            }
        }

        // Provide error information for any changes that were skipped.
        public static void OnSkippedChange(object sender, SkippedChangeEventArgs args)
        {
            log.Info("-- Skipped applying " + args.ChangeType.ToString().ToUpper()
                  + " for " + (!string.IsNullOrEmpty(args.CurrentFilePath) ?
                                args.CurrentFilePath : args.NewFilePath) + " due to error");

            if (args.Exception != null)
                log.Info("   [" + args.Exception.Message + "]");
        }

        // By default, conflicts are resolved in favor of the last writer. In this example,
        // the change from the source in the first session (replica 1), will always
        // win the conflict.
        public static void OnItemConflicting(object sender, ItemConflictingEventArgs args)
        {
            args.SetResolutionAction(ConflictResolutionAction.SourceWins);
            log.Info("-- Concurrency conflict detected for item " + args.DestinationChange.ItemId.ToString());
        }

        public static void OnItemConstraint(object sender, ItemConstraintEventArgs args)
        {
            args.SetResolutionAction(ConstraintConflictResolutionAction.SourceWins);
            log.Info("-- Constraint conflict detected for item " + args.DestinationChange.ItemId.ToString());
        }
    }
}
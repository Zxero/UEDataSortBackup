using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using Microsoft.Synchronization;

namespace UEDataSortBackup //goal: sort results folder into Year>Month>Day folders
{
    class DataSort
    {
        static void Main(string[] args)
        {            
            try
            {
                string sortPath = ConfigurationManager.AppSettings.Get("sortPath");//Load sortPath from config!
                List<string> toSort = new List<string>(Directory.EnumerateDirectories(sortPath, "*_*"));//Creating array of all directories in sortPath

                foreach (string path in toSort)//for each entry in the array we do the following:
                {
                    int x = 0;//variable for dupe later
                    string[] folder = path.Split('\\');//I want to do a small length check on our folders - don't want non result folders
                    string[] lengthCheck = folder[3].Split('_');
                    int count = lengthCheck[1].Length;
                    if (lengthCheck[1].Length != 17)//length check itself
                    {

                    }
                    else
                    {
                        string[] result = path.Split('_', ' ', '\\', '-');//Split each path by the criteria outlined
                        string newPath = result[0] + '\\' + result[1] + ' ' + result[2] + '\\' + result[3]
                            + '\\' + result[5] + '\\' + result[6] + '\\' + result[7] + '\\' + result[4]
                            + '_' + result[5] + '-' + result[6] + '-' + result[7] + ' ' + result[8];//creates new path based on the pieces of the split

                        while (Directory.Exists(newPath))
                        {
                            x = x + 1;
                            newPath = result[0] + '\\' + result[1] + ' ' + result[2] + '\\' + result[3]
                            + '\\' + result[5] + '\\' + result[6] + '\\' + result[7] + '\\' + result[4]
                            + '_' + result[5] + '-' + result[6] + '-' + result[7] + ' ' + result[8] + " DUPE" + x;//creates dupe if directory exists. loops, adding 1 to dupe until its available
                        }
                        Directory.CreateDirectory(newPath);//creates new directory

                        foreach (string dirPath in Directory.GetFiles(path, "*.*",
                            SearchOption.AllDirectories))
                            File.Move(dirPath, dirPath.Replace(path, newPath));//moves all files from original directory to new directory
                        DirectoryInfo di = new DirectoryInfo(path);
                    }
                    if (Directory.GetFiles(path).Length == 0 &&
                    Directory.GetDirectories(path).Length == 0)//delete the old directory in results, but only if its empty
                    {
                        Directory.Delete(path, false);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("The process failed: {0}", e.ToString());
            }

        }
    }
}
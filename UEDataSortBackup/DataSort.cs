using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace UEDataSortBackup //goal: sort results folder into Year>Month>Day folders.
{
    class DataSort
    {
        static void Main(string[] args)
        {
            try
            {
                string sortPath = @"C:\UE1 Data\Results";//Path of results. Need to create config file for this.
                List<string> toSort = new List<string>(Directory.EnumerateDirectories(sortPath, "*_*"));//Creating array of all directories in sortPath.

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
                            + '_' + result[5] + '-' + result[6] + '-' + result[7] + ' ' + result[8] + " DUPE" + x;//creates dupe if directory exists. loops, adding 1 to dupe until its open
                        }
                        Directory.CreateDirectory(newPath);//creates new directory

                        foreach (string dirPath in Directory.GetFiles(path, "*.*",
                            SearchOption.AllDirectories))
                            File.Move(dirPath, dirPath.Replace(path, newPath));//moves all files from original directory to new directory
                        DirectoryInfo di = new DirectoryInfo(path);
                    }
                }
                foreach (var directory in Directory.GetDirectories(sortPath))//delete empty directories in sortPath
                {
                    if (Directory.GetFiles(directory).Length == 0 &&
                        Directory.GetDirectories(directory).Length == 0)
                    {
                        Directory.Delete(directory, false);
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
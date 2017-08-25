using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace UEDataSortBackup //goal: sort results folder into Year>Month>Day folders. Then back it up to a specified location. Don't do this bad.
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sortPath = @"C:\UE1 Data\Results";
                List<string> toSort = new List<string>(Directory.EnumerateDirectories(sortPath, "*_*"));

                foreach (string path in toSort)
                {
                    int x = 0;
                    string folderName = path;
                    string[] result = path.Split('_', ' ', '\\', '-');
                    string newPath = result[0] + '\\' + result[1] + ' ' + result[2] + '\\' + result[3]
                        + '\\' + result[5] + '\\' + result[6] + '\\' + result[7] + '\\' + result[4]
                        + '_' + result[5] + '-' + result[6] + '-' + result[7] + ' ' + result[8];

                    Console.WriteLine(newPath);
                    Console.ReadLine();

                    while (Directory.Exists(newPath)) {                                                
                        x = x + 1;
                        newPath = result[0] + '\\' + result[1] + ' ' + result[2] + '\\' + result[3]
                        + '\\' + result[5] + '\\' + result[6] + '\\' + result[7] + '\\' + result[4]
                        + '_' + result[5] + '-' + result[6] + '-' + result[7] + ' ' + result[8] + " DUPE" + x;
                        Console.WriteLine("New path already exists. Trying dupe path " + x);
                        Console.ReadLine();
                    }
                    Console.WriteLine(newPath);
                    Console.ReadLine();
                    Directory.CreateDirectory(newPath);
                    Console.WriteLine("The directory was created successfully!");
                    Console.ReadLine();

                    foreach (string dirPath in Directory.GetFiles(path, "*.*",
                        SearchOption.AllDirectories))
                        File.Move(dirPath, dirPath.Replace(path, newPath));
                    Console.WriteLine("Directory moved from " + path + " to " + newPath);
                    Console.ReadLine();
                    Console.WriteLine("About to delete " + path);
                    Console.ReadLine();
                    DirectoryInfo di = new DirectoryInfo(path);
                    di.Delete();
                    Console.WriteLine(path + " deleted successfully!");
                }
                Console.WriteLine("Program will now exit!");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                Console.ReadLine();
                                }

        }
    }
}
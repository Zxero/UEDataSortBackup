﻿using System;
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
                    string folderName = path;
                    string[] result = path.Split('_');
                    string dateTime = result[1];
                    string[] resultTwo = dateTime.Split(' ');
                    string date = resultTwo[0];

                    Console.WriteLine(dateTime);
                    Console.WriteLine(date);
                    Console.WriteLine(folderName);
                    Console.ReadLine();

                }
                Console.WriteLine("{0} directories found.", toSort.Count);
            }
            catch (UnauthorizedAccessException UAEx)
            {
                Console.WriteLine(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                Console.WriteLine(PathEx.Message);
            }
            Console.ReadLine();
        }
    }
}
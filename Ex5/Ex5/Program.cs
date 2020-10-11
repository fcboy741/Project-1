using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Excercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //drive info
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    Console.WriteLine($"Drive name: {drive.Name}");
                    Console.WriteLine($"Format: {drive.DriveFormat}");
                    Console.WriteLine($"Type: {drive.DriveType}");
                    Console.WriteLine($"Root directory: {drive.RootDirectory}");
                    Console.WriteLine($"Volume label: {drive.VolumeLabel}");
                    Console.WriteLine($"Free space: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Available space:{ drive.AvailableFreeSpace}");
                    Console.WriteLine($"Total size: {drive.TotalSize}");
                    Console.WriteLine();
                }
            }
            //xuat ra tat ca file trong document
            string rootPath = @"C:\Users\Administrator\Documents";
            string[] dirs = Directory.GetDirectories(rootPath);
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
            }
            //create file txt

            string path = @"C:\Users\Administrator\Desktop\Test.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome to this text file");
                }
            }

            // Open the file to read from.           
            string path1 = @"C:\Users\Administrator\Desktop\Test.txt";
            using (StreamReader sr = File.OpenText(path1))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
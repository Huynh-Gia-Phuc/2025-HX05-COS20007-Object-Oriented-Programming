using System;
using System.Collections.Generic;
using System.Dynamic;

namespace iLoveMyTeacher
{
    class Program
    {
        static void Main(string[] args)
        {
            //File file1 = new File("Martin The Warrior by Brian JAcques", "text", 3720);
            //File file2 = new File("Northern Lights by Philip Pullman", "text", 3990);
            //File file3 = new File("he Escapement by K. J. Parker", "text", 4070);
            //File file4 = new File("Snow Crash by Neal Stephenson", "text", 4400);
            //File file5 = new File("Renegade's Magic by Robin Hobb", "text", 7600);
            //Folder folder = new Folder("Saved Files");

            //folder.Add(file1);
            //folder.Add(file2);
            //folder.Add(file3);
            //folder.Add(file4);    
            //folder.Add(file5);

            //Folder folder1 = new Folder("New Project");

            //File file6 = new File("ArtWork", "jpg", 5342);

            //File file7 = new File("PriceList", "xls", 832);


            //FileSystem fileSystem = new FileSystem();
            //fileSystem.Add(folder);
            //fileSystem.Add(folder1);
            //fileSystem.Add(file6);
            //fileSystem.Add(file7);
            //fileSystem.PrintContent();

           
            List<int> B = new List<int> { 3, 7, 13, 23 };
            string studentId = "105505856";

            Random random = new Random();

            // a) Creating a FileSystem.
            FileSystem fileSystem = new FileSystem();

            // b) Adding a number of B[0] files to the file system. For example, if B[0] = 29, 29 files will be added. Each
            //file should be named with the format "YourStudentID-index.txt".For example, '1119270-00.txt',
            // '1119270-01.txt', ..., '1119270-28.txt
            CreateFiles(fileSystem, B[0], studentId, random, 0);

            // c) Adding a folder that contains a number of B[1] files to the file system. The files have above format name.
            Folder folderB1 = new Folder("StudentFiles_Level1");
            CreateFiles(folderB1, B[1], studentId, random, B[0]);
            fileSystem.Add(folderB1);

            // d) Adding a folder that contains a folder that contains B[2] files to the file system.
            Folder outerFolder = new Folder("StudentFiles_Level2");
            Folder innerFolder = new Folder("InnerFolder");
            CreateFiles(innerFolder, B[2], studentId, random, B[0] + B[1]);
            outerFolder.Add(innerFolder);
            fileSystem.Add(outerFolder);

            // e) Adding a number of B[3]  empty folders to the file system.
            for (int i = 0; i < B[3]; i++)
            {
                Folder emptyFolder = new Folder($"EmptyFolder-{i.ToString("D2")}");
                fileSystem.Add(emptyFolder);
            }

            // f) Calling the PrintContents method.
            fileSystem.PrintContent();
        }

        //im sorry i am too lazy to create files individually:<
        static void CreateFiles(FileSystem fileSystem, int count, string studentId, Random random, int startIndex)
        {
            for (int i = 0; i < count; i++)
            {
                string fileName = $"{studentId}-{(startIndex + i).ToString("D2")}";
                int randomNumber = random.Next(100, 10001);
                File newFile = new File(fileName, "text", randomNumber);
                fileSystem.Add(newFile);
            }
        }

        //im sorry i am too lazy to create folders individually so i use the things u tell us last time C# can have overloading method:<
        static void CreateFiles(Folder folder, int count, string studentId, Random random, int startIndex)
        {
            for (int i = 0; i < count; i++)
            {
                string fileName = $"{studentId}-{(startIndex + i).ToString("D2")}";
                int randomNumber = random.Next(100, 10001);
                File newFile = new File(fileName, "text", randomNumber);
                folder.Add(newFile);
            }
        }
    }
}
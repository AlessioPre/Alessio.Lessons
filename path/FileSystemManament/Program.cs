using System;
using System.IO;
using System.Text;

namespace FileSystemManament
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Person[] person = new Person[] {
                new Person() { Name = "Bruno", Surname = "Ferreira" },
                new Person() { Name = "Bruno", Surname = "Ferreira" }
            };

            // readFromFile("C:\\CGM2023\\", "WriteOnFile.txt"); 
            //SimpleFileMove("C:\\CGM2023\\", "C:\\", "WriteOnFile.txt"); 
            WriteAsTabular("C:\\CGM2023\\", "TabulerFile.csv", person);
        }
        static void SpecialPath(string Driver, string myDirectory)
        {
            //Path.DirectorySeparatorChar ->  crea un Separatore \ oppure / in base al sistema operativo
            // -> WINDOWS -> C:\users\bruno
            // -> UNIX[Linux, MacOs] -> Home/Bruno ->  

            string path1 = $"{Driver}{Path.DirectorySeparatorChar}{myDirectory}";
            Console.WriteLine(path1);
        }
        static void SepcialDirectory()
        {
            string specialDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            Console.WriteLine(specialDir);
        }
        static void SplitPath()
        {
            //C:\Users\bruno\source\repos\LessonsWintet2023\FileSystemManament\bin\Debug\net5.0
            string myDirectory = Directory.GetCurrentDirectory();
            var splitedDir = myDirectory.Split(Path.DirectorySeparatorChar);

            foreach (string s in splitedDir)
            {
                Console.WriteLine(s);
            }

        }

        static void JoinPath(string dir, string FileName)
        {
            var myPath = Path.Combine(dir, FileName); // C:\miofile.txt
            Console.WriteLine(myPath);
        }
        static void getFileExtetion()
        {
            var fExt = Path.GetExtension("vendita.json");
            Console.WriteLine(fExt);
        }
        static void GetDirectoryInfo()
        {
            string path = Directory.GetCurrentDirectory();
            DirectoryInfo dInfo = new DirectoryInfo(path);

            foreach (var item in dInfo.GetDirectories())
            {
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Last Write: {item.LastWriteTime}");
            }
        }
        static void SearchInDirectory()
        {
            var files = Directory.EnumerateFiles(
                Directory.GetCurrentDirectory(),
                "*.dll",
                SearchOption.AllDirectories

                );

            foreach (var item in files)
            {
                Console.WriteLine(item);
            }
        }
        static void CreateFile(string file)
        {
            string[] names = new string[] { "Anna", "Marco", "Bruno" };
            File.Create(file); // ->  il nome del file de ve essere compreso del path completo. 
            DirectoryInfo info = new DirectoryInfo(file);
            File.WriteAllLines(file, names);
        }
        static void WriteOnFile(string path, string FileName)
        {
            string[] names = new string[] { "Anna", "Marco", "Bruno" };

            //logs
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllLines(Path.Combine(path, FileName), names); // -> Erease all content 
            File.AppendAllLines(Path.Combine(path, FileName), names); // -> Add Content text 
        }
        static void readFromFile(string Dir, String FileName)
        {
            var text = File.ReadAllText(Path.Combine(Dir, FileName));

            Console.WriteLine(text);
        }
        static void SimpleFileMove(string SrcPath, String DestPath, string FileName)
        {
            string src = Path.Combine(SrcPath, FileName);
            string dest = Path.Combine(DestPath, FileName);
            File.Move(src, dest);
        }
        static void SimpleFileCopy(string SrcPath, String DestPath, string FileName)
        {
            string src = Path.Combine(SrcPath, FileName);
            string dest = Path.Combine(DestPath, FileName);
            File.Copy(src, dest);
        }
        static void SimpleFileDelete(string SrcPath, String DestPath, string FileName)
        {
            string src = Path.Combine(SrcPath, FileName);
            // string dest = Path.Combine(DestPath, FileName);
            File.Delete(src);
        }

        static void WriteAsTabular(string path, string FileName, Person[] data)
        {
            StringBuilder sb = new StringBuilder();

            string FilePath = Path.Combine(path, FileName);

            if (!File.Exists(FilePath))
            {
                string header = string.Format("Name,Surname");
                sb.AppendLine(header);
            }

            foreach (var person in data)
            {
                sb.AppendLine(String.Format($"{person.Name},{person.Surname}"));
            }

            File.AppendAllText(FilePath, sb.ToString());

        }
    }
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Person()
        {
        }
    }


}





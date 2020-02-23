using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace CSharp_Net_module1_7_1_lab
{
    static class InOutOperation
    {
        // 1) declare properties  CurrentPath - path to file (without name of file), 
        // CurrentDirectory - name of current directory,
        // CurrentFile - name of current file
        public static string CurrentPath { get; set; }
        public static string CurrentDirectory { get; set; }
        public static string CurrentFile { get; set; }


        // 2) declare public methods:
        //ChangeLocation() - change of CurrentPath; 
        // method takes new file path as parameter, creates new directories (if it is necessary)
        public static void ChangeLocation(string NewFilePath)
        {
            if (!Directory.Exists(NewFilePath))
            {
                Console.WriteLine("Create new direcories?");
                Console.WriteLine("1. Yes/n2. No");
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        CreateDirectory(NewFilePath);
                        CurrentPath = NewFilePath;
                        break;
                    case 2:
                        Console.WriteLine("Refusal of creating new directories");
                        return;
                    default:
                        Console.WriteLine("Uncorrect option");
                        break;
                }
            }
            else
            {
                CurrentPath = NewFilePath;
            }


        }

        // CreateDirectory() - create new directory in current location
        public static void CreateDirectory(string CurrentLocation)
        {
            Directory.CreateDirectory(CurrentLocation);
        }
        // WriteData() – save data to file
        // method takes data (info about computers) as parameter
        public static void WriteData(Computer computerData)
        {
            if (!File.Exists(CurrentFile))
                Console.WriteLine($"{CurrentFile} was created");
            string pathAndFileName = CurrentPath + "\\" + CurrentFile;
            using (StreamWriter streamWriter = new StreamWriter(pathAndFileName, true))
            {
                streamWriter.WriteLine(computerData);
                streamWriter.WriteLine();
            }
        }

        // ReadData() – read data from file
        // method returns info about computers after reading it from file
        public static string ReadData(string pathAndFileName)
        {
            if (!File.Exists(pathAndFileName))
            {
                Console.WriteLine($"File {pathAndFileName} not found");
                return null;
            }
            using (StreamReader streamReader = new StreamReader(pathAndFileName))
            {
                return streamReader.ReadToEnd();
            }
        }
        // WriteZip() – save data to zip file
        // method takes data (info about computers) as parameter
        public static void WriteZip(Computer computerData, string fileNameCompress)
        {
            WriteData(computerData);
            using (FileStream CurrentFileToCompress = new FileStream(CurrentPath + "//" + CurrentFile, FileMode.OpenOrCreate))
            {
                using (FileStream CompressFile = File.Create("fghjk.7z"))
                {
                    using (GZipStream zipStream = new GZipStream(CompressFile, CompressionMode.Compress))
                    {
                        CurrentFileToCompress.CopyTo(zipStream);
                    }
                }
            }
        }
        // ReadZip() – read data from file
        // method returns info about computers after reading it from file
        public static string ReadZip(string pathAndFileName)
        {
            using (FileStream DecompressFile = File.OpenRead(pathAndFileName))
            {
                using (GZipStream zipStream = new GZipStream(DecompressFile, CompressionMode.Decompress))
                {
                    byte[] fileByte = new byte[ReadData(CurrentPath + "//" + CurrentFile).Length];
                    zipStream.Read(fileByte, 0, fileByte.Length);
                    return Encoding.Default.GetString(fileByte);
                }
            }
        }
        // ReadAsync() – read data from file asynchronously
        // method is async
        // method returns Task with info about computers
        // use ReadLineAsync() method to read data from file
        // Note: don't forget about await
        public static async Task<string> ReadAsync(string pathAndFileName)
        {
            await Task.Delay(700);
            string result="";
            StringBuilder stringBuilder = new StringBuilder();
            if (!File.Exists(pathAndFileName))
            {
                Console.WriteLine($"File {pathAndFileName} not found");
                return null;
            }
            using (StreamReader streamReader = new StreamReader(pathAndFileName))
            {
                while ((result = await streamReader.ReadLineAsync())!=null)
                {
                    stringBuilder.AppendLine(result);
                }
                return stringBuilder.ToString();
            }
        }

        // 7)
        // ADVANCED:
        // WriteToMemoryStream() – save data to memory stream
        // method takes data (info about computers) as parameter
        // info about computers is saved to Memory Stream

        // use  method GetBytes() from class UnicodeEncoding to save array of bytes from string data 
        // create new file stream
        // use method WriteTo() to save memory stream to file stream 
        // method returns file stream

        public static FileStream WriteToMemoryStream(Computer computerData)
        {
            var b = Encoding.Default.GetBytes(computerData.ToString());
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(b, 0, b.Length);
                using (FileStream fileStream = new FileStream(CurrentPath + "//" + CurrentFile, FileMode.OpenOrCreate))
                {
                    memoryStream.WriteTo(fileStream);
                    return fileStream;
                }
                
            }
        }

        // WriteToFileFromMemoryStream() – save data to file from memory stream and read it
        // method takes file stream as parameter
        // save data to file      
        public static string WriteToFileFromMemoryStream(FileStream fileStream)
        {
            using (fileStream = File.OpenRead(CurrentPath + "//" + CurrentFile))
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    byte[] array = new byte[fileStream.Length];
                    fileStream.Read(array, 0, array.Length);
                    memStream.Write(array, 0, array.Length);
                    memStream.Read(array, 0, array.Length);
                    return Encoding.Default.GetString(array);
                }
            }
        }

        // Note: 
        // - use '//' in path string or @ before it (for correct path handling without escape sequence)
        // - use 'using' keyword to organize correct working with files
        // - don't forget to check path before any file or directory operations
        // - don't forget to check existed directory and file before creating
        // use File class to check files, Directory class to check directories, Path to check path


    }
}

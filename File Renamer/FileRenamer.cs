using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace File_Renamer
{
    public class FileRenamer
    {

        public FileRenamer()
        {
                
        }

        public List<File> GetFiles(string topPath)
        {
            List<string> filePaths = new List<string>();
            List<File> files = new List<File>();

            //add all files in the top directory
            filePaths.AddRange(Directory.GetFiles(topPath));
            //get all subdirectories and add to list
            string[] subDirectories = GetDirectories(topPath);
  
            //loop through subdirectories and search files
            foreach (string dir in subDirectories)
            {
                //Console.WriteLine(dir);
                //Trace.WriteLine(dir);

                filePaths.AddRange(Directory.GetFiles(dir));

            }

            foreach (string path in filePaths)
            {

                Trace.WriteLine(path);
                string test = path.Split('\\').Last();
                files.Add(new File() { FileName = test, FilePath = path });

            }

            return files;
        }


        public string[] GetDirectories(string path)
        {
            string[] dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            return dirs;
        }


    }
   
}

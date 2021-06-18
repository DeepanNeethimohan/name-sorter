using System;
using System.IO;

namespace name_sorter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Return an error if there are no arguments
            if (args.Length == 0)
            {
                Console.WriteLine("Please retry with the full path of the file");
                return;
            }

            //Get the full path of the file with the names
            var filename = args[0];

            //Sort by Ascending by Default. For Descending specify argument as DESC
            var descending = args.Length > 2 && args[2] == "DESC" ? true:false;
            var outfile = args.Length > 1 ? args[1] : "sorted-names-list.txt";
            outfile = Directory.GetCurrentDirectory() + "\\" + outfile;

            //Stop if the file is blank
            if (filename == "")
            {
                Console.WriteLine("Blank not allowed for File. Please retry");
                return;
            }

            //Access the FileProcessor class to Sort the names in the file.
            NameProcessor nameProcessor = new NameProcessor(filename);

            //Read the names
            String returnvalue = nameProcessor.ReadNamesinFile();

            //Go ahead and Sort if the file is found. Else display the Exception messag. For e.g. file not found.
            if(returnvalue == "")
            {
                //Reverse all names
                nameProcessor.BringLastnametoFront();
                //Sort Ascending
                nameProcessor.SortNames(descending);
                //Display Sorted Names
                nameProcessor.DisplayNames();
            }
            else
            {
                //Exception Message
                Console.WriteLine(returnvalue);
                return;
            }

            returnvalue = nameProcessor.SavetoaNewFile(outfile);

            if(returnvalue != "")
            {
                Console.WriteLine(returnvalue);
                return;
            }

            Console.WriteLine("Sorting Completed Successfully. Check file {0} for the sorted names", outfile);
        }
    }
}

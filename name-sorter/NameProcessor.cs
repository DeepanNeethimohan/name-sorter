using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace name_sorter
{
    /// <summary>
    /// Class that holds methods to Process Names in a file
    /// </summary>
    public class NameProcessor
    {
        #region members
        public String[] names { get; set; }
        private static string _filename { get; set; }
        #endregion
        public List<Names> allNames = new List<Names>();
        public List<Names> sortedNames = new List<Names>();

        #region methods
        //Constructor to initialize the filename
        public NameProcessor(string filename)
        {
            _filename = filename;
        }
        /// <summary>
        /// Read all the names in the file. 
        /// </summary>
        /// <returns></returns>
       
        public string ReadNamesinFile()
        {
            try
            {
                //Read all lines in the file and store in a string array
                names = File.ReadAllLines(_filename);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }

        /// <summary>
        /// Use this method to bring the last name to front
        /// </summary>
        public void BringLastnametoFront()
        {
            String[] splitnames;

            for (var i = 0; i < names.Length; i++)
            {
                splitnames = names[i].Split(" ");
 
                var reversedName = splitnames[splitnames.Length - 1];

                for(var j = 0; j < splitnames.Length - 1; j++)
                {
                    reversedName = reversedName + " " + splitnames[j];
                }
                allNames.Add(new Names(names[i], reversedName));
            }
        }

        /// <summary>
        /// Use this method to Sort the names
        /// </summary>
        /// <param name="descending"></param>
        public void SortNames(bool descending)
        {
            sortedNames = allNames.OrderBy(c => c._reversedName).ToList();

            if (descending)
                sortedNames = allNames.OrderByDescending(c => c._reversedName).ToList();
        }

        /// <summary>
        /// Use this method to Display all the Sorted Names
        /// </summary>
        public void DisplayNames()
        {
            foreach(var name in sortedNames)
            {
                Console.WriteLine(name._name);
            }
        }

        /// <summary>
        /// Use this method to create a new file and save the sorted names.
        /// </summary>
        /// <param name="filefullpath"></param>
        /// <returns></returns>
        public string SavetoaNewFile(string filefullpath)
        {
            try
            {
                using (FileStream fs = File.Create(filefullpath)) ;
                File.WriteAllLines(filefullpath, sortedNames.Select(c => c._name).ToArray());
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        #endregion
    }
}

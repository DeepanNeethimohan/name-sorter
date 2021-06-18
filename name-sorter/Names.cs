using System;
using System.Collections.Generic;
using System.Text;

namespace name_sorter
{
    /// <summary>
    /// Class that holds the original name and the name with Last name in front
    /// </summary>
    public class Names
    {
        public string _name { get; set; }
        public string _reversedName { get; set; }
        public Names(string name, string reversedName)
        {
            _name = name;
            _reversedName = reversedName;
        }
    }
}

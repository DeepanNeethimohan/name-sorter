using name_sorter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace name_sorter.Tests
{
    [TestClass()]
    public class NameProcessorTests
    {
        [TestMethod()]
        public void ReadNamesinFileTest()
        {
            var filename = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/testfile.txt";
            NameProcessor nameProcessor = new NameProcessor(filename);

            //Read the names
            String returnvalue = nameProcessor.ReadNamesinFile();

            Assert.AreEqual("", returnvalue);
            Assert.AreEqual("Sindhu Deepan", nameProcessor.names[0]);
            Assert.AreEqual("Deepan Neethimohan", nameProcessor.names[1]);
            Assert.AreEqual("Siddhanth Deepan", nameProcessor.names[2]);

        }

        [TestMethod()]
        public void BringLastnametoFrontTest()
        {
            var filename = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/testfile.txt" ;
            NameProcessor nameProcessor = new NameProcessor(filename);

            //Read the names
            String returnvalue = nameProcessor.ReadNamesinFile();
            Assert.AreEqual("", returnvalue);

            if (returnvalue == "")
            {
                //Reverse all names
                nameProcessor.BringLastnametoFront();
                Assert.AreEqual("Deepan Sindhu", nameProcessor.allNames[0]._reversedName);
                Assert.AreEqual("Neethimohan Deepan", nameProcessor.allNames[1]._reversedName);
                Assert.AreEqual("Deepan Siddhanth", nameProcessor.allNames[2]._reversedName);
            }
        }

        [TestMethod()]
        public void SortNamesTest()
        {
            var filename = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/testfile.txt";
            NameProcessor nameProcessor = new NameProcessor(filename);

            //Read the names
            String returnvalue = nameProcessor.ReadNamesinFile();
            Assert.AreEqual("", returnvalue);

            if (returnvalue == "")
            {
                //Reverse all names
                nameProcessor.BringLastnametoFront();
                nameProcessor.SortNames(false);
                Assert.AreEqual("Siddhanth Deepan", nameProcessor.sortedNames[0]._name);
                Assert.AreEqual("Sindhu Deepan", nameProcessor.sortedNames[1]._name);
                Assert.AreEqual("Deepan Neethimohan", nameProcessor.sortedNames[2]._name);
            }
        }

        [TestMethod()]
        public void SavetoaNewFileTest()
        {
            var expected = "Siddhanth Deepan\r\nSindhu Deepan\r\nDeepan Neethimohan";
            var filename = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/testfile.txt";
            var outfile = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/testoutfile.txt";

            NameProcessor nameProcessor = new NameProcessor(filename);

            //Read the names
            String returnvalue = nameProcessor.ReadNamesinFile();

            Assert.AreEqual("", returnvalue);

            if (returnvalue == "")
            {
                //Reverse all names
                nameProcessor.BringLastnametoFront();
                //Sort Ascending
                nameProcessor.SortNames(false);

                returnvalue = nameProcessor.SavetoaNewFile(outfile);

                if (returnvalue != "")
                {
                    Assert.AreEqual("", returnvalue);

                    var result = File.ReadAllLines(outfile);
                    Assert.AreEqual(expected, result);
                }
            }
        }
    }
}
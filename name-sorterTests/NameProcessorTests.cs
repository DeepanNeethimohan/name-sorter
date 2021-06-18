using name_sorter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace name_sorter.Tests
{
    [TestClass()]
    public class NameProcessorTests
    {
        [TestMethod()]
        public void ReadNamesinFileTest()
        {
            var filename = @"./testfile.txt";
            NameProcessor nameProcessor = new NameProcessor(filename);

            //Read the names
            String returnvalue = nameProcessor.ReadNamesinFile();

            Assert.AreEqual(returnvalue, "");
            Assert.AreEqual(nameProcessor.names[0], "Sindhu Deepan");
            Assert.AreEqual(nameProcessor.names[1], "Deepan Neethimohan");
            Assert.AreEqual(nameProcessor.names[2], "Siddhanth Deepan");

        }

        [TestMethod()]
        public void BringLastnametoFrontTest()
        {
            var filename = @"./testfile.txt";
            NameProcessor nameProcessor = new NameProcessor(filename);

            //Read the names
            String returnvalue = nameProcessor.ReadNamesinFile();
            Assert.AreEqual(returnvalue, "");

            if (returnvalue == "")
            {
                //Reverse all names
                nameProcessor.BringLastnametoFront();
                Assert.AreEqual(nameProcessor.allNames[0]._reversedName, "Deepan Sindhu");
                Assert.AreEqual(nameProcessor.allNames[1]._reversedName, "Neethimohan Deepan");
                Assert.AreEqual(nameProcessor.allNames[2]._reversedName, "Deepan Siddhanth");
            }
        }

        [TestMethod()]
        public void SortNamesTest()
        {
            var filename = @"./testfile.txt";
            NameProcessor nameProcessor = new NameProcessor(filename);

            //Read the names
            String returnvalue = nameProcessor.ReadNamesinFile();
            Assert.AreEqual(returnvalue, "");

            if (returnvalue == "")
            {
                //Reverse all names
                nameProcessor.BringLastnametoFront();
                nameProcessor.SortNames(false);
                Assert.AreEqual(nameProcessor.sortedNames[0]._name, "Siddhanth Deepan");
                Assert.AreEqual(nameProcessor.sortedNames[1]._name, "Sindhu Deepan");
                Assert.AreEqual(nameProcessor.sortedNames[2]._name, "Deepan Neethimohan");
            }
        }

        [TestMethod()]
        public void DisplayNamesTest()
        {
            var expected = "Siddhanth Deepan\r\nSindhu Deepan\r\nDeepan Neethimohan";
            var filename = @"./testfile.txt";
            NameProcessor nameProcessor = new NameProcessor(filename);

            //Read the names
            String returnvalue = nameProcessor.ReadNamesinFile();

            Assert.AreEqual(returnvalue, "");

            if (returnvalue == "")
            {
                using (var sw = new StringWriter())
                {
                    Console.SetOut(sw);
                    //Reverse all names
                    nameProcessor.BringLastnametoFront();
                    //Sort Ascending
                    nameProcessor.SortNames(false);
                    //Display Sorted Names
                    nameProcessor.DisplayNames();

                    var result = sw.ToString().Trim();
                    Assert.AreEqual(expected, result);
                }
            }
        }

        [TestMethod()]
        public void SavetoaNewFileTest()
        {
            var expected = "Siddhanth Deepan\r\nSindhu Deepan\r\nDeepan Neethimohan";
            var filename = @"./testfile.txt";
            var outfile = @"./testoutfile.txt";
            NameProcessor nameProcessor = new NameProcessor(filename);

            //Read the names
            String returnvalue = nameProcessor.ReadNamesinFile();

            Assert.AreEqual(returnvalue, "");

            if (returnvalue == "")
            {
                //Reverse all names
                nameProcessor.BringLastnametoFront();
                //Sort Ascending
                nameProcessor.SortNames(false);

                returnvalue = nameProcessor.SavetoaNewFile(outfile);

                if (returnvalue != "")
                {
                    Assert.AreEqual(returnvalue, "");

                    var result = File.ReadAllLines(outfile);
                    Assert.AreEqual(expected, result);
                }
            }
        }
    }
}
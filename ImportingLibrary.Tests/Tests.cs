using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImportingLibrary.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class Tests
    {
        public Tests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestCountComponents()
        {
            var t = new Importer();
            t.DoImport();
            Assert.AreEqual(2, t.AvailableNumberOfOperations);
        }

        [TestMethod]
        public void TestOperations()
        {
            var t = new Importer();
            t.DoImport();

            string initial = "The result string says";
            string expectedResult1 = string.Format("{0} {1}", initial, "MEF is cool");
            string expectedResult2 = initial.ToUpper();

            var result = t.CallAllComponents(initial);
            
            Assert.IsTrue(result.Contains(expectedResult1));
            Assert.IsTrue(result.Contains(expectedResult2));

        }

    }
}
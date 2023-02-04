using System;
using System.Net;


namespace UnitTestProject1
{
    
    public class UnitTest1
    {


        [Fact]
        public void TestMethod1()
        {
            string strSource = "Jenifer";          
            string strActual1 = ConsoleAddressBook.Utility.FixText1(strSource);
            Assert.Equal(strActual1, "Jenifer");
        }

        [Fact]
        public void TestMethod2()
        {
            string strSource = "Richmond";
            string strActual2 = ConsoleAddressBook.Utility.FixText2(strSource);
            Assert.Equal(strActual2, "Richmond");
        }

        [Fact]
        public void TestMethod3()
        {
            string strSource = "NearCity";
            string strActual3 = ConsoleAddressBook.Utility.FixText3(strSource);
            Assert.Equal(strActual3, "NearCity");
        }

        [Fact]
        public void TestMethod4()
        {
            string strSource = "richmond@yahoo.com";
            string strActual4 = ConsoleAddressBook.Utility.FixText4(strSource);
            Assert.Equal(strActual4, "richmond@yahoo.com");

        }

        [Fact]
        public void TestMethod5()
        {
            string strSource = "0123456789";

            string strActual5 = ConsoleAddressBook.Utility.FixText5(strSource);
            Assert.Equal(expected: strActual5, actual: "0123456789");
        }

    }
}
namespace UnitTestProject1
{
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            string strSource = null;
            string firstname = "Jenifer";
            string strActual1 = ConsoleAddressBook.Utility.FixText1(strSource);
            Assert.AreEqual(expected: firstname, actual: strActual1);
        }
        [TestMethod]
        public void TestMethod2()
        {
            string strSource = null;
            string lastname = "Richmond";
            string strActual2 = ConsoleAddressBook.Utility.FixText2(strSource);
            Assert.AreEqual(expected: lastname, actual: strActual2);
        }
        [TestMethod]
        public void TestMethod3()
        {
            string strSource = null;
            string address = "NearCity";
            string strActual3 = ConsoleAddressBook.Utility.FixText3(strSource);
            Assert.AreEqual(expected: address, actual: strActual3);
        }
        [TestMethod]
        public void TestMethod4()
        {
            string strSource = null;
            string email = "richmond@yahoo.com";
            string strActual4 = ConsoleAddressBook.Utility.FixText4(strSource);
            Assert.AreEqual(expected: email, actual: strActual4);

        }
        [TestMethod]
        public void TestMethod5()
        {
            string strSource = null;
            string telephone = "0123456789";
            string strActual5 = ConsoleAddressBook.Utility.FixText5(strSource);
            Assert.AreEqual(expected: telephone, actual: strActual5);
        }

    }
}
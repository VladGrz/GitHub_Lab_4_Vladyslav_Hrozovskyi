using Lab_4_zavd_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Student s = new Student();
            string result = Lab_4_zavd_1.Student.StudentRating(s.rating);
            Assert.AreEqual("Можна вчитися краще!",result);
            s.rating = 65;
            result = Lab_4_zavd_1.Student.StudentRating(s.rating);
            Assert.AreEqual("Варто бiльше уваги придiляти навчанню!", result);
        }
    }
}

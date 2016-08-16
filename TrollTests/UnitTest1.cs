using System.IO.Pipes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.Scripts.Classes.Punters;
using UnityEngine.UI;
namespace TrollTests
{
    [TestClass]
    public class TestPunterFactory
    {
        PunterFactory myFactory = new PunterFactory();
        private Text myText = null;
        private Text myText2 = null;
        [TestMethod]
        public void TestJoe()
        {
            var joe = myFactory.CreatePunter("Joe", myText, myText2);
            Assert.AreEqual(joe.Name, "Joe");
        }
        [TestMethod]
        public void TestBob()
        {
            var bob = myFactory.CreatePunter("Bob", myText, myText2);
            Assert.AreEqual(bob.Name, "Bob");
        }
        [TestMethod]
        public void TestAl()
        {
            var al = myFactory.CreatePunter("Al", myText, myText2);
            Assert.AreEqual(al.Name, "Al");
        }
    }
}

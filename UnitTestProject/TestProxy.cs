using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HeadFirstDesignPattern.Proxy;

namespace UnitTestProject
{
    [TestClass]
    public class TestProxy
    {
        [TestMethod]
        public void TestMethod()
        {
            IClient client = new ProtectionProxy("thePassword");
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine(string.Format("main received Fiist: " + client.GetAccountNo("thePassword")));
            System.Diagnostics.Debug.WriteLine(string.Format("main received Second: " + client.GetAccountNo("thePasword")));
        }
    }
}

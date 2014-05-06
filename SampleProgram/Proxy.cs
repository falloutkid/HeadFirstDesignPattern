using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Proxy
{
    public interface IClient
    {
        string GetAccountNo();
        string GetAccountNo(string pass_word);
    }

    public class RealClient : IClient
    {
        private string accountNo = "12345";
        public RealClient()
        {
            System.Diagnostics.Debug.WriteLine("RealClient: Initialized");
        }
        public string GetAccountNo()
        {
            System.Diagnostics.Debug.WriteLine("RealClient's AccountNo: " + accountNo);
            return accountNo;
        }
        public string GetAccountNo(string pass_word)
        {
            System.Diagnostics.Debug.WriteLine("RealClient's AccountNo: " + accountNo);
            return accountNo;
        }
    }


    public class ProtectionProxy : IClient
    {
        private string password;
        RealClient client;

        public ProtectionProxy(string pwd)
        {
            System.Diagnostics.Debug.WriteLine("ProtectionProxy: Initialized");
            password = pwd;
            client = new RealClient();
        }

        public String GetAccountNo()
        {
            System.Diagnostics.Debug.WriteLine("Password: ");
            string tmpPwd = Console.ReadLine();

            return GetAccountNo(tmpPwd);
        }

        public String GetAccountNo(string pass_word)
        {
            if (pass_word == password)
            {
                return client.GetAccountNo();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("ProtectionProxy: Illegal password!");
                return "";
            }
        }
    }
}


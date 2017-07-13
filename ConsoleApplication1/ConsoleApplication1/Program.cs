using System;
using System.Text;
using System.Xml;
using System.Collections.Generic;

using System.ServiceModel;
namespace Server

{
    public struct chat
    {
       public string number;
       public List<string> message;
    }
    [ServiceContract]
    public interface IMyService
    {
       
        [OperationContract]
       bool AuthenticationMode(string login, string password);

        [OperationContract]
        string readxml(string number);
    }
    
    public class MyService : IMyService
    {
        public bool AuthenticationMode(string login, string password)
        {
            if (login == "Exxpyred@mail.ru")
                if (password == "Qwerty0852")
                    return true;
            return false;
        }

        public string readxml(string number)
        {
            chat ch = new chat();           
                XmlDocument xDoc = new XmlDocument();
            xDoc.Load("C:\\Users\\Денис\\Documents\\Visual Studio 2015\\Projects\\ConsoleApplication1\\ConsoleApplication1\\XMLFile1.xml");
          
            XmlElement xRoot = xDoc.DocumentElement;
            

                if (xRoot.Name=="user")
                {
                foreach (XmlNode xnode in xRoot)
                   
                        {
                            ch.number = xnode.Attributes.GetNamedItem("number").Value;
                            ch.message = new List<string>();
                            foreach (XmlNode n in xnode.ChildNodes)
                                ch.message.Add(n.InnerText);
                        }
                    

                }
            return ch.message[0];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            ServiceHost host = new ServiceHost(typeof(MyService), new Uri("http://localhost:8000/MyService"));
            
            host.AddServiceEndpoint(typeof(IMyService), new BasicHttpBinding(), "");
            
            host.Open();
            Console.WriteLine("the server has started successfully, the expected client connectivity");
            Console.ReadLine();
            
            host.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace WindowsFormsApplication1
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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Uri tcpUri = new Uri("http://localhost:8000/MyService");
            
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
           
            ChannelFactory<IMyService> factory = new ChannelFactory<IMyService>(binding, address);
            
            IMyService service = factory.CreateChannel();
            if (service.AuthenticationMode(textBox1.Text, textBox2.Text))
            {
                richTextBox1.Text = "Аунтефикация пройдена\n";
                string ch=service.readxml("");
                richTextBox1.Text += "пользователь-Zooker";
                richTextBox1.Text += "Сообщение-" + ch;}


            else richTextBox1.Text = "Не верный логин или пароль";

                
            }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}

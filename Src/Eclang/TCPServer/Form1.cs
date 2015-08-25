using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetComm;

namespace TCPServer
{
    using System.IO;
    using System.IO.Compression;

    public partial class Form1 : Form
    {
        Host TCPserver = new Host(8181);


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TCPserver.StartConnection();
            TCPserver.DataReceived += TCPserver_DataReceived; 
            listBox1.Items.Clear();
        }

        void TCPserver_DataReceived(string ID, byte[] Data)
        {
            var sw = new StreamReader(new GZipStream(new MemoryStream(Data), CompressionMode.Compress));
            
            TCPserver.Brodcast(Encoding.ASCII.GetBytes(sw.ReadToEnd()));
        }
    }
}

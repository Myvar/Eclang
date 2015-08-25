using System;
using System.Text;
using System.Windows.Forms;

using EcIDE.Contracts.ServiceProviders;

using NetComm;
using Telerik.WinControls.UI.Docking;

namespace MyvarEcAddin
{
    using System.IO;
    using System.IO.Compression;

    using EcIDE.Addins;

    public class StartUp : EcIDE.Contracts.ICommand
    {
        private WindowService ws;
        public Panel Container = new Panel();
        public Client TCP = new Client();
        public ListBox lb = new ListBox();
        private string id = "";
        private string buffer = "";

        private bool enabled;

        public void Init(ServiceContainer sp)
        {
            var os = sp.GetService<OptionsService>();
            

            if (!os.Contains("myvar_enabled"))
            {
                os.Add("myvar_enabled", true);
                os.Save();
            }
            enabled = os.Get<bool>("myvar_enabled");

            if (enabled)
            {
                ws = sp.GetService<WindowService>();
                TCP.Connect("myvar.tk", 8181, capitalize(Environment.UserName.ToLower().Replace("-pc", "")));
                TCP.DataReceived += TCP_DataReceived;
                id = capitalize(Environment.UserName.ToLower().Replace("-pc", ""));
            }
        }

        void TCP_DataReceived(byte[] Data, string ID)
        {
            if (ASCIIEncoding.ASCII.GetString(Data) != buffer)
            {
                lb.Items.Add(new StreamReader(new GZipStream(new MemoryStream(Data), CompressionMode.Decompress)).ReadToEnd());
            }
            else
            {
                buffer = "";
            }
        }


        private string capitalize(string inpt)
        {
            var ret = "";

            ret += inpt[0].ToString().ToUpper()[0];
            ret += inpt.Remove(0, 1);

            return ret;
        }

        public void OnFormClose()
        {
            if (enabled)
                TCP.Disconnect();
        }

        public void Run()
        {
            if (enabled)
            {
                lb.Dock = DockStyle.Fill;
                Container.Controls.Add(lb);

                var txtbox = new TextBox();
                txtbox.Dock = DockStyle.Bottom;
                Container.Controls.Add(txtbox);

                txtbox.KeyDown += txtbox_KeyDown;

                ComponentStorage.Add("container", ws.AddToolWindow("Developer Chat", DockPosition.Right, Container));
            }
        }

        private void txtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TCP.SendData(ASCIIEncoding.ASCII.GetBytes(id + ": " + (sender as TextBox).Text));
                buffer = id + ": " + (sender as TextBox).Text;
                lb.Items.Add(buffer);
                (sender as TextBox).Text = "";
            }
        }




    }
}

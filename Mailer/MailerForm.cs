using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace Mailer
{
    public partial class MailerForm : Form
    {
        public MailerForm()
        {
            InitializeComponent();
        }

        private void zip()
        {
            using (ZipFile zip = new ZipFile())
            {
                string[] filenames = System.IO.Directory.GetFileSystemEntries(Directory.GetCurrentDirectory());

                progressBar1.Maximum = filenames.Length-2;

                foreach (string file in filenames)
                {
                    

                    if (file.Contains("Mailer") || (file.Contains("Ionic")))
                        continue;

                    progressBar1.Value++;
                    progressBar1.Update();
                    ZipEntry e = zip.AddFile(file, "");
                    listBox1.Items.Add(file.ToString());
                }

                zip.Save("Mailer.zip");
            }
        }

        private void send()
        {
            MailMessage message = new MailMessage("ece7689@upnet.gr", "stefanos990@hotmail.com");
            Attachment data = new Attachment("Mailer.zip");
            message.Attachments.Add(data);
            SmtpClient client = new SmtpClient("patreas.upatras.gr");
            client.Credentials = CredentialCache.DefaultNetworkCredentials;

            client.Send(message);
        }
        private void send_btn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            zip();
            //send();
        }
    }
}

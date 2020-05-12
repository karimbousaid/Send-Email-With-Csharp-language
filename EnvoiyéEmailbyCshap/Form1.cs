using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvoiyéEmailbyCshap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
           
           
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Filettxt.Text = openFileDialog1.FileName.ToString();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage message = new MailMessage();
                message.From = new MailAddress(Emailtxt.Text);
                message.To.Add(EmailSendtxt.Text);
                message.Body = bodytxt.Text;
                message.Subject = Objecttxt.Text;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                if (Filettxt.Text != "")
                {
                    message.Attachments.Add(new Attachment(Filettxt.Text));
                }
                client.Credentials = new System.Net.NetworkCredential(Emailtxt.Text, Passwordtxt.Text);
                client.Send(message);
                MessageBox.Show("Email Send");
                message = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("You have Erreur " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Emailtxt.Clear();
            Passwordtxt.Clear();
            EmailSendtxt.Clear();
            Objecttxt.Clear();
            bodytxt.Clear();
            Filettxt.Clear();
        }

       

       
    }
}

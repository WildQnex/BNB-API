using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace BNB_API
{
    public partial class FormBNB : Form
    {
        public FormBNB()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DataRes data = await Updater.UpdateDataAsync();
            Box.Items.Clear();
            label2.Text = data.getCurTime();
            label4.Text = data.getUpdateTime();
            foreach (string item in data.getCurrenciesList()){
                Box.Items.Add(item);
            }
        }

        private async void timer1_Tick(object sender, EventArgs e){
            DataRes data = await Updater.UpdateDataAsync();
            Box.Items.Clear();
            label2.Text = data.getCurTime();
            label4.Text = data.getUpdateTime();
            foreach (string item in data.getCurrenciesList()){
                Box.Items.Add(item);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            DataRes data = await Updater.UpdateDataAsync();
            Box.Items.Clear();
            label2.Text = data.getCurTime();
            
            MailAddress from = new MailAddress("bsuir.project.adm@gmail.com", "Vadim");
            try
            {
                MailAddress to = new MailAddress(textBox1.Text);
            
                MailMessage m = new MailMessage(from, to);
            
                m.Subject = "Курс Валют";
                foreach (string item in data.getCurrenciesList())
                {
                    m.Body += item + "\n";
                }
            
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("bsuir.project.adm@gmail.com", "Evolato3147");
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(m);
                Box.Items.Add("Письмо отправлено");
            }
            catch
            {
                Box.Items.Add("Некоректынй e-mail");
            }

            }
    }
}

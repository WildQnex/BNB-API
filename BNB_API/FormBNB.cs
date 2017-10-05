using System;
using System.Threading.Tasks;
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
    }
}

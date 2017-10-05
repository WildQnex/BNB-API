using System;
using System.Windows.Forms;

namespace BNB_API
{
    public partial class FormBNB : Form
    {
        public FormBNB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();
            Data data = Updater.UpdateData();
            label2.Text = data.getCurTime();
            label4.Text = data.getUpdateTime();
            foreach (string item in data.getCurrenciesList()){
                Box.Items.Add(item);
            }
        }

       
    }
}

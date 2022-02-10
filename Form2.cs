using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14.HAFTA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void görünümToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void seçeneklerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                webBrowser1.Navigate(toolStripTextBox1.Text);
            }


        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.CanGoBack)
                toolStripButton2.Enabled = false;
            else
                toolStripButton2.Enabled = true;

            if (webBrowser1.CanGoForward)
                toolStripButton3.Enabled = false;
            else
                toolStripButton3.Enabled = true;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {

            if(e.MaximumProgress>0)
            toolStripProgressBar1.Maximum = (int)e.MaximumProgress;

            if (e.CurrentProgress > toolStripProgressBar1.Maximum)
                toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;  //yüklenen progress ayarladığımız max proggresden büyükse onu yazma sadece progressin valuesınu maxa ayarla maxdan fazla değilse maxla 0 arasındaysa diğer işlemi gerçekleştir

            else if (e.CurrentProgress >= 0)
                toolStripProgressBar1.Value = (int)e.CurrentProgress;
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.Text = webBrowser1.Document.Title;
            toolStripStatusLabel1.Text = webBrowser1.Document.Title;
        
            
            toolStripTextBox1.Text = webBrowser1.Url.ToString();

        }
    }
}

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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            

        private void btnOk_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtAdres.Text); //web browser kullanıcının girdiği adresi web browser içinde açsın


        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = (int)e.CurrentProgress; //her sayfa yüklendiğinde bir tık ilerlediğinde hangi seviyede olduğunu curent progress ile aldık

            if (e.CurrentProgress >= 0) //eğer 0da büyük bir değer gelirse toolstripproggresbar değerini mevcut değer olarak ayarla
                toolStripProgressBar1.Maximum = (int)e.MaximumProgress; //bi taraf int bi taraf long olduğundan hata verirdi başına int yazdık

        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
           
           toolStripStatusLabel1.Text = webBrowser1.Document.Title; //document yüklenen sayfanın kaynak kodu
                                                                    //yani yüklenenen sayfanın başlığını al toolstripstatustable'a yaz
                                                                    //bu kodda başlığı labelımızda yazdırdık eğer form yazan yerde yani tepede yaxdırmak istiyorsak

            this.Text = webBrowser1.Document.Title; //bu kodla artık tepede yazıyor ama başka sayfaya geçince label kısmı değişmiyor bunun değişmesi için 
            txtAdres.Text = webBrowser1.Url.ToString(); //artık tepede gittiğimiz sayfanın urlsi gözükecek

        }

        private void txtAdres_KeyPress(object sender, KeyPressEventArgs e)
        {
            //kulanıcının sadece entera bastığı olay lazım
            //keychar kullanıcının bastığı karakter
            //keys olayında bütün tuşlar var 
            //chara döndürmem lazım keys char değer alı

            if(e.KeyChar == (char)Keys.Enter)
            {
                webBrowser1.Navigate(txtAdres.Text); //kullanıcı entere bastığında web browserın navigatini adres olarak tanımla
            }
        }

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome(); //anasayfa butonuna basıldığında web browserın anasayfası ne olarak ayarlandıysa ona gitmeyi sağlar
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh(); //böylece yenileyecek
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //bu olayda geriye gidilebilir durumdaysa geriye gider yoksa buton pasif olmaya devam eder

            if (webBrowser1.CanGoBack) //cangoback olayı ileri gidip gidilmeyecğini gösterir
                btnGeri.Enabled = true;
            else
                btnGeri.Enabled = false;


            if (webBrowser1.CanGoForward) //web browserdaki adres ileri gidebilecek adresse
                btnileri.Enabled = true;
            else
                btnileri.Enabled = false;


            //daha butonlar bi işlem yapmıyor sadece aktiflik ayarladık



        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack(); //geri butonu aktif
        }

        private void btnileri_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward(); //ileri butonu aktif
        }
    }
}
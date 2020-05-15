using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seyr_u_sefer
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSeferKaydet frm = new FrmSeferKaydet();
            
            frm.Show();
            this.Hide();
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmSeferKaydet frm1 = new FrmSeferKaydet();
            frm1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToShortDateString();
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.Transparent;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seyr-ü Sefer bağlı listeler üzerinden geliştirilen otobüs seferleri takibi ve bilet satış uygulamasıdır.", "Hakkımızda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sefer ekleme, sefer silme, sefer listeleme, kaptan güncelleme, sefer geliri hesaplama, bilet rezervasyonu, bilet satışı ve iptali, koltuk bilgilerini görme, programın log kaydını kaydetme ve program verilerini dosya içerisinde saklama hizmetlerimiz arasındadır.","Hizmetlerimiz", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Web Sitesi: example.com"+Environment.NewLine+"Telefon numarası:+90(542)00000000", "İletişim Bilgileri", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)

        {
            FrmOneriSikayet frmgoster = new FrmOneriSikayet();
            frmgoster.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

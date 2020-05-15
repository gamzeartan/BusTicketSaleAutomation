using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace seyr_u_sefer
{
    public partial class FrmSeferKaydet : Form
    {
        public FrmSeferKaydet()
        {
            InitializeComponent();
        }

        public Linkedlist seferler = new Linkedlist();
        public Linkedlist biletler = new Linkedlist();
        public Linkedlist rezerveler = new Linkedlist();

        








        public void sefersayisi()
        {

            textBox4.Text = seferler.Size.ToString();
        }



        private void FrmSeferKaydet_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd, HH:HH";
            label1.Text = DateTime.Now.ToShortDateString();
            LogFile("Program başlatıldı.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);
          
            
            
            groupBox7.Visible = false;



        }

        public void LogFile(string sExceptionName, string sEventName, string sControlName, int nErrorLineNo, string sFormName)
        {
            StreamWriter log;
            if (!File.Exists("logfile.txt"))
            {
                log = new StreamWriter("logfile.txt");
            }
            else
            {
                log = File.AppendText("logfile.txt");
            }
            // Write to the file:
            log.WriteLine("Data Time:" + DateTime.Now+","+ "Exception Name:" + sExceptionName+","+ "Event Name:" + sEventName+","+"Control Name:" + sControlName+","+ "Error Line No.:" + nErrorLineNo+","+ "Form Name:" + sFormName);
          
            // Close the stream:
            log.Close();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmGiris frm1 = new FrmGiris();
            frm1.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int seferno = Convert.ToInt32(textBox1.Text);
                int yolcukapasite = Convert.ToInt32(comboBox2.SelectedItem);

                int biletfiyati = Convert.ToInt32(comboBox3.SelectedItem);
                if (seferler.Head == null)
                {
                    seferler.InsertPos(0, (new sefer { Seferno = seferno, Guzergah = comboBox1.SelectedItem.ToString(), Tarihsaat = dateTimePicker1.Value, Yolcukapasite = yolcukapasite, Plaka = textBox2.Text, Kaptan = textBox3.Text, Biletfiyati = biletfiyati }));
                    MessageBox.Show("sefer eklendi.");
                }
                else
                {
                    bool temp = false;
                    for (int i = 0; i < seferler.Size; i++)
                    {
                        if (seferno == seferler.GetElement(i).Data.Seferno)
                            temp = true;
                    }
                    if (temp == false)
                    {
                        seferler.InsertPos(0, (new sefer { Seferno = seferno, Guzergah = comboBox1.SelectedItem.ToString(), Tarihsaat = dateTimePicker1.Value, Yolcukapasite = yolcukapasite, Plaka = textBox2.Text, Kaptan = textBox3.Text, Biletfiyati = biletfiyati }));
                        MessageBox.Show("Sefer eklendi.");
                    }
                    else if (temp == true)
                        MessageBox.Show("Başka sefer numarası seçiniz.");
                }
                sefersayisi();
                Node current = new Node();
                current = seferler.Head;
                if (current == null)
                    return;

                comboBox4.Items.Clear();
                comboBox6.Items.Clear();
                comboBox9.Items.Clear();
                comboBox8.Items.Clear();

                do
                {

                    sefer m = current.Data;




                    comboBox4.Items.Add(m.Seferno + ". sefer / yolcu kapasitesi:" + m.Yolcukapasite + " Bilet Fiyat:" + m.Biletfiyati);
                    comboBox6.Items.Add("Sefer no: " + m.Seferno + " Yolcu kapasitesi: " + m.Yolcukapasite + " Güzergah: " + m.Guzergah + " Bilet Fiyat: " + m.Biletfiyati);
                    comboBox9.Items.Add( m.Seferno);
                    comboBox8.Items.Add( m.Seferno);
                    if (current.Next == null)

                        break;

                    else
                        current = current.Next;

                } while (true);
                //gecmis seferleri text dosyasına kaydetmek için
              


                GecmisSeferler(seferno.ToString(), comboBox1.SelectedItem.ToString(), dateTimePicker1.Value.ToString(), yolcukapasite.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), biletfiyati.ToString());
            }
            catch(Exception exe)
            {
                LogFile(exe.Message, e.ToString(), ((Control)sender).Name, exe.LineNumber(), this.FindForm().Name);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                int sefernosil = Convert.ToInt32(textBox1.Text);

                bool tempiv = true;


                for (int s = 0; s < biletler.Size; s++)
                {
                    if (biletler.GetElement(s).Data.Seferno == sefernosil)
                    {

                        tempiv = false;
                    }

                }
                if (tempiv == false)
                {
                    LogFile("Bilet alınmış sefer silinmeye çalışıldı.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);
                    MessageBox.Show("Sefere ait bilet bilgisi bulundu iptal edemezsiniz.");
                    
                }

                else if (tempiv == true)
                {

                    bool temp = false;
                    int indis = 0;

                    for (int i = 0; i < seferler.Size; i++)
                    {
                        if (seferler.GetElement(i).Data.Seferno == sefernosil)
                        {
                            indis = i;
                            temp = true;
                        }

                    }
                    if (temp == false)
                        MessageBox.Show("Biletinize ait bilgiler bulunamadi.");
                    else if (temp == true)
                    {
                        seferler.DeletePos(indis);
                        MessageBox.Show("Biletiniz iptal edildi.");
                        comboBox4.Items.Clear();
                        comboBox6.Items.Clear();
                        comboBox9.Items.Clear();
                        comboBox8.Items.Clear();

                        //}
                        sefersayisi();

                    }

                    Node current = new Node();
                    current = seferler.Head;
                    if (current == null)
                        return;


                    comboBox4.Items.Clear();
                    comboBox6.Items.Clear();
                    comboBox9.Items.Clear();
                    comboBox8.Items.Clear();
                    do
                    {

                        sefer m = current.Data;

                        comboBox4.Items.Add(m.Seferno + ". sefer / yolcu kapasitesi:" + m.Yolcukapasite);
                        comboBox9.Items.Add(m.Seferno);
                        comboBox8.Items.Add(m.Seferno);
                        comboBox6.Items.Add("Sefer no: " + m.Seferno + " Yolcu kapasitesi: " + m.Yolcukapasite + " Güzergah: " + m.Guzergah + " Bilet Fiyat: " + m.Biletfiyati);
                        if (current.Next == null)

                            break;

                        else
                            current = current.Next;

                    } while (true);
                    LogFile("Sefer silme işlemi yapıldı.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);
                }
            }
            catch(Exception exe)
            {
                LogFile(exe.Message, e.ToString(), ((Control)sender).Name, exe.LineNumber(), this.FindForm().Name);
            }
        }
           

        

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                int seferguncelle = Convert.ToInt32(textBox5.Text);
                bool temp = false;
                int indis = 0;
                for (int i = 0; i < seferler.Size; i++)
                {
                    if (seferler.GetElement(i).Data.Seferno == seferguncelle)
                    {
                        indis = i;
                        temp = true;

                    }

                }
                if (temp == false) { MessageBox.Show("Girdiğiniz sefere ait bilgiler bulunamadi.");
                    LogFile("Güncellenecek kaptal bilgisi bulunamadı.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);
                }
                else if (temp == true)
                {


                    seferler.GetElement(indis).Data.Kaptan = textBox3.Text;
                    MessageBox.Show("Kaptan güncellendi.");
                }
                LogFile("Kaptan güncelleme işlemi gerçekleştirildi.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);

            }
            catch (Exception exe)
            {
                LogFile(exe.Message, e.ToString(), ((Control)sender).Name, exe.LineNumber(), this.FindForm().Name);
            }
           
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                Node current = new Node();
                current = seferler.Head;
                if (current == null)
                    return;

                listBox1.Items.Clear();


                do
                {

                    sefer m = current.Data;

                    listBox1.Items.Add(
                        "sefer: " + m.Seferno + " " + m.Guzergah + " " + m.Tarihsaat + " Kapasite:"+ m.Yolcukapasite + " Plaka:" + m.Plaka + " Kaptan:" + m.Kaptan + " Fiyat:" + m.Biletfiyati
                        );
                    if (current.Next == null)

                        break;

                    else
                        current = current.Next;

                } while (true);
                LogFile("Seferler listelendi.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);
            }
            catch(Exception exe)
            {
                LogFile(exe.Message, e.ToString(), ((Control)sender).Name, exe.LineNumber(), this.FindForm().Name);
            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button65_Click(object sender, EventArgs e)
        {

            try
            {
                int sefernomusteri = Convert.ToInt32(textBox15.Text);
                int koltukno = Convert.ToInt32(txtKoltukNo.Text);
                int musterino = Convert.ToInt32(textBox10.Text);
                int telefonno = Convert.ToInt32(textBox8.Text);
                int biletinkapasitesi = Convert.ToInt32(textBox14.Text);
                int biletfiyat = Convert.ToInt32(textBox17.Text);

                bool tempyeni = false;

                for (int x = 0; x < rezerveler.Size; x++)
                {

                    if (sefernomusteri == rezerveler.GetElement(x).Data.Seferno && koltukno == rezerveler.GetElement(x).Data.KoltukNo)
                    {
                        tempyeni = true;
                    }
                }
                if (tempyeni == false)
                {
                    if (biletler.Head == null)
                    {
                        bool tempy = false;

                        for (int f = 0; f < rezerveler.Size; f++)
                        {
                            if (sefernomusteri == rezerveler.GetElement(f).Data.Seferno && koltukno == rezerveler.GetElement(f).Data.KoltukNo)
                            {
                                tempy = true;
                            }
                        }
                        if (tempy == false)
                        {
                            biletler.InsertPos(0, (new sefer { Seferno = sefernomusteri, MusteriAd = txtAd.Text, KoltukNo = koltukno, Cinsiyet = textBox7.Text, TelefonNo = telefonno, MusteriNo = musterino, BiletalKapasite = biletinkapasitesi, Biletfiyati = biletfiyat }));
                            MessageBox.Show("Bilet alındı.");
                           
                        }

                        else if (tempy == true) MessageBox.Show("Başka koltuk numarası seçiniz. Bu koltuk rezervedir.");
                         
                    }

                    else
                    {
                        bool temp = false;
                        for (int i = 0; i < biletler.Size; i++)
                        {

                            if (sefernomusteri == biletler.GetElement(i).Data.Seferno && koltukno == biletler.GetElement(i).Data.KoltukNo)
                                temp = true;

                        }

                        if (temp == false)
                        {
                            biletler.InsertPos(0, (new sefer { Seferno = sefernomusteri, MusteriAd = txtAd.Text, KoltukNo = koltukno, Cinsiyet = textBox7.Text, TelefonNo = telefonno, MusteriNo = musterino, Biletfiyati = biletfiyat }));
                            MessageBox.Show("Bilet alındı.");
                           
                        }
                        else if (temp == true)   MessageBox.Show("Başka koltuk numarası seçiniz. Bu koltuk rezervedir.");
              
                    }
                }
                else if (tempyeni == true)
                {
                    MessageBox.Show("Başka koltuk numarası seçiniz. Bu koltuk rezervedir.");
                   
                }
                LogFile("Bilet satın alma işlemi gerçekleştirildi.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);
            }
            catch (Exception exe)
            {

                LogFile(exe.Message, e.ToString(), ((Control)sender).Name, exe.LineNumber(), this.FindForm().Name);
            }
           


        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.DarkOrange)
            {
                if (textBox14.Text == "")
                {
                    MessageBox.Show("Sefer kapasite değeri giriniz.");
                }

                else if (Convert.ToInt32(((Button)sender).Text) > Convert.ToInt32(textBox14.Text))
                {
                    LogFile("Sefer kapasitesini aşan koltuk numarası seçildi.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);
                    MessageBox.Show("Seferin kapasite değerini aştınız uygun bir değer giriniz.");
                    txtKoltukNo.Clear();

                }
                else
                    txtKoltukNo.Text = ((Button)sender).Text;
            }
        }



        private void btnKoltukListesi_Click(object sender, EventArgs e)
        {
            try
            {
                int sefernoall = Convert.ToInt32(comboBox9.SelectedItem);
                string bos = "";
                string dolu = ""; int sayac = 0; int saydik = 0;

                for (int i = 1; i <= 60; i++)
                {
                    bool temp = false;
                    for (int j = 0; j < biletler.Size; j++)
                    {
                        if (sefernoall == biletler.GetElement(j).Data.Seferno && biletler.GetElement(j).Data.KoltukNo == i)
                        {

                            dolu += i.ToString() + Environment.NewLine;

                            temp = true;

                            sayac++;
                        }
                        saydik = (biletler.GetElement(j).Data.Biletfiyati) * sayac;
                    }
                    if (temp == false)
                        bos += i.ToString() + Environment.NewLine;


                }

                textBox16.Text = saydik.ToString();
                textBox12.Text = dolu;
                textBox13.Text = bos;


                listBox2.Items.Clear();
                for (int x = 0; x < rezerveler.Size; x++)
                {

                    if (sefernoall == rezerveler.GetElement(x).Data.Seferno)
                    {

                        listBox2.Items.Add("Rezerve Koltuk No: " + rezerveler.GetElement(x).Data.KoltukNo + " Ad Soyad: " + rezerveler.GetElement(x).Data.MusteriAd);

                    }


                }


                LogFile("Sefer koltuk bilgisi gösterilip sefer geliri hesaplandı.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);
            }
            catch (Exception exe)
            {
                LogFile(exe.Message, e.ToString(), ((Control)sender).Name, exe.LineNumber(), this.FindForm().Name);
            }
           

        }


        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox17.Text = comboBox4.Text.Remove(0, 43);
            textBox15.Text = comboBox4.Text.Remove(1);
            textBox14.Text = (comboBox4.Text.Remove(0, 28)).Remove(2);

        }

        private void button66_Click(object sender, EventArgs e)
        {
            try
            {
                int sefernomusterirezerve = Convert.ToInt32(textBox18.Text);
                // int sefernomusteri = Convert.ToInt32(textBox9.Text);
                int koltuknorezerve = Convert.ToInt32(textBox6.Text);
                int kapasiterezerve = Convert.ToInt32(textBox21.Text);
                int fiyatrezerve = Convert.ToInt32(textBox22.Text);


                if (rezerveler.Head == null)
                {
                    rezerveler.InsertPos(0, (new sefer { Seferno = sefernomusterirezerve, MusteriAd = textBox23.Text, KoltukNo = koltuknorezerve, Cinsiyet = "", TelefonNo = 0, MusteriNo = 0, BiletalKapasite = kapasiterezerve, Biletfiyati = fiyatrezerve }));
                    MessageBox.Show("Bilet Rezerve Edildi.");
                    LogFile("Bilet rezerve etme işlemi gerçekleştirildi.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);
                }
                else
                {
                    bool temp = false;
                    for (int i = 0; i < biletler.Size; i++)
                    {

                        if (sefernomusterirezerve == biletler.GetElement(i).Data.Seferno && koltuknorezerve == biletler.GetElement(i).Data.KoltukNo)
                            temp = true;

                    }

                    if (temp == false)
                    {
                        rezerveler.InsertPos(0, (new sefer { Seferno = sefernomusterirezerve, MusteriAd = textBox23.Text, KoltukNo = koltuknorezerve, Cinsiyet = "", TelefonNo = 0, MusteriNo = 0, BiletalKapasite = kapasiterezerve, Biletfiyati = fiyatrezerve }));
                        MessageBox.Show("Bilet Rezerve Edildi.");
                        LogFile("Bilet rezerve etme işlemi gerçekleştirildi.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);
                    }
                    else if (temp == true)
                  
                        MessageBox.Show("Dolu Koltuğu Rezerve Edemezsiniz!");
                        

                    }

                Node current = new Node();
                current = rezerveler.Head;
                if (current == null)
                    return;

                comboBox5.Items.Clear();

                comboBox7.Items.Clear();
                do
                {

                    sefer m = current.Data;




                    comboBox5.Items.Add("Sefer:" + m.Seferno + " Koltuk No: " + m.KoltukNo + " Ad Soyad: " + m.MusteriAd + " Kapasite: " + m.BiletalKapasite + " Bilet Fiyatı: " + m.Biletfiyati);

                    comboBox7.Items.Add("Sefer:" + m.Seferno + " Koltuk No: " + m.KoltukNo + " Ad Soyad: " + m.MusteriAd);

                    if (current.Next == null)

                        break;

                    else
                        current = current.Next;

                } while (true);
            }
            catch (Exception exe)
            {
                LogFile(exe.Message, e.ToString(), ((Control)sender).Name, exe.LineNumber(), this.FindForm().Name);

            }
            




        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            try
            {
                int rezerveiptalno = Convert.ToInt32(textBox18.Text);
                int rezerveiptalkoltukno = Convert.ToInt32(textBox6.Text);
                bool temp = false;
                int indis = 0;
                for (int i = 0; i < rezerveler.Size; i++)
                {
                    if (rezerveiptalno == rezerveler.GetElement(i).Data.Seferno && rezerveler.GetElement(i).Data.KoltukNo == rezerveiptalkoltukno)
                    {
                        indis = i;
                        temp = true;
                    }

                }
                if (temp == false)
                {
                    MessageBox.Show("Bu bilgilere ait rezerve bilet bulunmamaktadır.");
                    LogFile("Bu bilgilere ait rezerve bilet olmadığı için iptal işlemi gerçekleştirilemedi.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);
                }
                else if (temp == true)
                {
                    rezerveler.DeletePos(indis);
                    MessageBox.Show("Rezerve biletiniz iptal edildi.");
                    LogFile("Rezerve bilet iptal edildi.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);
                    comboBox5.Items.Clear();
                    comboBox7.Items.Clear();

                }

                Node current = new Node();
                current = rezerveler.Head;
                if (current == null)
                    return;

                comboBox5.Items.Clear();
                comboBox5.Refresh();

                comboBox7.Items.Clear();

                do
                {

                    sefer m = current.Data;




                    comboBox5.Items.Add("Sefer:" + m.Seferno + " Koltuk No" + m.KoltukNo);
                    comboBox7.Items.Add("Sefer:" + m.Seferno + " Koltuk No" + m.KoltukNo + "Ad Soyad: " + m.MusteriAd);
                    if (current.Next == null)

                        break;

                    else
                        current = current.Next;

                } while (true);


            }
            catch (Exception exe)
            {

                LogFile(exe.Message, e.ToString(), ((Control)sender).Name, exe.LineNumber(), this.FindForm().Name);
            }

           

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_MouseClick(object sender, MouseEventArgs e)
        {

        }


        //bilet iptal
        private void button51_Click(object sender, EventArgs e)
        {


            int biletiptalseferno = Convert.ToInt32(textBox19.Text);
            int biletiptalkoltukno = Convert.ToInt32(textBox20.Text);

            bool tempyeniss = true;



            if (rezerveler.Size == 0)
            {
                tempyeniss = false;
            }

            if (tempyeniss == false)
            {

                bool temp = false;
                int indis = 0;
                for (int i = 0; i < biletler.Size; i++)
                {
                    if (biletiptalseferno == biletler.GetElement(i).Data.Seferno && biletler.GetElement(i).Data.KoltukNo == biletiptalkoltukno)
                    {
                        indis = i;
                        temp = true;
                    }

                }
                if (temp == false)
                    MessageBox.Show("girilen bilete ait bilgiler bulunamadi.");
                else if (temp == true)
                {
                    biletler.DeletePos(indis);
                    MessageBox.Show(" Biletiniz iptal edildi.");


                }


            }

            else if (rezerveler.Head != null)
            {

                bool tempyenis = false;

                for (int x = 0; x < biletler.Size; x++)
                {

                    if (biletiptalseferno == rezerveler.GetElement(x).Data.Seferno && biletiptalkoltukno == rezerveler.GetElement(x).Data.KoltukNo)
                    {
                        tempyenis = true;
                    }
                }
                if (tempyenis == false)
                {

                    bool temp = false;
                    int indis = 0;
                    for (int i = 0; i < biletler.Size; i++)
                    {
                        if (biletiptalseferno == biletler.GetElement(i).Data.Seferno && biletler.GetElement(i).Data.KoltukNo == biletiptalkoltukno)
                        {
                            indis = i;
                            temp = true;
                        }

                    }
                    if (temp == false)
                        MessageBox.Show("girilen bilete ait bilgiler bulunamadi.");
                    else if (temp == true)
                    {
                        biletler.DeletePos(indis);
                        MessageBox.Show(" Biletiniz iptal edildi.");


                    }

                }


                else if (tempyenis == true)
                    MessageBox.Show("rezerve edilen bilet işlemlerini rezerve işlemleri bölümünden  yapınız.");



            }

            LogFile("Bilet silme işlemi gerçekleştirildi.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button52_Click(object sender, EventArgs e)
        {
            try
            {
                int biletiptalseferno = Convert.ToInt32(textBox15.Text);
                int biletiptalkoltukno = Convert.ToInt32(txtKoltukNo.Text);



                int sefernomusteri = Convert.ToInt32(textBox15.Text);
                // int sefernomusteri = Convert.ToInt32(textBox9.Text);
                int koltukno = Convert.ToInt32(txtKoltukNo.Text);
                int musterino = Convert.ToInt32(textBox10.Text);
                int telefonno = Convert.ToInt32(textBox8.Text);
                int biletinkapasitesi = Convert.ToInt32(textBox14.Text);
                int biletfiyat = Convert.ToInt32(textBox17.Text);


                bool tempmm = false;
                int indis = 0;

                for (int i = 0; i < rezerveler.Size; i++)
                {
                    if (biletiptalseferno == rezerveler.GetElement(i).Data.Seferno && biletiptalkoltukno == rezerveler.GetElement(i).Data.KoltukNo)
                    {
                        indis = i;
                        tempmm = true;
                    }

                }
                if (tempmm == false)
                
                    MessageBox.Show("Biletinize ait bilgiler bulunamadi.");
                   
                
                else if (tempmm == true)
                {
                    rezerveler.DeletePos(indis);

                    comboBox5.Items.Clear();


                    comboBox7.Items.Clear();
                }


                if (biletler.Head == null)
                {
                    biletler.InsertPos(0, (new sefer { Seferno = sefernomusteri, MusteriAd = txtAd.Text, KoltukNo = koltukno, Cinsiyet = textBox7.Text, TelefonNo = telefonno, MusteriNo = musterino, BiletalKapasite = biletinkapasitesi, Biletfiyati = biletfiyat }));
                    MessageBox.Show("Bilet alındı.");
                    

                }
                else
                {
                    bool temp = false;
                    for (int i = 0; i < biletler.Size; i++)
                    {

                        if (sefernomusteri == biletler.GetElement(i).Data.Seferno && koltukno == biletler.GetElement(i).Data.KoltukNo)
                            temp = true;

                    }

                    if (temp == false)
                    {
                        biletler.InsertPos(0, (new sefer { Seferno = sefernomusteri, MusteriAd = txtAd.Text, KoltukNo = koltukno, Cinsiyet = textBox7.Text, TelefonNo = telefonno, MusteriNo = musterino, Biletfiyati = biletfiyat }));
                        MessageBox.Show("Bilet alındı.");
                       

                    }
                    else if (temp == true)
                        MessageBox.Show("Başka koltuk numarası seçiniz.");
                

                }


                Node current = new Node();
                current = rezerveler.Head;
                if (current == null)
                    return;

                comboBox5.Items.Clear();
                comboBox5.Refresh();

                comboBox7.Items.Clear();

                do
                {

                    sefer m = current.Data;




                    comboBox5.Items.Add("Sefer:" + m.Seferno + " Koltuk No" + m.KoltukNo);
                    comboBox7.Items.Add("Sefer:" + m.Seferno + " Koltuk No" + m.KoltukNo + "Ad Soyad: " + m.MusteriAd);
                    if (current.Next == null)

                        break;

                    else
                        current = current.Next;

                } while (true);
                LogFile("Rezerve bilet satın alındı.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);

            }
            catch (Exception exe)
            {
                LogFile(exe.Message, e.ToString(), ((Control)sender).Name, exe.LineNumber(), this.FindForm().Name);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LogFile("Program kapatıldı.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGiris formuGoster = new FrmGiris();
            this.Hide();
            formuGoster.Show();
        }
        public void GecmisSeferler(string sfrno, string gzrgh, string trh, string kpste, string plk, string kptn, string fyt)
        {
            StreamWriter sefer;
            if (!File.Exists("GecmisSefer.txt"))
            {
                sefer = new StreamWriter("GecmisSefer.txt");
            }
            else
            {
                sefer = File.AppendText("GecmisSefer.txt");
            }
            // Write to the file:
            sefer.WriteLine("Sefer no::" + sfrno+","+ "Güzergah:" + gzrgh+ "," + "Tarih:" + trh+ "," + "Kapasite:" + kpste+ "," +"\nPlaka:" + plk+ "," + "Kaptan:" + kptn+ "," + "Bilet fiyatı:" + fyt);
       
            sefer.WriteLine("---");

            
            sefer.Close();
        }
        private void button53_Click(object sender, EventArgs e)
        {
            try
            {
                listBox3.Items.Clear();
                StreamReader oku;
                oku = File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "\\GecmisSefer.txt");
                string yazi;
                while ((yazi = oku.ReadLine()) != null) 
                {
                    listBox3.Items.Add(yazi.ToString());
                }
                oku.Close();//okumayı kapat
                LogFile("Geçmiş seferleri listeleme işlemi yapıldı.", e.ToString(), ((Control)sender).Name, 0, this.FindForm().Name);
            }
            catch (Exception exe)
            {

                LogFile(exe.Message, e.ToString(), ((Control)sender).Name, exe.LineNumber(), this.FindForm().Name);
            }
        }
          
        

        private void FrmSeferKaydet_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void button54_Click(object sender, EventArgs e)
        {
            int sefernoyagörebilgi = Convert.ToInt32(comboBox8.SelectedItem);
            int indis = 0;

            bool temp = true;
            for (int i = 0; i < seferler.Size; i++)
            {

                if (sefernoyagörebilgi == seferler.GetElement(i).Data.Seferno)
                    // indis = i;
                    listBox4.Items.Add("SEFER BİLGİLERİ--->  Sefer No: " + seferler.GetElement(i).Data.Seferno + " Güzergah: " + seferler.GetElement(i).Data.Guzergah + " Kaptan: " + seferler.GetElement(i).Data.Kaptan + " Plaka: " + seferler.GetElement(i).Data.Plaka + " Kapasite: " + seferler.GetElement(i).Data.Yolcukapasite + " Bilet Fiyatı: " + seferler.GetElement(i).Data.Biletfiyati + " Tarih/Saat: " + seferler.GetElement(i).Data.Tarihsaat);
                temp = false;
                // break;
            }

            if (temp == false)
            {
                int sayi = 0;
                int d = 0;

                for (int i = 0; i < biletler.Size; i++)
                {

                    if (sefernoyagörebilgi == biletler.GetElement(i).Data.Seferno)
                    {
                        d = i;
                        listBox4.Items.Add("Dolu Koltuk No: " + biletler.GetElement(i).Data.KoltukNo + " Ad Soyad: " + biletler.GetElement(i).Data.MusteriAd);
                        sayi++;
                    }



                }
                for (int x = 0; x < rezerveler.Size; x++)
                {

                    if (sefernoyagörebilgi == rezerveler.GetElement(x).Data.Seferno)
                    {

                        listBox4.Items.Add("Rezerve Koltuk No: " + rezerveler.GetElement(x).Data.KoltukNo + " Ad Soyad: " + rezerveler.GetElement(x).Data.MusteriAd);

                    }

                }
                indis = (biletler.GetElement(d).Data.Biletfiyati) * sayi;
                listBox4.Items.Add("Sefer Gelir: " + indis);
            }


       

            string tarih = label1.Text;

            String[] listboxDizi = new String[listBox4.Items.Count];

            listBox4.Items.CopyTo(listboxDizi, 0);
            if (!File.Exists(tarih + ".txt"))
            {
                System.IO.File.WriteAllLines(tarih + ".txt", listboxDizi);
            }
            else
            {
                System.IO.File.WriteAllLines(tarih + ".txt", listboxDizi);

               
            }
            return;
        }

        private void button55_Click(object sender, EventArgs e)
        {
          
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox7.Visible = true;

        }

        private void button56_Click(object sender, EventArgs e)
        {
            groupBox7.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = true;
          
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}





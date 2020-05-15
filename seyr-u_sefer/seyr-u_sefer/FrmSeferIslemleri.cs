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
    public partial class FrmSeferIslemleri : Form
    {
        public FrmSeferIslemleri()
        {
            InitializeComponent();
        }

        public Linkedlist seferler = new Linkedlist();


        


        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void FrmSeferIslemleri_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd, HH:HH";

           
        }

        public void sefersayisi()
        {

            textBox4.Text = seferler.Size.ToString();
        }
       

        private void button2_Click_1(object sender, EventArgs e)
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
                    MessageBox.Show("sefer ekledendi.");
                }
                else if (temp == true)
                    MessageBox.Show("başka sefer no seçiniz.");
            }
            sefersayisi();


        }

        private void button5_Click(object sender, EventArgs e)
        {

            int sefernosil = Convert.ToInt32(textBox1.Text);
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
            }
            sefersayisi();
        }

        private void button4_Click(object sender, EventArgs e)
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
            if (temp == false)
                MessageBox.Show("Biletinize ait bilgiler bulunamadi.");
            else if (temp == true)
            {
         
               
                seferler.GetElement(indis).Data.Kaptan = textBox3.Text;
                MessageBox.Show("Biletiniz güncellendi.");
            }
           

        }

      

        private void button7_Click(object sender, EventArgs e)
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
                    "sefer: " + m.Seferno + " " + m.Guzergah + " " + m.Tarihsaat + " " + m.Guzergah + " " + m.Yolcukapasite + " " + m.Plaka + " " + m.Kaptan + " " + m.Biletfiyati
                );
                if (current.Next == null)
                 
                break;

                else
                    current = current.Next; 

            } while (true);
        }
    }

    
    }


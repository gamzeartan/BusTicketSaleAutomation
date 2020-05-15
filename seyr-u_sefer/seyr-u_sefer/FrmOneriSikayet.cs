using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace seyr_u_sefer
{
    public partial class FrmOneriSikayet : Form
    {
        public FrmOneriSikayet()
        {
            InitializeComponent();
        }

        private void FrmOneriSikayet_Load(object sender, EventArgs e)
        {
            string msg = "https://forms.gle/QnxKnv6NZEfbfQnGA";
          
            linkLabel1.Text = msg;
        }

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
                var linkLabel = (LinkLabel)sender;
                var path = linkLabel.Text;
                try
                {
                    await Task.Run(() => Process.Start($@"{path}"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"An Error Has Occurred");
                }

            
        }
    }
}

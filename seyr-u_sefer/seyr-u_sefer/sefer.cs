using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seyr_u_sefer
{
    public class sefer
    {
        public int Seferno { get; set; }
        public string Guzergah { get; set; }
        public DateTime Tarihsaat { get; set; }
        public int Yolcukapasite { get; set; }
        public string Plaka { get; set; }
        public string Kaptan { get; set; }
        public int Biletfiyati { get; set; }

        public int MusteriNo { get; set; }

        public string MusteriAd { get; set; }

        public int KoltukNo { get; set; }

        public string Cinsiyet { get; set; }

        public int TelefonNo { get; set; }
        public int BiletalKapasite { get; set; }


        //koltuk durum bilgisi için
        public string Bos { get; set; }

        public string Dolu { get; set; }


        public string Rezerve { get; set; }



        

    }
}

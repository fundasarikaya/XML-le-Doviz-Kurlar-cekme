using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml;

namespace XML_İle_Döviz_Kurlarını_Çekme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bugun = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();

            string eskigun = "http://www.tcmb.gov.tr/kurlar/201501/15012015.xml";

            //xmldoc.Load(eskigun); dersek o gunku degerleri gosterir.
            xmldoc.Load(bugun);
            DateTime tarih =Convert.ToDateTime(xmldoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);//bu kısım interet sayfasının kaynagında alınarak yazılıyor
            
            string USD = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/BanknoteSelling").InnerXml;
            label1.Text = string.Format("Tarih {0} USD; {1}", tarih.ToShortDateString(), USD);

            string EURO = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='EUR']/BanknoteSelling").InnerXml;
            label2.Text = string.Format("Tarih {0} EURO; {1}", tarih.ToShortDateString(), EURO);
        }
        /*
         * XML: İNTERNETİ KULLANARAK VERİ ALIŞVERİŞİ 
         * YAPAN SİSTEMLER VE PLATFORMLAR ARASINDAKİ 
         * VERİ İLETİŞİMİNİ STANDARTHALE GETİRMEK İÇİN 
         * TASARLANAN İŞARETLEME DİLİ
         */
    }
}

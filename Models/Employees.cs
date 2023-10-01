using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAPtest_Desktop.Models
{
    internal class Employees
    {
        public int CalisanlarID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int PozisyonID { get; set; }
        public DateTime BaslangıcTarih { get; set; }
        public int Maas { get; set; }
        public string Adres { get; set; }
        public string Iletisim { get; set; }
        public bool Cinsiyet { get; set; }
        public string username { get; set; }
    }
}

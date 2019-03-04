using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OgrenciContext _db;
        private void Form1_Load(object sender, EventArgs e)
        {
            _db = new OgrenciContext();
            lstOgrenci.DataSource = _db.Ogrenciler.ToList();
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Ogrenci o = new Ogrenci();
            o.Ad = txtAd.Text;
            o.Soyad = txtSoyad.Text;
            o.Tc = Convert.ToInt32(txtTc.Text);
            o.Mail = txtMail.Text;
            o.DogumTarihi = DateTime.Parse(dtDogumTrh.Text);
            o.Yas = Convert.ToInt32(txtYas.Text);
            o.KayitTarihi = DateTime.Parse(dtKayitTrh.Text);
            _db.Ogrenciler.Add(o);
            _db.SaveChanges();

            lstOgrenci.DataSource = _db.Ogrenciler.ToList();
        }

        void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtTc.Clear();
            txtMail.Clear();
            txtYas.Clear();
        }

        private void dtDogumTrh_ValueChanged(object sender, EventArgs e)
        {
            int yas;
            DateTime dogumtar;
            dogumtar = Convert.ToDateTime(dtDogumTrh.Text);
            yas = DateTime.Now.Year - dogumtar.Year;
            txtYas.Text = yas.ToString();

        }
    }
}

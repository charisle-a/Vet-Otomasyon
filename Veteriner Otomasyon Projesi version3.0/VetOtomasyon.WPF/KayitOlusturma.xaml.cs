using DatabaseAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VetOtomasyon.WPF
{
    /// <summary>
    /// KayitOlusturma.xaml etkileşim mantığı
    /// </summary>
    public partial class KayitOlusturma : Window
    {
        public KayitOlusturma()
        {
            InitializeComponent();
        }

		private void btnKaydetClick(object sender, RoutedEventArgs e)
		{
            try
			{
 if(txtad.Text==""||txtSoyad.Text==""||txttc.Text==""||txttelno.Text=="")
			{
                MessageBox.Show("Boş Bırakılan Yerleri Doldurunuz.");
			}
            else
			{
Musteri musteri = new Musteri();
            musteri.Ad = txtad.Text;
            musteri.Soyad = txtSoyad.Text;
            musteri.TCNO = txttc.Text;
            musteri.TelNo = txttelno.Text;
            using (UnitOfWork unitOf = new UnitOfWork())
            {
                unitOf.MusteriWork.Add(musteri);
                unitOf.Save();
                MessageBox.Show("Müşteri Başarıyla Eklendi.");
            }
			}
			}
            catch(Exception)
			{
                MessageBox.Show("Bu TC ye sahip bir kayıt var.");
			}
           
            
        }
	}
}

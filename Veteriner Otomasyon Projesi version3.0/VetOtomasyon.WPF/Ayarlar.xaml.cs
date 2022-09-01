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
    /// Ayarlar.xaml etkileşim mantığı
    /// </summary>
    public partial class Ayarlar : Window
    {
        public Ayarlar()
        {
            InitializeComponent();
        }

		private void btnKullaniciClick(object sender, RoutedEventArgs e)
		{
            KullaniciAyarlar kullanici = new KullaniciAyarlar();
            kullanici.Show();this.Close();
		}

		private void btnDoktorClick(object sender, RoutedEventArgs e)
		{
            DoktorAyarlar doktor = new DoktorAyarlar();
            doktor.Show();this.Close();
		}
	}
}

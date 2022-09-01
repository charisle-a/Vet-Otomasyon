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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VetOtomasyon.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{

			InitializeComponent();
			datagridyenile();

		}

		private void btnAyar_Click(object sender, RoutedEventArgs e)
		{
			Ayarlar formayar = new Ayarlar();
			formayar.Show();
		}

		private void btnRandevuKabul_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				randevuShow randevu = (randevuShow)datagridview1.SelectedItems[0];

				using (UnitOfWork unitOf = new UnitOfWork())
				{
					foreach (var item in unitOf.randevuWork.GetAll().ToList())
						if (item.Id == randevu.Id)
						{
							item.Durum = "Kabul Edildi";
							unitOf.randevuWork.Update(item);
						}


					unitOf.Save();
					MessageBox.Show("Kabul Edildi");
				}
				datagridyenile();
			}
			catch (Exception)
			{
				MessageBox.Show("Seçilen bir kayıt yok");
			}
		}

		private void btnRandevuIptal(object sender, RoutedEventArgs e)
		{
			try
			{
				randevuShow randevu = (randevuShow)datagridview1.SelectedItems[0];

				using (UnitOfWork unitOf = new UnitOfWork())
				{
					foreach (var item in unitOf.randevuWork.GetAll().ToList())
						if (item.Id == randevu.Id)
						{
							item.Durum = "İptal Edildi";
							unitOf.randevuWork.Update(item);
						}


					unitOf.Save();
					MessageBox.Show("İptal edildi");
				}
				datagridyenile();
			}
			catch(Exception)
			{
				MessageBox.Show("Seçilen bir kayıt yok");
			}
		}

		private void btnRandevular_Click(object sender, RoutedEventArgs e)
		{
			Randevular formRandevular = new Randevular();
			formRandevular.Show();
		}

		private void btnYeni_Click(object sender, RoutedEventArgs e)
		{
			KayitOlusturma formkayit = new KayitOlusturma();
			formkayit.Show();
		}

		private void btnRandevu_Click(object sender, RoutedEventArgs e)
		{
			RandevuOlusturma formrandevuOlustur = new RandevuOlusturma();
			formrandevuOlustur.Show();
		}

		private void btnKayıtlar_Click(object sender, RoutedEventArgs e)
		{
			Kayıtlar kayıtlar = new Kayıtlar();
			kayıtlar.Show();
		}
		public void datagridyenile()
		{ 
			randevuShow rndshow = new randevuShow();
			using (UnitOfWork unitOf = new UnitOfWork())
			{
				List<randevuShow> randevular = new List<randevuShow>();
				foreach(var item in unitOf.randevuWork.GetAll())
				{

					if(item.Tarih==DateTime.Now.Date&&item.Durum=="Aktif")
					{
						rndshow.Id = item.Id;
						rndshow.Açıklama = item.Açıklama;
						rndshow.Durum = item.Durum;
						rndshow.SahipTC = item.MusteriTC;
						rndshow.tarih = item.Tarih.Date.ToString();
						foreach(var doktor in unitOf.doktorWork.GetAll().ToList())
						{
							if(item.DoktorId==doktor.Id)
							{
								rndshow.Doktor_AdSoyad = doktor.Ad + " " + doktor.Soyad;
							}
						}
						foreach(var musteri in unitOf.MusteriWork.GetAll().ToList())
						{
							if(item.MusteriTC==musteri.TCNO)
							{
								rndshow.Sahip_isim = musteri.Ad + " " + musteri.Soyad;
							}
						}
						randevular.Add(rndshow);
					}
				}
				datagridview1.ItemsSource = randevular;
			}
			
		}
		private void btnYenile_click(object sender, RoutedEventArgs e)
		{
			datagridyenile();
		}
	}
}

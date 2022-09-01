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
	/// RandevuOlusturma.xaml etkileşim mantığı
	/// </summary>
	public partial class RandevuOlusturma : Window
	{List<Doktorlar> doktorlars = new List<Doktorlar>();
		public RandevuOlusturma()
		{
			
			InitializeComponent();
			using (UnitOfWork unitOf = new UnitOfWork())
			{
				foreach(var item in unitOf.doktorWork.GetAll().ToList())
				{
					combobox1.Items.Add(item.Ad + " " + item.Soyad);
					doktorlars.Add(item);
				}
			}
		}

		private void btnKaydetClick(object sender, RoutedEventArgs e)
		{
			bool kayıt = false;
			try
			{
EntityLayer.Randevular randevu = new EntityLayer.Randevular();
			foreach(var item in doktorlars)
			{
				if(combobox1.SelectedItem.ToString()==(item.Ad+" "+item.Soyad))
				{
					randevu.DoktorId = item.Id;
				}
			}
			randevu.MusteriTC = txtUsername.Text;
			
			randevu.Tarih = datetimepicker1.SelectedDate.Value.Date;
			randevu.Açıklama = txtUsername_Copy.Text;
			randevu.Durum = "Aktif";
			using (UnitOfWork unitOf = new UnitOfWork())
			{
				foreach(var item in unitOf.MusteriWork.GetAll().ToList())
				{
					if (randevu.MusteriTC == item.TCNO)
					{
							kayıt = true;
							RandevuOlustur(randevu);
					}
					
						
				}
				if(kayıt==false)
					if (MessageBox.Show("Bu TCNo kullanılmıyor. Kayıt oluşturmak ister misiniz?", "Kayıt oluşturma", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
					{
						KayitOlusturma kyt = new KayitOlusturma();
						kyt.Show();
						this.Close();
					}



				}
			}
			catch (Exception)
			{

				MessageBox.Show("Boş bırakılan yerleri doldurunuz.");
			}
			

		}
		public void RandevuOlustur(EntityLayer.Randevular randevu)
		{
			using (UnitOfWork unitOf = new UnitOfWork())
			{
			if (MessageBox.Show("Randevu Oluşturulsun mu?", "?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
				unitOf.randevuWork.Add(randevu);
				unitOf.Save();
				MessageBox.Show("Randevu Başarıyla Oluşturuldu");

			}

			}
				
		}
	}
}

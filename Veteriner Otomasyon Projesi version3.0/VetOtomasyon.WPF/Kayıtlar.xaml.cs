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
	/// Interaction logic for Kayıtlar.xaml
	/// </summary>
	public partial class Kayıtlar : Window
	{
		public Kayıtlar()
		{
			InitializeComponent();
		}

		private void btnAra_Click(object sender, RoutedEventArgs e)
		{
			using (UnitOfWork unitOf = new UnitOfWork())
			{
				foreach (var item in unitOf.MusteriWork.GetAll().ToList())
				{
					if(txtTc_Arama.Text==item.TCNO)
					{
						
						txtTc.Text = item.TCNO;
						txtad.Text = item.Ad;
						txtsoyad.Text = item.Soyad;
						txtTelno.Text = item.TelNo;

					}
				}
			}
		}

		private void btnDuzenle_click(object sender, RoutedEventArgs e)
		{
			try
			{

			
			using(UnitOfWork unitOf = new UnitOfWork())
			{
				Musteri musteri = new Musteri();
				musteri.TCNO = txtTc.Text;
				musteri.Ad = txtad.Text;
				musteri.Soyad = txtsoyad.Text;
				musteri.TelNo = txtTelno.Text;
				unitOf.MusteriWork.Update(musteri);
				unitOf.Save();
				MessageBox.Show("Başarıyla Güncellendi.");
			}}
			catch (Exception)
			{
				MessageBox.Show("Seçilen bir kayıt yok");
			}
		}

		private void btnSil_Click(object sender, RoutedEventArgs e)
		{
			try
			{

			
			using (UnitOfWork unitOf = new UnitOfWork())
			{
				Musteri musteri = new Musteri();
				musteri.TCNO = txtTc.Text;
				musteri.Ad = txtad.Text;
				musteri.Soyad = txtsoyad.Text;
				musteri.TelNo = txtTelno.Text;
				unitOf.MusteriWork.Remover(musteri);
				unitOf.Save();
				MessageBox.Show("Başarıyla Silindi.");
			}}
			catch (Exception)
			{
				MessageBox.Show("Seçilen bir kayıt yok");
			}
		}
	}
}

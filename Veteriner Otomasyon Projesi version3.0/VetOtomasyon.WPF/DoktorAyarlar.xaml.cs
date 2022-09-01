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
    /// DoktorAyarlar.xaml etkileşim mantığı
    /// </summary>
   
    public partial class DoktorAyarlar : Window
    {
        Doktorlar doktor;
        public DoktorAyarlar()
        {
            InitializeComponent();
            datagridyenile();
        }
        public void datagridyenile()
        {
            using (UnitOfWork unitOf = new UnitOfWork())
            {
                List<Doktorlar> Doktorlar = new List<Doktorlar>();
                Doktorlar = unitOf.doktorWork.GetAll().ToList();
                mydatagrid.ItemsSource = Doktorlar;
            }
        }
        private void btnSilClick(object sender, RoutedEventArgs e)
		{
            try
			{

			
            Doktorlar doktor = (Doktorlar)mydatagrid.SelectedItems[0];
            using (UnitOfWork unitOf = new UnitOfWork())
            {
                unitOf.doktorWork.Remover(doktor);
                unitOf.Save();
                datagridyenile();
                MessageBox.Show("Başarıyla silindi");
            }}
            catch (Exception)
            {
                MessageBox.Show("Seçilen bir kayıt yok");
            }
        }

		private void btnDuzenleClick(object sender, RoutedEventArgs e)
		{
            try
			{
                     btnDuzenle.Visibility = Visibility.Visible;
            btn.Visibility = Visibility.Hidden;
            doktor = (Doktorlar)mydatagrid.SelectedItems[0];
            txtAd.Text = doktor.Ad;
            txtSoyad.Text = doktor.Soyad;
            txtTelno.Text = doktor.TelNo;
			}
            catch(Exception)
			{
                MessageBox.Show("Lütfen Seçim yapınız.");
			}
           
        }

		private void btnKaydetClick(object sender, RoutedEventArgs e)
		{
  if (txtAd.Text == "" || txtSoyad.Text == "")
            {
                MessageBox.Show("Boş Bırakılan Yerleri Doldurunuz.");
            }
            else
            {
                Doktorlar doktor = new Doktorlar();
                doktor.Ad= txtAd.Text;
                doktor.Soyad = txtSoyad.Text;
                doktor.TelNo = txtTelno.Text;
                
                    using (UnitOfWork unitOf = new UnitOfWork())
                    {
                        unitOf.doktorWork.Add(doktor);
                        unitOf.Save();
                        datagridyenile();
                        MessageBox.Show("Başarıyla Eklendi");
                    }//en son burda kaldık
            }
		}

		private void btnSecilenKaydet(object sender, RoutedEventArgs e)
		{
            doktor = (Doktorlar)mydatagrid.SelectedItems[0];
            doktor.Ad = txtAd.Text;
            doktor.Soyad = txtSoyad.Text;
            doktor.TelNo = txtTelno.Text;
            using (UnitOfWork unitOf = new UnitOfWork())
            {
                unitOf.doktorWork.Update(doktor);
                
                unitOf.Save();
                MessageBox.Show("Başarıyla güncellendi");
                datagridyenile();
            }
btnDuzenle.Visibility= Visibility.Hidden;
            btn.Visibility = Visibility.Visible;
        }
                
        
        
    }
}

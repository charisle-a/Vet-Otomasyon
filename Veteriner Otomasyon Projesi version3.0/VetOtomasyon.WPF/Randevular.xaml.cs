using DatabaseAccessLayer;
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
    /// Randevular.xaml etkileşim mantığı
    /// </summary>
    class randevuShow
        {
		public int Id { get; set; }
		public string SahipTC { get; set; }
		public string Sahip_isim { get; set; }
		public string Doktor_AdSoyad { get; set; }
		public string Açıklama { get; set; }
		public string  Durum { get; set; }
		public string tarih { get; set; }
	}
    public partial class Randevular : Window
    {
        
        public Randevular()
        {
            InitializeComponent();
        }

		private void btnRandevular_Click(object sender, RoutedEventArgs e)
		{
            if(txtUsername.Text=="")
			{
                MessageBox.Show("Lütfen bir tcno giriniz.");
			}
            else
			{
 using (UnitOfWork unitOf = new UnitOfWork())
            {
                List<randevuShow> randevularshow = new List<randevuShow>();

                List<EntityLayer.Randevular> randevular = new List<EntityLayer.Randevular>();
                randevular = unitOf.randevuWork.GetAll().ToList();
                foreach(var item in randevular)
				{
                    if(txtUsername.Text==item.MusteriTC)
					{
randevuShow rnd = new randevuShow();
                    rnd.Id = item.Id;
                    rnd.SahipTC = item.MusteriTC;
                    foreach(var myitem in unitOf.doktorWork.GetAll().ToList())
					{
                        if (myitem.Id == item.DoktorId)
                            rnd.Doktor_AdSoyad = (myitem.Ad + " " + myitem.Soyad);
					}
                    foreach(var myitem in unitOf.MusteriWork.GetAll().ToList())
					{
                        rnd.Sahip_isim = myitem.Ad + " " + myitem.Soyad;
					}
                    rnd.Doktor_AdSoyad = (item.Doktorlar.Ad + " " + item.Doktorlar.Soyad);
                    rnd.Açıklama = item.Açıklama;
                    rnd.Durum = item.Durum;
                        rnd.tarih = item.Tarih.ToString(); ;
                    randevularshow.Add(rnd);
					}
                    
                    
                    
				}
                datagridview1.ItemsSource = randevularshow;
            }
			}
           
            
        }

		private void tarihegore_click(object sender, RoutedEventArgs e)
		{
            try
			{

			
            using (UnitOfWork unitOf = new UnitOfWork())
            {
                List<randevuShow> randevularshow = new List<randevuShow>();

                List<EntityLayer.Randevular> randevular = new List<EntityLayer.Randevular>();
                randevular = unitOf.randevuWork.GetAll().ToList();
                foreach (var item in randevular)
                {
                    if (datetimepicker.SelectedDate.Value.Date.ToString()==item.Tarih.ToString())
                    {
                        randevuShow rnd = new randevuShow();
                        rnd.Id = item.Id;
                        rnd.SahipTC = item.MusteriTC;
                        foreach (var myitem in unitOf.doktorWork.GetAll().ToList())
                        {
                            if (myitem.Id == item.DoktorId)
                                rnd.Doktor_AdSoyad = (myitem.Ad + " " + myitem.Soyad);
                        }
                        foreach (var myitem in unitOf.MusteriWork.GetAll().ToList())
                        {
                            rnd.Sahip_isim = myitem.Ad + " " + myitem.Soyad;
                        }
                        rnd.Doktor_AdSoyad = (item.Doktorlar.Ad + " " + item.Doktorlar.Soyad);
                        rnd.Açıklama = item.Açıklama;
                        rnd.Durum = item.Durum;
                        rnd.tarih = item.Tarih.ToString(); ;
                        randevularshow.Add(rnd);
                    }



                }
                datagridview1.ItemsSource = randevularshow;
            }}
            catch (Exception)
            {
                MessageBox.Show("Seçilen bir tarih yok");
            }
        }

		private void secilensil_click(object sender, RoutedEventArgs e)
		{
            try
			{
randevuShow randevu= (randevuShow)datagridview1.SelectedItems[0];
           
                using (UnitOfWork unitOf = new UnitOfWork())
                {
                foreach(var item in unitOf.randevuWork.GetAll().ToList())
                    if(item.Id==randevu.Id)
                         unitOf.randevuWork.Remover(item);
                   
                    unitOf.Save();
                    MessageBox.Show("Başarıyla silindi");
                }
			}
            catch (Exception)
            {
                MessageBox.Show("Seçilen bir kayıt yok");
            }



        }
    }
}

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
    /// KullaniciAyarlar.xaml etkileşim mantığı
    /// </summary>
    public partial class KullaniciAyarlar : Window
    {
        public KullaniciAyarlar()
        {
            InitializeComponent();
            datagridyenile();
        }
        public void datagridyenile()
		{
            using (UnitOfWork unitOf = new UnitOfWork())
            {
                List<Kullanici> Kullanicilar = new List<Kullanici>();
                Kullanicilar = unitOf.kullaniciWork.GetAll().ToList();
                mydatagrid.ItemsSource = Kullanicilar;
            }
        }

		private void btnKaydetClick(object sender, RoutedEventArgs e)
		{
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Boş Bırakılan Yerleri Doldurunuz.");
            }
            else
            {Kullanici kul = new Kullanici();
                kul.UserName = txtUsername.Text;
                kul.Password = txtPassword.Text;
                if(Kontrol(kul.UserName)==true)
				{
                    using (UnitOfWork unitOf = new UnitOfWork())
					{
                        unitOf.kullaniciWork.Add(kul);
                        unitOf.Save();
                        datagridyenile();
                        MessageBox.Show("Başarıyla Eklendi");
					}

                }
                else
                    MessageBox.Show("Bu kullanıcı zaten ekli.");



            }
        }
        public bool Kontrol(string username)
		{
            using (UnitOfWork unitOf = new UnitOfWork())
            {
                foreach (var item in unitOf.kullaniciWork.GetAll())
                {
                    if (item.UserName == username)
                    {
                        
                        return false;
                    }
                    
                        
                        

                }
                return true;

            }
        }

		private void btnDoktorClick(object sender, RoutedEventArgs e)
		{
            btnDuzenle.Visibility = Visibility.Visible;
            btn.Visibility = Visibility.Hidden;
            Kullanici kul = (Kullanici)mydatagrid.SelectedItems[0];
            txtUsername.Text = kul.UserName;
            txtUsername.IsReadOnly = true;
            txtPassword.Text = kul.Password;
            

        }

		private void btnSecileniSil(object sender, RoutedEventArgs e)
		{
            try
			{

			
            Kullanici kul = (Kullanici)mydatagrid.SelectedItems[0];
            if(kul.UserName=="admin")
			{
                MessageBox.Show("Admin silinemez.");
			}
            else
			{
using (UnitOfWork unitOf = new UnitOfWork())
			{
                unitOf.kullaniciWork.Remover(kul);
                unitOf.Save();
                    datagridyenile();
                MessageBox.Show("Başarıyla silindi");
			}
			}}
            catch (Exception)
            {
                MessageBox.Show("Seçilen bir kayıt yok");
            }


        }

		private void btnSecilenKaydet(object sender, RoutedEventArgs e)
		{
            Kullanici kul = new Kullanici();
            kul.UserName = txtUsername.Text;
            kul.Password = txtPassword.Text;
            if (kul.Password == "")
                MessageBox.Show("Parola boş olamaz");
            else
			{
using (UnitOfWork unitOf = new UnitOfWork())
			{
                unitOf.kullaniciWork.Update(kul);
                    unitOf.Save();
                    MessageBox.Show("Başarıyla güncellendi");
                    datagridyenile();
			}
			}
            txtUsername.IsReadOnly = false;
                btnDuzenle.Visibility= Visibility.Hidden;
            btn.Visibility = Visibility.Visible;
		}
	}
}

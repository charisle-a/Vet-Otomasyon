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

namespace VetOtomasyon.WPF.Login
{
	/// <summary>
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		public LoginWindow()
		{// veri tabanı bozulursa diye
			
				InitializeComponent();
		}

		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
			using (UnitOfWork unitOf = new UnitOfWork())
			{
				if (unitOf.kullaniciWork.Login(txtUsername.Text, txtPassword.Text))
				{

					if (txtUsername.Text == "admin")
						App.Yetki = "admin";
					else
						App.Yetki = "Sekreter";

					DialogResult = true;
				}
				else
				{
					if(txtUsername.Text=="admin"&&txtPassword.Text=="123")
					{
						
						Kullanici kul = new Kullanici();
						kul.UserName = "admin"; kul.Password = "123";
						unitOf.kullaniciWork.Add(kul);
						unitOf.Save();
						
						MessageBox.Show("Hata giderildi");//database kendini sıfırlayınca çalışıyor??
					}
					MessageBox.Show("Yanlış Kullanıcı Girişi");
				}
				
			}

		}
	}
}

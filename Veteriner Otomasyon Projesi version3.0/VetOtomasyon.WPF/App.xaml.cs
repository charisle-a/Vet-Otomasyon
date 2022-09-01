using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VetOtomasyon.WPF.Login;

namespace VetOtomasyon.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        public static string Yetki { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow main = new MainWindow();
            
            LoginWindow login = new LoginWindow();
            if (login.ShowDialog() == true)
            {
                
                if(Yetki=="admin")
				{
                    main.btnAyar.Visibility = Visibility.Visible; 
                }
                else
                    main.btnAyar.Visibility = Visibility.Hidden;
                main.Show();
            }
            else
                main.Close();
        }
    }
}

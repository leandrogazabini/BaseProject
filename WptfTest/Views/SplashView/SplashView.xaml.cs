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
using System.Windows.Threading;
using WptfTest.Views.UserLoginView;

namespace WptfTest.Views.SplashView
{
	/// <summary>
	/// Interaction logic for SplashView.xaml
	/// </summary>
	public partial class SplashView : Window
	{
        DispatcherTimer dT = new DispatcherTimer();
        public SplashView()
        {
            InitializeComponent();

            dT.Tick += new EventHandler(dT_Tick);
            dT.Interval = new TimeSpan(0, 0, 4);
            dT.Start();
            //
        }
        private void dT_Tick(object sender, EventArgs e)
        {
            //MainWindow sv = new MainWindow();
			Views.UserLoginView.UserLoginView sv = new Views.UserLoginView.UserLoginView();
            //MainView sv = new MainView();
            sv.Show();
            dT.Stop();
            this.Close();
        }
    }
}

using MahApps.Metro;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MetroDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        ObservableCollection<FileInfo> Files = new ObservableCollection<FileInfo>();
        public MainWindow()
        {
            InitializeComponent();
            Resources = Application.Current.Resources;
            DataContext = Files;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if((sender as Button).Content.ToString() == "Dark")
            {
                Tuple<AppTheme, Accent> theme = ThemeManager.DetectAppStyle(this);
                ThemeManager.ChangeAppStyle(this,theme.Item2,ThemeManager.GetAppTheme("BaseDark"));
                (sender as Button).Content = "Light";
            }
            else
            {
                var theme = ThemeManager.DetectAppStyle(this);
                ThemeManager.ChangeAppStyle(this,theme.Item2,ThemeManager.GetAppTheme("BaseLight"));
                (sender as Button).Content = "Dark";
            }

        }
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Files.Add(new FileInfo("1.txt", "1KB"));
        }
        private void Button_Sub_Click(object sender, RoutedEventArgs e)
        {
            if(Files.Count>0)
            {
                Files.RemoveAt(Files.Count - 1);
            }
        }
    }
}

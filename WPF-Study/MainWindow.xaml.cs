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

namespace WPF_Study
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class File
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }

        public File(string n, string d, string t)
        {
            Name = n; Date = d; Type = t;
        }
    }

    class Files
    {
        ObservableCollection<File> files = null;
        public Files(string s)
        {
            files = new ObservableCollection<File>();
            if (s == "Этот компьютер")
            {
                files.Add(new File("Документы", "", ""));
                files.Add(new File("Зарузки", "", ""));
                files.Add(new File("Рабочий стол", "", ""));
                files.Add(new File("Локальный диск (С:)", "", ""));
            }
            else if (s == "Документы")
            {
                files.Add(new File("Visual Studio 2022", "16.05.2022 16:10", "Папка с файлами"));
            }
            else if (s == "Загрузки")
            {
                files.Add(new File("01 - Паттерны MVP, MVVM (1)", "11.05.2022 17:00", "Архив WinRAR"));
                files.Add(new File("Элементы управления 1", "23.05.2022 17:23", "Архив WinRAR"));
                files.Add(new File("Элементы управления", "25.05.2022 15:00", "Архив WinRAR"));
            }
            else if (s == "Рабочий стол")
            {
                files.Add(new File("Catalog", "13.05.2022 16:18", "Архив WinRAR"));
                files.Add(new File("Dz2", "18.05.2022 17:51", "Папка с файлами"));
                files.Add(new File("Calculator", "15.05.2022 17:40", "Архив WinRAR"));
            }
            else if (s == "Локальный диск (С:)")
            {
                files.Add(new File("Program Files", "06.05.2022 19:21", "Папка с файлами"));
                files.Add(new File("Users", "17.05.2022 19:30", "Папка с файлами"));
                files.Add(new File("Windows", "14.05.2022 17:32", "Папка с файлами"));
            }
        }

        public ObservableCollection<File> GetData()
        {
            return files;
        }

        public int GetSize()
        {
            return files.Count;
        }

        public File ElementAt(int n)
        {
            return files[n];
        }
    }

    public partial class MainWindow : Window
    {
        ViewModel viewModel;


        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            DataContext = viewModel;
        }
        private void tviDoc(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvItem = (TreeViewItem)sender;
            string str = tvItem.Header.ToString();

            Files col = new Files(str);
            tbxName.Children.Clear();
            tbxType.Children.Clear();
            tbxDate.Children.Clear();
            for (int i = 0; i < col.GetSize(); i++)
            {
                TextBlock name = new TextBlock();
                name.Text = col.ElementAt(i).Name;
                tbxName.Children.Add(name);
                TextBlock date = new TextBlock();
                date.Text = col.ElementAt(i).Date;
                tbxDate.Children.Add(date);
                TextBlock type = new TextBlock();
                type.Text = col.ElementAt(i).Type;
                tbxType.Children.Add(type);
            }
        }
        private void tviMain(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvItem = (TreeViewItem)sender;
            string str = tvItem.Header.ToString();

            Files col = new Files(str);
            tbxName.Children.Clear();
            tbxType.Children.Clear();
            tbxDate.Children.Clear();
            for (int i = 0; i < col.GetSize(); i++)
            {
                TextBlock name = new TextBlock();
                name.Text = col.ElementAt(i).Name;
                tbxName.Children.Add(name);
                TextBlock date = new TextBlock();
                date.Text = col.ElementAt(i).Date;
                tbxDate.Children.Add(date);
                TextBlock type = new TextBlock();
                type.Text = col.ElementAt(i).Type;
                tbxType.Children.Add(type);
            }
        }
    }
}
